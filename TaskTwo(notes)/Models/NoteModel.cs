using System.ComponentModel.DataAnnotations;

namespace TaskTwo_notes_.Models
{
    public class NoteModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Head { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
