using System;
using System.Collections.Generic;

#nullable disable

namespace ManejoDeEmpleados.Models
{
    public partial class Nomina
    {
        public int Id { get; set; }
        public double SueldoBruto { get; set; }
        public double SueldoNeto { get; set; }
        public double Comision { get; set; }
        public double Afp { get; set; }
        public double Cafeteria { get; set; }
        public double Cooperativa { get; set; }
        public double Isr { get; set; }
        public double Seguro { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
