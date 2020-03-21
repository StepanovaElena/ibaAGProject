using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BussinesLayer.Implementations
{
    public class EFUsersRepository : IUsersRepository
    {
        private EFDBContext context;

        public EFUsersRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return context.Users.Include(x => x.Groups).Include(y => y.Permissions).ToList();
        }

        public Users GetUserById(int userId)
        {
            return context.Set<Users>()
                .Include(x => x.Groups)
                .Include(y => y.Permissions)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == userId);            
        }

        public Users GetUserByEmail(string email)
        {
           return context.Users.Where(c => c.Email.ToLower().Equals(email.ToLower())).FirstOrDefault();
        }

        public Users GetUsersByEmailPassword(string email, string password)
        {
            return context.Users
                .Where(c => c.Email.ToLower().Contains(email.ToLower()))
                .FirstOrDefault(x => x.Password == password);
        }

        public int SaveUser(Users user)
        {
            if (user.Id == 0)
                context.Users.Add(user);
            else
                context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(Users user)
        {
            context.Users.Remove(user);
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
