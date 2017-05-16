using Apresentacao.Api.ViewModel;
using EscolaDominio;
using EscolaInfra.Context;
using EscolaServico;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;


namespace Apresentacao.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AlunoController : ApiController
    {
        private EscolaContexto db = new EscolaContexto();
        private readonly AlunoServico _alunoServico = new AlunoServico();
        private readonly EscolaService _escolaServico = new EscolaService();
        private readonly EscolaAlunoServico _escolaAlunoServico = new EscolaAlunoServico();

        [HttpGet]
        // GET: api/Aluno
        public List<AlunoApiViewModel> GetAlunos()
        {
            List<AlunoApiViewModel> alunos = new List<AlunoApiViewModel>();

            var getAlunos = _alunoServico.ObterTodosLazyLoad();

            if (getAlunos.Count > 0)
            {

                foreach (var item in getAlunos)
                {
                    alunos.Add(new AlunoApiViewModel
                    {
                        AlunoId = Convert.ToString(item.AlunoId),
                        CPF = item.CPF,
                        Nome = item.Nome,
                        RG = item.RG,
                        dtNascimento = item.dtNascimento.ToString(),
                        Sobrenome = item.Sobrenome
                    });
                }  
            }

            return alunos;
        }


        // GET: api/Aluno/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult GetAluno(int id)
        {
            var aluno = _alunoServico.ObterPorId(id);
            var escolaAluno = _escolaAlunoServico.ObterTodosLazyLoad().Where(a => a.AlunoId == aluno.AlunoId).LastOrDefault();
            var escola = _escolaServico.ObterTodosLazyLoad().Where(c => c.EscolaId == escolaAluno.EscolaId).FirstOrDefault();

            var alunoNovo = new AlunoEscolaViewModel
            {
                AlunoId = aluno.AlunoId,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                CPF = aluno.CPF,
                RG = aluno.RG,
                dtNascimento = aluno.dtNascimento,
                NomeEscola = escola.NomeEscola
            };

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(alunoNovo);
        }

        // PUT: api/Aluno/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            db.Entry(aluno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            var escolaAluno = _escolaAlunoServico.ObterTodosLazyLoad().Where(a => a.AlunoId == aluno.AlunoId).FirstOrDefault();

            var alunoNovo = new AlunoEscolaViewModel
            {
                AlunoId = aluno.AlunoId,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                CPF = aluno.CPF,
                RG = aluno.RG,
                dtNascimento = aluno.dtNascimento,
                CodigoMatricula = escolaAluno.CodigoMatricula

            };

            return Ok(alunoNovo);
        }

        // POST: api/Aluno
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aluno.Add(aluno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Aluno/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult DeleteAluno(int id)
        {
            var aluno = _alunoServico.ObterPorIdLazyLoad(id);
            var escolaAluno = _escolaAlunoServico.ObterTodosLazyLoad().Where(a => a.AlunoId == id).FirstOrDefault();

            if (aluno == null)
            {
                return NotFound();
            }

            _escolaAlunoServico.Excluir(escolaAluno);
            _alunoServico.Excluir(aluno);
            db.SaveChanges();

            return Ok(aluno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}