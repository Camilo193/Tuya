//Clase de dominio de la entidad Clientes 
using System.Collections.Generic;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;

namespace Framework.Domain.Core
{
    public class ClientesDomain : IClientesDomain{

        private readonly IClientesRepository _clientesRepository;

        public ClientesDomain(IClientesRepository clientesRepository) => _clientesRepository = clientesRepository;

        public bool Insertar(Clientes cliente)
        {
            return _clientesRepository.Insertar(cliente);
        }

        public bool Actualizar(Clientes cliente)
        {
            return _clientesRepository.Actualizar(cliente);
        }

        public bool Eliminar(string Identificacion)
        {
            return _clientesRepository.Eliminar(Identificacion);
        }

        public IEnumerable<Clientes> ObtenerTodos()
        {
            return _clientesRepository.ObtenerTodos();
        }

                public IEnumerable<Clientes> ObtenerPorIdentificacion(string Identificacion)
        {
            return _clientesRepository.ObtenerPorIdentificacion(Identificacion);
        }

        public Clientes Autenticar(string Identificacion, string Clave)
        {
            return _clientesRepository.Autenticar(Identificacion, Clave);
        }
    }
}
