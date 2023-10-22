using Projeto_Controle_Vendas.DAO;
using Projeto_Controle_Vendas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.VIEW
{
    public partial class Frmclientes : Form
    {
        public Frmclientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            // 1 - receber os dados dentro do obj modelo de cliente
            Cliente obj = new Cliente();
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbbuf.SelectedItem.ToString();

            // 2 passo - Criar um objeto de classe ClienteDAO e chamar o metodo cadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            tabelaclientes.DataSource = dao.listarClientes();
        }

        //botao pesquisar
        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            string nome = txtpesquisa.Text;
            ClienteDAO dao = new ClienteDAO();

            tabelaclientes.DataSource = dao.BuscarClientePorNome(nome);

            if (tabelaclientes.Rows.Count == 0) 
            {
                tabelaclientes.DataSource = dao.listarClientes();
            }

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            // 1 - receber os dados dentro do obj modelo de cliente
            Cliente obj = new Cliente();
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbbuf.Text;

            obj.codigo = int.Parse(txtcodigo.Text);

            // 2 passo - Criar um objeto de classe ClienteDAO e chamar o metodo cadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.AlterarCliente(obj);

            tabelaclientes.DataSource = dao.listarClientes();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            obj.codigo = int.Parse(txtcodigo.Text);
            ClienteDAO dao = new ClienteDAO();
            dao.ExcluirCliente(obj);
            tabelaclientes.DataSource = dao.listarClientes();
        }

        private void tabelaclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = tabelaclientes.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaclientes.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaclientes.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaclientes.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaclientes.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaclientes.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaclientes.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaclientes.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaclientes.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaclientes.CurrentRow.Cells[9].Value.ToString();
            txtcomplemento.Text = tabelaclientes.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaclientes.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaclientes.CurrentRow.Cells[12].Value.ToString();
            cbbuf.Text = tabelaclientes.CurrentRow.Cells[13].Value.ToString();

        }

        private void tabelaclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = tabelaclientes.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaclientes.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaclientes.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaclientes.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaclientes.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaclientes.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaclientes.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaclientes.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaclientes.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaclientes.CurrentRow.Cells[9].Value.ToString();
            txtcomplemento.Text = tabelaclientes.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaclientes.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaclientes.CurrentRow.Cells[12].Value.ToString();
            cbbuf.Text = tabelaclientes.CurrentRow.Cells[13].Value.ToString();

            tbClientes.SelectedTab = tabPage1;
        }

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";
            ClienteDAO dao = new ClienteDAO();

            tabelaclientes.DataSource = dao.ListarClientePorNome(nome);

        }   

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        //botao consultar cep
        private void btncep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" +cep+ "/xml/";
                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbbuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show ("Endereço não encontrado, por favor preencha manualmente.");
            }
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void Frmclientes_Load(object sender, EventArgs e)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            tabelaclientes.DataSource = clienteDAO.listarClientes();
        }
    }
}
