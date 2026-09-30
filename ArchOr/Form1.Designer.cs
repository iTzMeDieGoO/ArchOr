namespace ArchOr
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtOrigem = new Button();
            txtDestino = new Button();
            btnArquivar = new Button();
            txtProtocolo = new TextBox();
            dgvImagens = new DataGridView();
            colArquivo = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewComboBoxColumn();
            label1 = new Label();
            picPreview = new PictureBox();
            linkLabel1 = new LinkLabel();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvImagens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // txtOrigem
            // 
            txtOrigem.Location = new Point(173, 322);
            txtOrigem.Name = "txtOrigem";
            txtOrigem.Size = new Size(145, 23);
            txtOrigem.TabIndex = 0;
            txtOrigem.Text = "Origem";
            txtOrigem.UseVisualStyleBackColor = true;
            txtOrigem.Click += btnOrigem_Click;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(12, 322);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(155, 23);
            txtDestino.TabIndex = 1;
            txtDestino.Text = "Destino";
            txtDestino.UseVisualStyleBackColor = true;
            txtDestino.Click += btnDestino_Click;
            // 
            // btnArquivar
            // 
            btnArquivar.Location = new Point(324, 322);
            btnArquivar.Name = "btnArquivar";
            btnArquivar.Size = new Size(95, 23);
            btnArquivar.TabIndex = 2;
            btnArquivar.Text = "Arquivar";
            btnArquivar.UseVisualStyleBackColor = true;
            btnArquivar.Click += btnArquivar_Click;
            // 
            // txtProtocolo
            // 
            txtProtocolo.Location = new Point(163, 11);
            txtProtocolo.Name = "txtProtocolo";
            txtProtocolo.Size = new Size(138, 23);
            txtProtocolo.TabIndex = 5;
            // 
            // dgvImagens
            // 
            dgvImagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImagens.Columns.AddRange(new DataGridViewColumn[] { colArquivo, colCategoria });
            dgvImagens.Location = new Point(12, 44);
            dgvImagens.Name = "dgvImagens";
            dgvImagens.Size = new Size(407, 272);
            dgvImagens.TabIndex = 6;
            dgvImagens.SelectionChanged += dgvImagens_SelectionChanged;
            // 
            // colArquivo
            // 
            colArquivo.HeaderText = "Arquivo";
            colArquivo.Name = "colArquivo";
            colArquivo.ReadOnly = true;
            colArquivo.Visible = false;
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoria";
            colCategoria.Name = "colCategoria";
            colCategoria.Resizable = DataGridViewTriState.True;
            colCategoria.SortMode = DataGridViewColumnSortMode.Automatic;
            colCategoria.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(145, 19);
            label1.TabIndex = 7;
            label1.Text = "Número do Protocolo:";
            // 
            // picPreview
            // 
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(425, 44);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(195, 272);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 8;
            picPreview.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(453, 326);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(167, 15);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Desenvolvido por Diego Souza";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.Logotipo_ArchOr_removebg_preview;
            picLogo.Location = new Point(425, -58);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(207, 165);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 355);
            Controls.Add(picPreview);
            Controls.Add(picLogo);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(dgvImagens);
            Controls.Add(txtProtocolo);
            Controls.Add(btnArquivar);
            Controls.Add(txtDestino);
            Controls.Add(txtOrigem);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "ArchOr - Organizador de Arquivos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvImagens).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button txtOrigem;
        private Button txtDestino;
        private Button btnArquivar;
        private TextBox txtProtocolo;
        private DataGridView dgvImagens;
        private DataGridViewTextBoxColumn colArquivo;
        private DataGridViewComboBoxColumn colCategoria;
        private Label label1;
        private PictureBox picPreview;
        private LinkLabel linkLabel1;
        private PictureBox picLogo;
    }
}
