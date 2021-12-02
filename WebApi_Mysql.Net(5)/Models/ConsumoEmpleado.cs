using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Mysql.Net_5_.Models
{
    public partial class ConsumoEmpleado
    {
        public int Id { get; set; }
        public bool? Cooperativa { get; set; }
        public double? Comision { get; set; }
        public double? Cafeteria { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
