using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Gestion_contrato
    {
        private int _id_contrato;
        private string _run_profesional_asociado;
        private string _nombre_profesional_asociado;
        private int _id_asesoria;
        private int _run_representante;
        private string _descripcion_contrato;
        private string _fecha_pago;
        private int _cantidad_visitas_a_terreno;
        private int _cantidad_capacitaciones;
        private int _cantidad_asesorías;
        private string _estado_pago;
        private string _nombre_empresa;


        public int id_contrato
        {
            get
            {
                return _id_contrato;
            }
            set
            {
                _id_contrato = value;

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

        public string nombre_profesional_asociado
        {
            get
            {
                return _nombre_profesional_asociado;
            }
            set
            {
                _nombre_profesional_asociado = value;

            }
        }

        public int id_asesoria
        {
            get
            {
                return _id_asesoria;
            }
            set
            {
                _id_asesoria = value;

            }
        }

        public int run_representante
        {
            get
            {
                return _run_representante;
            }
            set
            {
                _run_representante = value;

            }
        }

        public string descripcion_contrato
        {
            get
            {
                return _descripcion_contrato;
            }
            set
            {
                _descripcion_contrato = value;

            }
        }
        public string fecha_pago
        {
            get
            {
                return _fecha_pago;
            }
            set
            {
                _fecha_pago = value;

            }
        }
        public int cantidad_visitas_a_terreno
        {
            get
            {
                return _cantidad_visitas_a_terreno;
            }
            set
            {
                _cantidad_visitas_a_terreno = value;

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
        public int cantidad_asesorías
        {
            get
            {
                return _cantidad_asesorías;
            }
            set
            {
                _cantidad_asesorías = value;

            }
        }
        
        public string estado_pago
        {
            get
            {
                return _estado_pago;
            }
            set
            {
                _estado_pago = value;

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
