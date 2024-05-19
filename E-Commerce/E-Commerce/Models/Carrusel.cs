using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Carrusel
{
    public int Idcarrusel { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }
}
