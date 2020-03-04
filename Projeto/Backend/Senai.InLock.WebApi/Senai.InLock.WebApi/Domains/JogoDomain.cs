using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Obrigatório o nome do jogo")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "Obrigatória a descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório o valor")]
        public string Valor { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
    
    }
}
