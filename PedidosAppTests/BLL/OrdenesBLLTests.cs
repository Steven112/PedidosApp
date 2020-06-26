using Microsoft.VisualStudio.TestTools.UnitTesting;
using PedidosApp.BLL;
using PedidosApp.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace PedidosApp.BLL.Tests
{
    [TestClass()]
    public class OrdenesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
           
            bool paso = false;
            OrdenDetalle ordenDetalle  = new OrdenDetalle(1, 1, 1,1, Convert.ToDecimal(100.00));
            List<OrdenDetalle> list = new List<OrdenDetalle>();
            list.Add(ordenDetalle);
            Ordenes ordenes = new Ordenes();
            ordenes.OrdenId = 3;
            ordenes.Fecha = DateTime.Now;
            ordenes.SuplidorId = 1;
            ordenes.Monto = Convert.ToDecimal(100.00);
            paso = OrdenesBLL.Guardar(ordenes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            OrdenDetalle ordenDetalle = new OrdenDetalle(1, 1, 1, 2, Convert.ToDecimal(100.00));
            List<OrdenDetalle> list = new List<OrdenDetalle>();
            list.Add(ordenDetalle);
            Ordenes ordenes = new Ordenes();
            ordenes.OrdenId = 5;
            ordenes.Fecha = DateTime.Now;
            ordenes.SuplidorId = 1;
            ordenes.Monto = Convert.ToInt32(250.00);
            paso = OrdenesBLL.Guardar(ordenes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = OrdenesBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = OrdenesBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Ordenes> lista = new List<Ordenes>();
            lista = OrdenesBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = OrdenesBLL.Existe(5);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetOrdenTest()
        {
            List<Ordenes> lista = new List<Ordenes>();
            lista = OrdenesBLL.GetOrden();
            Assert.IsNotNull(lista);
        }
    }
}