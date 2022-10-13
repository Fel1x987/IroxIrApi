using System;
using System.Collections.Generic;

namespace ApiClean.Models
{
    public partial class Producto
    {
        public Producto()
        {
          //  Venta = new HashSet<Venta>();
        }

        public int Idproductos { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Existencias { get; set; }
        public int Idventas { get; set; }
        public int? Idproductos2 { get; set; }
        public int CantidadVendida { get; set; }
        public DateTime Fecha { get; set; }

        //public virtual ICollection<Venta> Venta { get; set; }
    }
}
