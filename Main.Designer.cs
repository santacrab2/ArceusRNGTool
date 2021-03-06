using System;
namespace PLARNGGui
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.StandardSpawnstab = new System.Windows.Forms.TabPage();
            this.checknear = new System.Windows.Forms.Button();
            this.standardgroupid = new System.Windows.Forms.ComboBox();
            this.calculatebutton = new System.Windows.Forms.Button();
            this.InjectStandard = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pokemonselection = new System.Windows.Forms.ComboBox();
            this.Timeofdayselection = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.weatherselection = new System.Windows.Forms.ComboBox();
            this.MapSelection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guaranteedivs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ShinyRollstext = new System.Windows.Forms.TextBox();
            this.StandardSpawnsDisplay = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxAdvances = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SeedToInject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Outbreaktab = new System.Windows.Forms.TabPage();
            this.AlphaSearch = new System.Windows.Forms.CheckBox();
            this.outbreakspawncount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.outbreakmap = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.outbreakGuarIVs = new System.Windows.Forms.TextBox();
            this.outbreakShinyrolls = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.outbreakmaxadv = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.outbreakinject = new System.Windows.Forms.Button();
            this.outbreakseedtoinject = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.outbreakread = new System.Windows.Forms.Button();
            this.outbreakcalculate = new System.Windows.Forms.Button();
            this.outbreakgroupid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.OutbreakDisplay = new System.Windows.Forms.RichTextBox();
            this.MMOtab = new System.Windows.Forms.TabPage();
            this.Aggromap = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.MMOSRs = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Aggro = new System.Windows.Forms.CheckBox();
            this.MassiveRead = new System.Windows.Forms.Button();
            this.MassiveDisplay = new System.Windows.Forms.RichTextBox();
            this.distortiontab = new System.Windows.Forms.TabPage();
            this.distortionmap = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.Distortiondisplay = new System.Windows.Forms.RichTextBox();
            this.Teleporter = new System.Windows.Forms.TabPage();
            this.campteleportbutton = new System.Windows.Forms.Button();
            this.campreadbutton = new System.Windows.Forms.Button();
            this.campz = new System.Windows.Forms.TextBox();
            this.campy = new System.Windows.Forms.TextBox();
            this.Campx = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.teleportbutton = new System.Windows.Forms.Button();
            this.Teleporterdisplay = new System.Windows.Forms.RichTextBox();
            this.CoordZ = new System.Windows.Forms.TextBox();
            this.CoordY = new System.Windows.Forms.TextBox();
            this.CoordX = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.Disconnect = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.DistortionSRs = new System.Windows.Forms.TextBox();
            this.readalldisbutton = new System.Windows.Forms.Button();
            this.createdis = new System.Windows.Forms.Button();
            this.pastureteleport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.StandardSpawnstab.SuspendLayout();
            this.Outbreaktab.SuspendLayout();
            this.MMOtab.SuspendLayout();
            this.distortiontab.SuspendLayout();
            this.Teleporter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.StandardSpawnstab);
            this.tabControl1.Controls.Add(this.Outbreaktab);
            this.tabControl1.Controls.Add(this.MMOtab);
            this.tabControl1.Controls.Add(this.distortiontab);
            this.tabControl1.Controls.Add(this.Teleporter);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 395);
            this.tabControl1.TabIndex = 1;
            // 
            // StandardSpawnstab
            // 
            this.StandardSpawnstab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StandardSpawnstab.Controls.Add(this.checknear);
            this.StandardSpawnstab.Controls.Add(this.standardgroupid);
            this.StandardSpawnstab.Controls.Add(this.calculatebutton);
            this.StandardSpawnstab.Controls.Add(this.InjectStandard);
            this.StandardSpawnstab.Controls.Add(this.label9);
            this.StandardSpawnstab.Controls.Add(this.pokemonselection);
            this.StandardSpawnstab.Controls.Add(this.Timeofdayselection);
            this.StandardSpawnstab.Controls.Add(this.label8);
            this.StandardSpawnstab.Controls.Add(this.label7);
            this.StandardSpawnstab.Controls.Add(this.weatherselection);
            this.StandardSpawnstab.Controls.Add(this.MapSelection);
            this.StandardSpawnstab.Controls.Add(this.label6);
            this.StandardSpawnstab.Controls.Add(this.guaranteedivs);
            this.StandardSpawnstab.Controls.Add(this.label5);
            this.StandardSpawnstab.Controls.Add(this.label4);
            this.StandardSpawnstab.Controls.Add(this.ShinyRollstext);
            this.StandardSpawnstab.Controls.Add(this.StandardSpawnsDisplay);
            this.StandardSpawnstab.Controls.Add(this.label3);
            this.StandardSpawnstab.Controls.Add(this.MaxAdvances);
            this.StandardSpawnstab.Controls.Add(this.label2);
            this.StandardSpawnstab.Controls.Add(this.SeedToInject);
            this.StandardSpawnstab.Controls.Add(this.label1);
            this.StandardSpawnstab.Location = new System.Drawing.Point(4, 22);
            this.StandardSpawnstab.Name = "StandardSpawnstab";
            this.StandardSpawnstab.Padding = new System.Windows.Forms.Padding(3);
            this.StandardSpawnstab.Size = new System.Drawing.Size(768, 369);
            this.StandardSpawnstab.TabIndex = 0;
            this.StandardSpawnstab.Text = "StandardSpawns";
            // 
            // checknear
            // 
            this.checknear.Location = new System.Drawing.Point(598, 273);
            this.checknear.Name = "checknear";
            this.checknear.Size = new System.Drawing.Size(75, 23);
            this.checknear.TabIndex = 22;
            this.checknear.Text = "Check Near";
            this.checknear.UseVisualStyleBackColor = true;
            this.checknear.Click += new System.EventHandler(this.checknear_Click);
            // 
            // standardgroupid
            // 
            this.standardgroupid.FormattingEnabled = true;
            this.standardgroupid.Location = new System.Drawing.Point(411, 18);
            this.standardgroupid.Name = "standardgroupid";
            this.standardgroupid.Size = new System.Drawing.Size(63, 21);
            this.standardgroupid.TabIndex = 21;
            this.standardgroupid.SelectedIndexChanged += new System.EventHandler(this.standardgroupid_SelectedIndexChanged);
            // 
            // calculatebutton
            // 
            this.calculatebutton.Location = new System.Drawing.Point(369, 273);
            this.calculatebutton.Name = "calculatebutton";
            this.calculatebutton.Size = new System.Drawing.Size(105, 23);
            this.calculatebutton.TabIndex = 20;
            this.calculatebutton.Text = "Calculate";
            this.calculatebutton.UseVisualStyleBackColor = true;
            this.calculatebutton.Click += new System.EventHandler(this.calculatebutton_Click);
            // 
            // InjectStandard
            // 
            this.InjectStandard.Location = new System.Drawing.Point(487, 273);
            this.InjectStandard.Name = "InjectStandard";
            this.InjectStandard.Size = new System.Drawing.Size(105, 23);
            this.InjectStandard.TabIndex = 4;
            this.InjectStandard.Text = "Inject";
            this.InjectStandard.UseVisualStyleBackColor = true;
            this.InjectStandard.Click += new System.EventHandler(this.Inject_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Pokemon to find";
            // 
            // pokemonselection
            // 
            this.pokemonselection.FormattingEnabled = true;
            this.pokemonselection.Location = new System.Drawing.Point(437, 219);
            this.pokemonselection.Name = "pokemonselection";
            this.pokemonselection.Size = new System.Drawing.Size(121, 21);
            this.pokemonselection.TabIndex = 18;
            this.pokemonselection.SelectedIndexChanged += new System.EventHandler(this.pokemonselection_SelectedIndexChanged);
            // 
            // Timeofdayselection
            // 
            this.Timeofdayselection.FormattingEnabled = true;
            this.Timeofdayselection.Location = new System.Drawing.Point(418, 192);
            this.Timeofdayselection.Name = "Timeofdayselection";
            this.Timeofdayselection.Size = new System.Drawing.Size(121, 21);
            this.Timeofdayselection.TabIndex = 17;
            this.Timeofdayselection.SelectedIndexChanged += new System.EventHandler(this.Timeofdayselection_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(350, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Time of Day";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Weather";
            // 
            // weatherselection
            // 
            this.weatherselection.FormattingEnabled = true;
            this.weatherselection.Location = new System.Drawing.Point(404, 166);
            this.weatherselection.Name = "weatherselection";
            this.weatherselection.Size = new System.Drawing.Size(111, 21);
            this.weatherselection.TabIndex = 14;
            this.weatherselection.SelectedIndexChanged += new System.EventHandler(this.weatherselection_SelectedIndexChanged);
            // 
            // MapSelection
            // 
            this.MapSelection.FormattingEnabled = true;
            this.MapSelection.Location = new System.Drawing.Point(384, 139);
            this.MapSelection.Name = "MapSelection";
            this.MapSelection.Size = new System.Drawing.Size(121, 21);
            this.MapSelection.TabIndex = 13;
            this.MapSelection.SelectedIndexChanged += new System.EventHandler(this.MapSelection_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Map";
            // 
            // guaranteedivs
            // 
            this.guaranteedivs.Location = new System.Drawing.Point(437, 116);
            this.guaranteedivs.Name = "guaranteedivs";
            this.guaranteedivs.Size = new System.Drawing.Size(19, 20);
            this.guaranteedivs.TabIndex = 11;
            this.guaranteedivs.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Guaranteed IVs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Shiny Rolls";
            // 
            // ShinyRollstext
            // 
            this.ShinyRollstext.Location = new System.Drawing.Point(411, 96);
            this.ShinyRollstext.Name = "ShinyRollstext";
            this.ShinyRollstext.Size = new System.Drawing.Size(34, 20);
            this.ShinyRollstext.TabIndex = 8;
            this.ShinyRollstext.Text = "1";
            // 
            // StandardSpawnsDisplay
            // 
            this.StandardSpawnsDisplay.Location = new System.Drawing.Point(6, 6);
            this.StandardSpawnsDisplay.Name = "StandardSpawnsDisplay";
            this.StandardSpawnsDisplay.ReadOnly = true;
            this.StandardSpawnsDisplay.Size = new System.Drawing.Size(344, 357);
            this.StandardSpawnsDisplay.TabIndex = 7;
            this.StandardSpawnsDisplay.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max Advances";
            // 
            // MaxAdvances
            // 
            this.MaxAdvances.Location = new System.Drawing.Point(439, 70);
            this.MaxAdvances.Name = "MaxAdvances";
            this.MaxAdvances.Size = new System.Drawing.Size(100, 20);
            this.MaxAdvances.TabIndex = 5;
            this.MaxAdvances.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seed To Inject";
            // 
            // SeedToInject
            // 
            this.SeedToInject.Location = new System.Drawing.Point(439, 44);
            this.SeedToInject.Name = "SeedToInject";
            this.SeedToInject.Size = new System.Drawing.Size(153, 20);
            this.SeedToInject.TabIndex = 3;
            this.SeedToInject.Text = "0x0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Group ID";
            // 
            // Outbreaktab
            // 
            this.Outbreaktab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Outbreaktab.Controls.Add(this.AlphaSearch);
            this.Outbreaktab.Controls.Add(this.outbreakspawncount);
            this.Outbreaktab.Controls.Add(this.label16);
            this.Outbreaktab.Controls.Add(this.outbreakmap);
            this.Outbreaktab.Controls.Add(this.label15);
            this.Outbreaktab.Controls.Add(this.label14);
            this.Outbreaktab.Controls.Add(this.outbreakGuarIVs);
            this.Outbreaktab.Controls.Add(this.outbreakShinyrolls);
            this.Outbreaktab.Controls.Add(this.label13);
            this.Outbreaktab.Controls.Add(this.outbreakmaxadv);
            this.Outbreaktab.Controls.Add(this.label12);
            this.Outbreaktab.Controls.Add(this.outbreakinject);
            this.Outbreaktab.Controls.Add(this.outbreakseedtoinject);
            this.Outbreaktab.Controls.Add(this.label11);
            this.Outbreaktab.Controls.Add(this.outbreakread);
            this.Outbreaktab.Controls.Add(this.outbreakcalculate);
            this.Outbreaktab.Controls.Add(this.outbreakgroupid);
            this.Outbreaktab.Controls.Add(this.label10);
            this.Outbreaktab.Controls.Add(this.OutbreakDisplay);
            this.Outbreaktab.Location = new System.Drawing.Point(4, 22);
            this.Outbreaktab.Name = "Outbreaktab";
            this.Outbreaktab.Padding = new System.Windows.Forms.Padding(3);
            this.Outbreaktab.Size = new System.Drawing.Size(768, 369);
            this.Outbreaktab.TabIndex = 1;
            this.Outbreaktab.Text = "Outbreaks";
            // 
            // AlphaSearch
            // 
            this.AlphaSearch.AutoSize = true;
            this.AlphaSearch.Location = new System.Drawing.Point(668, 280);
            this.AlphaSearch.Name = "AlphaSearch";
            this.AlphaSearch.Size = new System.Drawing.Size(90, 17);
            this.AlphaSearch.TabIndex = 19;
            this.AlphaSearch.Text = "Alpha Search";
            this.AlphaSearch.UseVisualStyleBackColor = true;
            // 
            // outbreakspawncount
            // 
            this.outbreakspawncount.Location = new System.Drawing.Point(577, 6);
            this.outbreakspawncount.Name = "outbreakspawncount";
            this.outbreakspawncount.Size = new System.Drawing.Size(42, 20);
            this.outbreakspawncount.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(530, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Spawns";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // outbreakmap
            // 
            this.outbreakmap.FormattingEnabled = true;
            this.outbreakmap.Location = new System.Drawing.Point(404, 137);
            this.outbreakmap.Name = "outbreakmap";
            this.outbreakmap.Size = new System.Drawing.Size(103, 21);
            this.outbreakmap.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(370, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Map";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(370, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Guaranteed IVs";
            // 
            // outbreakGuarIVs
            // 
            this.outbreakGuarIVs.Location = new System.Drawing.Point(457, 111);
            this.outbreakGuarIVs.Name = "outbreakGuarIVs";
            this.outbreakGuarIVs.Size = new System.Drawing.Size(51, 20);
            this.outbreakGuarIVs.TabIndex = 13;
            this.outbreakGuarIVs.Text = "3";
            // 
            // outbreakShinyrolls
            // 
            this.outbreakShinyrolls.Location = new System.Drawing.Point(439, 85);
            this.outbreakShinyrolls.Name = "outbreakShinyrolls";
            this.outbreakShinyrolls.Size = new System.Drawing.Size(42, 20);
            this.outbreakShinyrolls.TabIndex = 12;
            this.outbreakShinyrolls.Text = "26";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(374, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Shiny Rolls";
            // 
            // outbreakmaxadv
            // 
            this.outbreakmaxadv.Location = new System.Drawing.Point(457, 62);
            this.outbreakmaxadv.Name = "outbreakmaxadv";
            this.outbreakmaxadv.Size = new System.Drawing.Size(75, 20);
            this.outbreakmaxadv.TabIndex = 10;
            this.outbreakmaxadv.Text = "100";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(374, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Max Advances";
            // 
            // outbreakinject
            // 
            this.outbreakinject.Location = new System.Drawing.Point(577, 275);
            this.outbreakinject.Name = "outbreakinject";
            this.outbreakinject.Size = new System.Drawing.Size(75, 23);
            this.outbreakinject.TabIndex = 8;
            this.outbreakinject.Text = "Inject";
            this.outbreakinject.UseVisualStyleBackColor = true;
            this.outbreakinject.Click += new System.EventHandler(this.outbreakinject_Click);
            // 
            // outbreakseedtoinject
            // 
            this.outbreakseedtoinject.Location = new System.Drawing.Point(457, 35);
            this.outbreakseedtoinject.Name = "outbreakseedtoinject";
            this.outbreakseedtoinject.Size = new System.Drawing.Size(134, 20);
            this.outbreakseedtoinject.TabIndex = 7;
            this.outbreakseedtoinject.Text = "0x0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(374, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Seed To Inject";
            // 
            // outbreakread
            // 
            this.outbreakread.Location = new System.Drawing.Point(415, 275);
            this.outbreakread.Name = "outbreakread";
            this.outbreakread.Size = new System.Drawing.Size(75, 23);
            this.outbreakread.TabIndex = 5;
            this.outbreakread.Text = "Read ";
            this.outbreakread.UseVisualStyleBackColor = true;
            this.outbreakread.Click += new System.EventHandler(this.outbreakread_Click);
            // 
            // outbreakcalculate
            // 
            this.outbreakcalculate.Location = new System.Drawing.Point(496, 275);
            this.outbreakcalculate.Name = "outbreakcalculate";
            this.outbreakcalculate.Size = new System.Drawing.Size(75, 23);
            this.outbreakcalculate.TabIndex = 4;
            this.outbreakcalculate.Text = "Calculate";
            this.outbreakcalculate.UseVisualStyleBackColor = true;
            this.outbreakcalculate.Click += new System.EventHandler(this.outbreakcalculate_Click);
            // 
            // outbreakgroupid
            // 
            this.outbreakgroupid.Location = new System.Drawing.Point(430, 6);
            this.outbreakgroupid.Name = "outbreakgroupid";
            this.outbreakgroupid.Size = new System.Drawing.Size(60, 20);
            this.outbreakgroupid.TabIndex = 2;
            this.outbreakgroupid.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(374, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Group ID";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // OutbreakDisplay
            // 
            this.OutbreakDisplay.Location = new System.Drawing.Point(6, 6);
            this.OutbreakDisplay.Name = "OutbreakDisplay";
            this.OutbreakDisplay.ReadOnly = true;
            this.OutbreakDisplay.Size = new System.Drawing.Size(362, 357);
            this.OutbreakDisplay.TabIndex = 0;
            this.OutbreakDisplay.Text = "";
            // 
            // MMOtab
            // 
            this.MMOtab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MMOtab.Controls.Add(this.Aggromap);
            this.MMOtab.Controls.Add(this.label26);
            this.MMOtab.Controls.Add(this.MMOSRs);
            this.MMOtab.Controls.Add(this.label17);
            this.MMOtab.Controls.Add(this.Aggro);
            this.MMOtab.Controls.Add(this.MassiveRead);
            this.MMOtab.Controls.Add(this.MassiveDisplay);
            this.MMOtab.Location = new System.Drawing.Point(4, 22);
            this.MMOtab.Name = "MMOtab";
            this.MMOtab.Padding = new System.Windows.Forms.Padding(3);
            this.MMOtab.Size = new System.Drawing.Size(768, 369);
            this.MMOtab.TabIndex = 2;
            this.MMOtab.Text = "Massive Outbreaks";
            // 
            // Aggromap
            // 
            this.Aggromap.FormattingEnabled = true;
            this.Aggromap.Location = new System.Drawing.Point(536, 40);
            this.Aggromap.Name = "Aggromap";
            this.Aggromap.Size = new System.Drawing.Size(121, 21);
            this.Aggromap.TabIndex = 8;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(385, 43);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(145, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Aggressive Path Search Map";
            // 
            // MMOSRs
            // 
            this.MMOSRs.Location = new System.Drawing.Point(466, 6);
            this.MMOSRs.Name = "MMOSRs";
            this.MMOSRs.Size = new System.Drawing.Size(46, 20);
            this.MMOSRs.TabIndex = 6;
            this.MMOSRs.Text = "13";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(398, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Shiny Rolls:";
            // 
            // Aggro
            // 
            this.Aggro.AutoSize = true;
            this.Aggro.Location = new System.Drawing.Point(527, 265);
            this.Aggro.Name = "Aggro";
            this.Aggro.Size = new System.Drawing.Size(140, 17);
            this.Aggro.TabIndex = 4;
            this.Aggro.Text = "Aggressive Path Search";
            this.Aggro.UseVisualStyleBackColor = true;
            this.Aggro.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MassiveRead
            // 
            this.MassiveRead.Location = new System.Drawing.Point(401, 261);
            this.MassiveRead.Name = "MassiveRead";
            this.MassiveRead.Size = new System.Drawing.Size(100, 23);
            this.MassiveRead.TabIndex = 3;
            this.MassiveRead.Text = "Read";
            this.MassiveRead.UseVisualStyleBackColor = true;
            this.MassiveRead.Click += new System.EventHandler(this.MassiveRead_Click);
            // 
            // MassiveDisplay
            // 
            this.MassiveDisplay.Location = new System.Drawing.Point(6, 6);
            this.MassiveDisplay.Name = "MassiveDisplay";
            this.MassiveDisplay.ReadOnly = true;
            this.MassiveDisplay.Size = new System.Drawing.Size(373, 357);
            this.MassiveDisplay.TabIndex = 0;
            this.MassiveDisplay.Text = "";
            // 
            // distortiontab
            // 
            this.distortiontab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.distortiontab.Controls.Add(this.createdis);
            this.distortiontab.Controls.Add(this.readalldisbutton);
            this.distortiontab.Controls.Add(this.DistortionSRs);
            this.distortiontab.Controls.Add(this.label28);
            this.distortiontab.Controls.Add(this.distortionmap);
            this.distortiontab.Controls.Add(this.label27);
            this.distortiontab.Controls.Add(this.Distortiondisplay);
            this.distortiontab.Location = new System.Drawing.Point(4, 22);
            this.distortiontab.Name = "distortiontab";
            this.distortiontab.Padding = new System.Windows.Forms.Padding(3);
            this.distortiontab.Size = new System.Drawing.Size(768, 369);
            this.distortiontab.TabIndex = 4;
            this.distortiontab.Text = "Distortions";
            // 
            // distortionmap
            // 
            this.distortionmap.FormattingEnabled = true;
            this.distortionmap.Location = new System.Drawing.Point(402, 6);
            this.distortionmap.Name = "distortionmap";
            this.distortionmap.Size = new System.Drawing.Size(119, 21);
            this.distortionmap.TabIndex = 2;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(368, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "Map";
            // 
            // Distortiondisplay
            // 
            this.Distortiondisplay.Location = new System.Drawing.Point(6, 6);
            this.Distortiondisplay.Name = "Distortiondisplay";
            this.Distortiondisplay.ReadOnly = true;
            this.Distortiondisplay.Size = new System.Drawing.Size(356, 357);
            this.Distortiondisplay.TabIndex = 0;
            this.Distortiondisplay.Text = "";
            // 
            // Teleporter
            // 
            this.Teleporter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Teleporter.Controls.Add(this.pastureteleport);
            this.Teleporter.Controls.Add(this.campteleportbutton);
            this.Teleporter.Controls.Add(this.campreadbutton);
            this.Teleporter.Controls.Add(this.campz);
            this.Teleporter.Controls.Add(this.campy);
            this.Teleporter.Controls.Add(this.Campx);
            this.Teleporter.Controls.Add(this.label25);
            this.Teleporter.Controls.Add(this.label24);
            this.Teleporter.Controls.Add(this.label23);
            this.Teleporter.Controls.Add(this.label22);
            this.Teleporter.Controls.Add(this.label21);
            this.Teleporter.Controls.Add(this.teleportbutton);
            this.Teleporter.Controls.Add(this.Teleporterdisplay);
            this.Teleporter.Controls.Add(this.CoordZ);
            this.Teleporter.Controls.Add(this.CoordY);
            this.Teleporter.Controls.Add(this.CoordX);
            this.Teleporter.Controls.Add(this.label20);
            this.Teleporter.Controls.Add(this.label19);
            this.Teleporter.Controls.Add(this.label18);
            this.Teleporter.Location = new System.Drawing.Point(4, 22);
            this.Teleporter.Name = "Teleporter";
            this.Teleporter.Padding = new System.Windows.Forms.Padding(3);
            this.Teleporter.Size = new System.Drawing.Size(768, 369);
            this.Teleporter.TabIndex = 3;
            this.Teleporter.Text = "Teleporter";
            // 
            // campteleportbutton
            // 
            this.campteleportbutton.Location = new System.Drawing.Point(608, 133);
            this.campteleportbutton.Name = "campteleportbutton";
            this.campteleportbutton.Size = new System.Drawing.Size(108, 23);
            this.campteleportbutton.TabIndex = 17;
            this.campteleportbutton.Text = "Camp Teleport";
            this.campteleportbutton.UseVisualStyleBackColor = true;
            this.campteleportbutton.Click += new System.EventHandler(this.campteleportbutton_Click);
            // 
            // campreadbutton
            // 
            this.campreadbutton.Location = new System.Drawing.Point(519, 133);
            this.campreadbutton.Name = "campreadbutton";
            this.campreadbutton.Size = new System.Drawing.Size(75, 23);
            this.campreadbutton.TabIndex = 16;
            this.campreadbutton.Text = "Camp Read";
            this.campreadbutton.UseVisualStyleBackColor = true;
            this.campreadbutton.Click += new System.EventHandler(this.campreadbutton_Click);
            // 
            // campz
            // 
            this.campz.Location = new System.Drawing.Point(582, 74);
            this.campz.Name = "campz";
            this.campz.Size = new System.Drawing.Size(133, 20);
            this.campz.TabIndex = 15;
            // 
            // campy
            // 
            this.campy.Location = new System.Drawing.Point(582, 48);
            this.campy.Name = "campy";
            this.campy.Size = new System.Drawing.Size(134, 20);
            this.campy.TabIndex = 14;
            // 
            // Campx
            // 
            this.Campx.Location = new System.Drawing.Point(582, 24);
            this.Campx.Name = "Campx";
            this.Campx.Size = new System.Drawing.Size(134, 20);
            this.Campx.TabIndex = 13;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(559, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 13);
            this.label25.TabIndex = 12;
            this.label25.Text = "Z:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(559, 51);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "Y:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(559, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "X:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(590, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 13);
            this.label22.TabIndex = 9;
            this.label22.Text = "Camp Coordinates";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(364, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "Teleport To";
            // 
            // teleportbutton
            // 
            this.teleportbutton.Location = new System.Drawing.Point(367, 133);
            this.teleportbutton.Name = "teleportbutton";
            this.teleportbutton.Size = new System.Drawing.Size(75, 23);
            this.teleportbutton.TabIndex = 7;
            this.teleportbutton.Text = "Teleport";
            this.teleportbutton.UseVisualStyleBackColor = true;
            this.teleportbutton.Click += new System.EventHandler(this.teleportbutton_Click);
            // 
            // Teleporterdisplay
            // 
            this.Teleporterdisplay.Location = new System.Drawing.Point(6, 6);
            this.Teleporterdisplay.Name = "Teleporterdisplay";
            this.Teleporterdisplay.ReadOnly = true;
            this.Teleporterdisplay.Size = new System.Drawing.Size(318, 357);
            this.Teleporterdisplay.TabIndex = 6;
            this.Teleporterdisplay.Text = "";
            // 
            // CoordZ
            // 
            this.CoordZ.Location = new System.Drawing.Point(367, 74);
            this.CoordZ.Name = "CoordZ";
            this.CoordZ.Size = new System.Drawing.Size(117, 20);
            this.CoordZ.TabIndex = 5;
            // 
            // CoordY
            // 
            this.CoordY.Location = new System.Drawing.Point(367, 48);
            this.CoordY.Name = "CoordY";
            this.CoordY.Size = new System.Drawing.Size(117, 20);
            this.CoordY.TabIndex = 4;
            // 
            // CoordX
            // 
            this.CoordX.Location = new System.Drawing.Point(367, 24);
            this.CoordX.Name = "CoordX";
            this.CoordX.Size = new System.Drawing.Size(117, 20);
            this.CoordX.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(344, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Z:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(344, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Y:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(344, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "X:";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(16, 12);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(127, 20);
            this.IP.TabIndex = 2;
            this.IP.Text = "192.168.1.0";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(149, 9);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(96, 23);
            this.connect.TabIndex = 3;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Location = new System.Drawing.Point(251, 9);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(89, 23);
            this.Disconnect.TabIndex = 5;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(368, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 13);
            this.label28.TabIndex = 3;
            this.label28.Text = "Shiny Rolls";
            // 
            // DistortionSRs
            // 
            this.DistortionSRs.Location = new System.Drawing.Point(433, 38);
            this.DistortionSRs.Name = "DistortionSRs";
            this.DistortionSRs.Size = new System.Drawing.Size(38, 20);
            this.DistortionSRs.TabIndex = 4;
            this.DistortionSRs.Text = "1";
            // 
            // readalldisbutton
            // 
            this.readalldisbutton.Location = new System.Drawing.Point(396, 208);
            this.readalldisbutton.Name = "readalldisbutton";
            this.readalldisbutton.Size = new System.Drawing.Size(125, 23);
            this.readalldisbutton.TabIndex = 5;
            this.readalldisbutton.Text = "Read All Distortions";
            this.readalldisbutton.UseVisualStyleBackColor = true;
            this.readalldisbutton.Click += new System.EventHandler(this.readalldisbutton_Click);
            // 
            // createdis
            // 
            this.createdis.Location = new System.Drawing.Point(568, 208);
            this.createdis.Name = "createdis";
            this.createdis.Size = new System.Drawing.Size(109, 23);
            this.createdis.TabIndex = 6;
            this.createdis.Text = "Create Distortion";
            this.createdis.UseVisualStyleBackColor = true;
            this.createdis.Click += new System.EventHandler(this.createdis_Click);
            // 
            // pastureteleport
            // 
            this.pastureteleport.Location = new System.Drawing.Point(562, 183);
            this.pastureteleport.Name = "pastureteleport";
            this.pastureteleport.Size = new System.Drawing.Size(106, 23);
            this.pastureteleport.TabIndex = 18;
            this.pastureteleport.Text = "Pasture Teleport";
            this.pastureteleport.UseVisualStyleBackColor = true;
            this.pastureteleport.Click += new System.EventHandler(this.pastureteleport_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "ArceusRNGTools";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.StandardSpawnstab.ResumeLayout(false);
            this.StandardSpawnstab.PerformLayout();
            this.Outbreaktab.ResumeLayout(false);
            this.Outbreaktab.PerformLayout();
            this.MMOtab.ResumeLayout(false);
            this.MMOtab.PerformLayout();
            this.distortiontab.ResumeLayout(false);
            this.distortiontab.PerformLayout();
            this.Teleporter.ResumeLayout(false);
            this.Teleporter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage StandardSpawnstab;
        public System.Windows.Forms.TabPage Outbreaktab;
        public System.Windows.Forms.TextBox IP;
        public System.Windows.Forms.ComboBox MapSelection;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox guaranteedivs;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox ShinyRollstext;
        public System.Windows.Forms.RichTextBox StandardSpawnsDisplay;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox MaxAdvances;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox SeedToInject;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button connect;
        public System.Windows.Forms.Button InjectStandard;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox weatherselection;
        public System.Windows.Forms.ComboBox Timeofdayselection;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox pokemonselection;
        private System.Windows.Forms.Button calculatebutton;
        private System.Windows.Forms.Button Disconnect;
        public System.Windows.Forms.RichTextBox OutbreakDisplay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button outbreakinject;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button outbreakread;
        private System.Windows.Forms.Button outbreakcalculate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox outbreakseedtoinject;
        public System.Windows.Forms.TextBox outbreakgroupid;
        public System.Windows.Forms.TextBox outbreakShinyrolls;
        public System.Windows.Forms.TextBox outbreakmaxadv;
        public System.Windows.Forms.ComboBox outbreakmap;
        public System.Windows.Forms.TextBox outbreakGuarIVs;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox outbreakspawncount;
        private System.Windows.Forms.TabPage MMOtab;
        public System.Windows.Forms.RichTextBox MassiveDisplay;
        private System.Windows.Forms.Button MassiveRead;
        private System.Windows.Forms.TabPage Teleporter;
        private System.Windows.Forms.Button teleportbutton;
        public System.Windows.Forms.RichTextBox Teleporterdisplay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox CoordX;
        public System.Windows.Forms.TextBox CoordY;
        public System.Windows.Forms.TextBox CoordZ;
        private System.Windows.Forms.Button campteleportbutton;
        private System.Windows.Forms.Button campreadbutton;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox Campx;
        public System.Windows.Forms.TextBox campy;
        public System.Windows.Forms.TextBox campz;
        public System.Windows.Forms.CheckBox AlphaSearch;
        public System.Windows.Forms.CheckBox Aggro;
        public System.Windows.Forms.TextBox MMOSRs;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox Aggromap;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.ComboBox standardgroupid;
        private System.Windows.Forms.Button checknear;
        private System.Windows.Forms.TabPage distortiontab;
        public System.Windows.Forms.ComboBox distortionmap;
        private System.Windows.Forms.Label label27;
        public System.Windows.Forms.RichTextBox Distortiondisplay;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox DistortionSRs;
        public System.Windows.Forms.Button readalldisbutton;
        public System.Windows.Forms.Button createdis;
        private System.Windows.Forms.Button pastureteleport;
    }
}

