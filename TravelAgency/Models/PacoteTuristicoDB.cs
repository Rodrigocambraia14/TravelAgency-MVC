using System.Collections.Generic;
using System;
using MySqlConnector;

namespace UC4_ATV2.Models
{
    public class PacoteTuristicoDB
    {
         private const string SqlConexao = "Database=CRUD_ATV2; Data Source=localhost; User Id=root";

         public void Inserir(PacoteTuristico pacoteTuristico)
         {
             MySqlConnection Conexao = new MySqlConnection(SqlConexao);
             Conexao.Open();
             string Query = "INSERT INTO PacoteTuristico (Nome, Origem, Destino, Atrativos, Saida, Retorno, Usuario) VALUES (@Nome, @Origem, @Destino, @Atrativos, @Saida, @Retorno, @Usuario)";

             MySqlCommand comando = new MySqlCommand(Query, Conexao);

             comando.Parameters.AddWithValue("@Nome", pacoteTuristico.Nome);
             comando.Parameters.AddWithValue("Origem", pacoteTuristico.Origem);
             comando.Parameters.AddWithValue("Destino", pacoteTuristico.Destino);
             comando.Parameters.AddWithValue("Atrativos", pacoteTuristico.Atrativos);
             comando.Parameters.AddWithValue("Saida", pacoteTuristico.Saida);
             comando.Parameters.AddWithValue("Retorno", pacoteTuristico.Retorno);
             comando.Parameters.AddWithValue("Usuario", pacoteTuristico.Usuario);
             comando.ExecuteNonQuery();

             Conexao.Close();
             
         }
         public List<PacoteTuristico> Listar()
         {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM PacoteTuristico";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacoteTuristico> ListaPacote = new List<PacoteTuristico>();

            while(Reader.Read())
            {
                PacoteTuristico PacoteAtual = new PacoteTuristico();
                PacoteAtual.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    PacoteAtual.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    PacoteAtual.Origem = Reader.GetString("Origem");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    PacoteAtual.Destino = Reader.GetString("Destino");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    PacoteAtual.Atrativos = Reader.GetString("Atrativos");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    PacoteAtual.Saida = Reader.GetDateTime("Saida");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Retorno")))
                    PacoteAtual.Retorno = Reader.GetDateTime("Retorno");

                PacoteAtual.Usuario = Reader.GetInt32("Usuario");
                
                ListaPacote.Add(PacoteAtual);
            }
            Conexao.Close();

            return ListaPacote;
         }
         public void Atualizar(PacoteTuristico pacoteTuristico)
         {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "UPDATE PacoteTuristico SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", pacoteTuristico.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacoteTuristico.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacoteTuristico.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacoteTuristico.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacoteTuristico.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacoteTuristico.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacoteTuristico.Usuario);
            Comando.Parameters.AddWithValue("@Id", pacoteTuristico.Id);
            Comando.ExecuteNonQuery();

            Conexao.Close();
         }
         public PacoteTuristico BuscarPorId(int Id)
         {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM PacoteTuristico WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);
            MySqlDataReader Reader = Comando.ExecuteReader();

            PacoteTuristico pacoteAtual = new PacoteTuristico();

             if(Reader.Read())
            {
                pacoteAtual.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    pacoteAtual.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pacoteAtual.Origem = Reader.GetString("Origem");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pacoteAtual.Destino = Reader.GetString("Destino");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pacoteAtual.Atrativos = Reader.GetString("Atrativos");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    pacoteAtual.Saida = Reader.GetDateTime("Saida");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Retorno")))
                    pacoteAtual.Saida = Reader.GetDateTime("Retorno");
                pacoteAtual.Usuario = Reader.GetInt32("Usuario");

            }
            Conexao.Close();

            return pacoteAtual;
 
         }
         public void Remover(int Id)
         {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "DELETE FROM PacoteTuristico WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);
            Comando.ExecuteNonQuery();

            Conexao.Close();
         }

    }
}