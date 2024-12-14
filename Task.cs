using System;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get;set }
        public string Title { get; set }
        public string Descripcion { get; set }
        public DateTime? DueDate { get; set }
        public string Status { get; set }
    }
}
