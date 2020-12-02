namespace UMSAT_ET_v1._1
{
    partial class ClaseImagen
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStripFoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnGuardarFoto = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStripFoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.menuStripFoto;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 243);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStripFoto
            // 
            this.menuStripFoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardarFoto});
            this.menuStripFoto.Name = "menuStripFoto";
            this.menuStripFoto.Size = new System.Drawing.Size(144, 26);
            // 
            // btnGuardarFoto
            // 
            this.btnGuardarFoto.Name = "btnGuardarFoto";
            this.btnGuardarFoto.Size = new System.Drawing.Size(143, 22);
            this.btnGuardarFoto.Text = "Guardar Foto";
            this.btnGuardarFoto.Click += new System.EventHandler(this.btnGuardarFoto_Click);
            // 
            // ClaseImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 243);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ClaseImagen";
            this.Text = "ClaseImagen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStripFoto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip menuStripFoto;
        private System.Windows.Forms.ToolStripMenuItem btnGuardarFoto;
    }
}