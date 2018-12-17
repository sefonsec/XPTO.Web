using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Xpto.Modelo
{
    public class Cliente
    {       
        public long Id { get; set; }

        public int IdArquivo { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [DisplayName("Sexo")]
        public string Sexo { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }    
    }
}
