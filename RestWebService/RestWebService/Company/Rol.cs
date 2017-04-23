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
        private int _ced_empleado;

        public Rol()
        { }

        public Rol(HttpContext context)
        {
            _nombre = context.Request["Nombre"];
            _descripcion = context.Request["Descripcion"];
            string _empleado_temp = context.Request["Ced_empleado"];
            if (_empleado_temp == null)
            {
                _ced_empleado = 0;
            }
            else
            {
                _ced_empleado = int.Parse(_empleado_temp);
            }
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

        public int Ced_empleado
        {
            get
            {
                return _ced_empleado;
            }

            set
            {
                _ced_empleado = value;
            }
        }
    }
}
