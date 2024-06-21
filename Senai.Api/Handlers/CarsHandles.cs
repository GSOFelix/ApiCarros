using Microsoft.EntityFrameworkCore;
using Senai.Api.Data;
using Senai.Core.Handler;
using Senai.Core.Models;
using Senai.Core.Requests.Cars;
using Senai.Core.Response;

namespace Senai.Api.Handlers
{
    public class CarsHandles(AppDbContext context) : ICarsHandler
    {
        public async Task<Response<Cars?>> CreateAsync(CreateCarsRequest request)
        {
            var cars = new Cars
            {
                UserId = request.UserId,
                Modelo = request.Modelo,
                Marca = request.Marca,
                Cor = request.Cor,
                Placa = request.Placa,
            };

            try
            {
                await context.Carros.AddAsync(cars);
                await context.SaveChangesAsync();

                return new Response<Cars?>(cars, "Carro criado com sucesso.", 200);
            }
            catch
            {
                return new Response<Cars?>(null, "erro ao criar carro.", 500);
            }


        }

        public async Task<Response<Cars?>> DeleteAsync(DeleteCarsRequest request)
        {
            try
            {
                var cars = await context.Carros.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);

                if (cars is null)
                {
                    return new Response<Cars?>(null, "Carro não encontrado", 400);
                }

                context.Carros.Remove(cars);
                await context.SaveChangesAsync();

                return new Response<Cars?>(cars, "Carro removido com sucesso.", 200);
            }
            catch
            {
                return new Response<Cars?>(null, "erro ao remover carro.", 500);
            }
        }

        public async Task<PagedResponse<List<Cars>?>> GetAllAsync(GetAllCarsRequest request)
        {
            try
            {
                var query = context
                    .Carros
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Marca);

                var cars = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Cars>?>(cars, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Cars>?>(null, 500, "Não foi possivel recuperar os carros.");
            }
        }

        public async Task<Response<Cars?>> GetByIdAsync(GetCarsByIdRequest request)
        {
            try
            {
                var car = await context.Carros.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);

                return car is null 
                    ? new Response<Cars?>(null, "Carro não encontrado", 400)
                    : new Response<Cars?>(car);
            }
            catch
            {
                return new Response<Cars?>(null, "erro ao localizar carro.", 500);
            }
        }

        public async Task<Response<Cars?>> UpdateAsync(UpdateCarsRequest request)
        {
            try
            {
                var car = await context.Carros.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);

                if (car is null)
                {
                    return new Response<Cars?>(null, "Carro não encontrado", 400);
                }

                car.Modelo = request.Modelo;
                car.Marca = request.Marca;
                car.Cor = request.Cor;
                car.Placa = request.Placa;

                context.Carros.Update(car);
                await context.SaveChangesAsync();

                return new Response<Cars?>(car, message: "Carro atualizado com sucesso");
            }
            catch
            {
                return new Response<Cars?>(null, "erro ao atualizar carro.", 500);
            }
        }
    }
}
