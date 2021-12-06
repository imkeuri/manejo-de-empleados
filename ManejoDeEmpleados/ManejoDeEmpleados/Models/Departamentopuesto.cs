using System;
using System.Collections.Generic;

#nullable disable

namespace ManejoDeEmpleados.Models
{
    public partial class Departamentopuesto
    {
        public Departamentopuesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }

        public virtual Departamentocl Departamento { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
