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
    public class TblLeadsEduqzController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblLeadsEduqz select dados;

            return Json(entidades.ToList<TblLeadsEduqz>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblLeadsEduqz.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblLeadsEduqz tblLeadsEduqz) // CRIAR
        {
            db.tblLeadsEduqz.Add(tblLeadsEduqz);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblLeadsEduqz> tblLeadsEduqz) // ATUALIZAR PATCH
        {
            var entidade = db.tblLeadsEduqz.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblLeadsEduqz.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblLeadsEduqz.Find(id);
            db.tblLeadsEduqz.Remove(entidade);
            db.SaveChanges();
        }
    }
}