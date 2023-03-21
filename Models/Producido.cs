using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Producido
{
    [Key]
    public int ProducidoId { get; set; }

    public DateOnly Fecha {get; set;} = DateOnly.FromDateTime(DateTime.Now);

    public string Concepto {get; set;}

    public int cantidad {get; set;}

    [ForeignKey("ProducidoId")]
    public List<ProducidoDetalle> ProducidoDetalle {get; set;} = new List<ProducidoDetalle>();




}

public class ProducidoDetalle 
{
    [Key]
    public int ProducidoId {get; set;}

    public int ProductoId {get; set;}

    public int Cantidad {get; set;}

}