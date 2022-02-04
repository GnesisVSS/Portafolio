using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Grafico
    {
        private int _cant;
        private string _nombre;

        public int cant
        {
            get
            {
                return _cant;
            }
            set
            {
                _cant = value;

            }
        }

        public string nombre
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
    }
}
