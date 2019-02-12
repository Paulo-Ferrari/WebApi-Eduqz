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
    public class TblPeriodoEstudanteController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblPeriodoEstudante select dados;

            return Json(entidades.ToList<TblPeriodoEstudante>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblPeriodoEstudante.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblPeriodoEstudante tblPeriodoEstudante) // CRIAR
        {
            db.tblPeriodoEstudante.Add(tblPeriodoEstudante);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblPeriodoEstudante> tblPeriodoEstudante) // ATUALIZAR PATCH
        {
            var entidade = db.tblPeriodoEstudante.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblPeriodoEstudante.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblPeriodoEstudante.Find(id);
            db.tblPeriodoEstudante.Remove(entidade);
            db.SaveChanges();
        }
    }
}