using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace L3MDB
{
    public class Rol
    {

        private string _nombre;
        private string _descripcion;

        public Rol()
        { }

        public Rol(HttpContext context)
        {
            _nombre = context.Request["Nombre"];
            _descripcion = context.Request["Descripcion"];
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

    }
}
