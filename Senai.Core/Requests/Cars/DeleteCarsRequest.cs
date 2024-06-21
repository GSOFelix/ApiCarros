using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Core.Requests.Cars
{
    public class DeleteCarsRequest : Request
    {

        public long Id { get; set; }



    }
}
