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
        private int _cedula_empleado;

        public Rol()
        { }

        public Rol(HttpContext context)
        {
            _nombre = context.Request["Nombre"];
            _descripcion = context.Request["Descripcion"];
            string _empleado_temp = context.Request["Empleado"];
            _cedula_empleado = int.Parse(_empleado_temp);
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

        public int Cedula_empleado
        {
            get
            {
                return _cedula_empleado;
            }

            set
            {
                _cedula_empleado = value;
            }
        }
    }
}
