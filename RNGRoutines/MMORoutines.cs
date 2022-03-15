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
                       
                        Program.main.MassiveDisplay.AppendText($"Max spawns: {maxspawns}\n");
                        var currspawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x50, 4).Result, 0);
                        Program.main.MassiveDisplay.AppendText($"Current spawns: {currspawns}\n\n");
                        var bonusround = BitConverter.ToUInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x18, 2).Result, 0);
                        var bonuscount = BitConverter.ToInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x60, 2).Result, 0);
                        if (Program.main.Aggro.Checked)
                        {
                            var truespawns = maxspawns;
                            maxspawns += 3;
                            var result = aggressiveoutbreakpathfind(groupseed, shinyrolls, maxspawns, truespawns, i, false);
                            foreach (var item in result)
                                Program.main.MassiveDisplay.AppendText(item);
                            if(bonusround == 1)
                            {
                                bool isbonus = true;
                                Program.main.MassiveDisplay.AppendText("Bonus Round");
                                truespawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x4c, 4).Result, 0);
                                var extracount = truespawns;
                                maxspawns = truespawns + 4;
                                groupseed = BitConverter.ToUInt64(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x44, 8).Result, 0);
                                var bonusseed = nextfilteredaggressiveoutbreakpathfindseed(groupseed, shinyrolls, maxspawns, truespawns, i, isbonus, groupseed, false);
                                truespawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x60, 4).Result, 0);
                                maxspawns = 10;
                                int s = 0;
                                foreach(var val in bonusseed)
                                {
                                    var seed = getbonusseed(s, shinyrolls, l, val);
                                    var extras = extracount - val.Sum();
                                    var extra = new int[extras];
                                    for (int c = 0; c < extra.Length; c++)
                                        extra[c] = 1;
                                    var nonalpha = aggressiveoutbreakpathfind(seed, shinyrolls, maxspawns, truespawns, i, isbonus);
                                    foreach(var idk in nonalpha)
                                    {
                                        Program.main.MassiveDisplay.AppendText(idk);
                                    }
                                }
                            }
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
                           
                        }

                    }

                }
            }
        }

        public HashSet<int[]> nextfilteredaggressiveoutbreakpathfindseed(ulong groupseed, int rolls, int spawns, int truespawns, int groupid, bool isbonus, ulong trueseed, bool alpha, int step = 0, int[] steps = null, HashSet<int[]> uniques = null, string[] storage = null)
        {
            SpawnerMMO[] encounters = new SpawnerMMO[0];
            int encsum = 0;
            (encounters, encsum) = GetEncountersum(groupid, isbonus);
            var main_rng = new Xoroshiro128Plus(groupseed);
            int[] _steps = null;
            if (steps == null || uniques is null || storage is null)
            {
                steps = Array.Empty<int>();
                uniques = new HashSet<int[]>();
                storage = Array.Empty<string>();
            }
            Array.Copy(steps, _steps, steps.Length);
            if (step != 0)
                _steps.Append(step);
            if (steps.Sum() + step < spawns - 4)
            {
                for (int _step = 1; _step < Math.Min(5, spawns - 4 - _steps.Sum()); _step++)
                {
                    if (nextfilteredaggressiveoutbreakpathfindseed(groupseed, rolls, spawns, truespawns, groupid, isbonus,trueseed,alpha, _step, _steps) != new HashSet<int[]>())
                    {
                        return uniques;
                    }
                }
            }
            else
            {
                _steps.Append(spawns - _steps.Sum() - 4);
                generatemassoutbreakaggressivepathseed(groupseed, rolls, _steps, ref uniques, ref storage, spawns, truespawns, encounters, encsum,trueseed, isbonus);
                if (_steps == getfinal(spawns))
                    return uniques;
            }
            return new HashSet<int[]>();

        }

        public void generatemassoutbreakaggressivepathseed(ulong groupseed,int rolls, int[] _steps,ref HashSet<int[]> uniques,ref string[] storage,int spawns,int truespawns,SpawnerMMO[] encounters,int encsum,ulong trueseed,bool isbonus)
        {
            int[] pokemon = new int[0];
            int guaranteedivs;
            Species species;
            bool alpha;
            var respawns = truespawns - 4;
            var mainrng = new Xoroshiro128Plus(groupseed);
            for(int i = 0; i < 4; i++)
            {
                var generatorseed = mainrng.Next();
                mainrng.Next();
                var fixedrng = new Xoroshiro128Plus(generatorseed);
                var encounter_slot = fixedrng.Next() / Math.Pow(2, 64) * encsum;
                (species, alpha) = getspecies(encounters, encounter_slot);
                if (isbonus && alpha)
                    guaranteedivs = 4;
                else if (isbonus && !alpha)
                    guaranteedivs = 3;
                else
                    guaranteedivs = 0;
                var fixedseed = fixedrng.Next();
            }
            groupseed = mainrng.Next();
            var respawnrng = new Xoroshiro128Plus(groupseed);
            var bonusseed = respawnrng;
            foreach(var step in _steps)
            {
                for(int k = 1; k<step + 1; k++)
                {
                    var generatorseed = respawnrng.Next();
                    respawnrng.Next();
                    var fixedrng = new Xoroshiro128Plus(generatorseed);
                    var encounter_slot = fixedrng.Next() / Math.Pow(2, 64) * encsum;
                    (species, alpha) = getspecies(encounters, encounter_slot);
                    if (isbonus && alpha)
                        guaranteedivs = 4;
                    else if (isbonus && !alpha)
                        guaranteedivs = 3;
                    else
                        guaranteedivs = 0;
                    fixedrng.Next();
                    fixedrng.Next();
                    pokemon.Append(k);
                }
                respawnrng = new Xoroshiro128Plus( respawnrng.Next());
                bonusseed.Next();
                var indy = Array.IndexOf(_steps, step);
                int sum = 0;
                for (int u = 0; u < indy; u++)
                    sum += _steps[u];
                int[] secondstep = new int[0];
                _steps.CopyTo(secondstep, indy);
                if (!uniques.Contains(secondstep.Concat(pokemon).ToArray()) && (sum + pokemon.Sum()) - respawns >=0 && sum - respawns < 0 )
                {
                    uniques.Add(secondstep.Concat(pokemon).ToArray());
                }
            }
        }
        public string[] aggressiveoutbreakpathfind(ulong groupseed, int rolls, int maxspawns, int truespawns, int groupid, bool bonusround, int step = 0, int[] steps = null, List<ulong> uniques =null, string[] storage =null)
        {
           SpawnerMMO[] encounters = new SpawnerMMO[0];
            int encsum = 0;
            (encounters,encsum) = GetEncountersum(groupid, bonusround);
            var mainrng = new Xoroshiro128Plus(groupseed);
            int[] _steps = Array.Empty<int>();
            if(steps == null || uniques == null || storage == null)
            {
                steps = Array.Empty<int>();
                uniques = new List<ulong>();
                storage = Array.Empty<string>();
            }
            Array.Copy(steps, _steps,steps.Length);
            if(step != 0)
                _steps.Append(step);
            if(steps.Sum() + step < maxspawns - 4)
            {
                for(int _step = 1; _step < Math.Min(5, maxspawns-4 - _steps.Sum()); _step++)
                {
                    if(aggressiveoutbreakpathfind(groupseed,rolls,maxspawns,truespawns,groupid,bonusround,_step,_steps) != Array.Empty<string>())
                    {
                        return storage;
                    }
                }
            }
            else
            {
                _steps.Append(maxspawns - _steps.Sum() - 4);
                generatemassoutbreakaggressivepath(groupseed, rolls, _steps,ref uniques, ref storage, maxspawns, truespawns,encounters, encsum, bonusround);
                if (_steps == getfinal(maxspawns))
                    return storage;
            }
            return Array.Empty<string>();
        }

        public int[] getfinal(int maxspawns)
        {
            maxspawns -= 4;
            int[] finalpath = new int[maxspawns/4];
            for (int i = 0; i < finalpath.Length; i++)
                finalpath[i] = 4;
            if (maxspawns % 4 != 0)
                finalpath.Append(maxspawns % 4);
            return Array.Empty<int>();
        }
        public void generatemassoutbreakaggressivepath(ulong groupseed,int rolls,int [] steps, ref List<ulong> uniques,ref string[] storage,int maxspawns,int truespawns,SpawnerMMO[] encounters,int encsum,bool bonsuround)
        {
            bool shiny = false;
            ulong encryption_constant = new ulong();
            ulong pid = new ulong();
            int[] ivs = new int[6];
            ulong ability = new ulong();
            ulong gender = new ulong();
            ulong nature = new ulong();
            ulong shinyseed = new ulong();
            int guaranteedivs;
            Species species;
            bool alpha;
            ulong generatorseed;
            var mainrng = new Xoroshiro128Plus(groupseed);
            for(int i = 1; i < 5; i++)
            {
                generatorseed = mainrng.Next();
                mainrng.Next();
                var fixedrng = new Xoroshiro128Plus(generatorseed);
                var encounter_slot = fixedrng.Next() / Math.Pow(2, 64) * encsum;
                (species, alpha) = getspecies(encounters, encounter_slot);
                if (bonsuround && alpha)
                    guaranteedivs = 4;
                else if (bonsuround && !alpha)
                    guaranteedivs = 3;
                else
                    guaranteedivs = 0;
                var fixedseed = fixedrng.Next();
                (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = Main.rngroutes.GenerateFromSeed(fixedseed, rolls, guaranteedivs);
                if(shiny && !uniques.Contains(fixedseed))
                {
                    uniques.Add(fixedseed);
                    storage.Append($"Initial Spawn {i}\nSpecies {species}\nShiny: {shiny}\nAlpha: {alpha}\nEC: {string.Format("{0:X}", encryption_constant)}\nPID: {string.Format("{0:X}", pid)}\nIVs: {ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility: {ability}\nGender: {gender}\nNature: {((Nature)nature)}\nShinySeed: {string.Format("0x{0:X}", generatorseed)}\n\n");
                }
            }
            groupseed = mainrng.Next();
            var respawnrng = new Xoroshiro128Plus(groupseed);
            foreach(var step in steps)
            {
                for(int i = 1; i < step + 1; i++)
                {
                    generatorseed = respawnrng.Next();
                    respawnrng.Next();
                    var fixedrng = new Xoroshiro128Plus(generatorseed);
                    var encounter_slot = fixedrng.Next() / Math.Pow(2, 64) * encsum;
                    (species, alpha) = getspecies(encounters, encounter_slot);
                    if (bonsuround && alpha)
                        guaranteedivs = 4;
                    else if (bonsuround && !alpha)
                        guaranteedivs = 3;
                    else
                        guaranteedivs = 0;
                    var fixedseed = fixedrng.Next();
                    var indy = Array.IndexOf(steps, step);
                    int sum = 0;
                    for (int u = 0; u < indy; u++)
                        sum += steps[u];
                    (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = Main.rngroutes.GenerateFromSeed(fixedseed, rolls, guaranteedivs);
                    if (shiny && !uniques.Contains(fixedseed) && sum + i + 4 <= truespawns)
                    {
                        string paths = "";
                        for (int u = 0; u < indy; u++)
                            paths += steps[u].ToString() + "|";

                        uniques.Add(fixedseed);
                        storage.Append($"Initial Spawn {i}\nSpecies {species}\nPath: {paths}Shiny: {shiny}\nAlpha: {alpha}\nEC: {string.Format("{0:X}", encryption_constant)}\nPID: {string.Format("{0:X}", pid)}\nIVs: {ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility: {ability}\nGender: {gender}\nNature: {((Nature)nature)}\nShinySeed: {string.Format("0x{0:X}", generatorseed)}\n\n");
                    }
                }
                respawnrng.Next();
            }
        }

        public (Species,bool) getspecies(SpawnerMMO[]encounters,double encounter_slot)
        {
            
            Species slot;
            int encsum = 0;
            bool alpha = false;
            foreach(var species in encounters)
            {
                encsum += species.Slot;
                if(encounter_slot < encsum)
                {
                    alpha = species.Alpha;
                    slot = species.Name;
                    return (slot,alpha);
                }
            }
            return (Species.None, false);
        }
        public (SpawnerMMO[], int) GetEncountersum(int groupid, bool bonus)
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
            var MMOSpawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/zyro670/JS-Finder/notabranch/Resources/pla_spawners/jsons/massivemassoutbreaks.json");
            mmoslots = JsonConvert.DeserializeObject<Dictionary<string, SpawnerMMO[]>>(MMOSpawnersjson);
            int encmax = 0;
            try
            {
                var encounters = mmoslots[enclong];
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
                return (encounters, encmax);
            }
            catch { return (null, 0); }
        }
        public ulong getbonusseed(int groupid,int rolls, int map,int[] paths)
        {
            var outbreakpointer = new long[] { 0x42BA6B0, 0x2B0, 0x58, 0x18, 0x1d4 + (groupid * 0x90) + (0xB80 * map) };
            var Outbreakoff = Main.routes.PointerAll(outbreakpointer).Result;
            int species = BitConverter.ToUInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff, 2).Result, 0);
            if (species != 0)
            {
                if (species == 201)
                    rolls = 19;
                var groupseed = BitConverter.ToUInt64(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x44, 8).Result, 0);
                var maxspawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x4c, 4).Result, 0);
                var mainrng = new Xoroshiro128Plus(groupseed);
                for(int b = 0; b < 4; b++)
                {
                    var generatorseed = mainrng.Next();
                    mainrng.Next();
                    var fixedrng = new Xoroshiro128Plus(generatorseed);
                    fixedrng.Next();
                    var fixedseed = fixedrng.Next();
                }
                groupseed = mainrng.Next();
                mainrng = new Xoroshiro128Plus(groupseed);
                var respawnrng = new Xoroshiro128Plus(groupseed);
                ulong generatorseeds;
                foreach(var path in paths)
                {
                    for(int pokemon = 0; pokemon < path; pokemon++)
                    {
                        generatorseeds = respawnrng.Next();
                        var tempseed = respawnrng.Next();
                        var fixerng = new Xoroshiro128Plus(generatorseeds);
                        fixerng.Next();
                        var fixerseed = fixerng.Next();
                        fixerseed = fixerng.Next();
                    }
                    respawnrng.Next();
                }
                var bonusseed = (respawnrng.Next() - 0x82A2B175229D6A5B) & 0xFFFFFFFFFFFFFFFF;
                return bonusseed;

            }
            return 0x0;
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
