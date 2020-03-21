"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var operators_1 = require("rxjs/operators");
function emailUnique(userService) {
    return function (control) {
        return userService.getUserByEmail(control.value).pipe(operators_1.map(function (responce) {
            return (responce.length > 0) ? { uniqueEmail: true } : null;
        }));
    };
}
exports.emailUnique = emailUnique;
//# sourceMappingURL=emailAsync.validators.js.map