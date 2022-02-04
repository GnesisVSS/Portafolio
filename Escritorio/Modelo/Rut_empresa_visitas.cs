using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Rut_empresa_visitas
    {
        private string _rut_empresa;
        private string _nombre_empresa;
        public string nombre_empresa
        {
            get
            {
                return _nombre_empresa;
            }
            set
            {
                _nombre_empresa = value;

            }
        }
        public string rut_empresa
        {
            get
            {
                return _rut_empresa;
            }
            set
            {
                _rut_empresa = value;

            }
        }
    }
}
