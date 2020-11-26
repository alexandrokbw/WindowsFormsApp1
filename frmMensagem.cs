using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMensagem : Form
    {
        public frmMensagem()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        
        public string mensagem;
        private void frmMensagem_Load(object sender, EventArgs e)
        {
            timer1.Start();
            switch (mensagem)
            {
                case "Erro":
                    lblMensagem.Text = "Olve um erro!";
                    lblMensagem2.Text = "Avise o administrador!";
                    this.BackColor = Color.Red;
                    timer1.Stop();
                    break;

                case "Campo em branco":
                    lblMensagem.Text = "Há campos em branco!";
                    this.BackColor = Color.Yellow;
                    break;

                case "Salvar":
                    lblMensagem.Text = "Sucesso!";
                    lblMensagem2.Text = "Os dados foram salvos com sucesso!";
                    this.BackColor = Color.Green;
                    break;
                case "Atualizar":
                    lblMensagem.Text = "Dados atualizados!";
                    lblMensagem2.Text = "Os dados foram atualizados com sucesso!";
                    this.BackColor = Color.LightBlue;
                    break;
                case "Excluir":
                    lblMensagem.Text = "Excluido!";
                    lblMensagem2.Text = "Os dados foram excluidos com sucesso!";
                    this.BackColor = Color.LightGoldenrodYellow;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.50)
            {
                Opacity -= 0.05;
            }
            else
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
