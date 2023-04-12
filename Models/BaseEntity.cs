using System;
using System.Collections.Generic;

namespace restAPI.Models
{
    public partial class BaseEntity
    {
        public int Id { get; set; }
        public int status { get; set; }
        public DateTime DateAdded  { get; set; }
        public DateTime DateUpdated { get; set;}
    }
}
