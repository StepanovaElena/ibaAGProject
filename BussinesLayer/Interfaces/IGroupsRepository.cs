using DataLayer.Entity;
using System.Collections.Generic;

namespace BussinesLayer.Interfaces
{
    public interface IGroupsRepository
    {
        IEnumerable<Groups> GetAllGroups();
        Groups GetGroupById(int groupId);
        Groups GetGroupByName(string groupName);
        int SaveGroup(Groups group);
        void DeleteGroup(Groups group);
        void DeleteEntity<TEntity>(TEntity entity);
        void AddEntity<TEntity>(TEntity entity);
    }
}
