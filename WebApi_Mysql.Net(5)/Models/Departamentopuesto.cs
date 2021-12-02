using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Mysql.Net_5_.Models
{
    public partial class Departamentopuesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }

        public virtual Departamentocl Departamento { get; set; }
    }
}
