using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Producto
{
    [Key]

    public int ProductoId {get; set;}

    public string? Descripcion { get; set; }

    public double Costo {get; set;}

    public double Precio {get; set;}

    public int Existencia {get; set;}

    public Producto()
    {
        
        Existencia = 0;
    }


        
    
}