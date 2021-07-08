using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCliente.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo nome é obrígatorio")]
        [MaxLength(80)]
        public string Nomes { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrígatorio")]
        [MaxLength(80)]
        public string Sobrenomes { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrígatorio")]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo teléfone é obrígatorio")]
        [MaxLength(50)]
        public string Telefone { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
