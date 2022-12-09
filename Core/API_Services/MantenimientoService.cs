using Domain.Data;
using Domain.DTOs.Mantenimiento;
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
                var response = await _dbContext.Mantenimientos
                    .Include(x => x.EquipoMedico)
                    .Where(x => x.IsActive == true && x.IsDeleted == false && x.EquipoMedico.IsActive==true && x.EquipoMedico.IsDeleted==false)
                    .Select(x => new Mantenimiento
                    {
                        Id = x.Id,
                        FechaDeMtto = x.FechaDeMtto,
                        TipoDeMtto = x.TipoDeMtto,
                        Observaciones = x.Observaciones,
                        Responsable = x.Responsable,
                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        EquipoMedicoId = x.EquipoMedicoId,
                        EquipoMedico = new EquipoMedico
                        {
                            Id = x.EquipoMedico.Id,
                            NombreDelEquipo = x.EquipoMedico.NombreDelEquipo,
                        }
                    })
                    .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
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
                var response = await _dbContext.Mantenimientos
                    .Include(x => x.EquipoMedico)
                    .Where(x => x.IsActive == true && x.IsDeleted == false && x.EquipoMedico.IsActive == true && x.EquipoMedico.IsDeleted == false)
                    .Select(x => new Mantenimiento
                    {
                        Id = x.Id,
                        FechaDeMtto = x.FechaDeMtto,
                        TipoDeMtto = x.TipoDeMtto,
                        Observaciones = x.Observaciones,
                        Responsable = x.Responsable,
                        EquipoMedicoId = x.EquipoMedicoId,
                        EquipoMedico = new EquipoMedico
                        {
                            Id = x.EquipoMedico.Id,
                            NombreDelEquipo = x.EquipoMedico.NombreDelEquipo,
                            NumDeIdentificacion= x.EquipoMedico.NumDeIdentificacion
                        }
                    })
                    .ToListAsync();
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

        public async Task<Response<Mantenimiento>> PostMantenimiento(int EquipoId, MantenimientoDTO dto)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var equipoResponse = await _equiposService.GetEquipo(EquipoId);
                if (equipoResponse == null || equipoResponse.Result == null || !equipoResponse.Success || equipoResponse.Entity == null)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }

                Mantenimiento mantenimiento = new Mantenimiento(dto);
                equipoResponse.Result.Mantenimientos.Add(mantenimiento);
                mantenimiento.EquipoMedicoId = EquipoId;

                await _dbContext.Mantenimientos.AddAsync(mantenimiento);
                int response = await _dbContext.SaveChangesAsync();
                if (response == 0)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }
                mantenimiento.EquipoMedico = new EquipoMedico
                {
                    Id = equipoResponse.Result.Id,
                    NombreDelEquipo = equipoResponse.Result.NombreDelEquipo,
                };
                internalStatus = InternalStatusCodes.CreateEntity_Ok;
                return new Response<Mantenimiento>(internalStatus, mantenimiento, mantenimiento);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Mantenimiento>(internalStatus, null);
            }
        }

        public async Task<Response<Mantenimiento>> PutMantenimiento(int id, MantenimientoDTO mantenimiento)
        {
            {
                InternalStatusCodes internalStatus;
                try
                {
                    var response = await _dbContext.Mantenimientos
                           .Include(x => x.EquipoMedico)
                            .FirstOrDefaultAsync(x => x.Id==id && x.IsActive == true && x.IsDeleted == false && x.EquipoMedico.IsActive == true && x.EquipoMedico.IsDeleted == false);


                    if (response == null)
                    {
                        internalStatus = InternalStatusCodes.GetEntity_ERROR;
                        return new Response<Mantenimiento>(internalStatus, new Mantenimiento());
                    }

                    var entity = response;
                    entity.Edit(mantenimiento);

                    int responsebf = await _dbContext.SaveChangesAsync();
                    entity.EquipoMedico.Mantenimientos = null;
                    if (responsebf == 0)
                    {
                        internalStatus = InternalStatusCodes.UpdateEntity_ERROR;
                        return new Response<Mantenimiento>(internalStatus, null);
                    }
                    internalStatus = InternalStatusCodes.UpdateEntity_Ok;
                    return new Response<Mantenimiento>(internalStatus, entity, entity);
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
                var response = await _dbContext.Mantenimientos
                           .Include(x => x.EquipoMedico)
                            .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false && x.EquipoMedico.IsActive == true && x.EquipoMedico.IsDeleted == false);


                if (response == null)
                {
                    internalStatus = InternalStatusCodes.GetEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, new Mantenimiento());
                }

                var entity = response;
                entity.Delete();

                int responsebf = await _dbContext.SaveChangesAsync();
                entity.EquipoMedico.Mantenimientos = null;
                if (responsebf == 0)
                {
                    internalStatus = InternalStatusCodes.DeleteEntity_ERROR;
                    return new Response<Mantenimiento>(internalStatus, null);
                }
                internalStatus = InternalStatusCodes.DeleteEntity_Ok;
                return new Response<Mantenimiento>(internalStatus, entity, entity);
            }
            catch
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<Mantenimiento>(internalStatus, null);
            }
        }
    }
}
