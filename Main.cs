using System;
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
            outbreakmap.DataSource = Enum.GetValues(typeof(Enums.Maps));
            MassiveMap.DataSource = Enum.GetValues(typeof(Enums.MMOMapCount));
      

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
            try
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
            catch { }
        }
       public static Socket Connection = new Socket(SocketType.Stream, ProtocolType.Tcp);
        private void connect_Click(object sender, EventArgs e)
        {
            Connection.Connect(Program.main.IP.Text,6000);
            if (Connection.Connected)
                Program.main.StandardSpawnsDisplay.AppendText("connected to switch\n");
           
        }
        public static BotBaseRoutines routes = new BotBaseRoutines();
        public static RngRoutines rngroutes = new RngRoutines();
        private void calculatebutton_Click(object sender, EventArgs e)
        {
            var groupid = Convert.ToUInt32(Program.main.groupid.Text);
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330,0x70 + groupid * 0x440 + 0x20 };
            var SpawnerOff = routes.PointerAll(SpawnerOffpoint).Result;
            var GeneratorSeed = routes.ReadBytesAbsoluteAsync(SpawnerOff, 8).Result;
            Program.main.StandardSpawnsDisplay.AppendText($"Generator Seed: {BitConverter.ToString(GeneratorSeed).Replace("-", "")}\n");
            var group_seed = (BitConverter.ToUInt64(GeneratorSeed, 0) - 0x82A2B175229D6A5B) & 0xFFFFFFFFFFFFFFFF;
            Program.main.StandardSpawnsDisplay.AppendText($"Group Seed: {string.Format("0x{0:X}", group_seed)}\n");
            
            var injectionseed = rngroutes.GenerateNextStandardMatch(group_seed);
            
        }

        private async void Inject_Click(object sender, EventArgs e)
        {
            var groupid = Convert.ToUInt32(Program.main.groupid.Text);
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + groupid * 0x440 + 0x20 };
            var SpawnerOff = routes.PointerAll(SpawnerOffpoint).Result;
            var seedlong = Convert.ToUInt64(Program.main.SeedToInject.Text, 16);
            await routes.WriteBytesAbsoluteAsync(BitConverter.GetBytes(Convert.ToUInt64(Program.main.SeedToInject.Text,16)),SpawnerOff);
            Program.main.StandardSpawnsDisplay.AppendText("Injecting: " + string.Format("{0:X}", Program.main.SeedToInject.Text)+"\n");
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            Connection.Close();
            Connection = new Socket(SocketType.Stream, ProtocolType.Tcp);
            Program.main.StandardSpawnsDisplay.AppendText("Disconnected from switch\n");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void outbreakread_Click(object sender, EventArgs e)
        {
            rngroutes.ReadOutbreakID();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void outbreakcalculate_Click(object sender, EventArgs e)
        {
            rngroutes.GenerateNextOutbreakMatch();
        }

        private async void outbreakinject_Click(object sender, EventArgs e)
        {
            var groupid = Convert.ToUInt32(Program.main.outbreakgroupid.Text);
            var SpawnerOffpoint = new long[] { 0x42a6ee0, 0x330, 0x70 + groupid * 0x440 + 0x20 };
            var SpawnerOff = routes.PointerAll(SpawnerOffpoint).Result;
            var seedlong = Convert.ToUInt64(Program.main.SeedToInject.Text, 16);
            await routes.WriteBytesAbsoluteAsync(BitConverter.GetBytes(Convert.ToUInt64(Program.main.outbreakseedtoinject.Text, 16)), SpawnerOff);
            Program.main.OutbreakDisplay.AppendText("Injecting: " + string.Format("{0:X}", Program.main.outbreakseedtoinject.Text) + "\n");
        }

        private void MassiveRead_Click(object sender, EventArgs e)
        {
            rngroutes.ReadMassOutbreak();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private async void teleportbutton_Click(object sender, EventArgs e)
        {
            var playerlocationptr = new long[] { 0x42D4720, 0x18, 0x48, 0x1F0, 0x18, 0x370, 0x90 };
            var playerlocationoff = routes.PointerAll(playerlocationptr).Result;
            var CoordX = uint.Parse(Program.main.CoordX.Text);
            byte[] X = BitConverter.GetBytes(CoordX);
            var CoordY = uint.Parse(Program.main.CoordY.Text);
            byte[] Y = BitConverter.GetBytes(CoordY);
            var CoordZ = uint.Parse(Program.main.CoordZ.Text);
            byte[] Z = BitConverter.GetBytes(CoordZ);

            await routes.WriteBytesAbsoluteAsync(X, playerlocationoff);
            await routes.WriteBytesAbsoluteAsync(Y, playerlocationoff + 0x4);
            await routes.WriteBytesAbsoluteAsync(Z, playerlocationoff + 0x8);
        }

        private async void campreadbutton_Click(object sender, EventArgs e)
        {
            var playerlocptr = new long[] { 0x42D4720, 0x18, 0x48, 0x1F0, 0x18, 0x370, 0x90 };
            var playerlocoff = routes.PointerAll(playerlocptr).Result;
            var coordx = BitConverter.ToUInt32(await routes.ReadBytesAbsoluteAsync(playerlocoff, 4), 0);
            var coordy = BitConverter.ToUInt32(await routes.ReadBytesAbsoluteAsync(playerlocoff + 0x4, 4), 0);
            var coordz = BitConverter.ToUInt32(await routes.ReadBytesAbsoluteAsync(playerlocoff + 0x8, 4), 0);
            Program.main.Campx.Text = $"{coordx}";
            Program.main.campy.Text = $"{coordy}";
            Program.main.campz.Text = $"{coordz}";
        }

        private async void campteleportbutton_Click(object sender, EventArgs e)
        {
            var playerlocationptr = new long[] { 0x42D4720, 0x18, 0x48, 0x1F0, 0x18, 0x370, 0x90 };
            var playerlocationoff = routes.PointerAll(playerlocationptr).Result;
            var CoordX = uint.Parse(Program.main.Campx.Text);
            byte[] X = BitConverter.GetBytes(CoordX);
            var CoordY = uint.Parse(Program.main.campy.Text);
            byte[] Y = BitConverter.GetBytes(CoordY);
            var CoordZ = uint.Parse(Program.main.campz.Text);
            byte[] Z = BitConverter.GetBytes(CoordZ);

            await routes.WriteBytesAbsoluteAsync(X, playerlocationoff);
            await routes.WriteBytesAbsoluteAsync(Y, playerlocationoff + 0x4);
            await routes.WriteBytesAbsoluteAsync(Z, playerlocationoff + 0x8);
        }
    }
}
