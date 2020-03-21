"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var operators_1 = require("rxjs/operators");
function nameUnique(groupService) {
    return function (control) {
        return groupService.getGroupByName(control.value).pipe(operators_1.map(function (responce) {
            return (responce.length > 0) ? { uniqueName: true } : null;
        }));
    };
}
exports.nameUnique = nameUnique;
//# sourceMappingURL=nameAsync.validators.js.map