using BussinesLayer;
using DataLayer.Entity;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Services
{
    public class UserService
    {
        private DataManager _dataManager;

        public UserService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public List<UserModel> GetAllUsers()
        {
            var _users = _dataManager.Users.GetAllUsers();
            List<UserModel> _modelsList = new List<UserModel>();
            foreach (var user in _users)
            {
                _modelsList.Add(GetUserById(user.Id));
            }
            return _modelsList;
        }

        public UserModel GetUserById(int userId)
        {
            Users _usersDbModel = _dataManager.Users.GetUserById(userId);
            return this.DbModelToModel(_usersDbModel);
        }

        public UserModel GetUserByEmail(string email)
        {
            var _usersDbModel = _dataManager.Users.GetUserByEmail(email);
            return this.DbModelToModel(_usersDbModel);
        }

        public int UserCreateOrUpdate(UserModel userModel)
        {
            Users _usersDbModel;
            if (userModel.Id != 0)
                _usersDbModel = this.UpdateUser(userModel);
            else
                _usersDbModel = this.CreateUser(userModel);

            return _dataManager.Users.SaveUser(_usersDbModel);
        }

        public bool UserDelete(int userId)
        {
            Users _usersDbModel = _dataManager.Users.GetUserById(userId);
            if (_usersDbModel != null & _usersDbModel.CanBeDeleted == true)
            {
                _dataManager.Users.DeleteUser(_usersDbModel);
                return true;
            }
            return false;
        }

        private UserModel DbModelToModel(Users usersDbModel)
        {
            if (usersDbModel == null)
                return new UserModel { };

            int _lengthPermissions = usersDbModel.Permissions.Count;
            int[] _permissions = new int[_lengthPermissions];
            int i = 0;
            int j = 0;

            foreach (var item in usersDbModel.Permissions)
            {
                if (i < _lengthPermissions)
                {
                    _permissions[i] = item.PermissionsId;
                    i++;
                }
            }

            int _lengthMembers = usersDbModel.Groups.Count;
            int[] _groups = new int[_lengthMembers];

            foreach (var group in usersDbModel.Groups)
            {
                if (j < _lengthMembers)
                {
                    _groups[j] = group.GroupsId;
                    j++;
                }
            }

            UserModel _userModel = new UserModel()
            {
                Id = usersDbModel.Id,
                Login = usersDbModel.Login,
                Email = usersDbModel.Email,
                Password = usersDbModel.Password,
                Permissions = _permissions,
                Membership = _groups
            };

            return _userModel;
        }

        private Users CreateUser(UserModel userModel)
        {
            Users _usersDbModel = new Users() 
            { 
                Login = userModel.Login,
                Password = userModel.Password,
                Email = userModel.Email,
            };            

            foreach (var item in userModel.Permissions)
            {
                _usersDbModel.Permissions.Add(new UsersPermissions { PermissionsId = item });
            }

            foreach (var item in userModel.Membership)
            {
                _usersDbModel.Groups.Add(new UsersGroups { GroupsId = item });
            }

            return _usersDbModel;
        }

        private Users UpdateUser(UserModel userModel)
        {
            Users _usersDbModel = _dataManager.Users.GetUserById(userModel.Id);

            for (int i = userModel.Permissions.Length - 1; i >= 0; i--)
            {
                if (!_usersDbModel.Permissions.Exists(x => x.PermissionsId == userModel.Permissions[i]))
                    _dataManager.Users.AddEntity<UsersPermissions>(new UsersPermissions
                    {
                        PermissionsId = userModel.Permissions[i],
                        UsersId = _usersDbModel.Id,
                        Users = _usersDbModel
                    });
            }
            for (int i = _usersDbModel.Permissions.Count - 1; i >= 0; i--)
            {
                if (!userModel.Permissions.Contains(_usersDbModel.Permissions[i].PermissionsId))
                    _dataManager.Users.DeleteEntity<UsersPermissions>(_usersDbModel.Permissions[i]);
            }
            for (int i = userModel.Membership.Length - 1; i >= 0; i--)
            {
                if (!_usersDbModel.Groups.Exists(x => x.GroupsId == userModel.Membership[i]))
                    _dataManager.Users.AddEntity<UsersGroups>(new UsersGroups
                    {
                        UsersId = _usersDbModel.Id,
                        GroupsId = userModel.Membership[i],
                        Users = _usersDbModel
                    });
            }
            for (int i = _usersDbModel.Groups.Count - 1; i >= 0; i--)
            {
                if (!userModel.Membership.Contains(_usersDbModel.Groups[i].UsersId))
                    _dataManager.Users.DeleteEntity<UsersGroups>(_usersDbModel.Groups[i]);
            }
            return _usersDbModel;
        }

    }
}
