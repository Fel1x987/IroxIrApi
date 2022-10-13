using ApiClean.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace ApiClean.Datos
{
    public class StoredDatos
    {
        //sp_getById(@id)
        //sp_getAll
        //exec clean.dbo.sp_getTop
        //sp_getTotal
        //sp_getExistencias
        //sp_getLess
        public List<Producto> getAll()
        {
            var oLista = new List<Producto>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_getAll", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Producto() {
                            Idproductos = Convert.ToInt32(dr["IDProductos"]),
                            Titulo = Convert.ToString(dr["Titulo"]),
                            Descripcion = Convert.ToString(dr["Descripcion"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            Existencias = Convert.ToInt32(dr["Existencias"]),
                            CantidadVendida = Convert.ToInt32(dr["CantidadVendida"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Producto getById(int IdP)
        {
            var oProducto = new Producto();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //string query =  + Convert.ToString(IdP);
                //SELECT Productos.Titulo, Productos.Descripcion, Productos.PrecioUnitario, Productos.Existencias, Ventas.CantidadVendida from Productos INNER JOIN Ventas on Productos.IDProductos = Ventas.IDProductos Where Productos.IDProductos = @IdFelix
                SqlCommand cmd = new SqlCommand("sp_getFelix", conexion);
                cmd.Parameters.AddWithValue("@IdFelix", IdP);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //oProducto.Idproductos = Convert.ToInt32(dr["IDProductos"]);
                        oProducto.Titulo = Convert.ToString(dr["Titulo"]);
                        oProducto.Descripcion = Convert.ToString(dr["Titulo"]);
                        oProducto.PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
                        oProducto.Existencias = Convert.ToInt32(dr["Existencias"]);
                        oProducto.CantidadVendida = Convert.ToInt32(dr["CantidadVendida"]);
                    }
                }
            }
            return oProducto;
        }
        public List<Producto> getTop()
        {
            var oLista = new List<Producto>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_getTop", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Producto()
                        {
                            Idproductos = Convert.ToInt32(dr["IDProductos"]),
                            Titulo = Convert.ToString(dr["Titulo"]),
                            CantidadVendida = Convert.ToInt32(dr["Ventas"]),

                        });
                    }
                }
            }
            return oLista;
        }
        public int getTotal()
        {
            int oProducto = 0;
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_getTotal", conexion);                
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProducto = Convert.ToInt32(dr[""]);
                    }
                }
            }
            return oProducto;
        }
        public int getExistencias()
        {
            int oProducto = 0;
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_getExistencias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProducto = Convert.ToInt32(dr["Existencias"]);
                    }
                }
            }
            return oProducto;
        }
        public List<Producto> getLess()
        {
            var oLista = new List<Producto>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_getLess", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Producto()
                        {
                            Idproductos = Convert.ToInt32(dr["IDProductos"]),
                            Titulo = Convert.ToString(dr["Titulo"]),
                            Existencias = Convert.ToInt32(dr["Existencias"]),

                        });
                    }
                }
            }
            return oLista;
        }
    }
}
