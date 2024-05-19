using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Carrito
{
    public int Idcarrito { get; set; }

    public int? Idproductos { get; set; }

    public int? Idusuario { get; set; }

    public int? Cantidad { get; set; }

    public virtual Productos? IdproductosNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
