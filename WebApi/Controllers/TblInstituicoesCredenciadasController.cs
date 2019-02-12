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
    public class TblInstituicoesCredenciadasController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblInstituicoesCredenciadas select dados;

            return Json(entidades.ToList<TblInstituicoesCredenciadas>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblInstituicoesCredenciadas.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblInstituicoesCredenciadas tblInstituicoesCredenciadas) // CRIAR
        {
            db.tblInstituicoesCredenciadas.Add(tblInstituicoesCredenciadas);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblInstituicoesCredenciadas> tblInstituicoesCredenciadas) // ATUALIZAR PATCH
        {
            var entidade = db.tblInstituicoesCredenciadas.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblInstituicoesCredenciadas.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblInstituicoesCredenciadas.Find(id);
            db.tblInstituicoesCredenciadas.Remove(entidade);
            db.SaveChanges();
        }
    }
}