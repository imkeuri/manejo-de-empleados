﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Mysql.Net_5_.Models
{
    public partial class Vacacionesestado
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public int VacacionesId { get; set; }

        public virtual Vacacione Vacaciones { get; set; }
    }
}
