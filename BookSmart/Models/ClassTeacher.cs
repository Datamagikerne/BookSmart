﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Models
{
    [Table("Class-Teacher")]
    public partial class ClassTeacher
    {
        [Key]
        [Column("CT_id")]
        public int CtId { get; set; }

        [StringLength(4)]
        [Unicode(false)]
        public string Initials { get; set; }

        [Column("Class_id")]
        public int? ClassId { get; set; }

        [ForeignKey("ClassId")]

        [InverseProperty("ClassTeachers")]

        public virtual Class Class { get; set; }
        [ForeignKey("Initials")]

        [InverseProperty("ClassTeachers")]
        public virtual Teacher InitialsNavigation { get; set; }
    }
}