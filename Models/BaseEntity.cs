using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace restAPI.Models
{
    public partial class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int status { get; set; }
        public DateTime DateAdded  { get; set; }
        public DateTime DateUpdated { get; set;}
    }
}
