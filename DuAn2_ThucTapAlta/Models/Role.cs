﻿namespace DuAn2_ThucTapAlta.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<User> Users { get; set; }
    }
}
