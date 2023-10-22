using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Controle_Vendas.CONEXAO
{
    public class ConnectionFactory
    {
        //metodo que conecta o banco de dados

        public MySqlConnection GetConnection()
        { 
            string conexao = ConfigurationManager.ConnectionStrings["projeto_vendas"].ConnectionString;
            return new MySqlConnection(conexao); 
        }
    }
}
