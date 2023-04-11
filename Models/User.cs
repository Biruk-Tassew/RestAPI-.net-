using System;
using System.Collections.Generic;

public enum Gender {
    MALE,
    FEMALE
}
namespace restAPI.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public Gender Gender { get; set;}
    }
}
