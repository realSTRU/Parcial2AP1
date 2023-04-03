using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class ProductoBLL
{

    private Contexto _context;

    public ProductoBLL(Contexto contexto)
    {
        this._context = contexto;
    }

    public bool Existe(int ProductoId)
    {
        return _context.Producto.Any(p => p.ProductoId == ProductoId);
    }

    public List<Producto> GetList()
    {
        return _context.Producto.AsNoTracking().ToList();
    }

    public List<Producto> GetListWithParameter(Expression<Func<Producto, bool>> query)
    {
        return _context.Producto.AsNoTracking().Where(query).ToList();
    }

    public Producto? Buscar(int ProductoId)
    {
        return _context.Producto.Find(ProductoId);
    }

    public bool Guardar(Producto producto)
    {
        if(!Existe(producto.ProductoId))
        {
           return Guardar(producto);
        }
        else
        {
            return Modificar(producto);
        }
    }

    public bool Insertar(Producto producto)
    {
        _context.Producto.Add(producto);

        bool guardo = _context.SaveChanges() > 0;

        _context.Entry(producto).State = EntityState.Detached;

        return guardo;
    }

    public bool Modificar(Producto producto)
    {   
        _context.Producto.Update(producto);
        bool guardo = _context.SaveChanges() > 0;

        _context.Entry(producto).State = EntityState.Detached;

        return guardo;
    }


}