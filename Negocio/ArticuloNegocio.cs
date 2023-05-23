using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Collections;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.SetearQuery("SELECT A.*, M.Descripcion AS Desc_Marca, C.Descripcion AS Desc_Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.leer();
                while (datos.Reader.Read())
                {
                    Articulo aux = new Articulo();

                    int idArticulo = (int)datos.Reader["Id"];
                    aux.Id = idArticulo;
                    if (!(datos.Reader["Codigo"] is DBNull)) aux.Codigo = (string)datos.Reader["Codigo"];
                    if (!(datos.Reader["Nombre"] is DBNull)) aux.Nombre = (string)datos.Reader["Nombre"];
                    if (!(datos.Reader["Descripcion"] is DBNull)) aux.Descripcion = (string)datos.Reader["Descripcion"];
                    if (!(datos.Reader["Precio"] is DBNull)) aux.Precio = (decimal)datos.Reader["Precio"];

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);


                    if (!(datos.Reader["IdMarca"] is DBNull))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)datos.Reader["Desc_Marca"];
                        aux.Marca.Id = (int)datos.Reader["IdMarca"];

                    }

                    if(!(datos.Reader["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.Reader["Desc_Categoria"];
                        aux.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }
        }

        public int guardar(Articulo nuevoArticulo)
        {
            int idArticulo = -1;
            string codigo = nuevoArticulo.Codigo;
            string nombre = nuevoArticulo.Nombre;
            string descripcion = nuevoArticulo.Descripcion;
            int idMarca = nuevoArticulo.Marca.Id;
            int idCategoria = nuevoArticulo.Categoria.Id;
            decimal precio = nuevoArticulo.Precio;

            string query = $"INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES(@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio);" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;";
            ConexionDB db = new ConexionDB();
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@nombre", nombre);
                db.setearParametro("@codigo", codigo);
                db.setearParametro("@descripcion", descripcion);
                db.setearParametro("@precio", precio);
                db.setearParametro("@idCategoria", idCategoria);
                db.setearParametro("@idMarca", idMarca);
                db.leer();

                if (db.Reader.Read())
                {
                    idArticulo = (int)db.Reader["ID"];
                }

                return idArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrar();
            }

        }

        public List<Articulo> listarPorMarca(int idMarca)
        {
            ConexionDB db = new ConexionDB();
            List<Articulo> lista = new List<Articulo> ();
            string query = "SELECT A.Id as Id, A.Codigo as Codigo, A.Precio as Precio, A.Nombre as Nombre, A.Descripcion as Descripcion, A.IdMarca as IdMarca, M.Descripcion as Marca, A.IdCategoria as IdCategoria, C.Descripcion as Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.IdMarca = @idMarca";
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@idMarca", idMarca);
                db.leer();
                while (db.Reader.Read())
                {
                    Articulo aux = new Articulo();

                    int idArticulo = (int)db.Reader["Id"];
                    aux.Id = idArticulo;
                    if (!(db.Reader["Codigo"] is DBNull)) aux.Codigo = (string)db.Reader["Codigo"];
                    if (!(db.Reader["Nombre"] is DBNull)) aux.Nombre = (string)db.Reader["Nombre"];
                    if (!(db.Reader["Descripcion"] is DBNull)) aux.Descripcion = (string)db.Reader["Descripcion"];
                    if (!(db.Reader["Precio"] is DBNull)) aux.Precio = (decimal)db.Reader["Precio"];

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);


                    if (!(db.Reader["IdMarca"] is DBNull))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)db.Reader["Marca"];
                        aux.Marca.Id = (int)db.Reader["IdMarca"];

                    }

                    if (!(db.Reader["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)db.Reader["Categoria"];
                        aux.Categoria.Id = (int)db.Reader["IdCategoria"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrar();
            }
        }

        public List<Articulo> listarPorCategoria(int idCategoria)
        {
            ConexionDB db = new ConexionDB();
            List<Articulo> lista = new List<Articulo>();
            string query = "SELECT A.Id as Id, A.Codigo as Codigo, A.Precio as Precio, A.Nombre as Nombre, A.Descripcion as Descripcion, A.IdMarca as IdMarca, M.Descripcion as Marca, A.IdCategoria as IdCategoria, C.Descripcion as Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.IdCategoria = @idCategoria";
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@idCategoria", idCategoria);
                db.leer();
                while (db.Reader.Read())
                {
                    Articulo aux = new Articulo();

                    int idArticulo = (int)db.Reader["Id"];
                    aux.Id = idArticulo;
                    if (!(db.Reader["Codigo"] is DBNull)) aux.Codigo = (string)db.Reader["Codigo"];
                    if (!(db.Reader["Nombre"] is DBNull)) aux.Nombre = (string)db.Reader["Nombre"];
                    if (!(db.Reader["Descripcion"] is DBNull)) aux.Descripcion = (string)db.Reader["Descripcion"];
                    if (!(db.Reader["Precio"] is DBNull)) aux.Precio = (decimal)db.Reader["Precio"];

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);


                    if (!(db.Reader["IdMarca"] is DBNull))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)db.Reader["Marca"];
                        aux.Marca.Id = (int)db.Reader["IdMarca"];

                    }

                    if (!(db.Reader["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)db.Reader["Categoria"];
                        aux.Categoria.Id = (int)db.Reader["IdCategoria"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrar();
            }
        }

        public List<Articulo> buscar(string busqueda, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB db = new ConexionDB();
            string query;
            if (filtro == "Sin Filtro" || filtro == "")
                query = $"SELECT A.*, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.Codigo = '{busqueda}' OR A.Nombre = '{busqueda}' OR A.Descripcion = '{busqueda}' OR M.Descripcion = '{busqueda}' OR C.Descripcion = '{busqueda}'";
            else if (filtro == "Marca")
                query = $"SELECT A.*, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE M.Descripcion = '{busqueda}'";
            else if (filtro == "Categoria")
                query = $"SELECT A.*, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE C.Descripcion = '{busqueda}'";
            else
                query = $"SELECT A.*, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.{filtro} = '{busqueda}'";
            
            try
            {
                db.SetearQuery(query);
                db.leer();
                while (db.Reader.Read())
                {
                    Articulo aux = new Articulo();
                    int idArticulo = (int)db.Reader["Id"];
                    aux.Id = idArticulo;
                    if (!(db.Reader["Codigo"] is DBNull)) aux.Codigo = (string)db.Reader["Codigo"];
                    if (!(db.Reader["Nombre"] is DBNull)) aux.Nombre = (string)db.Reader["Nombre"];
                    if (!(db.Reader["Descripcion"] is DBNull)) aux.Descripcion = (string)db.Reader["Descripcion"];
                    if (!(db.Reader["Precio"] is DBNull)) aux.Precio = (decimal)db.Reader["Precio"];

                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);


                    if (!(db.Reader["IdMarca"] is DBNull))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)db.Reader["Marca"];
                        aux.Marca.Id = (int)db.Reader["IdMarca"];

                    }

                    if (!(db.Reader["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)db.Reader["Categoria"];
                        aux.Categoria.Id = (int)db.Reader["IdCategoria"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrar();
            }
        }

        public int modificar(Articulo articulo)
        {
            ConexionDB db = new ConexionDB();
            string query = "UPDATE ARTICULOS SET Nombre = @nombre, Codigo = @codigo, Descripcion = @descripcion, Precio = @precio, IdCategoria = @idCategoria, IdMarca = @idMarca WHERE id = @idArticulo";
            int rowsAffected = 0;
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@nombre", articulo.Nombre);
                db.setearParametro("@codigo", articulo.Codigo);
                db.setearParametro("@descripcion", articulo.Descripcion);
                db.setearParametro("@precio", articulo.Precio);
                db.setearParametro("@idCategoria", articulo.Categoria.Id);
                db.setearParametro("@idMarca", articulo.Marca.Id);
                db.setearParametro("@idArticulo", articulo.Id);
                rowsAffected = db.ejecutarQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                db.cerrar();
            }

        }

        public int eliminar(int idArticulo)
        {
            ConexionDB db = new ConexionDB();
            string query = "DELETE FROM ARTICULOS WHERE Id = @idArticulo";
            int rowsAffected = 0;
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@idArticulo", idArticulo);
                rowsAffected = db.ejecutarQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrar();
            }
        }
    }
}
