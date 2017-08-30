namespace Treinador {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSeta = new System.Windows.Forms.Label();
            this.labelEsquerdoCounter = new System.Windows.Forms.Label();
            this.labelDireitoCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTerminado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonLado = new System.Windows.Forms.RadioButton();
            this.radioButtonAlternado = new System.Windows.Forms.RadioButton();
            this.radioButtonSimples = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDescanso = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelExercicio = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 839F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelExercicio, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 532F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1151, 780);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(305, 645);
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(833, 122);
            this.progressBar1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.labelSeta);
            this.panel1.Controls.Add(this.labelEsquerdoCounter);
            this.panel1.Controls.Add(this.labelDireitoCounter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(305, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 526);
            this.panel1.TabIndex = 21;
            // 
            // labelSeta
            // 
            this.labelSeta.BackColor = System.Drawing.Color.Transparent;
            this.labelSeta.Font = new System.Drawing.Font("Wingdings", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelSeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelSeta.Location = new System.Drawing.Point(342, 207);
            this.labelSeta.Name = "labelSeta";
            this.labelSeta.Size = new System.Drawing.Size(139, 132);
            this.labelSeta.TabIndex = 22;
            this.labelSeta.Text = "ç";
            this.labelSeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEsquerdoCounter
            // 
            this.labelEsquerdoCounter.AutoSize = true;
            this.labelEsquerdoCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelEsquerdoCounter.Font = new System.Drawing.Font("Segoe UI Black", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEsquerdoCounter.ForeColor = System.Drawing.Color.Yellow;
            this.labelEsquerdoCounter.Location = new System.Drawing.Point(-22, -18);
            this.labelEsquerdoCounter.Name = "labelEsquerdoCounter";
            this.labelEsquerdoCounter.Size = new System.Drawing.Size(578, 665);
            this.labelEsquerdoCounter.TabIndex = 21;
            this.labelEsquerdoCounter.Text = "0";
            this.labelEsquerdoCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDireitoCounter
            // 
            this.labelDireitoCounter.AutoSize = true;
            this.labelDireitoCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelDireitoCounter.Font = new System.Drawing.Font("Segoe UI Black", 300F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireitoCounter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDireitoCounter.Location = new System.Drawing.Point(425, -18);
            this.labelDireitoCounter.Name = "labelDireitoCounter";
            this.labelDireitoCounter.Size = new System.Drawing.Size(578, 665);
            this.labelDireitoCounter.TabIndex = 20;
            this.labelDireitoCounter.Text = "0";
            this.labelDireitoCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonTerminado, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 113);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(286, 526);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // buttonTerminado
            // 
            this.buttonTerminado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTerminado.Font = new System.Drawing.Font("Wingdings", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonTerminado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonTerminado.Location = new System.Drawing.Point(3, 410);
            this.buttonTerminado.Name = "buttonTerminado";
            this.buttonTerminado.Size = new System.Drawing.Size(280, 113);
            this.buttonTerminado.TabIndex = 26;
            this.buttonTerminado.Text = "ü";
            this.buttonTerminado.UseVisualStyleBackColor = true;
            this.buttonTerminado.Click += new System.EventHandler(this.buttonTerminado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonLado);
            this.groupBox1.Controls.Add(this.radioButtonAlternado);
            this.groupBox1.Controls.Add(this.radioButtonSimples);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 273);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Exercício";
            // 
            // radioButtonLado
            // 
            this.radioButtonLado.AutoSize = true;
            this.radioButtonLado.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioButtonLado.Location = new System.Drawing.Point(31, 176);
            this.radioButtonLado.Name = "radioButtonLado";
            this.radioButtonLado.Size = new System.Drawing.Size(247, 63);
            this.radioButtonLado.TabIndex = 2;
            this.radioButtonLado.Text = "Lado-Lado";
            this.radioButtonLado.UseVisualStyleBackColor = true;
            this.radioButtonLado.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonAlternado
            // 
            this.radioButtonAlternado.AutoSize = true;
            this.radioButtonAlternado.Checked = true;
            this.radioButtonAlternado.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAlternado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioButtonAlternado.Location = new System.Drawing.Point(31, 112);
            this.radioButtonAlternado.Name = "radioButtonAlternado";
            this.radioButtonAlternado.Size = new System.Drawing.Size(232, 63);
            this.radioButtonAlternado.TabIndex = 1;
            this.radioButtonAlternado.TabStop = true;
            this.radioButtonAlternado.Text = "Alternado";
            this.radioButtonAlternado.UseVisualStyleBackColor = true;
            this.radioButtonAlternado.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSimples
            // 
            this.radioButtonSimples.AutoSize = true;
            this.radioButtonSimples.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSimples.ForeColor = System.Drawing.Color.Navy;
            this.radioButtonSimples.Location = new System.Drawing.Point(31, 48);
            this.radioButtonSimples.Name = "radioButtonSimples";
            this.radioButtonSimples.Size = new System.Drawing.Size(191, 63);
            this.radioButtonSimples.TabIndex = 0;
            this.radioButtonSimples.Text = "Simples";
            this.radioButtonSimples.UseVisualStyleBackColor = true;
            this.radioButtonSimples.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.labelDescanso, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.trackBar1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 282);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(280, 122);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // labelDescanso
            // 
            this.labelDescanso.AutoSize = true;
            this.labelDescanso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescanso.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescanso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelDescanso.Location = new System.Drawing.Point(3, 0);
            this.labelDescanso.Name = "labelDescanso";
            this.labelDescanso.Size = new System.Drawing.Size(274, 61);
            this.labelDescanso.TabIndex = 21;
            this.labelDescanso.Text = "Descanso: 50s";
            this.labelDescanso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.GrayText;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(3, 64);
            this.trackBar1.Maximum = 60;
            this.trackBar1.Minimum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(274, 55);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 20;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Treinador.Properties.Resources.whistle_icon;
            this.pictureBox1.Location = new System.Drawing.Point(13, 645);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // labelExercicio
            // 
            this.labelExercicio.AutoSize = true;
            this.labelExercicio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this.labelExercicio, 2);
            this.labelExercicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExercicio.Font = new System.Drawing.Font("Segoe WP", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExercicio.ForeColor = System.Drawing.Color.DarkRed;
            this.labelExercicio.Location = new System.Drawing.Point(13, 10);
            this.labelExercicio.Name = "labelExercicio";
            this.labelExercicio.Size = new System.Drawing.Size(1125, 100);
            this.labelExercicio.TabIndex = 24;
            this.labelExercicio.Text = "Exercício";
            this.labelExercicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 59F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1151, 780);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.Name = "Form1";
            this.Text = "Treinador";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSeta;
        private System.Windows.Forms.Label labelEsquerdoCounter;
        private System.Windows.Forms.Label labelDireitoCounter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonTerminado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelDescanso;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelExercicio;
        public System.Windows.Forms.RadioButton radioButtonLado;
        public System.Windows.Forms.RadioButton radioButtonAlternado;
        public System.Windows.Forms.RadioButton radioButtonSimples;
    }
}

