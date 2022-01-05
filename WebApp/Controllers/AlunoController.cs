using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Recuperar")]
        [Authorize(Roles = Funcao.Professor)]
        public IHttpActionResult Recuperar()
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                return Ok(aluno.listarAlunos());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Recuperar/{id:int}/{nome?}/{sobrenome?}")]
        public AlunoDTO Get(int id, string nome = null, string sobrenome = null)
        {
            AlunoModel aluno = new AlunoModel();

            return aluno.listarAlunos(id).FirstOrDefault();
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}")]
        public IHttpActionResult Recuperar(string data, string nome)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                IEnumerable<AlunoDTO> alunos = aluno.listarAlunos().Where(x => x.data == data || x.nome == nome);

                if (alunos.Any())
                    return NotFound();
                else
                    return Ok(alunos);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // POST: api/Aluno
        [HttpPost]
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                AlunoModel _alunos = new AlunoModel();

                _alunos.Inserir(aluno);

                return Ok(_alunos.listarAlunos());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Aluno/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                aluno.id = id;

                _aluno.Atualizar(aluno);

                return Ok(_aluno.listarAlunos(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Aluno/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Deletar(id);

                return Ok("Deletado com sucesso !");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
