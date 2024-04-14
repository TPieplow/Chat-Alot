using Chat_Alot_Library.DbContext;
using Chat_Alot_Library.Factories;
using Chat_Alot_Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Chat_Alot_Library.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual async Task<ResponseResult> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(entity);
        }
        catch (Exception ex) { return ResponseFactory.InternalError(ex.Message); }
    }

    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is null)
            {
                return ResponseFactory.NotFound();
            }
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex) { return ResponseFactory.InternalError(ex.Message); }
    }

    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            if (result is null)
            {
                return ResponseFactory.NotFound(typeof(TEntity).Name);
            }
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex) { return ResponseFactory.InternalError(ex.Message); }
    }

    public virtual async Task<ResponseResult> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
                _context.Entry(result).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(result);
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex) { return ResponseFactory.InternalError(ex.Message); }
    }

    public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if ( result is not null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok("Removed");
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex) { return ResponseFactory.InternalError(ex.Message); }
    }

    public virtual async Task<ResponseResult> AlreadyExists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().AnyAsync(predicate);
            if (result)
            {
                return ResponseFactory.Exists();
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex) { return ResponseFactory.InternalError(ex.Message); }
    }
}
