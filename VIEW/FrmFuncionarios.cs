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
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void btncep_Click(object sender, EventArgs e)
        {

        }

        //Botão novo e usado para limpar todos os campos da tela de cadastro funcionários
        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        //Botão Salvar
        private void btnsalvar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();

            //Receber os dados dos campos
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.cargo = cbbcargo.SelectedItem.ToString();
            obj.email = txtemail.Text;
            obj.senha = txtsenha.Text; 
            obj.nivel_acesso = cbbnivel.SelectedItem.ToString();
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.complemento = txtcomplemento.Text;
            obj.numero = int.Parse (txtnumero.Text);
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbbuf.SelectedItem.ToString();

            //Criar o objeto FuncionarioDAO
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.CadastrarFuncionario (obj);

            //Recarregar o datagridview 
            tabelafuncionarios.DataSource = dao.listarFuncionarios();

        }

        //Botão Editar
        private void btneditar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();

            //Receber os dados dos campos
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.cargo = cbbcargo.SelectedItem.ToString();
            obj.email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.nivel_acesso = cbbnivel.SelectedItem.ToString();
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.complemento = txtcomplemento.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbbuf.SelectedItem.ToString();
            obj.codigo = int.Parse(txtcodigo.Text);

            //Criar o objeto FuncionarioDAO
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.alterarfuncionario(obj);

            //Recarregar o datagridview 
            tabelafuncionarios.DataSource = dao.listarFuncionarios();
        }

        //Botão Excluir
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();
            obj.codigo = int.Parse (txtcodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.excluirfuncionario (obj);

            //Recarregar o datagridview
            tabelafuncionarios.DataSource = dao.listarFuncionarios();
        }

        //Botão Pesquisar funcionários
        private void btnpesquisa_Click(object sender, EventArgs e)
        {
            string nome = txtpesquisa.Text;
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelafuncionarios.DataSource= dao.buscarFuncionariosPorNome(nome);
            if (tabelafuncionarios.Rows.Count == 0 || txtpesquisa.Text == string.Empty) 
            {
                MessageBox.Show("Funcionário não encontrado!");
                tabelafuncionarios.DataSource = dao.listarFuncionarios();
            }
        }
        
        //API buscar CEP
        private void btncep_Click_1(object sender, EventArgs e)
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

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            tabelafuncionarios.DataSource = funcionarioDAO.listarFuncionarios();
        }

        private void tabelafuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = tabelafuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelafuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelafuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelafuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelafuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = tabelafuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbbcargo.Text = tabelafuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbbnivel.Text = tabelafuncionarios.CurrentRow.Cells[7].Value.ToString();
            txttelefone.Text = tabelafuncionarios.CurrentRow.Cells[8].Value.ToString();
            txtcelular.Text = tabelafuncionarios.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = tabelafuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = tabelafuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtnumero.Text = tabelafuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtcomplemento.Text = tabelafuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtbairro.Text = tabelafuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtcidade.Text = tabelafuncionarios.CurrentRow.Cells[15].Value.ToString();
            cbbuf.Text = tabelafuncionarios.CurrentRow.Cells[16].Value.ToString();
            tabFuncionarios.SelectedTab = tabPage1;
        }

        //Pesquisa funcionário por aproximação usando % do método like
        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelafuncionarios.DataSource = dao.listarFuncionariosPorNome(nome);
        }
    }
}
