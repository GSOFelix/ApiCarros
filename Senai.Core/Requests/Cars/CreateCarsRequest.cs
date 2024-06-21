using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Core.Requests.Cars
{
    public class CreateCarsRequest : Request
    {

        [Required(ErrorMessage ="Marca invalida")]
        [MaxLength(80,ErrorMessage ="A Marca deve conter até 80 caracteres")]
        public string Marca {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Modelo invalida")]
        [MaxLength(80, ErrorMessage = "O modelo deve conter até 80 caracteres")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cor invalida")]
        [MaxLength(20, ErrorMessage = "A cor deve conter até 20 caracteres")]
        public string Cor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Placa invalida")]
        [MaxLength(7, ErrorMessage = "A placa deve conter até 7 caracteres")]
        public string Placa { get; set; } = string.Empty;



    }
}
