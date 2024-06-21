using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Core;
using Senai.Core.Handler;
using Senai.Core.Models;
using Senai.Core.Requests.Cars;
using Senai.Core.Response;

namespace Senai.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CarrosController: ControllerBase
    {
        private readonly ICarsHandler _carsHandler;

        public CarrosController(ICarsHandler carsHandler)
        {
            _carsHandler = carsHandler;
        }

        /// <summary>
        /// Cria um novo carro.
        /// </summary>
        /// <remarks>
        /// Exemplo de corpo da requisição:
        ///
        ///     POST /v1/Carros
        ///     {
        ///         "marca": "string",
        ///         "modelo": "string",
        ///         "cor": "string",
        ///         "placa": "string"
        ///     }
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Response<Cars>),200)]
        public async Task<IResult> CreateCar([FromBody] CreateCarsRequest request)
        {
            try
            {
                request.UserId = ApiConfigurations.DefautUserId;
                var response = await _carsHandler.CreateAsync(request);

                return response.IsSuccess
                    ? TypedResults.Created($"v1/Carros/{response.Data?.Id}", response)
                    : TypedResults.BadRequest(response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza dados de um carro.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Response<Cars>),200)]
        public async Task<IResult> UpdateCar(UpdateCarsRequest request,long id)
        {
            try
            {
                request.UserId = ApiConfigurations.DefautUserId;
                request.Id = id;

                var result = await _carsHandler.UpdateAsync(request);
                return result.IsSuccess
                    ? TypedResults.Ok(request)
                    : TypedResults.BadRequest(request);
            }
            catch(Exception ex) 
            {
                return TypedResults.BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um carro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Response<Cars>), 200)]
        public async Task<IResult> DeleteCar(long id)
        {
            var request = new DeleteCarsRequest
            {
                UserId = ApiConfigurations.DefautUserId,
                Id = id,
            };

            var result = await _carsHandler.DeleteAsync(request);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }

       /// <summary>
       /// Recupera todos os carros.
       /// </summary>
       /// <param name="pageNumber"></param>
       /// <param name="pagesize"></param>
       /// <returns></returns>
        [HttpGet]
        public async Task<IResult> GetAllCars(
            [FromQuery] int pageNumber = Configuration.DefautPageNumber,
            [FromQuery] int pagesize = Configuration.DefautPageSize)
        {
            var request = new GetAllCarsRequest
            {
                UserId = ApiConfigurations.DefautUserId,
                PageNumber = pageNumber,
                PageSize = pagesize
            };

            var result =  await _carsHandler.GetAllAsync(request);
            return result.IsSuccess
                ?TypedResults.Ok(result)
                :TypedResults.BadRequest(result);
        }
    }
}
