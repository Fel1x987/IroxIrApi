using System;
using System.Collections.Generic;

namespace ApiClean.Models
{
    public partial class Venta
    {
        public int Idventas { get; set; }
        public int? Idproductos { get; set; }
        public int? CantidadVendida { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Producto? IdproductosNavigation { get; set; }
    }
}
