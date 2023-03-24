using Homework1.Data.Context;
using Homework1.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    
    public readonly AppDbContext context;
    private DbSet<TEntity> entities;
    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        this.entities = this.context.Set<TEntity>();    
    }
    public List<TEntity> GetAll()
    {
        return entities.ToList();
    }

    

    public TEntity GetByID(int id)
    {
        return entities.Find(id);
    }

    public void Insert(TEntity entity)
    {
        entities.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        entities.Remove(entity);
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        entities.Update(entity);
        //entities.ToList().Where()
    }
    public void Filter(TEntity entity, string name)
    {

        //entities.Where(FirstName == name).FirstOrDefault();
        //GetAll().Where(x => x.FirstName == name).FirstOrDefault();
        //entity.Where(x => x.FirstName == name).FirstOrDefault();
        //entity
        //GetAll().Where(x => x.Id == id).FirstOrDefault();



    }

}
