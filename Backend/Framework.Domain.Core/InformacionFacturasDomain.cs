using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class InformacionFacturasDomain : IInformacionFacturasDomain
    {
        private readonly IInformacionFacturasRepository _informacionFacturasRepository;

        public InformacionFacturasDomain(IInformacionFacturasRepository informacionFacturasRepository) =>
            _informacionFacturasRepository = informacionFacturasRepository;

        public bool Insertar(InformacionFacturas informacionFacturas)
        {
            return _informacionFacturasRepository.Insertar(informacionFacturas);
        }

    }
}
