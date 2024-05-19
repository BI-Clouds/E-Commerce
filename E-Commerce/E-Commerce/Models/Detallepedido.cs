using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Detallepedido
{
    public int Iddetalle { get; set; }

    public int? Idpedido { get; set; }

    public string? Domicilioentrega { get; set; }

    public DateTime? Fechapedido { get; set; }

    public DateTime? Fechapago { get; set; }

    public DateTime? Fechaenvio { get; set; }

    public virtual Pedido? IdpedidoNavigation { get; set; }
}
