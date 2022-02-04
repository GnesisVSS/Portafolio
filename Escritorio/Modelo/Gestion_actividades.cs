using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Gestion_actividades
    {
        private string _nombre_empleado;
        private string _nombreempresa;
        private int _cantidad_asesoria;
        private int _cantidad_visitas;
        private int _cantidad_capacitaciones;

        public string nombre_empleado
        {
            get
            {
                return _nombre_empleado;
            }
            set
            {
                _nombre_empleado = value;

            }
        }
        public string nombreempresa
        {
            get
            {
                return _nombreempresa;
            }
            set
            {
                _nombreempresa = value;

            }
        }
        public int cantidad_asesoria
        {
            get
            {
                return _cantidad_asesoria;
            }
            set
            {
                _cantidad_asesoria = value;

            }
        }
        public int cantidad_visitas
        {
            get
            {
                return _cantidad_visitas;
            }
            set
            {
                _cantidad_visitas = value;

            }
        }
        public int cantidad_capacitaciones
        {
            get
            {
                return _cantidad_capacitaciones;
            }
            set
            {
                _cantidad_capacitaciones = value;

            }
        }
    }

    
}
