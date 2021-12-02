using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using System.Linq;
using WebApi_Mysql.Net_5_.Models;

namespace WebApi_Mysql.Net_5_.Controllers
{
    public class CalcularNomina
    {
        public double Cooperativa { get; set; }
        public double comision { get; set; }
        public double SueldoNeto { get; set; }
        public double Cafeteria  { get; set; }
        public double Afp { get; set; }
        public double Seguro { get; set; }

        public double ISR { get; set; } 


        public static CalcularNomina CalculaNomina(ConsumoEmpleado empleado, Empleado sueldo)
        {
            CalcularNomina nomina = new CalcularNomina();


            if (empleado.Cooperativa == true)
            {

                nomina.Cooperativa = (sueldo.SueldoEmpleado * 5) / 100;
            }
            else
            {
                nomina.Cooperativa = 0;
            }


            nomina.comision = (double)empleado.Comision;


            nomina.Cafeteria = (double)empleado.Cafeteria;

            nomina.Afp = (sueldo.SueldoEmpleado * 2.87) / 100;

            nomina.Seguro = (sueldo.SueldoEmpleado * 3.04) / 100;


            if (nomina.comision == 0 && nomina.Cafeteria == 0 && nomina.Cooperativa == 0)
            {
                nomina.SueldoNeto = (sueldo.SueldoEmpleado + nomina.comision - nomina.Cooperativa - nomina.Cafeteria - nomina.Afp - nomina.Seguro);

                return nomina;
            }
            // -------------------------------------------------------------------------------------------------------------------------------------

            double isr_Escala = (sueldo.SueldoEmpleado - nomina.Seguro - nomina.Afp) * 12;

            if (isr_Escala <= 416220)
            {
                nomina.ISR = 0;
            }
            else if (isr_Escala >= 416220.01 && isr_Escala <= 624329 )
            {
                double Calculo_Escala = ((isr_Escala - 416220.01 )* 15) / 100;
                nomina.ISR = Calculo_Escala / 12;
            }
            else if (isr_Escala >= 624329.01 && isr_Escala <= 867123 )
            {
                double Calculo_Escala = ( (isr_Escala - 624329.01 ) * 20) / 100;
                nomina.ISR = (Calculo_Escala + 31216) / 12;
            }
            else if (isr_Escala >= 867123.01)
            {
                double Calculo_Escala = ((isr_Escala - 867123.01) * 25) / 100;
                nomina.ISR = (Calculo_Escala + 79776) / 12; 
            }

            nomina.SueldoNeto = (sueldo.SueldoEmpleado + nomina.comision - nomina.Cooperativa - nomina.Cafeteria - nomina.Afp - nomina.Seguro - nomina.ISR);

            return nomina;
        }



    }
}
