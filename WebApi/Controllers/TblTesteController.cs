using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WebApi.Models;
using System.Web.Http.OData;

namespace WebApi.Controllers
{
    public class TblTesteController : ApiController
    {
        private DbEduqzContext db = new DbEduqzContext();

        //------------------------ MÉTODOS -------------------------   ****** FUNCIONA ******
        
        public IHttpActionResult GetAll() // CONSULTA GERAL
        {
            var entidades = from dados in db.tblTeste select dados;

            return Json(entidades.ToList<TblTeste>());
        }

        public IHttpActionResult GetId(int id) // CONSULTA POR ID
        {
            var entidade = db.tblTeste.Find(id);
            return Json(entidade);
        }

        public void Post([FromBody]TblTeste tblTeste) // CRIAR
        {
            db.tblTeste.Add(tblTeste);
            db.SaveChanges();
        }
 
        public void Patch(int id, Delta<TblTeste> tblTeste) // ATUALIZAR PATCH
        {
            var entidade = db.tblTeste.FirstOrDefault(x => x.id == id);

            if (entidade != null)
            {
                tblTeste.Patch(entidade);
                db.SaveChanges();
            }
        }

        public void Delete(int id) // DELETAR
        {
            var entidade = db.tblTeste.Find(id);
            db.tblTeste.Remove(entidade);
            db.SaveChanges();
        }

        /*public void Put(int id, [FromBody]TblTeste tblTeste) // ATUALIZAR - PUT EXEMPLO (não apagar)
        {
            var entidade = db.tblTeste.Find(id);

            entidade.nome = tblTeste.nome;
            entidade.sobrenome = tblTeste.sobrenome;
            entidade.apelido = tblTeste.apelido;

            db.SaveChanges();
        }*/
    }
}