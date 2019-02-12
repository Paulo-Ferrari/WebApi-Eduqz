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
    public class TblUniversidadesSISUController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblUniversidadesSISU select dados;

            return Json(entidades.ToList<TblUniversidadesSISU>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblUniversidadesSISU.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblUniversidadesSISU tblUniversidadesSISU) // CRIAR
        {
            db.tblUniversidadesSISU.Add(tblUniversidadesSISU);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblUniversidadesSISU> tblUniversidadesSISU) // ATUALIZAR PATCH
        {
            var entidade = db.tblUniversidadesSISU.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblUniversidadesSISU.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblUniversidadesSISU.Find(id);
            db.tblUniversidadesSISU.Remove(entidade);
            db.SaveChanges();
        }
    }
}