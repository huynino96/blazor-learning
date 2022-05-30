using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListBlazor.Api.Enums;

namespace TodoListBlazor.Api.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public Guid? AssigneeId { get; set; }

        [ForeignKey("AssigneeId")]
        public User Assignee { get; set; }

        public DateTime CreatedDate { get; set; }

        public Priority priority { get; set; }
        
        public Status status { get; set; }
    }
}
