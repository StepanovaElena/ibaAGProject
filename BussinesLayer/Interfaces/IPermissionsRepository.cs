using DataLayer;
using System.Collections.Generic;

namespace BussinesLayer.Interfaces
{
    public interface IPermissionsRepository
    {
        IEnumerable<Permissions> GetAllPermissions();
        Permissions GetPermissionById(int permissionId);
    }
}
