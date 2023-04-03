using Microsoft.EntityFrameworkCore;


public class Contexto : DbContext
{


    public DbSet<Producto> Producto {get; set;}

    public DbSet<Producido> Producido {get; set;}
    public Contexto(DbContextOptions<Contexto> options) :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Producto>().HasData
        (
            new Producto
            {
                ProductoId = 1,
                Descripcion ="Mani Japones",
                Costo = 20,
                Precio = 35,
                Existencia = 12,
                

            },
             new Producto
            {
                ProductoId = 2,
                Descripcion ="Pistacho",
                Costo = 50,
                Precio = 75,
                Existencia = 10,
                

                

            },
             new Producto
            {
                ProductoId = 3,
                Descripcion ="Cajuil salado",
                Costo = 60,
                Precio = 90,
                Existencia = 5,
                


            },
             new Producto
            {
                ProductoId = 4,
                Descripcion ="Almendras",
                Costo = 33,
                Precio = 50,
                Existencia = 2,
                


            },
            new Producto
            {
                ProductoId = 5,
                Descripcion ="Sobre Mixto",
                Costo= 200,
                Precio = 300,
                Existencia = 0
            }
       
        );


    }


}