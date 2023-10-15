using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


    public class Shop
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public int TownId { get; set; }
    public virtual Town Towns { get; set; }
    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}

