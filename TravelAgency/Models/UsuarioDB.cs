using System.Collections.Generic;
using MySqlConnector;

namespace UC4_ATV2.Models
{
    public class UsuarioDB
    {
        private const string SqlConexao = "Database=CRUD_ATV2; Data Source=localhost; User Id=root";

        public Usuario TesteLogin(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM Usuario WHERE Login = @Login AND Senha = @Senha";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = null;

            if(Reader.Read())
            {
                UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
            }
            Conexao.Close();

            return UsuarioEncontrado;

        }
        public List<Usuario> ListarUser()
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM Usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

            while(Reader.Read())
            {
                Usuario UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                if(!Reader.IsDBNull(Reader.GetOrdinal("DataNascimento")))
                    UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
                
                Lista.Add(UsuarioEncontrado);
            }
            Conexao.Close();

            return Lista;
            
        }
        public void InserirUser(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "INSERT INTO Usuario (Nome, Login, Senha, DataNascimento) VALUES (@Nome, @Login, @Senha, @DataNascimento)";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public void AtualizarUser(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            Comando.Parameters.AddWithValue("@Id", usuario.Id);
            Comando.ExecuteNonQuery();

            Conexao.Close();

        }
        public void RemoverUser(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "DELETE FROM Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);
            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
        public Usuario BuscarPorIdUser(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(SqlConexao);
            Conexao.Open();
            string Query = "SELECT * FROM Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", Id);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();

            if(Reader.Read())
            {
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                if(!Reader.IsDBNull(Reader.GetOrdinal("DataNascimento")))
                    UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }
            Conexao.Close();
            return UsuarioEncontrado;
        }
    }
    
}