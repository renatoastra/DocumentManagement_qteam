using DocumentManagement.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace DocumentManagement.Models
{
    [Table("Document")]
    public class DocumentModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Title must contain at least 5 characters")]
        [Required(ErrorMessage = "Please choose your Document Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please choose your Document Process")]
        [Column("ProcessId")]
        public int ProcessId { get; set; }

        public Process? Process { get; set; }

        [Required(ErrorMessage = "Please choose the Category of the document")]
        [Column("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please insert a valid document code")]
        [DocumentCodeCustomValidation]
        [Column("Code")]
        public int? Code { get; set; }

        [Column("File Url")]
        public string? FileUrl { get; set; }

        [NotMapped]
        [DocumentFormatCustomValidation]
        public IFormFile File { get; set; }

    }
}
