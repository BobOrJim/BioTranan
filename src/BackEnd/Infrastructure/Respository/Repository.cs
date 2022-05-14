using Common.Entities;
using Common.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Respository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        
        private readonly TrananDbContext _trananDbContext;
        private DbSet<T> genericTable;

        public Repository(TrananDbContext trananDbContext)
        {
            _trananDbContext = trananDbContext;
            genericTable = _trananDbContext.Set<T>();
        }


        //Create
        public async Task<bool> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                await genericTable.AddAsync(entity);
                return (await _trananDbContext.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }


        //Read
        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                return await genericTable.FindAsync(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        
        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await genericTable.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }


        
        //Update
        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                genericTable.Update(entity);
                return (await _trananDbContext.SaveChangesAsync()) > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        
        //Delete
        public async Task<bool> DeleteAsync(Guid id)
        {

            //Is correct Guid
            if (id == Guid.Empty)
                throw new ArgumentNullException("id");

            try
            {
                T? entity = await genericTable.FindAsync(id);
                if (entity == null)
                    return false;

                genericTable.Remove(entity);
                return (await _trananDbContext.SaveChangesAsync() > 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }


        private Expression<Func<T, bool>> hej = (T t) => t.Id == Guid.Empty;

        private Func<T, bool> hej2 = (T t) => t.Id == Guid.Empty;
        

        //Labb area med kod från Ola.
        private void test(T mittT)
        {
            bool kalle = hej2(mittT);

            bool kalle2 = hej.Compile()(mittT);


            var a = SearchSpecificEntity(x => x.Id == Guid.Parse("8c9d8f5c-f8f4-4f7f-b8e8-f8f8f8f8f8f8"));
            var b = SearchSpecificEntity(LastNumberIsAn8(mittT));
        }

        //Generic search med func
        //Skillnaden mellan Expression func och func nedan.
        //https://stackoverflow.com/questions/793571/why-would-you-use-expressionfunct-rather-than-funct
        public async Task<T?> SearchSpecificEntity(Expression<Func<T, bool>> filter)
        {
            return await genericTable.FirstOrDefaultAsync(filter);
        }

        private Expression<Func<T, bool>> LastNumberIsAn8(T id)
        {
            return (x) => id.Id.ToString().Substring(id.Id.ToString().Length - 1) == "8";
        }


    }
}
