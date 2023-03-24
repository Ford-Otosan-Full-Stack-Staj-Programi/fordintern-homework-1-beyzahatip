using Homework1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Data;

public interface IUnitOfWork: IDisposable
{
    IGenericRepository<Staff> StaffRepository { get; }
    List<Staff> Filter(string city, string province );
    void Complete();
}
