using Microsoft.EntityFrameworkCore;
using PedidosApp.DAL;
using PedidosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PedidosApp.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            if (!Existe(orden.OrdenId))
                return Insertar(orden);
            else
                return Modificar(orden);
        }

        private static bool Insertar(Ordenes orden)
        {
            Productos productos = new Productos();
            bool paso = false;
            Contexto contexto = new Contexto();
            OrdenDetalle ordenDetalle = new OrdenDetalle();
            
            try
            {

                foreach (var item in orden.ordenDetalles)
                {
                   /* var producto = contexto.productos.Find(item.ProductoId);
                    if (producto != null)
                    {
                        
                        contexto.productos.Find(item.ProductoId).Inventario -= item.Cantidad;
                    }*/
                    contexto.ordenes.Add(orden);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Ordenes orden)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(orden.OrdenId);
            try
            {

                foreach (var item in anterior.ordenDetalles)
                {
                    var aux = contexto.productos.Find(item.ProductoId);
                    if (!orden.ordenDetalles.Exists(d => d.OrdenId == item.OrdenId))
                    {
                        if (aux != null)
                        {
                            aux.Inventario += item.Cantidad;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in orden.ordenDetalles)
                {

                    var aux = contexto.productos.Find(item.ProductoId);
                    if (item.OrdenId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (aux != null)
                        {
                            aux.Inventario -= item.Cantidad;
                        }

                    }
                    else

                        contexto.Entry(item).State = EntityState.Modified;



                }
                contexto.Entry(orden).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var envio = contexto.ordenes.Find(id);

                if (envio != null)
                {
                    contexto.ordenes.Remove(envio);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes orden;

            try
            {
                orden = contexto.ordenes.Where(e => e.OrdenId == id).Include(e => e.ordenDetalles).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return orden;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.ordenes.Any(e => e.OrdenId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Ordenes> GetOrden()
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.ordenes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;

        }
    }
}
