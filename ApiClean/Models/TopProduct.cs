using System;
using System.Collections.Generic;

namespace ApiClean.Models
{
    public partial class TopProduct
    {
        public string Titulo { get; set; } = null!;
        public int? Ventas { get; set; }
    }
}
