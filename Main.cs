﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using SysBot.Base;


namespace PLARNGGui
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            MapSelection.DataSource = Enum.GetValues(typeof(Enums.Maps));
            weatherselection.DataSource = Enum.GetValues(typeof(Enums.Weather));
            Timeofdayselection.DataSource = Enum.GetValues(typeof(Enums.Time));
      

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MapSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokemonselection.Items.Clear();
            var Spawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/Spawners/{Program.main.MapSelection.SelectedItem}.json");
            var Encountersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/encounters/{Program.main.MapSelection.SelectedItem}.json");
            var encmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Encountersjson);
            var spawnmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Spawnersjson);
            var groupname = spawnmap[$"{Program.main.groupid.Text}"]["name"];
            var possiblespawns = encmap[$"{groupname}"][$"{((Enums.Time)Program.main.Timeofdayselection.SelectedItem == Enums.Time.Any ? "Any Time" : Program.main.Timeofdayselection.SelectedItem)}" + "/" + $"{((Enums.Weather)Program.main.weatherselection.SelectedItem == Enums.Weather.All ? "All Weather" : Program.main.weatherselection.SelectedItem)}"];
            try
            {
                foreach (var key in possiblespawns)
                {
                    pokemonselection.Items.Add($"{key}".Remove($"{key}".IndexOf(":")).Replace("\"", ""));
                }
            }
            catch { pokemonselection.Items.Add("(None)"); }
        }

        private void weatherselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokemonselection.Items.Clear();
            var Spawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/Spawners/{Program.main.MapSelection.SelectedItem}.json");
            var Encountersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/encounters/{Program.main.MapSelection.SelectedItem}.json");
            var encmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Encountersjson);
            var spawnmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Spawnersjson);
            var groupname = spawnmap[$"{Program.main.groupid.Text}"]["name"];
            var possiblespawns = encmap[$"{groupname}"][$"{((Enums.Time)Program.main.Timeofdayselection.SelectedItem == Enums.Time.Any ? "Any Time" : Program.main.Timeofdayselection.SelectedItem)}" + "/" + $"{((Enums.Weather)Program.main.weatherselection.SelectedItem == Enums.Weather.All ? "All Weather" : Program.main.weatherselection.SelectedItem)}"];
            try
            {
                foreach (var key in possiblespawns)
                {
                    pokemonselection.Items.Add($"{key}".Remove($"{key}".IndexOf(":")).Replace("\"", ""));
                }
            }
            catch { pokemonselection.Items.Add("(None)"); }
        }

        private void Timeofdayselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokemonselection.Items.Clear();
            var Spawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/Spawners/{Program.main.MapSelection.SelectedItem}.json");
            var Encountersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/encounters/{Program.main.MapSelection.SelectedItem}.json");
            var encmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Encountersjson);
            var spawnmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Spawnersjson);
            var groupname = spawnmap[$"{Program.main.groupid.Text}"]["name"];
            var possiblespawns = encmap[$"{groupname}"][$"{((Enums.Time)Program.main.Timeofdayselection.SelectedItem == Enums.Time.Any ? "Any Time" : Program.main.Timeofdayselection.SelectedItem)}" + "/" + $"{((Enums.Weather)Program.main.weatherselection.SelectedItem == Enums.Weather.All ? "All Weather" : Program.main.weatherselection.SelectedItem)}"];
            try
            {
                foreach (var key in possiblespawns)
                {
                    pokemonselection.Items.Add($"{key}".Remove($"{key}".IndexOf(":")).Replace("\"", ""));
                }
            }
            catch { pokemonselection.Items.Add("(None)"); }
        }

        private void pokemonselection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupid_TextChanged(object sender, EventArgs e)
        {
            pokemonselection.Items.Clear();
            var Spawnersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/Spawners/{Program.main.MapSelection.SelectedItem}.json");
            var Encountersjson = new WebClient().DownloadString($"https://raw.githubusercontent.com/santacrab2/SysBot.NET/RNGstuff/encounters/{Program.main.MapSelection.SelectedItem}.json");
            var encmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Encountersjson);
            var spawnmap = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Spawnersjson);
            var groupname = spawnmap[$"{Program.main.groupid.Text}"]["name"];
            var possiblespawns = encmap[$"{groupname}"][$"{((Enums.Time)Program.main.Timeofdayselection.SelectedItem == Enums.Time.Any ? "Any Time" : Program.main.Timeofdayselection.SelectedItem)}" + "/" + $"{((Enums.Weather)Program.main.weatherselection.SelectedItem == Enums.Weather.All ? "All Weather" : Program.main.weatherselection.SelectedItem)}"];
            try
            {
                foreach (var key in possiblespawns)
                {
                    pokemonselection.Items.Add($"{key}".Remove($"{key}".IndexOf(":")).Replace("\"", ""));
                }
            }
            catch { pokemonselection.Items.Add("(None)"); }
        }
       public static Socket Connection = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private void connect_Click(object sender, EventArgs e)
        {
            Connection.Connect(Program.main.IP.Text,6000);
            if (Connection.Connected)
                Program.main.StandardSpawnsDisplay.AppendText("connected to switch\n");
           
        }
        public static BotBaseRoutines routes = new BotBaseRoutines();
        private void calculatebutton_Click(object sender, EventArgs e)
        {
            var groupid = Convert.ToUInt32(Program.main.groupid.Text);
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330,0x70 + groupid * 0x440 + 0x20 };
            Program.main.StandardSpawnsDisplay.AppendText(SpawnerOffpoint[0].ToString());
            var SpawnerOff = routes.PointerAll(SpawnerOffpoint).Result;
            var GeneratorSeed = routes.ReadBytesAbsoluteAsync(SpawnerOff, 8).Result;
            Program.main.StandardSpawnsDisplay.AppendText($"Generator Seed: {BitConverter.ToString(GeneratorSeed).Replace("-", "")}\n");
            var group_seed = (BitConverter.ToUInt64(GeneratorSeed, 0) - 0x82A2B175229D6A5B) & 0xFFFFFFFFFFFFFFFF;
            Program.main.StandardSpawnsDisplay.AppendText($"Group Seed: {string.Format("0x{0:X}", group_seed)}\n");
            var rngroutes = new RngRoutines();
            var injectionseed = rngroutes.GenerateNextStandardMatch(group_seed);
            
        }

        private async void Inject_Click(object sender, EventArgs e)
        {
            var groupid = Convert.ToUInt32(Program.main.groupid.Text);
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + groupid * 0x440 + 0x20 };
            Program.main.StandardSpawnsDisplay.AppendText(SpawnerOffpoint[0].ToString());
            var SpawnerOff = routes.PointerAll(SpawnerOffpoint).Result;
            await routes.WriteBytesAbsoluteAsync(BitConverter.GetBytes(Convert.ToUInt64(Program.main.SeedToInject.Text)),SpawnerOff);
            Program.main.StandardSpawnsDisplay.AppendText("Injecting: " + string.Format("0x{0:X}", Convert.ToUInt64(Program.main.SeedToInject.Text)));
        }
    }
}
