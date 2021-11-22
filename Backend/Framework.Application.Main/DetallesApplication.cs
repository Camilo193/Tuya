//asd
using AutoMapper;
using Framework.Application.DTO;
using Framework.Application.Interface;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Framework.Application.Main
{
    public class DetallesApplication : IDetallesApplication
    {
        #region Inyección de dependencias
        private readonly IDetallesDomain _detallesDomain;
        
        private readonly IMapper _mapper;

        public DetallesApplication(IDetallesDomain detallesDomain, IMapper iMapper)
        {
            _detallesDomain = detallesDomain;
            _mapper = iMapper;
        }
        #endregion

        public Response<bool> Insertar(DetallesDTO[] detalleDTO)
        {
            var response = new Response<bool>();
            try
            {
                var detalle = _mapper.Map<Detalles[]>(detalleDTO);
                response.Data = _detallesDomain.Insertar(detalle);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro ingresado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "No hay Stock suficiente en al menos un producto";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<bool> Actualizar(DetallesDTO detalleDTO)
        {
            var response = new Response<bool>();
            try
            {
                var detalle = _mapper.Map<Detalles>(detalleDTO);
                response.Data = _detallesDomain.Actualizar(detalle);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro actualizado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<bool> Eliminar(int Codigo)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _detallesDomain.Eliminar(Codigo);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro eliminado exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response<IEnumerable<DetallesDTO>> ObtenerTodos()
        {
            var response = new Response<IEnumerable<DetallesDTO>>();
            try
            {
                var detalle = _detallesDomain.ObtenerTodos();
                response.Data = _mapper.Map<IEnumerable<DetallesDTO>>(detalle);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }


        public Response<IEnumerable<DetallesDTO>> ObtenerPorCodigo(int Codigo)
        {
            var response = new Response<IEnumerable<DetallesDTO>>();
            try
            {
                var detalle = _detallesDomain.ObtenerPorCodigo(Codigo);
                response.Data = _mapper.Map<IEnumerable<DetallesDTO>>(detalle);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Valide la información ingresada por favor.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

    }
}
