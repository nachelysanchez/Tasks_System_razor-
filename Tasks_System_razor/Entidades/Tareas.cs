using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks_System_razor.Entidades
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir el nombre de la tarea")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la descripción de la tarea")]
        public string Descripcion { get; set; }
    }
}
