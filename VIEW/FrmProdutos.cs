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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            FornecedorDAO f_dao = new FornecedorDAO();
            cbbforn.DataSource = f_dao.listarFornecedores();
            cbbforn.DisplayMember = "nome";
            cbbforn.ValueMember = "id";

            ProdutoDAO dao = new ProdutoDAO();  
            tabelaproduto.DataSource = dao.listarProdutos();
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //1 passo - Receber todos os dados da tela
            Produto obj = new Produto();

            obj.descricao = txtdesc.Text;
            obj.preco = decimal.Parse(txtpreco.Text);
            obj.qtdestoque = int.Parse(txtqtdest.Text);
            obj.for_id = int.Parse(cbbforn.SelectedValue.ToString());

            //2 passo - Criar o objeto DAO
            ProdutoDAO dao = new ProdutoDAO();
            dao.cadastrarProduto(obj);

            new Helpers().LimparTela(this);

            //3 passo - Recarregar o DataGridView com os dados dos produtos


        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
    }
}
