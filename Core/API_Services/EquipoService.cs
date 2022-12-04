using Domain.Data;
using Domain.DTOs.EquipoMedico;
using Domain.DTOs.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.API_Services
{
    public class EquipoService : IEquiposService
    {
        private ApplicationDbContext _dbContext;
        public EquipoService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Response<EquipoMedico>> DeleteEquipo(int id)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var entityResponse = await GetEquipo(id);
                if (!entityResponse.Success || entityResponse.Entity == null)
                {
                    return entityResponse;
                }
                var entity = (EquipoMedico)entityResponse.Entity;
                entity.Delete();

                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.DeleteEntity_ERROR;
                    return new Response<EquipoMedico>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.DeleteEntity_Ok;
                return new Response<EquipoMedico>(internalStatus, null, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<EquipoMedico>(internalStatus, null);
            }
        }

        public async Task<Response<EquipoMedico>> GetEquipo(int id)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var response = await _dbContext.EquiposMedicos.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
                if (response == null)
                {
                    internalStatus = InternalStatusCodes.GetEntity_ERROR;
                    return new Response<EquipoMedico>(internalStatus, new EquipoMedico());
                }
                internalStatus = InternalStatusCodes.GetEntity_Ok;
       
                return new Response<EquipoMedico>(internalStatus, response, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<EquipoMedico>(internalStatus, null);
            }
        }

        public async Task<Response<List<EquipoMedico>>> GetEquipos()
        {
            InternalStatusCodes internalStatus;
            try
            {
                var response = await _dbContext.EquiposMedicos.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
                if (response == null || response.Count() == 0)
                {
                    internalStatus = InternalStatusCodes.GetList_ERROR;
                    return new Response<List<EquipoMedico>>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.GetList_Ok;
                return new Response<List<EquipoMedico>>(internalStatus, response, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<List<EquipoMedico>>(internalStatus, null);
            }
        }

        public async Task<Response<EquipoMedico>> PostEquipo(EquipoMedicoDTO dto)
        {
            InternalStatusCodes internalStatus;
            try
            {

                EquipoMedico equipo = new EquipoMedico(dto);
                await _dbContext.EquiposMedicos.AddAsync(equipo);
                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<EquipoMedico>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.CreateEntity_Ok;
                return new Response<EquipoMedico>(internalStatus, equipo, equipo);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<EquipoMedico>(internalStatus, null);
            }
        }

        public async Task<Response<EquipoMedico>> PutEquipo(int id, EquipoMedicoDTO dto)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var entityResponse = await GetEquipo(id);
                if (!entityResponse.Success || entityResponse.Entity == null)
                {
                    return entityResponse;
                }

                var entity = (EquipoMedico)entityResponse.Entity;
                entity.Edit(dto);

                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.UpdateEntity_ERROR;
                    return new Response<EquipoMedico>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.UpdateEntity_Ok;
                return new Response<EquipoMedico>(internalStatus, entity, entity);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<EquipoMedico>(internalStatus, null);
            }
        }
    }
}
