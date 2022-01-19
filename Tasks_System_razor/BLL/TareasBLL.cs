using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tasks_System_razor.DAL;
using Tasks_System_razor.Entidades;

namespace Tasks_System_razor.BLL
{
    public class TareasBLL
    {
        /// <summary>
        /// Permite buscar una tarea mediante id
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static bool Existe(int id)
        {

            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Tareas.Any(t => t.TareaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        /// <summary>
        /// Permite guardar una tarea
        /// </summary>
        /// <param name="tarea">La entidad que se desea guardar</param>
        public static bool Guardar(Tareas tarea)
        {
            if (!Existe(tarea.TareaId))
            {
                return Insertar(tarea);
            }
            else
            {
                return Modificar(tarea);
            }
        }
        /// <summary>
        /// Permite insertar una tarea en la base de datos
        /// </summary>
        /// <param name="tarea">La entidad que se desea guardar</param>
        private static bool Insertar(Tareas tarea)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Tareas.Add(tarea);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        /// <summary>
        /// Permite modificar una tarea en la base de datos
        /// </summary>
        /// <param name="tarea">La entidad que se desea modificar</param>
        private static bool Modificar(Tareas tarea)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(tarea).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        /// <summary>
        /// Permite eliminar una tarea mediante id
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea eliminar</param>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var tarea = contexto.Tareas.Find(id);
                if (tarea != null)
                {
                    contexto.Tareas.Remove(tarea);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return paso;
        }
        /// <summary>
        /// Permite buscar una tarea mediante id
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static Tareas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Tareas tarea;
            try
            {
                tarea = contexto.Tareas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }
        /// <summary>
        /// Permite buscar una tarea con filtros
        /// </summary>
        /// <param name="criterio">El criterio por el cual se buscara</param>
        public static List<Tareas> GetList(Expression<Func<Tareas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Tareas> lista = new List<Tareas>();

            try
            {
                lista = contexto.Tareas.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        /// <summary>
        /// Permite obtener el listado de todas las tareas agregadad
        /// </summary>
        public static List<Tareas> GetTareas()
        {
            Contexto contexto = new Contexto();
            List<Tareas> lista = new List<Tareas>();

            try
            {
                lista = contexto.Tareas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        /// <summary>
        /// Permite buscar si una tarea ya existe con un nombre
        /// </summary>
        /// <param name="nombre">El nombre que se verificara</param>
        public static bool ExisteNombre(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Tareas.Any(e => e.Nombre == nombre);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
    }
}
