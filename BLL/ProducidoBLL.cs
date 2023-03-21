using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


public class ProducidoBLL
{

    private Contexto _contexto;

    public ProducidoBLL(Contexto contexto)
    {
        this._contexto = contexto;
    }

    public bool Existe(int ProducidoId)
    {
        try
        {
            return _contexto.Producido.Any(p => p.ProducidoId == ProducidoId);
        }
        catch
        {
            throw;
        }
        
    }

    public bool Insertar(Producido producido)
    {
        Console.WriteLine("entre a insertar \n\n\n\n\n\n\n\n\n\n\n\n");
        try
        {
            if(producido != null)
            {
                
                if(producido.ProducidoDetalle != null)
                {
                   
                    foreach(var item in producido.ProducidoDetalle)
                    {
                        var producto = _contexto.Producto.Find(item.ProductoId);

                        if(producto != null)
                        {
                            producto.Existencia -= item.Cantidad;
                            _contexto.Entry(producto).State = EntityState.Modified;
                        }
                    }
                    
                }
                
                
                _contexto.Producido.Add(producido);
                
                bool paso =_contexto.SaveChanges() > 0;
                _contexto.Entry(producido).State =EntityState.Detached;
                return paso;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }
    }

    public bool Modificar(Producido producido)
    {
        try{
            if(producido != null)
            {
                var ProducidoAnterior = 
                _contexto.Producido
                .Where(p => p.ProducidoId == producido.ProducidoId)
                .Include(p => p.ProducidoDetalle)
                .AsNoTracking()
                .SingleOrDefault();

                if(ProducidoAnterior != null)
                {
                    foreach(var item in ProducidoAnterior.ProducidoDetalle)
                    {
                        var producto = _contexto.Producto.Find(item.ProductoId);

                        if(producto != null)
                        {
                            producto.Existencia += item.Cantidad;
                            _contexto.Entry(producto).State = EntityState.Modified;
                        }

                    }
                }
                if(producido != null)
                {
                    foreach(var item in producido.ProducidoDetalle)
                    {
                        var producto = _contexto.Producto.Find(item.ProductoId);

                        if(producto != null)
                        {
                            producto.Existencia -= item.Cantidad;
                            _contexto.Entry(producto).State = EntityState.Modified;
                            
                        }
                    }
                }

                var DetallesAModificar = _contexto.Set<ProducidoDetalle>().Where(p => p.ProducidoId == producido.ProducidoId);
                _contexto.Set<ProducidoDetalle>().RemoveRange(DetallesAModificar);
                _contexto.Entry(producido).State = EntityState.Modified;

                return _contexto.SaveChanges() > 0;
                

                


            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }
    }

    public bool Eliminar(Producido producido)
    {
        try{
            if(producido != null)
            {
                    var ProducidoAnterior = 
                    _contexto.Producido
                    .Where(p => p.ProducidoId == producido.ProducidoId)
                    .Include(p => p.ProducidoDetalle)
                    .AsNoTracking()
                    .SingleOrDefault();

                if(ProducidoAnterior != null)
                {
                    foreach(var item in ProducidoAnterior.ProducidoDetalle)
                    {
                        var producto = _contexto.Producto.Find(item.ProductoId);

                        if(producto != null)
                        {
                            producto.Existencia += item.Cantidad;
                            _contexto.Entry(producto).State = EntityState.Modified;
                        }

                    }
                }

                var DetallesAEliminar = _contexto.Set<ProducidoDetalle>().Where(p => p.ProducidoId == producido.ProducidoId);
                _contexto.Set<ProducidoDetalle>().RemoveRange(DetallesAEliminar);
                _contexto.Entry(producido).State = EntityState.Deleted;

                return _contexto.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

                


        }
        catch
        {
            throw;
        }
    }

    public List<Producido> GetList()
    {
        return _contexto.Producido.ToList();
    }

    public List<Producido> GetListWithParameter(Expression<Func<Producido, bool>> query){
        return _contexto.Producido.AsNoTracking().Where(query).ToList();
    }

    public Producido? Buscar(int ProducidoId)
    {
        return _contexto.Producido.Where(o=>o.ProducidoId==ProducidoId)
        .Include(o=>o.ProducidoDetalle)
        .AsNoTracking()
        .SingleOrDefault();
    }
    

    public bool Guardar(Producido producido)
    {
        if(!Existe(producido.ProducidoId))
        {
            return Insertar(producido);
        }
        else
        {
            return Modificar(producido);
        }
    }
}