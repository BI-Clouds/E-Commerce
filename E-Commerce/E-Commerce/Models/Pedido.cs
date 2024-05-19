using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int? Idproductos { get; set; }

    public int? Idusuario { get; set; }

    public int? Cantidadpedido { get; set; }

    public string? Actividad { get; set; }

    public decimal? Totalpedido { get; set; }

    public string? Contacto { get; set; }

    public DateTime? Fechaventa { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual Productos? IdproductosNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
