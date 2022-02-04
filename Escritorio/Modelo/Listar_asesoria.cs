using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Listar_asesoria
    {
        private int _idasesoria;
        private DateTime _fechaasesoria;
        private int _cantaccidentes;
        private int _tasaaccidentes;
        private string _rutemp;
        private int _valorasesoria;
        private string _runprf;

        public int idasesoria
        {
            get
            {
                return _idasesoria;
            }
            set
            {
                _idasesoria = value;

            }
        }
        public DateTime fechaasesoria
        {
            get
            {
                return _fechaasesoria;
            }
            set
            {
                _fechaasesoria = value;

            }
        }
        public int cantaccidentes
        {
            get
            {
                return _cantaccidentes;
            }
            set
            {
                _cantaccidentes = value;

            }
        }
        public int tasaaccidentes
        {
            get
            {
                return _tasaaccidentes;
            }
            set
            {
                _tasaaccidentes = value;

            }
        }
        public string rutemp
        {
            get
            {
                return _rutemp;
            }
            set
            {
                _rutemp = value;

            }
        }
        public int valorasesoria
        {
            get
            {
                return _valorasesoria;
            }
            set
            {
                _valorasesoria = value;

            }
        }
        public string runprf
        {
            get
            {
                return _runprf;
            }
            set
            {
                _runprf = value;

            }
        }
    }
}
