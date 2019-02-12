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
    public class TblInstituicaoCursoController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   

        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblInstituicaoCurso select dados;

            return Json(entidades.ToList<TblInstituicaoCurso>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblInstituicaoCurso.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblInstituicaoCurso tblInstituicaoCurso) // CRIAR
        {
            db.tblInstituicaoCurso.Add(tblInstituicaoCurso);
            db.SaveChanges();
        }

        public void Patch(int id, Delta<TblInstituicaoCurso> tblInstituicaoCurso) // ATUALIZAR PATCH
        {
            var entidade = db.tblInstituicaoCurso.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblInstituicaoCurso.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblInstituicaoCurso.Find(id);
            db.tblInstituicaoCurso.Remove(entidade);
            db.SaveChanges();
        }
    }
}