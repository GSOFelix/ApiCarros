using Senai.Core.Models;
using Senai.Core.Requests.Cars;
using Senai.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Core.Handler
{
    public interface ICarsHandler
    {
        Task<Response<Cars?>> CreateAsync(CreateCarsRequest request);
        Task<Response<Cars?>> UpdateAsync(UpdateCarsRequest request);
        Task<Response<Cars?>> DeleteAsync(DeleteCarsRequest request);
        Task<Response<Cars?>> GetByIdAsync(GetCarsByIdRequest request);
        Task<PagedResponse<List<Cars>?>> GetAllAsync(GetAllCarsRequest request); 
    }
}
