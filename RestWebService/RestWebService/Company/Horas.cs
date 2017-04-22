using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace L3MDB
{
    public class Horas
    {

        private string _ID_semana;
        private int _horas_ordinarias;
        private int _horas_extras;
        private int _ced_empleado;

        public Horas()
        { }

        public Horas(HttpContext context)
        {
            _ID_semana = context.Request["ID_semana"];
            string _horas_ordinarias_temp = context.Request["Pri_apellido"];
            _horas_ordinarias = int.Parse(_horas_ordinarias_temp);
            if (context.Request["Horas_extras"] == null)
            {
                _horas_extras = 0;
            }
            else
            {
                string _horas_extras_temp = context.Request["Horas_extras"];
                _horas_extras = int.Parse(_horas_extras_temp);
            }
            string _ced_empleado_temp = context.Request["Ced_empleado"];
            _ced_empleado = int.Parse(_ced_empleado_temp);
            
        }

        public string ID_semana
        {
            get
            {
                return _ID_semana;
            }

            set
            {
                _ID_semana = value;
            }
        }

        public int Horas_ordinarias
        {
            get
            {
                return _horas_ordinarias;
            }

            set
            {
                _horas_ordinarias = value;
            }
        }

        public int Horas_extras
        {
            get
            {
                return _horas_extras;
            }

            set
            {
                _horas_extras = value;
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
