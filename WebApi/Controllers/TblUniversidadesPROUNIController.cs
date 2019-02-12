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
    public class TblUniversidadesPROUNIController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();
        
        //------------------------ MÉTODOS -------------------------

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblUniversidadesPROUNI select dados;

            return Json(entidades.ToList<TblUniversidadesPROUNI>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblUniversidadesPROUNI.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblUniversidadesPROUNI tblUniversidadesPROUNI) // CRIAR
        {
            db.tblUniversidadesPROUNI.Add(tblUniversidadesPROUNI);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblUniversidadesPROUNI> tblUniversidadesPROUNI) // ATUALIZAR PATCH
        {
            var entidade = db.tblUniversidadesPROUNI.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblUniversidadesPROUNI.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblUniversidadesPROUNI.Find(id);
            db.tblUniversidadesPROUNI.Remove(entidade);
            db.SaveChanges();
        }
    }
}