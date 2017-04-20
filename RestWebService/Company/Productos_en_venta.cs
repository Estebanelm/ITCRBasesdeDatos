using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace L3MDB
{
    public class Productos_en_venta
    {

        private int _Codigo_producto;
        private double _Precio_individual;
        private int _Cantidad;
        private int _Codigo_venta;

        public Productos_en_venta()
        { }

        public Productos_en_venta(HttpContext context)
        {
            string _Codigo_producto_temp = context.Request["Codigo_producto"];
            _Codigo_producto = int.Parse(_Codigo_producto_temp);
            string _Precio_individual_temp = context.Request["Precio_individual"];
            _Precio_individual = double.Parse(_Precio_individual_temp);
            string _Cantidad_temp = context.Request["Cantidad"];
            _Cantidad = int.Parse(_Cantidad_temp);
            string _Codigo_venta_temp = context.Request["Codigo_venta"];
            _Codigo_venta = int.Parse(_Codigo_venta_temp);
        }

        public int Codigo_producto
        {
            get
            {
                return _Codigo_producto;
            }

            set
            {
                _Codigo_producto = value;
            }
        }

        public double Precio_individual
        {
            get
            {
                return _Precio_individual;
            }

            set
            {
                _Precio_individual = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public int Codigo_venta
        {
            get
            {
                return _Codigo_venta;
            }

            set
            {
                _Codigo_venta = value;
            }
        }
    }
}
