using System;
using System.Collections.Generic;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carrito { get; set; }

    public virtual DbSet<Carrusel> Carrusel { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Detallepedido> Detallepedido { get; set; }

    public virtual DbSet<Msjcontacto> Msjcontacto { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Rolprincipal> Rolprincipal { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Idcarrito).HasName("PK__CARRITO__BDDE160EC1F37F74");

            entity.ToTable("CARRITO");

            entity.Property(e => e.Idcarrito).HasColumnName("IDCARRITO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Idproductos).HasColumnName("IDPRODUCTOS");
            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

            entity.HasOne(d => d.IdproductosNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.Idproductos)
                .HasConstraintName("FK__CARRITO__IDPRODU__5070F446");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__CARRITO__IDUSUAR__5165187F");
        });

        modelBuilder.Entity<Carrusel>(entity =>
        {
            entity.HasKey(e => e.Idcarrusel).HasName("PK__CARRUSEL__429EA06259E97962");

            entity.ToTable("CARRUSEL");

            entity.Property(e => e.Idcarrusel).HasColumnName("IDCARRUSEL");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Imagen)
                .HasColumnType("image")
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__CATEGORI__ADC0E71984E9E60C");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");
            entity.Property(e => e.Nombrecategoria)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("NOMBRECATEGORIA");
        });

        modelBuilder.Entity<Detallepedido>(entity =>
        {
            entity.HasKey(e => e.Iddetalle).HasName("PK__DETALLEP__A1AC0F64739E508C");

            entity.ToTable("DETALLEPEDIDO");

            entity.Property(e => e.Iddetalle).HasColumnName("IDDETALLE");
            entity.Property(e => e.Domicilioentrega)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DOMICILIOENTREGA");
            entity.Property(e => e.Fechaenvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAENVIO");
            entity.Property(e => e.Fechapago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAPAGO");
            entity.Property(e => e.Fechapedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAPEDIDO");
            entity.Property(e => e.Idpedido).HasColumnName("IDPEDIDO");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.Idpedido)
                .HasConstraintName("FK__DETALLEPE__IDPED__4AB81AF0");
        });

        modelBuilder.Entity<Msjcontacto>(entity =>
        {
            entity.HasKey(e => e.Idcontacto).HasName("PK__MSJCONTA__4F3DCD41D63D3AD0");

            entity.ToTable("MSJCONTACTO");

            entity.Property(e => e.Idcontacto).HasColumnName("IDCONTACTO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAIL");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MENSAJE");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("PK__PEDIDO__769F9E4E89951934");

            entity.ToTable("PEDIDO");

            entity.Property(e => e.Idpedido).HasColumnName("IDPEDIDO");
            entity.Property(e => e.Actividad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACTIVIDAD");
            entity.Property(e => e.Cantidadpedido).HasColumnName("CANTIDADPEDIDO");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.Fechaventa)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAVENTA");
            entity.Property(e => e.Idproductos).HasColumnName("IDPRODUCTOS");
            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");
            entity.Property(e => e.Totalpedido)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("TOTALPEDIDO");

            entity.HasOne(d => d.IdproductosNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idproductos)
                .HasConstraintName("FK__PEDIDO__IDPRODUC__45F365D3");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__PEDIDO__IDUSUARI__46E78A0C");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Idproductos).HasName("PK__PRODUCTO__42AECE7E329237EC");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.Idproductos).HasColumnName("IDPRODUCTOS");
            entity.Property(e => e.Cantidadstock).HasColumnName("CANTIDADSTOCK");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Descuento)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");
            entity.Property(e => e.Imagen).HasColumnName("IMAGEN");
            entity.Property(e => e.Marca)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Nombreproducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREPRODUCTO");
            entity.Property(e => e.Precio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idcategoria)
                .HasConstraintName("FK__PRODUCTOS__IDCAT__4222D4EF");
        });

        modelBuilder.Entity<Rolprincipal>(entity =>
        {
            entity.HasKey(e => e.Idrolprincipal).HasName("PK__ROLPRINC__9AE007F7ACBCDC65");

            entity.ToTable("ROLPRINCIPAL");

            entity.Property(e => e.Idrolprincipal).HasColumnName("IDROLPRINCIPAL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__USUARIO__98242AA94C0A72EC");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ACTIVO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CLAVE");
            entity.Property(e => e.Correo)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Idrolprincipal).HasColumnName("IDROLPRINCIPAL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Restablecer)
                .HasDefaultValueSql("((0))")
                .HasColumnName("RESTABLECER");

            entity.HasOne(d => d.IdrolprincipalNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrolprincipal)
                .HasConstraintName("FK__USUARIO__IDROLPR__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
