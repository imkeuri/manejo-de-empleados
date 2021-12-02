using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Mysql.Net_5_.Models
{
    public partial class Vacacione
    {
        public Vacacione()
        {
            Vacacionesestados = new HashSet<Vacacionesestado>();
        }

        public int Id { get; set; }
        public DateTime InicioVacaciones { get; set; }
        public DateTime HastaVacaciones { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<Vacacionesestado> Vacacionesestados { get; set; }
    }
}
