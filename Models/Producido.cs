using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Producido
{
    [Key]
    public int ProducidoId { get; set; }

    [Required(ErrorMessage = "La Fecha es un campo obligatorio.")]
    public DateTime Fecha {get; set;} = DateTime.Now;

    [Required(ErrorMessage = "El concepto es obligatorio")]
    public string Concepto {get; set;}

    [Required(ErrorMessage ="El producto a producir es requerido.")]
    public int ProductoId {get; set;}

    [Required(ErrorMessage ="La cantiad a producir es requerida")]
    public int cantidad {get; set;}

    [ForeignKey("ProducidoId")]
    public List<ProducidoDetalle> ProducidoDetalle {get; set;} = new List<ProducidoDetalle>();




}

public class ProducidoDetalle 
{
    [Key]
    public int DetalleId {get; set;}
    public int ProducidoId {get; set;}

    [Required(ErrorMessage = "El detalle debe de contener un producto especificado")]
    public int ProductoId {get; set;}

    [Required(ErrorMessage = "El detalle debe de tener una cantidad especificada")]
    public int Cantidad {get; set;}

   

    

    

 

}