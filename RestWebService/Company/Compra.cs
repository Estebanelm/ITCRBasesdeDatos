using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace L3MDB
{
    public class Compra
    {

        private int _Codigo;
        private int _Cedula_proveedor;
        private string _Descripcion;
        private string _Foto;
        private string _Fecha_Registro;
        private string _Fecha_real;
        private string _Codigo_sucursal;

        public Compra()
        { }

        public Compra(HttpContext context)
        {
            string _Codigo_temp = context.Request["Codigo"];
            _Codigo = int.Parse(_Codigo_temp);
            string _Cedula_proveedor_temp = context.Request["Cedula_proveedor"];
            _Cedula_proveedor = int.Parse(_Cedula_proveedor_temp);
            _Descripcion = context.Request["Descripcion"];
            _Foto = context.Request["Foto"];
            _Fecha_Registro = context.Request["Fecha_registro"];
            _Fecha_real = context.Request["Fecha_real"];
            _Codigo_sucursal = context.Request["Codigo_sucursal"];

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

        public int Cedula_proveedor
        {
            get
            {
                return _Cedula_proveedor;
            }

            set
            {
                _Cedula_proveedor = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string Foto
        {
            get
            {
                return _Foto;
            }

            set
            {
                _Foto = value;
            }
        }

        public string Fecha_Registro
        {
            get
            {
                return _Fecha_Registro;
            }

            set
            {
                _Fecha_Registro = value;
            }
        }

        public string Fecha_real
        {
            get
            {
                return _Fecha_real;
            }

            set
            {
                _Fecha_real = value;
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
    }
}
