using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ArchOr
{
    public partial class Form1 : Form
    {
        private string arquivoConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ConfigurarGrid();
            CarregarCaminhosSalvos();
        }

        private void SalvarCaminhos()
        {
            File.WriteAllLines(arquivoConfig, new string[] { txtOrigem.Text, txtDestino.Text });
        }

        private void CarregarCaminhosSalvos()
        {
            if (File.Exists(arquivoConfig))
            {
                string[] linhas = File.ReadAllLines(arquivoConfig);
                if (linhas.Length >= 2)
                {
                    txtOrigem.Text = linhas[0];
                    txtDestino.Text = linhas[1];

                    if (Directory.Exists(txtOrigem.Text))
                    {
                        CarregarImagensDaPasta(txtOrigem.Text);
                    }
                }
            }
        }

        private void ConfigurarGrid()
        {
            dgvImagens.Columns.Clear();

            DataGridViewTextBoxColumn colArquivo = new DataGridViewTextBoxColumn();
            colArquivo.Name = "colArquivo";
            colArquivo.HeaderText = "Arquivo";
            colArquivo.Width = 200;
            colArquivo.ReadOnly = true;
            dgvImagens.Columns.Add(colArquivo);

            DataGridViewComboBoxColumn colCategoria = new DataGridViewComboBoxColumn();
            colCategoria.Name = "colCategoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.Width = 180;
            colCategoria.Items.Add("CIQR");
            colCategoria.Items.Add("Nota de Exigencia");
            colCategoria.Items.Add("Documento de Arquivo");
            colCategoria.Items.Add("Titulo de Registro");
            dgvImagens.Columns.Add(colCategoria);
        }

        private void ChecarBotaoArquivar()
        {
            btnArquivar.Enabled = dgvImagens.Rows.Count > 0;
        }

        private void CarregarImagensDaPasta(string pasta)
        {
            dgvImagens.Rows.Clear();

            // Limpa o visualizador caso tenha alguma imagem velha
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }

            string[] todosArquivos = Directory.GetFiles(pasta);

            foreach (string arquivo in todosArquivos)
            {
                string extensao = Path.GetExtension(arquivo).ToLower();
                if (extensao == ".jpg" || extensao == ".jpeg" || extensao == ".png")
                {
                    string nomeArquivo = Path.GetFileName(arquivo);
                    int indiceLinha = dgvImagens.Rows.Add(nomeArquivo);
                    dgvImagens.Rows[indiceLinha].Tag = arquivo;
                }
            }
            ChecarBotaoArquivar();
        }

        // --- NOVO EVENTO: MOSTRAR IMAGEM AO CLICAR NA LISTA ---
        private void dgvImagens_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada e se ela contém o caminho salvo na Tag
            if (dgvImagens.CurrentRow != null && dgvImagens.CurrentRow.Tag != null)
            {
                string caminhoImagem = dgvImagens.CurrentRow.Tag.ToString();

                if (File.Exists(caminhoImagem))
                {
                    // Limpa a imagem anterior da memória
                    if (picPreview.Image != null)
                    {
                        picPreview.Image.Dispose();
                    }

                    // Carrega a imagem sem bloquear o arquivo original usando FileStream
                    using (FileStream fs = new FileStream(caminhoImagem, FileMode.Open, FileAccess.Read))
                    {
                        picPreview.Image = Image.FromStream(fs);
                    }
                }
            }
        }

        private void btnOrigem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtOrigem.Text = fbd.SelectedPath;
                    CarregarImagensDaPasta(fbd.SelectedPath);
                    SalvarCaminhos();
                }
            }
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestino.Text = fbd.SelectedPath;
                    SalvarCaminhos();
                }
            }
        }

        private void btnArquivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProtocolo.Text) || string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MessageBox.Show("Preencha o Protocolo e o Destino.");
                return;
            }

            string pastaDoProtocolo = Path.Combine(txtDestino.Text, txtProtocolo.Text);

            if (Directory.Exists(pastaDoProtocolo))
            {
                MessageBox.Show($"Atenção: A pasta do protocolo '{txtProtocolo.Text}' já existe no destino selecionado! O processo foi cancelado.",
                                "Protocolo já existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }

            Dictionary<string, int> contagemPorPasta = new Dictionary<string, int>();

            // NOVA LISTA: Guarda as linhas que foram arquivadas com sucesso
            List<DataGridViewRow> linhasProcessadas = new List<DataGridViewRow>();

            foreach (DataGridViewRow linha in dgvImagens.Rows)
            {
                if (linha.IsNewRow || linha.Tag == null) continue;

                string caminhoOriginal = linha.Tag.ToString();
                string categoriaEscolhida = linha.Cells["colCategoria"].Value?.ToString();

                // Se a categoria está em branco, PULA e não adiciona na lista de remoção
                if (string.IsNullOrWhiteSpace(categoriaEscolhida)) continue;

                string subPasta = Path.Combine(pastaDoProtocolo, categoriaEscolhida);
                if (!Directory.Exists(subPasta)) Directory.CreateDirectory(subPasta);

                if (!contagemPorPasta.ContainsKey(categoriaEscolhida))
                {
                    contagemPorPasta.Add(categoriaEscolhida, 1);
                }

                int numero = contagemPorPasta[categoriaEscolhida];
                string extensao = Path.GetExtension(caminhoOriginal);
                string novoNome = $"{categoriaEscolhida}({numero}){extensao}";
                string caminhoFinal = Path.Combine(subPasta, novoNome);

                File.Copy(caminhoOriginal, caminhoFinal, true);
                contagemPorPasta[categoriaEscolhida]++;

                // Marca esta linha específica para ser apagada da tela depois
                linhasProcessadas.Add(linha);
            }

            // Remove da interface visual apenas as imagens que foram para o destino
            foreach (DataGridViewRow linha in linhasProcessadas)
            {
                dgvImagens.Rows.Remove(linha);
            }

            MessageBox.Show("Arquivamento concluído com sucesso!");
            txtProtocolo.Clear();

            // A LINHA dgvImagens.Rows.Clear(); FOI REMOVIDA DAQUI

            ChecarBotaoArquivar();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Opcional: Muda a cor do link para indicar que já foi clicado
            linkLabel1.LinkVisited = true;

            // Substitua a URL abaixo pelo link do seu GitHub, LinkedIn ou portfólio
            string url = "https://github.com/iTzMeDieGoO";

            // Comando seguro para abrir links nas versões mais recentes do C# .NET
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}