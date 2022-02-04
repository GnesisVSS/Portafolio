using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class gestionClientes
    {
        private string Run
        {
            get { return Run; }
            set
            {
                if (value.Trim().Length == 10 || value.Trim().Length == 9)
                {
                    Run = value;
                }
                else
                {
                    throw new ArgumentException("rut debe tener 10 digitos");
                }

            }
        }
        private string Contratos
        {
            get { return Contratos;  }
            set
            {
                if (Contratos !="")
                {
                    Contratos = value;
                }
                else
                {
                    throw new ArgumentException("El campo no puede estar vacio");
                }
            }
        }

        private DateTime FechaPago{ get; set; }

        private string Actividades
        {
            get { return Actividades; }
            set
            {
                if (Actividades != "")
                {
                    Actividades = value;
                }
                else
                {
                    throw new ArgumentException("El campo no puede estar vacio");
                }
            }
        }

        private string Estado_Pago
        {
            get { return Estado_Pago; }
            set
            {
                if (Estado_Pago != "")
                {
                    Estado_Pago = value;
                }
                else
                {
                    throw new ArgumentException("El campo no puede estar vacio");
                }
            }
        }

        private string Empresa
        {
            get { return Empresa; }
            set
            {
                if (Empresa != "")
                {
                    Empresa = value;
                }
                else
                {
                    throw new ArgumentException("El campo no puede estar vacio");
                }
            }
        }
    }
}
