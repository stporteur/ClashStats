
namespace ClashStats
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leagueOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warriorOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warriorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letsPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.latestLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allLeaguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewWarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.latestWarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allWarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.latestGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scoreOptionsToolStripMenuItem,
            this.organizationToolStripMenuItem,
            this.letsPlayToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeScriptToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fileToolStripMenuItem.Text = "&Fichiers";
            // 
            // executeScriptToolStripMenuItem
            // 
            this.executeScriptToolStripMenuItem.Name = "executeScriptToolStripMenuItem";
            this.executeScriptToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.executeScriptToolStripMenuItem.Text = "Executer un script de mise à jour";
            this.executeScriptToolStripMenuItem.Click += new System.EventHandler(this.executeScriptToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.settingsToolStripMenuItem.Text = "&Paramètres";
            this.settingsToolStripMenuItem.Visible = false;
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.closeToolStripMenuItem.Text = "&Fermer";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // scoreOptionsToolStripMenuItem
            // 
            this.scoreOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leagueOptionsToolStripMenuItem,
            this.warriorOptionsToolStripMenuItem,
            this.simulationToolStripMenuItem});
            this.scoreOptionsToolStripMenuItem.Name = "scoreOptionsToolStripMenuItem";
            this.scoreOptionsToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.scoreOptionsToolStripMenuItem.Text = "&Paramètres de calcul";
            // 
            // leagueOptionsToolStripMenuItem
            // 
            this.leagueOptionsToolStripMenuItem.Name = "leagueOptionsToolStripMenuItem";
            this.leagueOptionsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.leagueOptionsToolStripMenuItem.Text = "&Ligue";
            this.leagueOptionsToolStripMenuItem.Click += new System.EventHandler(this.leagueOptionsToolStripMenuItem_Click);
            // 
            // warriorOptionsToolStripMenuItem
            // 
            this.warriorOptionsToolStripMenuItem.Name = "warriorOptionsToolStripMenuItem";
            this.warriorOptionsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.warriorOptionsToolStripMenuItem.Text = "&Guerrier";
            this.warriorOptionsToolStripMenuItem.Click += new System.EventHandler(this.warriorOptionsToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.simulationToolStripMenuItem.Text = "&Simulation";
            this.simulationToolStripMenuItem.Click += new System.EventHandler(this.simulationToolStripMenuItem_Click);
            // 
            // organizationToolStripMenuItem
            // 
            this.organizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clansToolStripMenuItem,
            this.warriorsToolStripMenuItem});
            this.organizationToolStripMenuItem.Name = "organizationToolStripMenuItem";
            this.organizationToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.organizationToolStripMenuItem.Text = "&Organisation";
            // 
            // clansToolStripMenuItem
            // 
            this.clansToolStripMenuItem.Name = "clansToolStripMenuItem";
            this.clansToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.clansToolStripMenuItem.Text = "&Clans";
            this.clansToolStripMenuItem.Click += new System.EventHandler(this.clansToolStripMenuItem_Click);
            // 
            // warriorsToolStripMenuItem
            // 
            this.warriorsToolStripMenuItem.Name = "warriorsToolStripMenuItem";
            this.warriorsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.warriorsToolStripMenuItem.Text = "&Guerriers";
            this.warriorsToolStripMenuItem.Click += new System.EventHandler(this.warriorsToolStripMenuItem_Click);
            // 
            // letsPlayToolStripMenuItem
            // 
            this.letsPlayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leaguesToolStripMenuItem,
            this.warToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.letsPlayToolStripMenuItem.Name = "letsPlayToolStripMenuItem";
            this.letsPlayToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.letsPlayToolStripMenuItem.Text = "A vos armes !";
            // 
            // leaguesToolStripMenuItem
            // 
            this.leaguesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewLeagueToolStripMenuItem,
            this.latestLeagueToolStripMenuItem,
            this.allLeaguesToolStripMenuItem});
            this.leaguesToolStripMenuItem.Name = "leaguesToolStripMenuItem";
            this.leaguesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.leaguesToolStripMenuItem.Text = "Les ligues";
            // 
            // startNewLeagueToolStripMenuItem
            // 
            this.startNewLeagueToolStripMenuItem.Name = "startNewLeagueToolStripMenuItem";
            this.startNewLeagueToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.startNewLeagueToolStripMenuItem.Text = "Commencer une ligue";
            this.startNewLeagueToolStripMenuItem.Click += new System.EventHandler(this.startNewLeagueToolStripMenuItem_Click);
            // 
            // latestLeagueToolStripMenuItem
            // 
            this.latestLeagueToolStripMenuItem.Name = "latestLeagueToolStripMenuItem";
            this.latestLeagueToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.latestLeagueToolStripMenuItem.Text = "Voir la ligue en cours";
            this.latestLeagueToolStripMenuItem.Click += new System.EventHandler(this.latestLeagueToolStripMenuItem_Click);
            // 
            // allLeaguesToolStripMenuItem
            // 
            this.allLeaguesToolStripMenuItem.Name = "allLeaguesToolStripMenuItem";
            this.allLeaguesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.allLeaguesToolStripMenuItem.Text = "Voir toutes les ligues";
            this.allLeaguesToolStripMenuItem.Visible = false;
            // 
            // warToolStripMenuItem
            // 
            this.warToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewWarToolStripMenuItem,
            this.latestWarToolStripMenuItem,
            this.allWarsToolStripMenuItem});
            this.warToolStripMenuItem.Name = "warToolStripMenuItem";
            this.warToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.warToolStripMenuItem.Text = "Les GDC";
            // 
            // startNewWarToolStripMenuItem
            // 
            this.startNewWarToolStripMenuItem.Name = "startNewWarToolStripMenuItem";
            this.startNewWarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.startNewWarToolStripMenuItem.Text = "Commencer une GDC";
            this.startNewWarToolStripMenuItem.Click += new System.EventHandler(this.startNewWarToolStripMenuItem_Click);
            // 
            // latestWarToolStripMenuItem
            // 
            this.latestWarToolStripMenuItem.Name = "latestWarToolStripMenuItem";
            this.latestWarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.latestWarToolStripMenuItem.Text = "Voir la dernière GDC";
            this.latestWarToolStripMenuItem.Click += new System.EventHandler(this.latestWarToolStripMenuItem_Click);
            // 
            // allWarsToolStripMenuItem
            // 
            this.allWarsToolStripMenuItem.Name = "allWarsToolStripMenuItem";
            this.allWarsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.allWarsToolStripMenuItem.Text = "Voir toutes les GDC";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGamesToolStripMenuItem,
            this.latestGamesToolStripMenuItem,
            this.allGamesToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gameToolStripMenuItem.Text = "Les Jeux";
            // 
            // startGamesToolStripMenuItem
            // 
            this.startGamesToolStripMenuItem.Name = "startGamesToolStripMenuItem";
            this.startGamesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.startGamesToolStripMenuItem.Text = "Commencer des jeux";
            this.startGamesToolStripMenuItem.Click += new System.EventHandler(this.startGamesToolStripMenuItem_Click);
            // 
            // latestGamesToolStripMenuItem
            // 
            this.latestGamesToolStripMenuItem.Name = "latestGamesToolStripMenuItem";
            this.latestGamesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.latestGamesToolStripMenuItem.Text = "Voir les derniers jeux";
            this.latestGamesToolStripMenuItem.Click += new System.EventHandler(this.latestGamesToolStripMenuItem_Click);
            // 
            // allGamesToolStripMenuItem
            // 
            this.allGamesToolStripMenuItem.Name = "allGamesToolStripMenuItem";
            this.allGamesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.allGamesToolStripMenuItem.Text = "Voir tous les jeux";
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 24);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(983, 560);
            this.containerPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 584);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Clash Stats";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoreOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leagueOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warriorOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.ToolStripMenuItem organizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warriorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem letsPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaguesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem latestLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allLeaguesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewWarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem latestWarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allWarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem latestGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeScriptToolStripMenuItem;
    }
}