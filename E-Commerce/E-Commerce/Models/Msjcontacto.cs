using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Msjcontacto
{
    public int Idcontacto { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Mensaje { get; set; }

    public string? Mail { get; set; }

    public string? Telefono { get; set; }
}
