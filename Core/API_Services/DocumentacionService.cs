using Domain.Data;
using Domain.DTOs.Documentacion;
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
    public class DocumentacionService : IDocumentacion
    {
        private ApplicationDbContext _dbContext;
        public DocumentacionService(ApplicationDbContext context)
        {
            _dbContext = context;
        }


        
        public async Task<Response<Documentacion>> DeleteDocumento(int id)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var entityResponse = await GetDocumento(id);
                if (!entityResponse.Success || entityResponse.Entity == null)
                {
                    return entityResponse;
                }
                var entity = (Documentacion)entityResponse.Entity;
                entity.Delete();

                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.DeleteEntity_ERROR;
                    return new Response<Documentacion>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.DeleteEntity_Ok;
                return new Response<Documentacion>(internalStatus, null, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Documentacion>(internalStatus, null);
            }
        }

        public async Task<Response<Documentacion>> GetDocumento(int id)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var response = await _dbContext.Documentacion.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
                if (response == null)
                {
                    internalStatus = InternalStatusCodes.GetEntity_ERROR;
                    return new Response<Documentacion>(internalStatus, new Documentacion());
                }
                internalStatus = InternalStatusCodes.GetEntity_Ok;

                return new Response<Documentacion>(internalStatus, response, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Documentacion>(internalStatus, null);
            }
        }

        public async Task<Response<List<Documentacion>>> GetDocumentos()
        {
            InternalStatusCodes internalStatus;
            try
            {
                var response = await _dbContext.Documentacion.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
                if (response == null || response.Count() == 0)
                {
                    internalStatus = InternalStatusCodes.GetList_ERROR;
                    return new Response<List<Documentacion>>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.GetList_Ok;
                return new Response<List<Documentacion>>(internalStatus, response, response);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<List<Documentacion>>(internalStatus, null);
            }
        }

        public async Task<Response<Documentacion>> PostDocumento(DocumentacionDTO dto)
        {
            InternalStatusCodes internalStatus;
            try
            {

                Documentacion equipo = new Documentacion(dto);
                await _dbContext.Documentacion.AddAsync(equipo);
                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<Documentacion>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.CreateEntity_Ok;
                return new Response<Documentacion>(internalStatus, equipo, equipo);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Documentacion>(internalStatus, null);
            }
        }
    }
}
