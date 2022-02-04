using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public class Info_reporte_cliente
    {
        private string _runemp;
        private string _nombreemp;
        private string _nombrerep;
        private int _rutrep;

        public string runemp
        {
            get
            {
                return _runemp;
            }
            set
            {
                _runemp = value;

            }
        }

        public string nombreemp
        {
            get
            {
                return _nombreemp;
            }
            set
            {
                _nombreemp = value;

            }
        }

        public string nombrerep
        {
            get
            {
                return _nombrerep;
            }
            set
            {
                _nombrerep = value;

            }
        }

        public int rutrep
        {
            get
            {
                return _rutrep;
            }
            set
            {
                _rutrep = value;

            }
        }

    }
}
