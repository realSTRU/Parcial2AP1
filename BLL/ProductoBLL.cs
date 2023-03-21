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
        return _context.Producto.ToList();
    }

    public List<Producto> GetListWithParameter(Expression<Func<Producto, bool>> query)
    {
        return _context.Producto.AsNoTracking().Where(query).ToList();
    }

    public Producto? Buscar(int ProductoId)
    {
        return _context.Producto.Find(ProductoId);
    }


}