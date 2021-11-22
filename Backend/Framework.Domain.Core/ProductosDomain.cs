//Clase de dominio de la entidad Productos 
using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class ProductosDomain : IProductosDomain{

        private readonly IProductosRepository _productosRepository;

        public ProductosDomain(IProductosRepository productosRepository) => _productosRepository = productosRepository;

        public bool Insertar(Productos producto)
        {
            return _productosRepository.Insertar(producto);
        }

        public bool Actualizar(Productos producto)
        {
            return _productosRepository.Actualizar(producto);
        }

        public bool Eliminar(int Codigo)
        {
            return _productosRepository.Eliminar(Codigo);
        }

        public IEnumerable<Productos> ObtenerTodos()
        {
            return _productosRepository.ObtenerTodos();
        }

                public IEnumerable<Productos> ObtenerPorCodigo(int Codigo)
        {
            return _productosRepository.ObtenerPorCodigo(Codigo);
        }
    }
}
