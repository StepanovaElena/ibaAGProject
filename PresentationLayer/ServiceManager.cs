using BussinesLayer;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private GroupService _groupService;
        private UserService _userService;
        private AuthService _authService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _groupService = new GroupService(_dataManager);
            _userService = new UserService(_dataManager);
            _authService = new AuthService(_dataManager);
        }
        public GroupService Groups { get { return _groupService; } }
        public UserService Users { get { return _userService; } }
        public AuthService Auth { get { return _authService; } }
    }
}
