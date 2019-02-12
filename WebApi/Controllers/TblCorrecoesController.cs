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
    public class TblCorrecoesController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblCorrecoes select dados;

            return Json(entidades.ToList<TblCorrecoes>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblCorrecoes.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblCorrecoes tblCorrecoes) // CRIAR
        {
            db.tblCorrecoes.Add(tblCorrecoes);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblCorrecoes> tblCorrecoes) // ATUALIZAR PATCH
        {
            var entidade = db.tblCorrecoes.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblCorrecoes.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblCorrecoes.Find(id);
            db.tblCorrecoes.Remove(entidade);
            db.SaveChanges();
        }
    }
}