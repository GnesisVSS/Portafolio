using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Representante
    {
        private int _rut_representante;
        private string _nombre_representante;

        public int rut_representante
        {
            get
            {
                return _rut_representante;
            }
            set
            {
                _rut_representante = value;

            }
        }

        public string nombre_representante
        {
            get
            {
                return _nombre_representante;
            }
            set
            {
                _nombre_representante = value;

            }
        }
    }
}
