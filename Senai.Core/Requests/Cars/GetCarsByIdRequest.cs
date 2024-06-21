using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Core.Requests.Cars
{
    public class GetCarsByIdRequest : Request
    {

        public int Id { get; set; }

    }
}
