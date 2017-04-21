using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace L3MDB
{
    public class Categoria
    {


        private int _ID;
        private string _Descripcion;
        private int _Codigo_producto;

        public Categoria()
        { }

        public Categoria(HttpContext context)
        {
            string ID_temp = context.Request["ID"];
            _ID = int.Parse(ID_temp);
            _Descripcion = context.Request["Descripcion"];
            string _Codigo_producto_temp = context.Request["ID_producto"];
            _Codigo_producto = int.Parse(_Codigo_producto_temp);
            
        }

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
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
    }
}
