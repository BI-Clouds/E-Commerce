using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models;

public partial class Productos
{
    public int Idproductos { get; set; }

    [Display(Name = "Producto")]
    public string? Nombreproducto { get; set; }

    public string? Marca { get; set; }


    [DataType(DataType.Upload)]
    public byte[]? Imagen { get; set; }

    [Display(Name = "Stock")]
    public int? Cantidadstock { get; set; }

    public decimal? Precio { get; set; }

    public int? Idcategoria { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Descuento { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    [Display(Name = "Categoria")]
    public virtual Categoria? IdcategoriaNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
