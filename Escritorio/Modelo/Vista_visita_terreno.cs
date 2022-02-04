using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Vista_visita_terreno
    {
        private int _idvisita;
        private string _fechavisita;
        private string _tipovisitas;
        private string _estado;
        private string _rut_empresa;
        private string _run_profesional_asociado;
        private string _nombre_empresa;

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
        public string run_profesional_asociado
        {
            get
            {
                return _run_profesional_asociado;
            }
            set
            {
                _run_profesional_asociado = value;

            }
        }

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
    }
}
