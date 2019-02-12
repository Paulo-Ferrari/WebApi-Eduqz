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
    public class TblRedesController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblRedes select dados;

            return Json(entidades.ToList<TblRedes>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblRedes.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblRedes tblRedes) // CRIAR
        {
            db.tblRedes.Add(tblRedes);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblRedes> tblRedes) // ATUALIZAR PATCH
        {
            var entidade = db.tblRedes.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblRedes.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblRedes.Find(id);
            db.tblRedes.Remove(entidade);
            db.SaveChanges();
        }
    }
}