using ManejoDeEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoDeEmpleados.Services
{
    public class ServiceNomina
    {
        manejoempleadosContext db = new();
        public void AddNomina(Empleado empleado)
        {
            Nomina nomina = new();
            nomina.EmpleadoId = empleado.Id;
            nomina.SueldoBruto = empleado.SueldoEmpleado;
            nomina.Cooperativa = (0.05 * nomina.SueldoBruto);
            nomina.Comision = (100 * nomina.SueldoBruto) / 100;
            nomina.Cafeteria = 500;
            nomina.Afp = 0.287 * nomina.SueldoBruto / 100;
            nomina.SueldoNeto = nomina.SueldoBruto - nomina.Cooperativa + nomina.Comision - nomina.Cafeteria - nomina.Afp;
            nomina.Isr = (nomina.SueldoBruto - nomina.Afp) * 12;

            if (nomina.Isr < 416220)
            {
                nomina.SueldoNeto = nomina.SueldoNeto;
            }
            else if (nomina.Isr >= 416220 && nomina.Isr <= 624329)
            {
                nomina.SueldoNeto = (nomina.Isr - 416220 * 0.15 / 100) / 12;
            }
            else if (nomina.Isr >= 624329 && nomina.Isr <= 867123)
            {
                nomina.SueldoNeto = (nomina.Isr - 624329 * 0.20 / 100) + 31216 / 12;
            }
            else if (nomina.Isr >= 867123)
            {
                nomina.SueldoNeto = (nomina.Isr - 867123 * 0.25 / 100) + 79776 / 12;
            }

            db.Nominas.Add(nomina);
            db.SaveChangesAsync();
        }
    }
}
