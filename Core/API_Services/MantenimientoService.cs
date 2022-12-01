using Domain.Data;
using Domain.DTOs.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.API_Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.API_Services
{
    public class MantenimientoService : IMantenimientoService
    {
        private ApplicationDbContext _dbContext;
        private IEquiposService _equiposService;
        public MantenimientoService(ApplicationDbContext context, IEquiposService equiposService)
        {
            _dbContext = context;
            _equiposService = equiposService;
        }
 


        public async Task<Response<Mantenimiento>> GetMantenimiento(int id)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var response = await _dbContext.Mantenimientos.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
                if (response == null)
                {
                    internalStatus = InternalStatusCodes.GetEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, new Mantenimiento());
                }
                internalStatus = InternalStatusCodes.GetEntity_Ok;

                return new Response<Mantenimiento>(internalStatus, response, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Mantenimiento>(internalStatus, null);
            }
        }

        public async Task<Response<List<Mantenimiento>>> GetMantenimientos()
        {
            InternalStatusCodes internalStatus;
            try
            {
                var response = await _dbContext.Mantenimientos.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
                if (response == null || response.Count() == 0)
                {
                    internalStatus = InternalStatusCodes.GetList_ERROR;
                    return new Response<List<Mantenimiento>>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.GetList_Ok;
                return new Response<List<Mantenimiento>>(internalStatus, response, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<List<Mantenimiento>>(internalStatus, null);
            }
        }

        public async Task<Response<Mantenimiento>> PostMantenimiento(int EquipoId, Mantenimiento mantenimiento)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var equipoResponse = await _equiposService.GetEquipo(EquipoId);
                if (!equipoResponse.Success || equipoResponse.Entity == null)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }

                
                mantenimiento.CreateEntity();
                equipoResponse.Result.Mantenimientos.Add(mantenimiento);
                mantenimiento.EquipoMedicoId = EquipoId;
                
                await _dbContext.Mantenimientos.AddAsync(mantenimiento);
                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.CreateEntity_Ok;
                return new Response<Mantenimiento>(internalStatus, mantenimiento, mantenimiento);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Mantenimiento>(internalStatus, null);
            }
        }

        public async Task<Response<Mantenimiento>> PutMantenimiento(int id, Mantenimiento mantenimiento)
        {
            {
                InternalStatusCodes internalStatus;
                try
                {
                    var entityResponse = await GetMantenimiento(id);
                    if (!entityResponse.Success || entityResponse.Entity == null)
                    {
                        return entityResponse;
                    }

                    var entity = (Mantenimiento)entityResponse.Entity;
                    entity.Edit(mantenimiento);

                    int response = await _dbContext.SaveChangesAsync();
                    if (response == 0)
                    {
                        internalStatus = InternalStatusCodes.UpdateEntity_ERROR;
                        return new Response<Mantenimiento>(internalStatus, null);
                    }
                    internalStatus = InternalStatusCodes.UpdateEntity_Ok;
                    return new Response<Mantenimiento>(internalStatus, mantenimiento, mantenimiento);
                }
                catch
                {
                    internalStatus = InternalStatusCodes.Unknown_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }
            }

        }
        public async Task<Response<Mantenimiento>> DeleteMantenimiento(int id)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var entityResponse = await GetMantenimiento(id);
                if (!entityResponse.Success || entityResponse.Entity == null)
                {
                    return entityResponse;
                }
                var entity = (Mantenimiento)entityResponse.Entity;
                entity.Delete();

                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.DeleteEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.DeleteEntity_Ok;
                return new Response<Mantenimiento>(internalStatus, null, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Mantenimiento>(internalStatus, null);
            }
        }
    }
}
