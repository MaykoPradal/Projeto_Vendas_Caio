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
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        //API Buscar CEP
        private void btncep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";
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

                MessageBox.Show("Endereço não encontrado, por favor preencha manualmente.");
            }
        }

        //Botão novo e usado para limpar todos os campos da tela de cadastro fornecedores
        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        //Botão salvar fornecedor
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();
            obj.nome = txtnome.Text;
            obj.email = txtemail.Text;
            obj.cnpj = txtcnpj.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text; 
            obj.estado = cbbuf.Text;

            //Criar o obj da Classe FornecedorDAO
            FornecedorDAO dao = new FornecedorDAO();
            dao.cadastrarFornecedor(obj);

            //Carregar o DataGridView de fornecedor
            tabelaFornecedores.DataSource = dao.listarFornecedores();
            new Helpers().LimparTela(this);

        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            //listar todos os fornecedores
            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.listarFornecedores();
        }

        private void tabelaFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //pegar dados das linhas selecionadas
            txtcodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = tabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = tabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
            txttelefone.Text = tabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtcelular.Text = tabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtcep.Text = tabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtendereco.Text = tabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtnumero.Text = tabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtcomplemento.Text = tabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = tabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtcidade.Text = tabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
            cbbuf.Text = tabelaFornecedores.CurrentRow.Cells[12].Value.ToString();

            tbFornecedores.SelectedTab = tabPage1;
        }

        //Botão alterar 
        private void btneditar_Click(object sender, EventArgs e)
        {
            
            Fornecedor obj = new Fornecedor();
            obj.nome = txtnome.Text;
            obj.email = txtemail.Text;
            obj.cnpj = txtcnpj.Text;
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

            //Criar o obj da Classe FornecedorDAO
            FornecedorDAO dao = new FornecedorDAO();
            dao.alterarFornecedor(obj);

            //Carregar o DataGridView de fornecedor
            tabelaFornecedores.DataSource = dao.listarFornecedores();

            new Helpers().LimparTela(this);
        }

        //Botão excluir 
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();
            obj.codigo = int.Parse(txtcodigo.Text);

            //Criar o obj da Classe FornecedorDAO
            FornecedorDAO dao = new FornecedorDAO();
            dao.excluirFornecedor(obj);

            //Carregar o DataGridView de fornecedor
            tabelaFornecedores.DataSource = dao.listarFornecedores();

            new Helpers().LimparTela(this);
        }
    }
}
