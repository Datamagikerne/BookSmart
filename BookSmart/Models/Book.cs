﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Models
{
    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            BookClasses = new HashSet<BookClass>();
        }

        [Key]
        [Column("Book_id")]
        public int BookId { get; set; }

        [StringLength(30)]
        [Unicode(false)]
        public string Title { get; set; }

        [StringLength(30)]
        [Unicode(false)]
        public string Author { get; set; }

        public int Year { get; set; }

        [Column("Subject_id")]
        public int? SubjectId { get; set; }

        [ForeignKey("SubjectId")]

        [InverseProperty("Books")]
        public virtual Subject Subject { get; set; }

        [InverseProperty("Book")]
        public virtual ICollection<BookClass> BookClasses { get; set; }
    }
}