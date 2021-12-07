using System;
using System.Collections.Generic;

#nullable disable

namespace ManejoDeEmpleados.Models
{
    public partial class ConsumoEmpleado
    {
        public int Id { get; set; }
        public bool? Cooperativa { get; set; }
        public int? Cafeteria { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
