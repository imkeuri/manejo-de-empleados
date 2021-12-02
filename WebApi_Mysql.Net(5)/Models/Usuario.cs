using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Mysql.Net_5_.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
