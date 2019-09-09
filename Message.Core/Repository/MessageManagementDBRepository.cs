using Message.Core.Models;
using Message.Entity.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Core.Repository
{
    public abstract class MessageManagementDBRepository<TEntity> : BaseRepository<TEntity> where TEntity : class, new()
    {
        //public override DbContext GetDB()
        //{
        //    MessageManagementContext _messageManagementContext = AppDependencyResolver.Current.GetService<MessageManagementContext>();
        //    return _messageManagementContext;
        //}
        public MessageManagementDBRepository() : base(AppDependencyResolver.Current.GetService<MessageManagementContext>())
        {
        }

    }
}
