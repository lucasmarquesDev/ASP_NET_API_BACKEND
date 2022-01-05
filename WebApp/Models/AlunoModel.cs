using App.Domain;
using App.Repository;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class AlunoModel
    {
        public List<AlunoDTO> listarAlunos(int? id = null)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                return alunoDB.listarAlunosDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
        }

        public void Inserir(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir Aluno: Erro => {ex.Message}");
            }
        }

        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();

                alunoDB.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Atualizar Aluno: Erro => {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var alunoDB = new AlunoDAO();

                alunoDB.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Deletar Aluno: Erro => {ex.Message}");
            }
        }
    }
}