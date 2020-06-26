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
    public class SuplidoresBLL
    {
        
        private static bool Insertar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.suplidores.Add(suplidor);
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
        public static bool Modificar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
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
                var suplidor = contexto.suplidores.Find(id);

                if (suplidor != null)
                {
                    contexto.suplidores.Remove(suplidor);
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

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;

            try
            {
                suplidor = contexto.suplidores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.suplidores.Where(criterio).ToList();
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
                encontrado = contexto.suplidores.Any(e => e.SuplidorId == id);
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

        public static List<Suplidores> GetSuplidor()
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.suplidores.ToList();
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
