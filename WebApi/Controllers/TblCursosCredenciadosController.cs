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
    public class TblCursosCredenciadosController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblCursosCredenciados select dados;

            return Json(entidades.ToList<TblCursosCredenciados>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblCursosCredenciados.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblCursosCredenciados tblCursosCredenciados) // CRIAR
        {
            db.tblCursosCredenciados.Add(tblCursosCredenciados);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblCursosCredenciados> tblCursosCredenciados) // ATUALIZAR PATCH
        {
            var entidade = db.tblCursosCredenciados.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblCursosCredenciados.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblCursosCredenciados.Find(id);
            db.tblCursosCredenciados.Remove(entidade);
            db.SaveChanges();
        }
    }
}