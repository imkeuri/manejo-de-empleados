using System;
using System.Collections.Generic;

#nullable disable

namespace ManejoDeEmpleados.Models
{
    public partial class Departamentocl
    {
        public Departamentocl()
        {
            Departamentopuestos = new HashSet<Departamentopuesto>();
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }

        public virtual ICollection<Departamentopuesto> Departamentopuestos { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
