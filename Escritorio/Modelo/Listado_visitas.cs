using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Listado_visitas
    {
        private int _idvisita;
        private string _fechavisita;
        private string _tipovisitas;
        private string _estado;
        private string _rutemp;

        public int idvisita
        {
            get
            {
                return _idvisita;
            }
            set
            {
                _idvisita = value;

            }
        }
        public string fechavisita
        {
            get
            {
                return _fechavisita;
            }
            set
            {
                _fechavisita = value;

            }
        }
        public string tipovisitas
        {
            get
            {
                return _tipovisitas;
            }
            set
            {
                _tipovisitas = value;

            }
        }
        public string estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;

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
    }
}
