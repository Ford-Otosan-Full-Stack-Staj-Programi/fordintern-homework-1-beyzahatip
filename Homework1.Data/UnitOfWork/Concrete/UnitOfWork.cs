using Homework1.Data.Context;
using Homework1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext context;
        private bool disposed;
        public IGenericRepository<Staff> StaffRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            StaffRepository = new GenericRepository<Staff>(context);
        }
        //public void CompleteWithTransaction()
        //{
        //    using (var dbContextTransaction = context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            context.SaveChanges();
        //            dbContextTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            // logging                    
        //            dbContextTransaction.Rollback();
        //        }
        //    }
        //}

        public List<Staff> Filter(string city, string province)
        {
            List<Staff> staff = StaffRepository.GetAll();

            var filtered = staff.Where(staff => staff.City.Equals(city) && staff.Province.Equals(province)).ToList();


            return (List<Staff>)filtered;
        }


        public void Complete()
        {
            context.SaveChanges();
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
