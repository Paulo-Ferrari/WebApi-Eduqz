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
    public class TblRedacoesController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblRedacoes select dados;

            return Json(entidades.ToList<TblRedacoes>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblRedacoes.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblRedacoes tblRedacoes) // CRIAR
        {
            db.tblRedacoes.Add(tblRedacoes);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblRedacoes> tblRedacoes) // ATUALIZAR PATCH
        {
            var entidade = db.tblRedacoes.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblRedacoes.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblRedacoes.Find(id);
            db.tblRedacoes.Remove(entidade);
            db.SaveChanges();
        }
    }
}