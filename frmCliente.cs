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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        frmMensagem mesagem;
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var context = new OficinaBDEntities();
            if (txtCodigo.Text=="")
            {

                var cliente = new tbCliente()
                {
                    nome = txtNome.Text,
                    telefone = txtTelefone.Text,
                    cpf = txtCPF.Text,
                    endereco = txtEndereco.Text,
                    cep = txtCep.Text,
                    cidade = txtCidade.Text,
                    estado = txtEstado.Text
                };
                context.tbCliente.Add(cliente);
                context.SaveChanges();

                mesagem = new frmMensagem();
                mesagem.mensagem = "Salvar"; 
            }
            else
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                tbCliente cliente = context.tbCliente.First(p => p.idCliente == codigo);

                cliente.nome = txtNome.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.cpf = txtCPF.Text;
                cliente.endereco = txtEndereco.Text;
                cliente.cep = txtCep.Text;
                cliente.cidade = txtCidade.Text;
                cliente.estado = txtEstado.Text;

                context.SaveChanges();
                mesagem = new frmMensagem();
                mesagem.mensagem = "Atualizar";
            }
            mesagem.Show();
            dtgCliente.DataSource = Todos;
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            dtgCliente.DataSource = Todos;
        }
        public virtual List<tbCliente> Todos
        {
            get
            {
                var context = new OficinaBDEntities();
                return context.tbCliente.ToList();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtCPF.Clear();
            txtEndereco.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text!="")
            {
                var context = new OficinaBDEntities();
                int codigo = Convert.ToInt32(txtCodigo.Text);
                tbCliente cliente = context.tbCliente.First(p => p.idCliente == codigo);

                context.tbCliente.Attach(cliente);
                context.Set<tbCliente>().Remove(cliente);
                context.SaveChanges();
            }
            mesagem = new frmMensagem();
            mesagem.mensagem = "Excluir";
            dtgCliente.DataSource = Todos;
            mesagem.Show();
        }


        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCPF.TextLength == 11)
                {
                    long CPF = Convert.ToInt64(txtCPF.Text);
                    string CPFFormatado = String.Format(@"{0:\000\.000\.000\-00}", CPF);
                    txtCPF.Text = CPFFormatado;
                }
            }
            catch (Exception)
            {
            }

        }

        private void dtgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgCliente.Rows[e.RowIndex].Cells["idCliente"].Value.ToString();
            txtNome.Text = dtgCliente.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txtTelefone.Text = dtgCliente.Rows[e.RowIndex].Cells["Telefone"].Value.ToString();
            txtCPF.Text = dtgCliente.Rows[e.RowIndex].Cells["CPF"].Value.ToString();
            txtEndereco.Text = dtgCliente.Rows[e.RowIndex].Cells["Endereco"].Value.ToString();
            txtCep.Text = dtgCliente.Rows[e.RowIndex].Cells["Cep"].Value.ToString();
            txtCidade.Text = dtgCliente.Rows[e.RowIndex].Cells["Cidade"].Value.ToString();
            txtEstado.Text = dtgCliente.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
        }




    }
}
