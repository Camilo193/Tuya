using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Framework.Domain.Entity;
using Framework.InfraStructure.Data;
using Framework.InfraStructure.Interface;
using Framework.Transversal.Common;

namespace Framework.InfraStructure.Repository
{
    public class InformacionFacturasRepository : IInformacionFacturasRepository
    {

        private readonly EFConnectionFactory _EFConnectionFactory;
        private readonly IConnectionFactory _connectionFactory;

        public InformacionFacturasRepository(IConnectionFactory connectionFactory, EFConnectionFactory EFConnectionFactory)
        {
            _EFConnectionFactory = EFConnectionFactory;
            _connectionFactory = connectionFactory;
        }


        public bool Insertar(InformacionFacturas informacionFacturas)
        {

            using (var context = _EFConnectionFactory)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var Factura = informacionFacturas.Factura;
                    var ListaDetalles = informacionFacturas.Detalle.AsList<Detalles>();
                    try
                    {
                        context.Facturas.Add(Factura);
                        context.SaveChanges();

                        foreach (var producto in ListaDetalles)
                        {
                            var verificarStock = context.Productos.First(x => x.Codigo == producto.Producto && x.Stock >= producto.Cantidad);

                            context.Detalles.Add(producto);
                            context.SaveChanges();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}

