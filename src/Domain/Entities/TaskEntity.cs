using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities
{
    public class TaskEntity
    {
        
        public Guid TaskId { get; set; } = Guid.NewGuid();


        public string? Title { get; set; }

       
        public string? Description { get; set; }

     
        public DateTime Creation { get; set; }

    
        public bool Completed { get; set; }

        // Otras propiedades y métodos
    }
}