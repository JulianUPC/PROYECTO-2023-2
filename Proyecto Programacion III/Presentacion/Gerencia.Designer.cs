namespace Concesionario_J_M
{
    partial class Gerencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gerencia));
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Volver = new System.Windows.Forms.PictureBox();
            this.Btn_Informacion = new System.Windows.Forms.Button();
            this.Btn_Inventario = new System.Windows.Forms.Button();
            this.Btn_Finanzas = new System.Windows.Forms.Button();
            this.Btn_Ventas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Volver)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Volver";
            // 
            // Btn_Volver
            // 
            this.Btn_Volver.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Volver.Image")));
            this.Btn_Volver.Location = new System.Drawing.Point(451, 396);
            this.Btn_Volver.Name = "Btn_Volver";
            this.Btn_Volver.Size = new System.Drawing.Size(70, 60);
            this.Btn_Volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Volver.TabIndex = 12;
            this.Btn_Volver.TabStop = false;
            this.Btn_Volver.Click += new System.EventHandler(this.Btn_Volver_Click);
            // 
            // Btn_Informacion
            // 
            this.Btn_Informacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Informacion.BackgroundImage")));
            this.Btn_Informacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Informacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Informacion.Location = new System.Drawing.Point(13, 12);
            this.Btn_Informacion.Name = "Btn_Informacion";
            this.Btn_Informacion.Size = new System.Drawing.Size(227, 378);
            this.Btn_Informacion.TabIndex = 14;
            this.Btn_Informacion.UseVisualStyleBackColor = true;
            this.Btn_Informacion.Click += new System.EventHandler(this.Btn_Informacion_Click);
            // 
            // Btn_Inventario
            // 
            this.Btn_Inventario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Inventario.BackgroundImage")));
            this.Btn_Inventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Inventario.Location = new System.Drawing.Point(246, 12);
            this.Btn_Inventario.Name = "Btn_Inventario";
            this.Btn_Inventario.Size = new System.Drawing.Size(234, 378);
            this.Btn_Inventario.TabIndex = 15;
            this.Btn_Inventario.UseVisualStyleBackColor = true;
            this.Btn_Inventario.Click += new System.EventHandler(this.Btn_Inventario_Click);
            // 
            // Btn_Finanzas
            // 
            this.Btn_Finanzas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Finanzas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Finanzas.Location = new System.Drawing.Point(486, 12);
            this.Btn_Finanzas.Name = "Btn_Finanzas";
            this.Btn_Finanzas.Size = new System.Drawing.Size(234, 378);
            this.Btn_Finanzas.TabIndex = 16;
            this.Btn_Finanzas.Text = "Finanzas";
            this.Btn_Finanzas.UseVisualStyleBackColor = true;
            this.Btn_Finanzas.Click += new System.EventHandler(this.Btn_Finanzas_Click);
            // 
            // Btn_Ventas
            // 
            this.Btn_Ventas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Ventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ventas.Location = new System.Drawing.Point(726, 12);
            this.Btn_Ventas.Name = "Btn_Ventas";
            this.Btn_Ventas.Size = new System.Drawing.Size(234, 378);
            this.Btn_Ventas.TabIndex = 16;
            this.Btn_Ventas.Text = "Ventas";
            this.Btn_Ventas.UseVisualStyleBackColor = true;
            this.Btn_Ventas.Click += new System.EventHandler(this.Btn_Ventas_Click);
            // 
            // Gerencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(975, 455);
            this.Controls.Add(this.Btn_Ventas);
            this.Controls.Add(this.Btn_Finanzas);
            this.Controls.Add(this.Btn_Inventario);
            this.Controls.Add(this.Btn_Informacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Volver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gerencia";
            this.Text = "Gerencia";
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Volver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Btn_Volver;
        private System.Windows.Forms.Button Btn_Informacion;
        private System.Windows.Forms.Button Btn_Inventario;
        private System.Windows.Forms.Button Btn_Finanzas;
        private System.Windows.Forms.Button Btn_Ventas;
    }
}