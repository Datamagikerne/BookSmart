﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Models
{
    [Table("Class")]
    public partial class Class
    {
        [Key]
        [StringLength(7)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Education { get; set; }
    }
}