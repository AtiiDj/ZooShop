using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


    public class Town
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    public virtual Shop Shops { get; set; }
}
