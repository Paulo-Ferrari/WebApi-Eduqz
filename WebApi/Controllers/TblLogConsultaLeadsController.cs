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
    public class TblLogConsultaLeadsController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblLogConsultaLeads select dados;

            return Json(entidades.ToList<TblLogConsultaLeads>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblLogConsultaLeads.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblLogConsultaLeads tblLogConsultaLeads) // CRIAR
        {
            db.tblLogConsultaLeads.Add(tblLogConsultaLeads);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblLogConsultaLeads> tblLogConsultaLeads) // ATUALIZAR PATCH
        {
            var entidade = db.tblLogConsultaLeads.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblLogConsultaLeads.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblLogConsultaLeads.Find(id);
            db.tblLogConsultaLeads.Remove(entidade);
            db.SaveChanges();
        }
    }
}