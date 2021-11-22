//Clase de dominio de la entidad Detalles 
using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class DetallesDomain : IDetallesDomain{

        private readonly IDetallesRepository _detallesRepository;

        public DetallesDomain(IDetallesRepository detallesRepository) => _detallesRepository = detallesRepository;

        public bool Insertar(Detalles[] detalle)
        {
            if (_detallesRepository.verificarStock(detalle))
            {
                return _detallesRepository.Insertar(detalle);
            }
            else {
                return false;
            }
        }

        public bool Actualizar(Detalles detalle)
        {
            return _detallesRepository.Actualizar(detalle);
        }

        public bool Eliminar(int Codigo)
        {
            return _detallesRepository.Eliminar(Codigo);
        }

        public IEnumerable<Detalles> ObtenerTodos()
        {
            return _detallesRepository.ObtenerTodos();
        }

                public IEnumerable<Detalles> ObtenerPorCodigo(int Codigo)
        {
            return _detallesRepository.ObtenerPorCodigo(Codigo);
        }
    }
}
