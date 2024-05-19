using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Rolprincipal
{
    public int Idrolprincipal { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
