using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


    public class Animal
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string Type { get; set; }
    public string Colour { get; set; }
    public int ShopId { get; set; }
    public virtual Shop Shops { get; set; }

    public int ClientId { get; set; }
    public virtual Client Clients { get; set; }
}

