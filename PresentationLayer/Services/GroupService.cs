using BussinesLayer;
using DataLayer.Entity;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Services
{
    public class GroupService
    {
        private DataManager _dataManager;

        public GroupService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public GroupModel GetGroupById(int groupId)
        {
            var _groupsDbModel = _dataManager.Groups.GetGroupById(groupId);
            return this.DbModelToModel(_groupsDbModel);
        }

        public GroupModel GetGroupByName(string name)
        {
            var _groupDbModel = _dataManager.Groups.GetGroupByName(name);
            return this.DbModelToModel(_groupDbModel);
        }

        public List<GroupModel> GetAllGroups()
        {
            var _groups = _dataManager.Groups.GetAllGroups();
            List<GroupModel> _modelsList = new List<GroupModel>();
            foreach (var item in _groups)
            {
                _modelsList.Add(GetGroupById(item.Id));
            }
            return _modelsList;
        }

        public int GroupCreateOrUpdate(GroupModel groupModel)
        {
            Groups _groupsDbModel;
            if (groupModel.Id != 0)
                _groupsDbModel = this.UpdateGroup(groupModel);
            else
                _groupsDbModel = this.CreateGroup(groupModel);

            return _dataManager.Groups.SaveGroup(_groupsDbModel);
        }

        public bool GroupDelete(int groupId)
        {
            Groups _groupsDbModel = _dataManager.Groups.GetGroupById(groupId);
            if (_groupsDbModel != null & _groupsDbModel.CanBeDeleted == true)
            {
                _dataManager.Groups.DeleteGroup(_groupsDbModel);
                return true;
            }
            return false;
        }

        private GroupModel DbModelToModel(Groups groupsDbModel)
        {
            if (groupsDbModel == null)            
                return new GroupModel { };

            int _lengthPermissions = groupsDbModel.Permissions.Count;
            int[] _permissions = new int[_lengthPermissions];
            int i = 0;
            int j = 0;

            foreach (var item in groupsDbModel.Permissions)
            {
                if (i < _lengthPermissions)
                {
                    _permissions[i] = item.PermissionsId;
                    i++;
                }
            }

            int _lengthMembers = groupsDbModel.Users.Count;
            int[] _users = new int[_lengthMembers];

            foreach (var item in groupsDbModel.Users)
            {
                if (j < _lengthMembers)
                {
                    _users[j] = item.UsersId;
                    j++;
                }
            }

            GroupModel _groupModel = new GroupModel()
            {
                Id = groupsDbModel.Id,
                Name = groupsDbModel.Name,
                Permissions = _permissions,
                Membership = _users
            };

            return _groupModel;
        }

        private Groups CreateGroup(GroupModel groupModel)
        {
            Groups _groupsDbModel = new Groups();
            _groupsDbModel.Name = groupModel.Name;
            foreach (var item in groupModel.Permissions)
            {
                _groupsDbModel.Permissions.Add(new GroupsPermissions { PermissionsId = item });
            }

            foreach (var item in groupModel.Membership)
            {
                _groupsDbModel.Users.Add(new UsersGroups { UsersId = item });
            }

            return _groupsDbModel;
        }

        private Groups UpdateGroup(GroupModel groupModel)
        {
            Groups _groupsDbModel = _dataManager.Groups.GetGroupById(groupModel.Id);

            for (int i = groupModel.Permissions.Length - 1; i >= 0; i--)
            {
                if (!_groupsDbModel.Permissions.Exists(x => x.PermissionsId == groupModel.Permissions[i]))
                    _dataManager.Groups.AddEntity<GroupsPermissions>(new GroupsPermissions
                    {
                        PermissionsId = groupModel.Permissions[i],
                        GroupsId = groupModel.Id,
                        Groups = _groupsDbModel
                    });
            }
            for (int i = _groupsDbModel.Permissions.Count - 1; i >= 0; i--)
            {
                if (!groupModel.Permissions.Contains(_groupsDbModel.Permissions[i].PermissionsId))
                    _dataManager.Groups.DeleteEntity<GroupsPermissions>(_groupsDbModel.Permissions[i]);
            }
            for (int i = groupModel.Membership.Length - 1; i >= 0; i--)
            {
                if (!_groupsDbModel.Users.Exists(x => x.UsersId == groupModel.Membership[i]))
                    _dataManager.Groups.AddEntity<UsersGroups>(new UsersGroups
                    {
                        UsersId = groupModel.Membership[i],
                        GroupsId = groupModel.Id,
                        Groups = _groupsDbModel
                    });
            }
            for (int i = _groupsDbModel.Users.Count - 1; i >= 0; i--)
            {
                if (!groupModel.Membership.Contains(_groupsDbModel.Users[i].UsersId))
                    _dataManager.Groups.DeleteEntity<UsersGroups>(_groupsDbModel.Users[i]);
            }
            return _groupsDbModel;
        }
    }
}
