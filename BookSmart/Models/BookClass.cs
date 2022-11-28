﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Models
{
    [Table("Book-Class")]
    public partial class BookClass
    {
        [Key]
        [Column("BC_id")]
        public int BcId { get; set; }
        [StringLength(7)]
        [Unicode(false)]
        public string Name { get; set; }
        [Column("Book_id")]
        public int? BookId { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty("BookClasses")]
        public virtual Book Book { get; set; }
        [ForeignKey("Name")]
        [InverseProperty("BookClasses")]
        public virtual Class NameNavigation { get; set; }
    }
}