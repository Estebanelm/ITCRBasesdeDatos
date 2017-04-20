using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace L3MDB
{
    public class Venta
    {


        private int _Codigo;
        private int _Descuento;
        private double _Precio_total;
        private string _Codigo_sucursal;
        private int _Cedula_cajero;

        public Venta()
        { }

        public Venta(HttpContext context)
        {
            string _Codigo_venta_temp = context.Request["Codigo_venta"];
            _Codigo = int.Parse(_Codigo_venta_temp);
            string _Descuento_temp = context.Request["Descuento"];
            _Descuento = int.Parse(_Descuento_temp);
            string _Precio_total_temp = context.Request["Precio_total"];
            _Precio_total = double.Parse(_Precio_total_temp);
            _Codigo_sucursal = context.Request["Sucursal"];
            string _Cedula_cajero_temp = context.Request["Cedula_cajero"];
            _Cedula_cajero = int.Parse(_Cedula_cajero_temp);
        }

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }

        public int Descuento
        {
            get
            {
                return _Descuento;
            }

            set
            {
                _Descuento = value;
            }
        }

        public double Precio_total
        {
            get
            {
                return _Precio_total;
            }

            set
            {
                _Precio_total = value;
            }
        }

        public string Codigo_sucursal
        {
            get
            {
                return _Codigo_sucursal;
            }

            set
            {
                _Codigo_sucursal = value;
            }
        }

        public int Cedula_cajero
        {
            get
            {
                return _Cedula_cajero;
            }

            set
            {
                _Cedula_cajero = value;
            }
        }
    }
}
