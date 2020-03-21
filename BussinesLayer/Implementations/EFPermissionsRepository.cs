using BussinesLayer.Interfaces;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinesLayer.Implementations
{
    public class EFPermissionsRepository: IPermissionsRepository
    {
        private EFDBContext context;

        public EFPermissionsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Permissions> GetAllPermissions()
        {
            return context.Permissions.ToList();
        }                
        
        public Permissions GetPermissionById(int permissionId)
        {
            return context.Permissions.FirstOrDefault(x => x.Id == permissionId);
        }
    }
}
