app.factory('usersService', function ($http) {
    var fac = {};

    // get all users
    fac.getUsers = function (d) {
        return $http({ url: 'Admin/GetAllUsers' });
    }

    // get User by userId
    fac.getUser = function (userId) {
        var response = $http({
            method: "post",
            url: "Admin/GetUserById",
            params: {
                id: JSON.stringify(userId)
            }
        });
        return response;
    }

    // Add User
    fac.AddUser = function (user) {
        var response = $http({
            method: "post",
            url: "Admin/AddUser",
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    }

    // Update Book 
    fac.updateUser = function (user) {
        var response = $http({
            method: "post",
            url: "Admin/UpdateUser",
            data: JSON.stringify(user),
            dataType: "json"
        });
        return response;
    }

    // Delete User
    fac.deleteUser = function (userId) {
        var response = $http({
            method: "post",
            url: "Admin/DeleteUser",
            params: {
                userId: JSON.stringify(userId)
            }
        });
        return response;
    }

    return fac;
});
