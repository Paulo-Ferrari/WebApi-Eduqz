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
    public class TblPerfilController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS ------------------------- 

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblPerfil select dados;

            return Json(entidades.ToList<TblPerfil>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblPerfil.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblPerfil tblPerfil) // CRIAR
        {
            db.tblPerfil.Add(tblPerfil);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblPerfil> tblPerfil) // ATUALIZAR PATCH
        {
            var entidade = db.tblPerfil.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblPerfil.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblPerfil.Find(id);
            db.tblPerfil.Remove(entidade);
            db.SaveChanges();
        }

    }
}