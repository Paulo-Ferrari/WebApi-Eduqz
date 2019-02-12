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
    public class TblUsuariosController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblUsuarios select dados;

            return Json(entidades.ToList<TblUsuarios>());
        }

        public IHttpActionResult GetId(int id)  // CONSULTA POR ID
        {
            var entidade = db.tblUsuarios.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblUsuarios tblUsuarios) // CRIAR
        {
            db.tblUsuarios.Add(tblUsuarios);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblUsuarios> tblUsuarios) // ATUALIZAR PATCH
        {
            var entidade = db.tblUsuarios.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblUsuarios.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblUsuarios.Find(id);
            db.tblUsuarios.Remove(entidade);
            db.SaveChanges();
        }
    }
}