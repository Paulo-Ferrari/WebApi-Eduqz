//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUsuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string genero { get; set; }
        public Nullable<System.DateTime> data_nascimento { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string profissao { get; set; }
        public int periodo_id { get; set; }
        public int rede_id { get; set; }
        public int instituicao_id { get; set; }
        public int meta_universidade_id { get; set; }
        public int meta_curso_id { get; set; }
    }
}
