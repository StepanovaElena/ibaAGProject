using DataLayer.Entity;
using System.Collections.Generic;

namespace BussinesLayer.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUserById(int userId);
        Users GetUserByEmail(string email);
        Users GetUsersByEmailPassword(string email, string password);
        int SaveUser(Users user);
        void DeleteUser(Users user);
        void DeleteEntity<TEntity>(TEntity entity);
        void AddEntity<TEntity>(TEntity entity);
    }
}
