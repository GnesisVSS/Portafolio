using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Asesoria
    {
        private int _id;
        private string _rut_emp;
        private string _nombre_emp;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

            }
        }

        public string rut_emp
        {
            get
            {
                return _rut_emp;
            }
            set
            {
                _rut_emp = value;

            }
        }

        public string nombre_emp
        {
            get
            {
                return _nombre_emp;
            }
            set
            {
                _nombre_emp = value;

            }
        }
    }
}
