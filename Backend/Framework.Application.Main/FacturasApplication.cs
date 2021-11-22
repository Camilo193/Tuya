using AutoMapper;
using Framework.Application.DTO;
using Framework.Application.Interface;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Main
{
    public class FacturasApplication : IFacturasApplication
    {
        #region Inyección de dependencias
        private readonly IFacturasDomain _facturasDomain;
        
        private readonly IMapper _mapper;

        public FacturasApplication(IFacturasDomain facturasDomain, IMapper iMapper)
        {
            _facturasDomain = facturasDomain;
            _mapper = iMapper;
        }
        #endregion

        public Response<bool> Insertar(FacturasDTO facturaDTO)
        {
            var response = new Response<bool>();
            try
            {
                var factura = _mapper.Map<Facturas>(facturaDTO);
                response.Data = _facturasDomain.Insertar(factura);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro ingresado exitosamente.";
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

        public Response<bool> Actualizar(FacturasDTO facturaDTO)
        {
            var response = new Response<bool>();
            try
            {
                var factura = _mapper.Map<Facturas>(facturaDTO);
                response.Data = _facturasDomain.Actualizar(factura);
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
                response.Data = _facturasDomain.Eliminar(Codigo);
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

        public Response<IEnumerable<FacturasDTO>> ObtenerTodos()
        {
            var response = new Response<IEnumerable<FacturasDTO>>();
            try
            {
                var factura = _facturasDomain.ObtenerTodos();
                response.Data = _mapper.Map<IEnumerable<FacturasDTO>>(factura);
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


        public Response<IEnumerable<FacturasDTO>> ObtenerPorCodigo(int Codigo)
        {
            var response = new Response<IEnumerable<FacturasDTO>>();
            try
            {
                var factura = _facturasDomain.ObtenerPorCodigo(Codigo);
                response.Data = _mapper.Map<IEnumerable<FacturasDTO>>(factura);
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

        public Response<dynamic> RecibirPedido(List<PedidosDTO> detalleDTO)
        {
            var response = new Response<dynamic>();
            try
            {
                response.Data = _facturasDomain.RecibirPedido(detalleDTO);

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

        public Response<dynamic> EnviarPedido(List<PedidosDTO> detalleDTO)
        {
            var response = new Response<dynamic>();
            try
            {
                response.Data = _facturasDomain.EnviarPedido(detalleDTO);

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

        //public Response<bool> InsertarFacturas(DetallesDTO detallesDTO)
        //{
        //    var response = new Response<bool>();
        //    try
        //    {
        //        var factura = _mapper.Map<Detalles>(detallesDTO);
        //        response.Data = _facturasDomain.InsertarFacturas(factura);
        //        if (response.Data)
        //        {
        //            response.IsSuccess = true;
        //            response.Message = "Registro ingresado exitosamente.";
        //        }
        //        else
        //        {
        //            response.IsSuccess = false;
        //            response.Message = "Valide la información ingresada por favor.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = "Error: " + ex.Message;
        //    }

        //    return response;
        //}


    }
}
