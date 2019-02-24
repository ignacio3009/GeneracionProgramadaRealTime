namespace GeneracionProgramadaRealTime
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarCarpetaDePoliticasYProgramasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarCentralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckedBoxCentrales = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarCarpetaDePoliticasYProgramasToolStripMenuItem,
            this.seleccionarCentralesToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // cambiarCarpetaDePoliticasYProgramasToolStripMenuItem
            // 
            this.cambiarCarpetaDePoliticasYProgramasToolStripMenuItem.Name = "cambiarCarpetaDePoliticasYProgramasToolStripMenuItem";
            this.cambiarCarpetaDePoliticasYProgramasToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.cambiarCarpetaDePoliticasYProgramasToolStripMenuItem.Text = "Cambiar Carpeta de Politicas y Programas";
            // 
            // seleccionarCentralesToolStripMenuItem
            // 
            this.seleccionarCentralesToolStripMenuItem.Name = "seleccionarCentralesToolStripMenuItem";
            this.seleccionarCentralesToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.seleccionarCentralesToolStripMenuItem.Text = "Seleccionar Centrales";
            // 
            // MainPanel
            // 
            this.MainPanel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainPanel.GridLines = true;
            this.MainPanel.Location = new System.Drawing.Point(0, 27);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(320, 388);
            this.MainPanel.TabIndex = 1;
            this.MainPanel.UseCompatibleStateImageBehavior = false;
            this.MainPanel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Central";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Gen Prog [MW]";
            this.columnHeader2.Width = 169;
            // 
            // CheckedBoxCentrales
            // 
            this.CheckedBoxCentrales.FormattingEnabled = true;
            this.CheckedBoxCentrales.Items.AddRange(new object[] {
            "Rapel",
            "Ralco",
            "ElToro",
            "Cipreses",
            "Pangue",
            "Canutillar",
            "Pehuenche",
            "Abanico",
            "Colbún"});
            this.CheckedBoxCentrales.Location = new System.Drawing.Point(326, 27);
            this.CheckedBoxCentrales.Name = "CheckedBoxCentrales";
            this.CheckedBoxCentrales.Size = new System.Drawing.Size(162, 379);
            this.CheckedBoxCentrales.TabIndex = 2;
            this.CheckedBoxCentrales.SelectedIndexChanged += new System.EventHandler(this.CheckedBoxCentrales_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 412);
            this.Controls.Add(this.CheckedBoxCentrales);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Generacion Programada CEN";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarCarpetaDePoliticasYProgramasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarCentralesToolStripMenuItem;
        private System.Windows.Forms.ListView MainPanel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckedListBox CheckedBoxCentrales;
    }
}

