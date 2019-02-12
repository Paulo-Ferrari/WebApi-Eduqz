using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
using System.Web.Http.OData;

namespace WebApi.Controllers
{
    public class TblConcursosCalendarioController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblConcursosCalendario select dados;

            return Json(entidades.ToList<TblConcursosCalendario>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblConcursosCalendario.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblConcursosCalendario tblConcursosCalendario) // CRIAR
        {
            db.tblConcursosCalendario.Add(tblConcursosCalendario);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblConcursosCalendario> tblConcursosCalendario) // ATUALIZAR PATCH
        {
            var entidade = db.tblConcursosCalendario.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblConcursosCalendario.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblConcursosCalendario.Find(id);
            db.tblConcursosCalendario.Remove(entidade);
            db.SaveChanges();
        }
    }
}