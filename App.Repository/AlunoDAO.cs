using App.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    public class AlunoDAO
    {
        private string stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;

        public AlunoDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<AlunoDTO> listarAlunosDB(int? id = null)
        {
            try
            {
                var listaAlunos = new List<AlunoDTO>();

                IDbCommand cmd = conexao.CreateCommand();

                if (id == null)
                    cmd.CommandText = "Select *from Alunos";
                else
                    cmd.CommandText = $"Select *from Alunos where id = {id}";

                IDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    var alunoDb = new AlunoDTO
                    {
                        id = Convert.ToInt32(result["id"]),
                        nome = result["nome"].ToString(),
                        sobrenome = result["sobrenome"].ToString(),
                        telefone = result["telefone"].ToString(),
                        ra = Convert.ToInt32(result["ra"].ToString()),
                        data = result["data"].ToString()
                    };

                    listaAlunos.Add(alunoDb);
                }

                return listaAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void InserirAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand cmd = conexao.CreateCommand();
                cmd.CommandText = "Insert into Alunos (nome, sobrenome, telefone, ra, data) values (@nome, @sobrenome, @telefone, @ra, @data)";

                IDbDataParameter paramNome = new SqlParameter("@nome", aluno.nome);
                cmd.Parameters.Add(paramNome);

                IDbDataParameter paramSobrenome = new SqlParameter("@sobrenome", aluno.sobrenome);
                cmd.Parameters.Add(paramSobrenome);

                IDbDataParameter paramTelefone = new SqlParameter("@telefone", aluno.telefone);
                cmd.Parameters.Add(paramTelefone);

                IDbDataParameter paramRA = new SqlParameter("@ra", aluno.ra);
                cmd.Parameters.Add(paramRA);

                IDbDataParameter paramData = new SqlParameter("@data", aluno.data = "");
                cmd.Parameters.Add(paramData);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void AtualizarAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand cmd = conexao.CreateCommand();
                cmd.CommandText = "Update Alunos set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, ra = @ra, data = @data where id = @id";

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                IDbDataParameter paramRA = new SqlParameter("ra", aluno.ra);
                IDbDataParameter paramData = new SqlParameter("data", aluno.data);
                IDbDataParameter paramId = new SqlParameter("id", aluno.id);

                cmd.Parameters.Add(paramNome);
                cmd.Parameters.Add(paramSobrenome);
                cmd.Parameters.Add(paramTelefone);
                cmd.Parameters.Add(paramRA);
                cmd.Parameters.Add(paramData);
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand cmd = conexao.CreateCommand();
                cmd.CommandText = "Delete from Alunos where id = @id";

                IDbDataParameter paramId = new SqlParameter("id", id);

                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}