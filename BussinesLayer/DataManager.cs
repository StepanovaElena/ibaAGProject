using BussinesLayer.Interfaces;

namespace BussinesLayer
{
    public class DataManager
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IGroupsRepository _groupsRepository;
        private readonly IPermissionsRepository _permissionsRepository;

        public DataManager(
            IUsersRepository usersRepository, 
            IGroupsRepository groupsRepository, 
            IPermissionsRepository permissionsRepository)
        {
            _usersRepository = usersRepository;
            _groupsRepository = groupsRepository;
            _permissionsRepository = permissionsRepository;
        }

        public IUsersRepository Users { get { return _usersRepository; } }
        public IGroupsRepository Groups { get { return _groupsRepository; } }
        public IPermissionsRepository Permissions { get { return _permissionsRepository; } }
    }
}
