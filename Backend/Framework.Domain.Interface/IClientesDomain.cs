//Interfaz del dominio de la entidad Clientes
using Framework.Domain.Entity;
using System.Collections.Generic;


namespace Framework.Domain.Interface
{
    public interface IClientesDomain
    { 
        Clientes Autenticar(string Identificacion, string Clave);
        bool Insertar(Clientes Cliente);
        bool Actualizar(Clientes Cliente);
        bool Eliminar(string Identificacion);
        IEnumerable<Clientes>ObtenerTodos();
        IEnumerable<Clientes>ObtenerPorIdentificacion(string Identificacion);
    }
}