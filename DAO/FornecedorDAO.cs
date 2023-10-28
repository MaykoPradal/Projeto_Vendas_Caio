﻿using MySql.Data.MySqlClient;
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
    public class FornecedorDAO
    {
        private MySqlConnection conexao;

        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region Método cadastrar fornecedor
        public void cadastrarFornecedor(Fornecedor obj)
        {
            try
            { //1 passo - definir o comando sql - insert into 
                string sql = @"insert into tb_fornecedores (nome, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)" + 
                    "values (@nome, @cnpj, @email, @telefone, @celular, @cep , @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2 passo - organizar o comando sql 
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                // 3 - abrir a conexao e executar o comando sql 
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor Cadastrado com Sucesso!");
                //fechar conexão
                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro " + erro);
            }
        
        
        }



        #endregion

        #region Listar todos fornecedores
        public DataTable listarFornecedores()
        {
            
            {
                try
                {
                    //1 passo - criar o DataTable e o comando sql
                    DataTable tabelafornecedores = new DataTable();
                    string sql = "select * from tb_fornecedores";

                    //2 passo - Organizar o comando sql e executar
                    MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                    conexao.Open();
                    executacmd.ExecuteNonQuery();

                    //3 passo - Criar o MySqlAdapter para preencher os dados do DataTable
                    MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                    da.Fill(tabelafornecedores);

                    //4 passo - Fechar conexão
                    conexao.Close();

                    return tabelafornecedores;

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Erro ao executar o comando sql: " + erro);
                    return null;
                }


            }
        }

        #endregion

        #region método para alterar um fornecedor
        public void alterarFornecedor(Fornecedor obj) 
        {
            try
            {
                //1 passo - é criar o comando sql 
                string sql = @"update tb_fornecedores set nome = @nome, cnpj = @cnpj, email = @email, telefone = @telefone, celular = @celular, cep = @cep, endereco = @endereco, 
                                            numero = @numero, complemento = @complemento , bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";

                //2 passo - organizar e executar sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Dados alterados com sucesso");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        
        
        }


        #endregion

        #region método para excluir fornecedor
        public void excluirFornecedor(Fornecedor obj) 
        {

            try
            {
                //1 passo - É criar o comando sql 
                string sql = @"delete from tb_fornecedores where id = @id";

                //2 passo - É organizar e executar o comando sql 
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Fornecedor excluido com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion
    }
}
