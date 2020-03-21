"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var forms_1 = require("@angular/forms");
var GroupShared = /** @class */ (function () {
    function GroupShared() {
        this.permissions = [];
        this.users = [];
    }
    GroupShared.createFormControl = function (id) {
        return new forms_1.FormControl(id);
    };
    Object.defineProperty(GroupShared.prototype, "permissionsArray", {
        get: function () {
            return this.form.get('permissions');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(GroupShared.prototype, "membershipArray", {
        get: function () {
            return this.form.get('membership');
        },
        enumerable: true,
        configurable: true
    });
    GroupShared.prototype.addRemovePermission = function (e, id) {
        (e.target.checked) ? this.addPermission(id) : this.deletePermission(id);
    };
    GroupShared.prototype.addRemoveMembership = function (e, id) {
        (e.target.checked) ? this.addMembership(id) : this.deleteMembership(id);
    };
    GroupShared.prototype.addPermission = function (id) {
        this.permissionsArray.push(GroupShared.createFormControl(id));
    };
    GroupShared.prototype.deletePermission = function (id) {
        var _this = this;
        var i = 0;
        this.permissionsArray.controls.forEach(function (item) {
            if (item.value === id) {
                _this.permissionsArray.removeAt(i);
                return;
            }
            i++;
        });
    };
    GroupShared.prototype.addMembership = function (id) {
        this.membershipArray.push(GroupShared.createFormControl(id));
    };
    GroupShared.prototype.deleteMembership = function (id) {
        var _this = this;
        var i = 0;
        this.membershipArray.controls.forEach(function (item) {
            if (item.value === id) {
                _this.membershipArray.removeAt(i);
                return;
            }
            i++;
        });
    };
    return GroupShared;
}());
exports.GroupShared = GroupShared;
//# sourceMappingURL=group-shared.js.map