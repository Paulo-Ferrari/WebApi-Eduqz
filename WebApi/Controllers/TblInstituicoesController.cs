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
    public class TblInstituicoesController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblInstituicoes select dados;

            return Json(entidades.ToList<TblInstituicoes>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblInstituicoes.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblInstituicoes tblInstituicoes) // CRIAR
        {
            db.tblInstituicoes.Add(tblInstituicoes);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblInstituicoes> tblInstituicoes) // ATUALIZAR PATCH
        {
            var entidade = db.tblInstituicoes.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblInstituicoes.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblInstituicoes.Find(id);
            db.tblInstituicoes.Remove(entidade);
            db.SaveChanges();
        }
    }
}