﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Models
{
    [Table("Subject")]
    public partial class Subject
    {
        public Subject()
        {
            Books = new HashSet<Book>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }

        [Key]
        [Column("Subject_id")]
        public int SubjectId { get; set; }

        [StringLength(30)]
        [Unicode(false)]
        public string Name { get; set; }


        [InverseProperty("Subject")]
        public virtual ICollection<Book> Books { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }
}