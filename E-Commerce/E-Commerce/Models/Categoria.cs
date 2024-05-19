using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models;

public partial class Categoria

{
    public int Idcategoria { get; set; }

    [Display(Name = "Categoria")]
    public string? Nombrecategoria { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
