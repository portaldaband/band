using Apresentacao.Api.ViewModel;
using EscolaDominio;
using EscolaInfra.Context;
using EscolaServico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
namespace Apresentacao.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EscolaAlunoController : ApiController
    {
        private EscolaContexto db = new EscolaContexto();
        private readonly EscolaService _escolaServico = new EscolaService();
        private readonly EscolaAlunoServico _escolaAlunoServico = new EscolaAlunoServico();
        private readonly AlunoServico _alunoServico = new AlunoServico();


        [HttpGet]
        // GET: api/EscolaAluno
        public List<EscolaAlunoApiViewModel> GetEscolaAluno()
        {
            List<EscolaAlunoApiViewModel> escolaAluno = new List<EscolaAlunoApiViewModel>();
            foreach (var item in db.EscolaAluno)
            {
                escolaAluno.Add(new EscolaAlunoApiViewModel
                {
                    AlunoId = item.AlunoId.ToString(),
                    CodigoMatricula = item.CodigoMatricula,
                    EscolaId = item.EscolaId.ToString()
                });
            }
            return escolaAluno;

        }


        // GET: api/EscolaAluno/5
        [ResponseType(typeof(EscolaAlunoApiViewModel))]
        public IHttpActionResult GetEscolaAluno(int id)
        {
            EscolaAluno escolaAluno = db.EscolaAluno.Find(id);
            if (escolaAluno == null)
            {
                return NotFound();
            }

            return Ok(escolaAluno);
        }

        // PUT: api/EscolaAluno/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEscolaAluno(EscolaAluno escolaAluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            if (escolaAluno == null)
            {
                return BadRequest("Este aluno não esta associado a uma escola.");
            }


            if(db.Entry(escolaAluno).State == EntityState.Detached)
            db.EscolaAluno.Attach(escolaAluno);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            var escolaAlunoViewModel = new EscolaAlunoApiViewModel
            {
                AlunoId = escolaAluno.AlunoId.ToString(),
                EscolaId = escolaAluno.EscolaId.ToString(),
                CodigoMatricula = escolaAluno.CodigoMatricula
            };

            return Ok(escolaAlunoViewModel);
        }

        // POST: api/EscolaAluno
        [ResponseType(typeof(EscolaAluno))]
        public IHttpActionResult PostEscola(EscolaAluno escolaAluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EscolaAluno.Add(escolaAluno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { EscolaId = escolaAluno.EscolaId , AlunoId = escolaAluno .AlunoId}, escolaAluno);
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