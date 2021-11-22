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
    public class InformacionFacturasApplication : IInformacionFacturasApplication
    {
       
        private readonly IInformacionFacturasDomain _informacionFacturasDomain;

        private readonly IMapper _mapper;

        public InformacionFacturasApplication(IInformacionFacturasDomain informacionFacturasDomain, IMapper iMapper)
        {
            _informacionFacturasDomain = informacionFacturasDomain;
            _mapper = iMapper;
        }

        public Response<bool> Insertar(InformacionFacturasDTO informacionFacturasDTO)
        {
            var response = new Response<bool>();
            try
            {
                var informacionFactura = _mapper.Map<InformacionFacturas>(informacionFacturasDTO);
                response.Data = _informacionFacturasDomain.Insertar(informacionFactura);
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
                response.Message = "Error: " + ex.InnerException;
            }

            return response;
        }
    }
}
