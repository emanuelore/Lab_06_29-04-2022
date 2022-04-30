using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProducto
    {
		public List<Producto> Listar(Producto producto)
		{
			SqlParameter[] parameters = null;
			string commandText = string.Empty;
			List<Producto> productos = null;

			try

			{
				commandText = "USP_GetProducto";
				parameters = new SqlParameter[1];
				parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
				parameters[0].Value = producto.IdProducto;
				productos = new List<Producto>();

				using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText,
					CommandType.StoredProcedure, parameters))
				{
					while (reader.Read())
					{
						productos.Add(new Producto
						{
							IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
							NombreProducto = reader["nombreproducto"] != null ? Convert.ToString(reader["nombreproducto"]) : string.Empty,
							IdProveedor = reader["idproveedor"] != null ? Convert.ToInt32(reader["idproveedor"]) : 0,
							IdCategoria = reader["idcategoria"] != null ? Convert.ToInt32(reader["idcategoria"]) : 0,
							CantidadPorUnidad = reader["cantidadporunidad"] != null ? Convert.ToString(reader["cantidadporunidad"]) : string.Empty,
							PrecioUnidad = reader["preciounidad"] != null ? Convert.ToInt32(reader["preciounidad"]) : 0,
							UnidadesEnExistencia = reader["unidadesenexistencia"] != null ? Convert.ToInt32(reader["unidadesenexistencia"]) : 0,
							UnidadesEnPedido = reader["unidadesenpedido"] != null ? Convert.ToInt32(reader["unidadesenpedido"]) : 0,
							NivelNuevoPedido = reader["nivelnuevopedido"] != null ? Convert.ToInt32(reader["nivelnuevopedido"]) : 0,
							Suspendido = reader["suspendido"] != null ? Convert.ToInt32(reader["suspendido"]) : 0,
							CategoriaProducto = reader["categoriaproducto"] != null ? Convert.ToString(reader["categoriaproducto"]) : string.Empty

						});
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return productos;
		}

		public void Insertar(Producto producto)
		{
			SqlParameter[] parameters = null;
			string commandText = string.Empty;
			try
			{
				commandText = "USP_InsProducto";
				parameters = new SqlParameter[10];

				parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
				parameters[0].Value = producto.NombreProducto;
				parameters[1] = new SqlParameter("@idProveedor", SqlDbType.Int);
				parameters[1].Value = producto.IdProveedor;
				parameters[2] = new SqlParameter("@idCategoria", SqlDbType.Int);
				parameters[2].Value = producto.IdCategoria;
				parameters[3] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar);
				parameters[3].Value = producto.CantidadPorUnidad;
				parameters[4] = new SqlParameter("@precioUnidad", SqlDbType.Int);
				parameters[4].Value = producto.PrecioUnidad;
				parameters[5] = new SqlParameter("@unidadesEnExistencia", SqlDbType.Int);
				parameters[5].Value = producto.UnidadesEnExistencia;
				parameters[6] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
				parameters[6].Value = producto.UnidadesEnPedido;
				parameters[7] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
				parameters[7].Value = producto.NivelNuevoPedido;
				parameters[8] = new SqlParameter("@suspendido", SqlDbType.Int);
				parameters[8].Value = producto.Suspendido;
				parameters[9] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar);
				parameters[9].Value = producto.CategoriaProducto;

				SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public void Actualizar(Producto producto)
		{
			SqlParameter[] parameters = null;
			string commandText = string.Empty;
			try
			{
				commandText = "USP_UpdProducto";
				parameters = new SqlParameter[11];

				parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
				parameters[0].Value = producto.IdProducto;
				parameters[1] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
				parameters[1].Value = producto.NombreProducto;
				parameters[2] = new SqlParameter("@idProveedor", SqlDbType.Int);
				parameters[2].Value = producto.IdProveedor;
				parameters[3] = new SqlParameter("@idCategoria", SqlDbType.Int);
				parameters[3].Value = producto.IdCategoria;
				parameters[4] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar);
				parameters[4].Value = producto.CantidadPorUnidad;
				parameters[5] = new SqlParameter("@precioUnidad", SqlDbType.Int);
				parameters[5].Value = producto.PrecioUnidad;
				parameters[6] = new SqlParameter("@unidadesEnExistencia", SqlDbType.Int);
				parameters[6].Value = producto.UnidadesEnExistencia;
				parameters[7] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
				parameters[7].Value = producto.UnidadesEnPedido;
				parameters[8] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
				parameters[8].Value = producto.NivelNuevoPedido;
				parameters[9] = new SqlParameter("@suspendido", SqlDbType.Int);
				parameters[9].Value = producto.Suspendido;
				parameters[10] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar);
				parameters[10].Value = producto.CategoriaProducto;

				SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public void Eliminar(int IdProducto)
		{
			SqlParameter[] parameters = null;
			string commandText = string.Empty;
			try
			{
				commandText = "USP_DelProducto";
				parameters = new SqlParameter[1];
				parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
				parameters[0].Value = IdProducto;
				SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}

