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
        public void AddNomina(Empleado empleado, ConsumoEmpleado consumo)
        {
           
            Nomina nomina = new();
            nomina.SueldoBruto = empleado.SueldoEmpleado;
            nomina.EmpleadoId = empleado.Id;

            if (consumo.Cooperativa == true)
            {

                nomina.Cooperativa = (nomina.SueldoBruto * 5) / 100;
            }
            else
            {
                nomina.Cooperativa = 0;
            }

          


            nomina.Comision = ( nomina.SueldoBruto * 5) / 100; ;

            nomina.Cafeteria = consumo.Cafeteria;

            nomina.Afp = (nomina.SueldoBruto * 2.87) / 100;

            nomina.Seguro = (nomina.SueldoBruto * 3.04) / 100;



            // -------------------------------------------------------------------------------------------------------------------------------------

            double isr_Escala = (nomina.SueldoBruto - nomina.Seguro - nomina.Afp) * 12;

            if (isr_Escala <= 416220)
            {
                nomina.Isr = 0;
            }
            else if (isr_Escala >= 416220.01 && isr_Escala <= 624329)
            {
                double Calculo_Escala = ((isr_Escala - 416220.01) * 15) / 100;
                nomina.Isr = Calculo_Escala / 12;
            }
            else if (isr_Escala >= 624329.01 && isr_Escala <= 867123)
            {
                double Calculo_Escala = ((isr_Escala - 624329.01) * 20) / 100;
                nomina.Isr = (Calculo_Escala + 31216) / 12;
            }
            else if (isr_Escala >= 867123.01)
            {
                double Calculo_Escala = ((isr_Escala - 867123.01) * 25) / 100;
                nomina.Isr = (Calculo_Escala + 79776) / 12;
            }

            nomina.SueldoNeto = (double)(nomina.SueldoBruto + nomina.Comision - nomina.Cooperativa - nomina.Cafeteria - nomina.Afp - nomina.Seguro - nomina.Isr);

            db.Nominas.Add(nomina);
            db.SaveChangesAsync();
        }
    }
}
