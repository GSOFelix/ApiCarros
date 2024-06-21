using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Core.Models
{
    public class Cars
    {
        public long Id { get; set; }

        public string Marca { get; set; } = string.Empty;

        public string Modelo { get; set; } = string.Empty;

        public string? Cor { get; set; }

        public string? Placa { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}
