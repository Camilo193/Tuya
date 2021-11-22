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
    public class ClientesApplication : IClientesApplication
    {
        #region Inyección de dependencias
        private readonly IClientesDomain _clientesDomain;
        
        private readonly IMapper _mapper;

        public ClientesApplication(IClientesDomain clientesDomain, IMapper iMapper)
        {
            _clientesDomain = clientesDomain;
            _mapper = iMapper;
        }
        #endregion

        public Response<bool> Insertar(ClientesDTO clienteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var cliente = _mapper.Map<Clientes>(clienteDTO);
                response.Data = _clientesDomain.Insertar(cliente);
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
                response.Message = "Error: " + ex.InnerException;
            }

            return response;
        }

        public Response<bool> Actualizar(ClientesDTO clienteDTO)
        {
            var response = new Response<bool>();
            try
            {
                var cliente = _mapper.Map<Clientes>(clienteDTO);
                response.Data = _clientesDomain.Actualizar(cliente);
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

        public Response<bool> Eliminar(string Identificacion)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _clientesDomain.Eliminar(Identificacion);
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

        public Response<IEnumerable<ClientesDTO>> ObtenerTodos()
        {
            var response = new Response<IEnumerable<ClientesDTO>>();
            try
            {
                var cliente = _clientesDomain.ObtenerTodos();
                response.Data = _mapper.Map<IEnumerable<ClientesDTO>>(cliente);
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


        public Response<IEnumerable<ClientesDTO>> ObtenerPorIdentificacion(string Identificacion)
        {
            var response = new Response<IEnumerable<ClientesDTO>>();
            try
            {
                var cliente = _clientesDomain.ObtenerPorIdentificacion(Identificacion);
                response.Data = _mapper.Map<IEnumerable<ClientesDTO>>(cliente);
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

        public Response<ClientesDTO> Autenticar(string Identificacion, string Clave)
        {
            var response = new Response<ClientesDTO>();

            try
            {
                var cliente = _clientesDomain.Autenticar(Identificacion, Clave);
                response.Data = _mapper.Map<ClientesDTO>(cliente);

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
            catch (Exception ex) {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
