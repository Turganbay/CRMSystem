app.factory('subscriptionService', function ($http) {
    var fac = {};

    // get All User Events Ids
    fac.getUserEventsIds = function (userId) {
        var response = $http({
            method: "post",
            url: "Admin/GetUserEventsIds",
            params: {
                id: JSON.stringify(userId)
            }
        });
        return response;
    }

    // Add Subscription
    fac.AddSubscription = function (userId, eventId) {
        var response = $http({
            method: "post",
            url: "Admin/AddSubscription",
            params: {
                userId: JSON.stringify(userId),
                eventId: JSON.stringify(eventId),
            },
            dataType: "json"
        });
        return response;
    }

    // Delete Subscription

    fac.deleteSubscription = function (userId, eventId) {
        var response = $http({
            method: "post",
            url: "Admin/DeleteSubscription",
            params: {
                userId: JSON.stringify(userId),
                eventId: JSON.stringify(eventId),
            }
        });
        return response;
    }

    // get all subscriptions
    fac.getSubscriptions = function (d) {
        return $http({ url: 'Admin/GetAllSubscriptions' });
    }
    

    /*
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
    */
    return fac;
});
