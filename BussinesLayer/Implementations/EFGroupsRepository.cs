using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BussinesLayer.Implementations
{
    public class EFGroupsRepository :  IGroupsRepository
    {

        private EFDBContext context;
        
        public EFGroupsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Groups> GetAllGroups()
        {
            return context.Groups.ToList();
        }

        public Groups GetGroupById(int groupId)
        {
            return context.Set<Groups>()
                .Include(x => x.Users)
                .Include(y => y.Permissions)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == groupId);
        }

        public Groups GetGroupByName(string groupName)
        {
            return context.Groups.Where(c => c.Name.ToLower().Equals(groupName.ToLower())).FirstOrDefault();
        }

        public int SaveGroup(Groups group)
        {
            if (group.Id == 0)
                context.Groups.Add(group);
            else
                context.Entry(group).State = EntityState.Modified;            
            context.SaveChanges();
            return group.Id;
        }

        public void DeleteGroup(Groups group)
        {
            context.Groups.Remove(group);
            context.SaveChanges();
        }

        public void DeleteEntity<TEntity>(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void AddEntity<TEntity>(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }
    }
}
