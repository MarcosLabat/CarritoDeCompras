using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.SetearQuery("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.leer();
                while (datos.Reader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Descripcion = (string)datos.Reader["Descripcion"];
                    aux.Id = (int)datos.Reader["Id"];
                    listaCategorias.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrar();
            }


            return listaCategorias;
        }

        public List<Categoria> filtrar(string busqueda)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            ConexionDB db = new ConexionDB();
            string query = "SELECT Id, Descripcion FROM CATEGORIAS WHERE Descripcion = @busqueda";
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@busqueda", busqueda);
                db.leer();
                while (db.Reader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Descripcion = (string)db.Reader["Descripcion"];
                    aux.Id = (int)db.Reader["Id"];
                    listaCategorias.Add(aux);
                    
                }

                return listaCategorias;
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

        public Categoria buscarPorDescripcion(string descripcion)
        {
            Categoria categoria = null;
            ConexionDB db = new ConexionDB();
            string query = "SELECT Id, Descripcion FROM CATEGORIAS WHERE Descripcion = @descripcion";
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@descripcion", descripcion);
                db.leer();
                if (db.Reader.Read())
                {
                    categoria = new Categoria();
                    categoria.Descripcion = (string)db.Reader["Descripcion"];
                    categoria.Id = (int)db.Reader["Id"];
                }

                return categoria;
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

        public int guardar(string nuevaCategoria)
        {
            int idCategoria = -1;
            string descripcion = nuevaCategoria;
            string query = "INSERT INTO CATEGORIAS(Descripcion) VALUES(@descripcion);" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;";
            ConexionDB db = new ConexionDB();
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@descripcion", descripcion);
                db.leer();

                if (db.Reader.Read())
                {
                    idCategoria = (int)db.Reader["ID"];
                }

                return idCategoria;
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

        public int modificar(string descripcion, int idCategoria)
        {
            ConexionDB db = new ConexionDB();
            string query = "UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @idCategoria";
            int rowsAffected = 0;
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@descripcion", descripcion);
                db.setearParametro("@idCategoria", idCategoria);
                rowsAffected = db.ejecutarQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int eliminar(int idCategoria)
        {
            ConexionDB db = new ConexionDB();
            string query = "DELETE FROM CATEGORIAS WHERE Id = @idCategoria";
            int rowsAffected = 0;
            try
            {
                db.SetearQuery(query);
                db.setearParametro("@idCategoria", idCategoria);
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
