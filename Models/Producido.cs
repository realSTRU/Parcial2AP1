using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Producido
{
    [Key]
    public int ProducidoId { get; set; }

    [Required(ErrorMessage = "La Fecha es un campo obligatorio.")]
    public DateOnly Fecha {get; set;} = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "El concepto es obligatorio")]
    public string Concepto {get; set;}

    [ForeignKey("ProducidoId")]
    public List<ProducidoDetalle> ProducidoDetalle {get; set;} = new List<ProducidoDetalle>();




}

public class ProducidoDetalle 
{
    [Key]
    public int DetalleId {get; set;}
    public int ProducidoId {get; set;}

    public int ProductoId {get; set;}

    public int Cantidad {get; set;}

   

    

    

 

}