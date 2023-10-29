using MySql.Data.MySqlClient;
using Projeto_Controle_Vendas.CONEXAO;
using Projeto_Controle_Vendas.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_Vendas.DAO
{
    public class ProdutoDAO
    {
        private MySqlConnection conexao;
        public  ProdutoDAO() 
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método Cadastrar Produtos
        public void cadastrarProduto(Produto obj) 
        {
            try
            {
                //1 passo - Definir o comando sql - insert into 
                string sql = @"insert into tb_produtos (descricao, preco, qtd_estoque, for_id) 
                                values(@descricao, @preco, @qtd_estoque, @for_id)";

                //2 passo - Organizar e Executar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtd_estoque", obj.qtdestoque);
                executacmd.Parameters.AddWithValue("@for_id", obj.for_id);

                //3 passo - Abrir a conexão e executar o comando
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto Cadastrado com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " +erro);
            }
            
        
        
        }
        #endregion

        #region Método ListarProdutos
        public DataTable listarProdutos()
        {
            try
            {
                //1 passo - Criar o DataTable e o comando sql
                DataTable tableaproduto = new DataTable();
                string sql = @"select tb_produtos.id as 'Código', 
                                      tb_produtos.descricao as 'Descrição',
                                      tb_produtos.preco as 'Preço',
                                      tb_produtos.qtd_estoque as 'Qtd Estoque',
                                      tb_fornecedores.nome as 'Fornecedor' from tb_produtos 
                                      join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id);";

                //2 passo - Organizar o comando sql e executar 
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar o MySqlAdapter para preencher os dados do DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tableaproduto);

                //4 passo - fechar conexão
                conexao.Close();
                return tableaproduto;

            }
            catch (Exception)
            {

                throw;
            }
        
        } 
        #endregion
    }
}
