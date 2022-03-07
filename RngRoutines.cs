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
    public class RngRoutines 
    {

        public (bool shiny, ulong EC, ulong PID, int[] IVs, ulong ability, ulong gender, ulong nature, ulong fixedseed) GenerateFromSeed(ulong seed, int rolls, int guranteedivs)
        {
            
            bool shiny = false;
            ulong EC;
            ulong pid = 0;
            int[] ivs;
            ulong ability;
            ulong gender;
            ulong nature;
            ulong sseed = 0;
            Random rand = new Random();
            var rng = new Xoroshiro128Plus(seed);

            EC = rng.NextInt(0xFFFFFFFF);
            var sidtid = rng.NextInt(0xFFFFFFFF);
            for (int i = 0; i < rolls; i++)
            {
                pid = rng.NextInt(0xFFFFFFFF);
                shiny = ((pid >> 16) ^ (sidtid >> 16) ^ (pid & 0xFFFF) ^ (sidtid & 0xFFFF)) < 0x10;

                if (shiny)
                {
                    sseed = rng.GetState().s0;
                    break;
                }
            }

            ivs = new int[] { -1, -1, -1, -1, -1, -1 };
            for (int i = 0; i < guranteedivs; i++)
            {
                var index = rng.NextInt(6);
                while ((int)index >= 6)
                    index = rng.NextInt(6);


                while (ivs[index] != -1)
                {
                    index = rng.NextInt(6);
                    while ((int)index >= 6)
                        index = rng.NextInt(6);

                }

                ivs[index] = 31;
            }
            for (int i = 0; i < 6; i++)
            {
                if (ivs[i] == -1)
                    ivs[i] = (int)rng.NextInt(32);
            }
            ability = rng.NextInt(2);
            gender = rng.NextInt(252) + 1;
            nature = rng.NextInt(25);
            while ((int)nature >= 25)
                nature = rng.NextInt(25);
            return (shiny, EC, pid, ivs, ability, gender, nature, sseed);
        }

        public ulong GenerateNextStandardMatch(ulong seed)
        {
            ulong seed1 = 0x82A2B175229D6A5B;
            bool alphamatch = false;
           
            ulong sseed = 0;
            var mainrng = new Xoroshiro128Plus(seed);
            var Spawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/Spawners/{Program.main.MapSelection.SelectedItem}.json");
            var Encountersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/encounters/{Program.main.MapSelection.SelectedItem}.json");
            var encmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Encountersjson);
            var spawnmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Spawnersjson);
            var encslotsum = 101;
            var encmin = 0;
            var encmax = 100;
                var groupname = spawnmap[$"{Program.main.groupid.Text}"]["name"];
               

                var possiblespawns = encmap[$"{groupname}"][$"{((Enums.Time)Program.main.Timeofdayselection.SelectedItem == Enums.Time.Any ? "Any Time" : $"{Program.main.Timeofdayselection.SelectedItem}")}" + "/" + $"{((Enums.Weather)Program.main.weatherselection.SelectedItem == Enums.Weather.All ? "All Weather" : $"{Program.main.weatherselection.SelectedItem}")}"];


                foreach (var key in possiblespawns)
                {
                    encslotsum += (int)key.Value;
                }

                

                foreach (var key in possiblespawns)
                {

                    var keyspecies = $"{key}".Remove($"{key}".IndexOf(":")).Replace("\"", "");

                    if ((string)Program.main.pokemonselection.SelectedItem == keyspecies)
                    {
                        encmax = encmin + (int)key.Value;
                        break;
                    }
                    else
                        encmin += (int)key.Value;
                }
            
            bool shiny = false;
            ulong encryption_constant = new ulong();
            ulong pid = new ulong();
            int[] ivs = new int[6];
            ulong ability = new ulong();
            ulong gender = new ulong();
            ulong nature = new ulong();
            ulong shinyseed = new ulong();
            int advances = 0;
            var maxadv = Convert.ToUInt32(Program.main.MaxAdvances.Text);


            for (int i = 0; i <= maxadv; i++)
            {
               
               
                var generator_seed = mainrng.Next();
                mainrng.Next();
                var rng = new Xoroshiro128Plus(generator_seed);
                var EncounterSlotRand = (float)(encslotsum * (float)((float)rng.Next() * 5.421e-20f)) + 0.0;
                (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(rng.Next(), Convert.ToInt32(Program.main.ShinyRollstext.Text), Convert.ToInt32(Program.main.guaranteedivs.Text));
                if (encmin >= (float)EncounterSlotRand && (float)EncounterSlotRand > encmax)
                {
                    continue;
                }
                

                if (shiny)
                {
                    
                        sseed = generator_seed;
                        break;
                }

                mainrng = new Xoroshiro128Plus(mainrng.Next());
                sseed = generator_seed;
                advances = i;

            }
            if (advances >= Convert.ToInt32(Program.main.MaxAdvances.Text))
            {

                Program.main.StandardSpawnsDisplay.AppendText("No Match Found with in your Max Advances\n");
                Program.main.StandardSpawnsDisplay.AppendText($"Advances: {advances}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", sseed)}\n");
                Program.main.SeedToInject.Text = string.Format("0x{0:X}", sseed);
                return sseed;
            }
           Program.main.StandardSpawnsDisplay.AppendText($"Advances: {advances}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", sseed)}\n");
            Program.main.SeedToInject.Text = string.Format("0x{0:X}", sseed);


            return sseed;
        }
        public void ReadOutbreakID()
        {
            ulong seed1 = 0x82A2B175229D6A5B;
            bool alphamatch = false;
            ulong sseed = 0;
            var Spawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/Spawners/{Program.main.outbreakmap.SelectedItem}.json");
            var Encountersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/encounters/{Program.main.outbreakmap.SelectedItem}.json");
            var encmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Encountersjson);
            var spawnmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Spawnersjson);
            var minimum = spawnmap.Count()-16;
            var group_id = minimum + 30;
            ulong groupseed = 0;
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + group_id * 0x440 + 0x408 };
            var SpawnerOff = Main.routes.PointerAll(SpawnerOffpoint).Result;
            while (groupseed == 0 && group_id != minimum)
            {
                group_id -= 1;
                SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + group_id * 0x440 + 0x408 };
                SpawnerOff = Main.routes.PointerAll(SpawnerOffpoint).Result;
                groupseed = BitConverter.ToUInt64(Main.routes.ReadBytesAbsoluteAsync(SpawnerOff, 8).Result,0);
            }
            if(group_id == minimum)
            {
                Program.main.OutbreakDisplay.AppendText("No Outbreaks Found.");
                return;
            }
            Program.main.outbreakgroupid.Text = $"{group_id}";
            var coords = spawnmap[$"{group_id}"]["coords"];
            Program.main.OutbreakDisplay.AppendText($"Group: {group_id}\nX: {coords[0]}\nY: {coords[1]}\nZ: {coords[2]}\n");
            SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + group_id * 0x440 + 0x20 };
            SpawnerOff = Main.routes.PointerAll(SpawnerOffpoint).Result;
            var GeneratorSeed = Main.routes.ReadBytesAbsoluteAsync(SpawnerOff, 8).Result;
            Program.main.OutbreakDisplay.AppendText($"Generator Seed: {BitConverter.ToString(GeneratorSeed).Replace("-", "")}\n");
            var group_seed = (BitConverter.ToUInt64(GeneratorSeed, 0) - 0x82A2B175229D6A5B) & 0xFFFFFFFFFFFFFFFF;
            Program.main.OutbreakDisplay.AppendText($"Group Seed: {string.Format("0x{0:X}", group_seed)}\n");
            var spawns = 0;
            for (int i = 0; i < 4; i++)
            {
                SpawnerOffpoint = new long[] { 0x42BA6B0, 0x2B0, 0x58, 0x18, 0x60 + i * 0x50 };
                SpawnerOff = Main.routes.PointerAll(SpawnerOffpoint).Result;
                spawns = BitConverter.ToInt16(Main.routes.ReadBytesAbsoluteAsync(SpawnerOff, 2).Result, 0);
                if (10 <= spawns && spawns <= 15)
                {
                    Program.main.outbreakspawncount.Text = $"{spawns}";
                    break;
                }
            }
            var main_rng = new Xoroshiro128Plus(group_seed);
            GenerateCurrentMassOutbreak(main_rng);
        }
        public void GenerateCurrentMassOutbreak(Xoroshiro128Plus mainrng)
        {
            bool shiny = false;
            ulong encryption_constant = new ulong();
            ulong pid = new ulong();
            int[] ivs = new int[6];
            ulong ability = new ulong();
            ulong gender = new ulong();
            ulong nature = new ulong();
            ulong shinyseed = new ulong();
            ulong GeneratorSeed;
            Xoroshiro128Plus fixedrng;
            double EncounterSlotRand;
            bool alpha = false;
            ulong fixedseed;
            for(int i = 1; i < 5; i++)
            {
                GeneratorSeed = mainrng.Next();
                mainrng.Next();
                fixedrng = new Xoroshiro128Plus(GeneratorSeed);
                EncounterSlotRand = (float)(101 * (float)((float)fixedrng.Next() * 5.421e-20f)) + 0.0;
                if (EncounterSlotRand >= 100)
                    alpha = true;
                fixedseed = fixedrng.Next();
                (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixedseed, Convert.ToInt32(Program.main.outbreakShinyrolls.Text), alpha? 3: 0);
                Program.main.OutbreakDisplay.AppendText($"Initial Spawn: {i}\nAlpha: {alpha}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", GeneratorSeed)}\n\n");
                alpha = false;
            }
            ulong groupseed = mainrng.Next();
            mainrng = new Xoroshiro128Plus(groupseed);
            var respawnrng = new Xoroshiro128Plus(groupseed);
            int spawns = Convert.ToInt32(Program.main.outbreakspawncount.Text);
            for(int i = 1; i < spawns-3; i++)
            {
                GeneratorSeed = respawnrng.Next();
                respawnrng.Next();
                respawnrng = new Xoroshiro128Plus(respawnrng.Next());
                fixedrng = new Xoroshiro128Plus(GeneratorSeed);
                EncounterSlotRand = (float)(101 * (float)((float)fixedrng.Next() * 5.421e-20f)) + 0.0;
                if (EncounterSlotRand >= 100)
                    alpha = true;
                fixedseed = fixedrng.Next();
                (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixedseed, Convert.ToInt32(Program.main.outbreakShinyrolls.Text), alpha ? 3 : 0);
                Program.main.OutbreakDisplay.AppendText($"Respawn: {i}\nAlpha: {alpha}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", GeneratorSeed)}\n\n");
                alpha = false;
            }
            return;
        }
        public void GenerateNextOutbreakMatch()
        {
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + Convert.ToInt32(Program.main.outbreakgroupid.Text) * 0x440 + 0x20 };
            var SpawnerOff = Main.routes.PointerAll(SpawnerOffpoint).Result;
            var startGeneratorSeed = Main.routes.ReadBytesAbsoluteAsync(SpawnerOff, 8).Result;
            Program.main.OutbreakDisplay.AppendText($"Generator Seed: {BitConverter.ToString(startGeneratorSeed).Replace("-", "")}\n");
            var group_seed = (BitConverter.ToUInt64(startGeneratorSeed, 0) - 0x82A2B175229D6A5B) & 0xFFFFFFFFFFFFFFFF;
            Program.main.OutbreakDisplay.AppendText($"Group Seed: {string.Format("0x{0:X}", group_seed)}\n");
            var mainrng = new Xoroshiro128Plus(group_seed);
            bool shiny = false;
            ulong encryption_constant = new ulong();
            ulong pid = new ulong();
            int[] ivs = new int[6];
            ulong ability = new ulong();
            ulong gender = new ulong();
            ulong nature = new ulong();
            ulong shinyseed = new ulong();
            ulong GeneratorSeed;
            Xoroshiro128Plus fixedrng;
            double EncounterSlotRand;
            bool alpha = false;
            ulong fixedseed;
            int advances = 0;
            while(advances< Convert.ToInt32(Program.main.outbreakmaxadv.Text))
            {
                for (int i = 1; i < 5; i++)
                {
                    GeneratorSeed = mainrng.Next();
                    mainrng.Next();
                    fixedrng = new Xoroshiro128Plus(GeneratorSeed);
                    EncounterSlotRand = (float)(101 * (float)((float)fixedrng.Next() * 5.421e-20f)) + 0.0;
                    if (EncounterSlotRand >= 100)
                        alpha = true;
                    fixedseed = fixedrng.Next();
                    (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixedseed, Convert.ToInt32(Program.main.outbreakShinyrolls.Text), alpha ? 3 : 0);

                    if (shiny && Program.main.AlphaSearch.Checked && alpha)
                    {
                        Program.main.OutbreakDisplay.AppendText($"Initial Spawn: {i}\nAlpha: {alpha}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", GeneratorSeed)}\n\n");
                        Program.main.outbreakseedtoinject.Text = string.Format("0x{0:X}", GeneratorSeed);
                        return;
                    }
                    if (shiny && !Program.main.AlphaSearch.Checked)
                    {
                        Program.main.OutbreakDisplay.AppendText($"Initial Spawn: {i}\nAlpha: {alpha}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", GeneratorSeed)}\n\n");
                        Program.main.outbreakseedtoinject.Text = string.Format("0x{0:X}", GeneratorSeed);
                        return;
                    }
                    alpha = false;
                }
                ulong groupseed = mainrng.Next();
                mainrng = new Xoroshiro128Plus(groupseed);
                var respawnrng = new Xoroshiro128Plus(groupseed);
                int spawns = Convert.ToInt32(Program.main.outbreakspawncount.Text);
                for (int i = 1; i < spawns - 3; i++)
                {
                    GeneratorSeed = respawnrng.Next();
                    respawnrng.Next();
                    respawnrng = new Xoroshiro128Plus(respawnrng.Next());
                    fixedrng = new Xoroshiro128Plus(GeneratorSeed);
                    EncounterSlotRand = (float)(101 * (float)((float)fixedrng.Next() * 5.421e-20f)) + 0.0;
                    if (EncounterSlotRand >= 100)
                        alpha = true;
                    fixedseed = fixedrng.Next();
                    (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixedseed, Convert.ToInt32(Program.main.outbreakShinyrolls.Text), alpha ? 3 : 0);

                    if (shiny && Program.main.AlphaSearch.Checked && alpha)
                    {
                        Program.main.OutbreakDisplay.AppendText($"Respawn: {i}\nAlpha: {alpha}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", GeneratorSeed)}\n\n");
                        Program.main.outbreakseedtoinject.Text = string.Format("0x{0:X}", GeneratorSeed);
                        return;
                    }
                    if (shiny && !Program.main.AlphaSearch.Checked)
                    {
                        Program.main.OutbreakDisplay.AppendText($"Respawn: {i}\nAlpha: {alpha}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", GeneratorSeed)}\n\n");
                        Program.main.outbreakseedtoinject.Text = string.Format("0x{0:X}", GeneratorSeed);
                        return;
                    }
                    alpha = false;
                }
                advances++;
            }
            if(advances >= Convert.ToInt32(Program.main.outbreakmaxadv.Text))
            {
                Program.main.OutbreakDisplay.AppendText("No Matches found within your max advances\n");
            }
            
        }
        public void ReadMassOutbreak()
        {
            for(int i = 0; i < 15; i++)
            {
                var outbreakpointer = new long[] { 0x42BA6B0, 0x2B0, 0x58, 0x18, 0x1d4 + (i * 0x90) + (0xB80 * ((int)(Enums.Maps)Program.main.MassiveMap.SelectedItem)) };
                var Outbreakoff = Main.routes.PointerAll(outbreakpointer).Result;
                var location = Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x24, 2).Result;
                var map = BitConverter.ToString(location);
                switch (map)
                {
                    case "B7-56": map = " in the Cobalt Coastlands"; break;
                    case "04-55": map = " in the Crimson Mirelands"; break;
                    case "51-53": map = " in the Alabaster Icelands"; break;
                    case "9E-51": map = " in the Coronet Highlands"; break;
                    case "1D-5A": map = " in the Obsidian Fieldlands"; break;
                    case "00-00": map = ""; break;
                }
                if(i == 0)
                    Program.main.MassiveDisplay.AppendText($"Searching {map}\n");
                int species = BitConverter.ToUInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff, 2).Result,0);
                Task.Delay(1000);
                Program.main.MassiveDisplay.AppendText($"GroupID: {i} {(Species)species}\n");
                if(species != 0)
                {
                    bool shiny = false;
                    ulong encryption_constant = new ulong();
                    ulong pid = new ulong();
                    int[] ivs = new int[6];
                    ulong ability = new ulong();
                    ulong gender = new ulong();
                    ulong nature = new ulong();
                    ulong shinyseed = new ulong();
                    var spawncoordx = BitConverter.ToUInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x14, 4).Result, 0);
                    var spawncoordy = BitConverter.ToUInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x10, 4).Result, 0);
                    var spawncoordz = BitConverter.ToUInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff - 0x0C, 4).Result, 0);
                    Program.main.MassiveDisplay.AppendText($"Coordinates: X: {spawncoordx} Y: {spawncoordy} Z: {spawncoordz}\n");
                    var groupseed = BitConverter.ToUInt64( Main.routes.ReadBytesAbsoluteAsync(Outbreakoff+0x44, 8).Result,0);
                    var maxspawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff+0x4c, 4).Result,0);
                    Program.main.MassiveDisplay.AppendText($"Max spawns: {maxspawns}\n");
                    var currspawns = BitConverter.ToInt32(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff+0x50,4).Result,0);
                    Program.main.MassiveDisplay.AppendText($"Current spawns: {currspawns}\n\n");
                    var bonusround = BitConverter.ToUInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff + 0x18, 2).Result, 0);
                    var bonuscount = BitConverter.ToInt16(Main.routes.ReadBytesAbsoluteAsync(Outbreakoff+0x60,2).Result, 0);
                   
                    var mainrng = new Xoroshiro128Plus(groupseed);
                    for (int h = 0; h < 4; h++)
                    {
                        var generatorseed = mainrng.Next();
                        mainrng.Next();
                        var fixedrng = new Xoroshiro128Plus(generatorseed);
                        fixedrng.Next();
                        var fixedseed = fixedrng.Next();
                        (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixedseed, 13,0);
                        if(shiny)
                            Program.main.MassiveDisplay.AppendText($"Initial Spawn {h}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generatorseed)}\n\n");
                    }
                    groupseed = mainrng.Next();
                    mainrng = new Xoroshiro128Plus(groupseed);
                    var respawnrng = new Xoroshiro128Plus(groupseed);
                    for(int p=1; p < maxspawns - 3; p++)
                    {
                        var generator_seed = respawnrng.Next();
                        respawnrng.Next();
                        respawnrng = new Xoroshiro128Plus(respawnrng.Next());
                        var fixed_rng = new Xoroshiro128Plus(generator_seed);
                        fixed_rng.Next();
                        var fixed_seed = fixed_rng.Next();
                        
                        (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixed_seed, 13, 0);
                        if(shiny)
                            Program.main.MassiveDisplay.AppendText($"Respawn {p}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generator_seed)}\n\n");
                    }
                    if(bonusround != 0)
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
                            (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixedseed, 13, 3);
                            if (shiny)
                                Program.main.MassiveDisplay.AppendText($"Initial Bonus Spawn {h}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generatorseed)}\n\n");
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

                            (shiny, encryption_constant, pid, ivs, ability, gender, nature, shinyseed) = GenerateFromSeed(fixed_seed, 13, 0);
                            if (shiny)
                                Program.main.MassiveDisplay.AppendText($"Bonus Respawn {p}\nShiny:{shiny}\nEC:{string.Format("{0:X}", encryption_constant)}\nPID:{string.Format("{0:X}", pid)}\nIVs:{ivs[0]}/{ivs[1]}/{ivs[2]}/{ivs[3]}/{ivs[4]}/{ivs[5]}\nAbility:{ability}\nGender:{gender}\nNature{((Nature)nature)}\nShinySeed{string.Format("0x{0:X}", generator_seed)}\n\n");
                        }
                    }

                }
            }
        }
    }
}

