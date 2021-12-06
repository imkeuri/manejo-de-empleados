using System;
using System.Collections.Generic;

#nullable disable

namespace ManejoDeEmpleados.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            ConsumoEmpleados = new HashSet<ConsumoEmpleado>();
            Vacaciones = new HashSet<Vacacione>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int DepartamentoclId { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int SueldoEmpleado { get; set; }

        public virtual Departamentocl Departamentocl { get; set; }
        public virtual ICollection<ConsumoEmpleado> ConsumoEmpleados { get; set; }
        public virtual ICollection<Vacacione> Vacaciones { get; set; }
    }
}
