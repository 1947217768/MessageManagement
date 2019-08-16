using Message.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Message.Core.Repository
{
    public interface IMessageManagementRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
    }
}
