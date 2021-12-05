using ManejoDeEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManejoDeEmpleados.Services
{
    public class ServiceEmpleado
    {
        manejoempleadosContext db = new manejoempleadosContext();

        public int LastID()
        {
            int id;
            if (db.Empleados.Count() != 0)
            {
                id = db.Empleados.Select(x => x.Id).Max();
            }
            else
            {
                id = 0;
            }
            return id;
        }

        public void GenerarSecuencia(Empleado empleado)
        {
            string digitos;
            int numero = LastID() + 1;
            if (numero < 10) digitos = "000";
            else if (numero < 100 && numero > 9) digitos = "00";
            else digitos = "0";
            string secuencia = $"{(empleado.Nombre[0]+empleado.Nombre[1]+empleado.Nombre[2]).ToString().ToUpper()}-{digitos}";
            empleado.Codigo = secuencia;
        }
    }
}
