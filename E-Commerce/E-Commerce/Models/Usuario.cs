using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public int? Idrolprincipal { get; set; }

    public string? Clave { get; set; }

    public bool? Restablecer { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual Rolprincipal? IdrolprincipalNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
