using Apresentacao.Api.ViewModel;
using EscolaDominio;
using EscolaInfra.Context;
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
    public class EscolaController : ApiController
    {
        private EscolaContexto db = new EscolaContexto();

        [HttpGet]
        // GET: api/Escola
        public List<EscolaApiViewModel> GetEscola()
        {
            List<EscolaApiViewModel> escolas = new List<EscolaApiViewModel>();
            foreach (var item in db.Escola)
            {
                escolas.Add(new EscolaApiViewModel
                {
                    NomeEscola = item.NomeEscola,
                    EscolaId = Convert.ToString(item.EscolaId)
                });
            }


            return escolas;

        }


        // GET: api/Escola/5
        [ResponseType(typeof(Escola))]
        public IHttpActionResult GetEscola(int id)
        {
            Escola escola = db.Escola.Find(id);
            if (escola == null)
            {
                return NotFound();
            }

            return Ok(escola);
        }

        // PUT: api/Escola/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEscola(int id, Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escola.EscolaId)
            {
                return BadRequest();
            }

            db.Entry(escola).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Escola
        [ResponseType(typeof(Escola))]
        public IHttpActionResult PostEscola(Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Escola.Add(escola);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = escola.EscolaId }, escola);
        }

        // DELETE: api/Escola/5
        [ResponseType(typeof(Escola))]
        public IHttpActionResult DeleteEscola(int id)
        {
            Escola escola = db.Escola.Find(id);
            if (escola == null)
            {
                return NotFound();
            }

            db.Escola.Remove(escola);
            db.SaveChanges();

            return Ok(escola);
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