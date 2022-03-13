using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PLARNGGui
{
    public class MMORoutines
    {
        public void ReadMassOutbreak()
        {
            string map = "";
            var shinyrolls = Convert.ToInt32(Program.main.MMOSRs.Text);
            for (int l = 0; l < 5; l++)
            {
                for (int i = 0; i < 15; i++)
                {
                    var outbreakpointer = new long[] { 0x42BA6B0, 0x2B0, 0x58, 0x18, 0x1d4 + (i * 0x90) + (0xB80 * l) };
                    var Outbreakoff = Main.routes.PointerAll(outbreakpointer).Result;

                    if (i == 0)
                    {
                        var location = Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x24, 2).Result;
                        map = BitConverter.ToString(location);
                        switch (map)
                        {
                            case "B7-56": map = "in the Cobalt Coastlands"; break;
                            case "04-55": map = "in the Crimson Mirelands"; break;
                            case "51-53": map = "in the Alabaster Icelands"; break;
                            case "9E-51": map = "in the Coronet Highlands"; break;
                            case "1D-5A": map = "in the Obsidian Fieldlands"; break;
                            case "45-26": map = "none"; break;
                        }

                        Program.main.MassiveDisplay.AppendText($"Searching {map}\n");
                    }
                    int species = BitConverter.ToUInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff, 2).Result, 0);
                    Task.Delay(1000);

                    if (species != 0)
                    {
                        if (species == 201)
                            shinyrolls = 19;
                        Program.main.MassiveDisplay.AppendText($"GroupID: {i} {(Species)species}\n");
                        bool shiny = false;
                        ulong encryption_constant = new ulong();
                        ulong pid = new ulong();
                        int[] ivs = new int[6];
                        ulong ability = new ulong();
                        ulong gender = new ulong();
                        ulong nature = new ulong();
                        ulong shinyseed = new ulong();
                        var spawncoordx = BitConverter.ToSingle(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x14, 4).Result, 0);
                        var spawncoordy = BitConverter.ToSingle(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x10, 4).Result, 0);
                        var spawncoordz = BitConverter.ToSingle(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x0C, 4).Result, 0);
                        Program.main.MassiveDisplay.AppendText($"Coordinates: X: {spawncoordx} Y: {spawncoordy} Z: {spawncoordz}\n");
                        var groupseed = BitConverter.ToUInt64(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x44, 8).Result, 0);
                        var maxspawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x4c, 4).Result, 0);
                        var truebonusspawns = maxspawns + 3;
                        Program.main.MassiveDisplay.AppendText($"Max spawns: {maxspawns}\n");
                        var currspawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x50, 4).Result, 0);
                        Program.main.MassiveDisplay.AppendText($"Current spawns: {currspawns}\n\n");
                        var bonusround = BitConverter.ToUInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x18, 2).Result, 0);
                        var bonuscount = BitConverter.ToInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x60, 2).Result, 0);
                        if (Program.main.Aggro.Checked)
                        {
                            var truespawns = maxspawns;
                            maxspawns = maxspawns + 3;
                            aggressiveoutbreakpathfind(groupseed, shinyrolls, truebonusspawns, maxspawns, i, false);
                            continue;
                        }
                        var mainrng = new Xoroshiro128Plus(groupseed);
                        for (int h = 0; h < 4; h++)
                        {
                            var generatorseed = mainrng.Next();
                            mainrng.Next();
                            var fixedrng = new Xoroshiro128Plus(generatorseed);
                            fixedrng.Next();
                            var fixedseed = fixedrng.Next();
                            (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = Main.rngroutes.GenerateFromSeed(fixedseed, shinyrolls, 0);
                            if (shiny)
                            {
                                Program.main.MassiveDisplay.AppendText($"Initial Spawn {h}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generatorseed)}\n\n");
                                Program.main.Teleporterdisplay.AppendText($"Map: {map.Replace("in the ", "")}\nInitial Spawn {h}\nSpecies: {(Species)species}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generatorseed)}\n\n");
                                Program.main.Teleporterdisplay.AppendText($"Coords:\nX: {spawncoordx}\nY: {spawncoordy}\nZ: {spawncoordz}\n ");
                                Program.main.CoordX.Text = $"{spawncoordx}"; Program.main.CoordY.Text = $"{spawncoordy}"; Program.main.CoordZ.Text = $"{spawncoordz}";
                            }
                        }
                        groupseed = mainrng.Next();
                        mainrng = new Xoroshiro128Plus(groupseed);
                        var respawnrng = new Xoroshiro128Plus(groupseed);
                        for (int p = 1; p < maxspawns - 3; p++)
                        {
                            var generator_seed = respawnrng.Next();
                            respawnrng.Next();
                            respawnrng = new Xoroshiro128Plus(respawnrng.Next());
                            var fixed_rng = new Xoroshiro128Plus(generator_seed);
                            fixed_rng.Next();
                            var fixed_seed = fixed_rng.Next();

                            (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = Main.rngroutes.GenerateFromSeed(fixed_seed, 13, 0);
                            if (shiny)
                            {
                                Program.main.MassiveDisplay.AppendText($"Respawn {p}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generator_seed)}\n\n");
                                Program.main.Teleporterdisplay.AppendText($"Map: {map.Replace("in the ", "")}\nRespawn {p}\nSpecies: {(Species)species}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generator_seed)}\n\n");
                                Program.main.Teleporterdisplay.AppendText($"Coords:\nX: {spawncoordx}\nY: {spawncoordy}\nZ: {spawncoordz}\n ");
                                Program.main.CoordX.Text = $"{spawncoordx}"; Program.main.CoordY.Text = $"{spawncoordy}"; Program.main.CoordZ.Text = $"{spawncoordz}";
                            }
                        }
                        if (bonusround != 0)
                        {
                            Program.main.MassiveDisplay.AppendText($"group {i} has a bonus round.\n\n");
                            var bonusseed = respawnrng.Next() - 0x82A2B175229D6A5B & 0xFFFFFFFFFFFFFFFF;
                            mainrng = new Xoroshiro128Plus(bonusseed);
                            for (int h = 0; h < 4; h++)
                            {
                                var generatorseed = mainrng.Next();
                                mainrng.Next();
                                var fixedrng = new Xoroshiro128Plus(generatorseed);
                                fixedrng.Next();
                                var fixedseed = fixedrng.Next();
                                mainrng.Next();
                                (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = Main.rngroutes.GenerateFromSeed(fixedseed, 13, 3);
                                if (shiny)
                                {
                                    Program.main.MassiveDisplay.AppendText($"Initial Bonus Spawn {h}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generatorseed)}\n\n");
                                    Program.main.Teleporterdisplay.AppendText($"Map: {map.Replace("in the ", "")}\nInitial Bonus Spawn {h}\nSpecies: {(Species)species}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generatorseed)}\n\n");
                                    Program.main.Teleporterdisplay.AppendText($"Coords:\nX: {spawncoordx}\nY: {spawncoordy}\nZ: {spawncoordz}\n ");
                                    Program.main.CoordX.Text = $"{spawncoordx}"; Program.main.CoordY.Text = $"{spawncoordy}"; Program.main.CoordZ.Text = $"{spawncoordz}";
                                }
                            }
                            bonusseed = mainrng.Next();
                            mainrng = new Xoroshiro128Plus(bonusseed);
                            var bonusrng = new Xoroshiro128Plus(bonusseed);
                            for (int p = 1; p < bonuscount - 3; p++)
                            {
                                var generator_seed = bonusrng.Next();
                                bonusrng.Next();
                                bonusrng = new Xoroshiro128Plus(respawnrng.Next());
                                var fixed_rng = new Xoroshiro128Plus(generator_seed);
                                fixed_rng.Next();
                                var fixed_seed = fixed_rng.Next();

                                (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = Main.rngroutes.GenerateFromSeed(fixed_seed, 13, 0);
                                if (shiny)
                                {
                                    Program.main.MassiveDisplay.AppendText($"Bonus Respawn {p}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generator_seed)}\n\n");
                                    Program.main.Teleporterdisplay.AppendText($"Map: {map.Replace("in the ", "")}\nBonus Respawn {p}\nSpecies: {(Species)species}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generator_seed)}\n\n");
                                    Program.main.Teleporterdisplay.AppendText($"Coords:\nX: {spawncoordx}\nY: {spawncoordy}\nZ: {spawncoordz}\n ");
                                    Program.main.CoordX.Text = $"{spawncoordx}"; Program.main.CoordY.Text = $"{spawncoordy}"; Program.main.CoordZ.Text = $"{spawncoordz}";
                                }
                            }
                            if (Program.main.Aggro.Checked)
                            {
                                groupseed = BitConverter.ToUInt64(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x44, 8).Result, 0);
                            }
                        }

                    }

                }
            }
        }
        public void aggressiveoutbreakpathfind(ulong groupseed, int rolls, int maxspawns, int truespawns, int groupid, bool bonusround)
        {
            Dictionary<string, dynamic> encounters = new Dictionary<string, dynamic>();
            int encsum = 0;
            encsum = GetEncountersum(groupid, bonusround);
            var mainrng = new Xoroshiro128Plus(groupseed);

        }
        public int GetEncountersum(int groupid, bool bonus)
        {
            var pointer = new long[5];
            if (bonus)
            {
                pointer = new long[] { 0x42BA6B0, 0x2B0, 0x58, 0x18, 0x1d4 + (groupid * 0x90) + (0xb80 * (int)(Enums.Maps)Program.main.Aggromap.SelectedItem) + 0x2c };
            }
            else
                pointer = new long[] { 0x42BA6B0, 0x2B0, 0x58, 0x18, 0x1d4 + (groupid * 0x90) + (0xb80 * (int)(Enums.Maps)Program.main.Aggromap.SelectedItem) + 0x24 };
            var pointeroff = Main.routes.PointerAll(pointer).Result;
            var enclong = "0x" + BitConverter.ToUInt64(Main.routes.ReadBytesAbsoluteAsync(pointeroff, 8).Result, 0).ToString().ToUpper();
            var MMOSpawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/capitalism-sudo/PyNXReader/master/resources/mmo_es.json");
            mmoslots = JsonConvert.DeserializeObject<Dictionary<string, SpawnerMMO[]>>(MMOSpawnersjson);
            int encmax = 0;
            foreach (var keyValuePair in mmoslots)
            {
                if (keyValuePair.Key == enclong)
                {

                    foreach (var keyValue in keyValuePair.Value)
                    {
                        encmax += keyValue.Slot;

                    }
                }
            }
            return encmax;
        }

        public class SpawnerMMO
        {
            public int Slot { get; set; }
            public Species Name { get; set; }

            public int Form { get; set; }
            public bool Alpha { get; set; }
            public int[] Levels { get; set; } = Array.Empty<int>();
            public int IVs { get; set; }
        }
        public Dictionary<string, SpawnerMMO[]> mmoslots { get; set; } = new Dictionary<string, SpawnerMMO[]>();
    }
}
