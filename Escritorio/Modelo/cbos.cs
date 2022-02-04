using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public enum cbos : short
    {
        Gestion_de_Contratos,
        Capacitaciones
    }

    public enum perfil : short
    {
        Ver_Mi_Perfil,
        Cerrar_Sesión
    }

    public enum camposContratos : short {
        Todos,
        Run_Asociado,
        Contratos,
        Fecha_Pago,
        Actividades,
        Estado_de_pago,
        Empresa
    }

    public enum metodoPago : short {
        Debito,
        Credito,
        Transferencia
    }

    public enum visitas : short {
        Buscar_Visitas_Realizadas,
        Generar_Visita_a_Terreno
    }

    public enum asesorias : short {
        Nueva_Asesoría,
        Asesorías
    }

    public enum filtroVisita : short {
        Pendiente,
        Realizada
    }
    public enum reportes : short
    {
        Reporte_General_Cliente,
        Reporte_Estadistico_Cliente,
        Reporte_Estadistico_Global
    }

    public enum cliente_admin : short
    {
        Creación_contrato,
        Gestión_de_Contratos,
        Registro_cliente,
        Registro_empresa
    }

    public enum profesionales_admin : short
    {
        Registro_profesional,
        Gestión_de_actividades
    }

    public enum jornada : short
    {
        nocturna,
        diurna
    }

    public enum tipo_contrato : short
    {
        contrato_1,
        contrato_2,
        contrato_3
    }

    public enum tipo_plan : short
    {
        plan_1,
        plan_2,
        plan_3
    }

    public enum genero : short {
        Femenino,
        Masculino
    }

    public enum comuna : short {
        Puente_Alto,
        Maipú,
        La_florida,
        Cerrillos
    }

    public enum rubro : short {
        Industrial,
        Construcción,
        Minero
    }

    public enum profesion : short
    {
        Admin,
        Ingeniero,
        Medico,
        Contador
    }
}
