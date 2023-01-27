using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SLNClinica.Models
{
    public class Medico
    {
        //Ejercicio MODEL-CONTROLLER

        //Tarea 1
        //Nueva solución: SLNClinica

        //Tarea2

        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es un campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es un campo obligatorio")]
        public string Apellido { get; set; }

        [RegularExpression("^[a-zA-Z]{2}\\d{4}$")]//dsp lo vemos
        public int Matricula { get; set; }

    }
}
