app.factory('eventsService', function ($http) {
    var fac = {};

    // get all Events
    fac.getEvents = function (d) {
        return $http({ url: 'Admin/GetAllEvents' });
    }

    // get Event by userId
    fac.getEvent = function (eventId) {
        var response = $http({
            method: "post",
            url: "Admin/GetEventById",
            params: {
                id: JSON.stringify(eventId)
            }
        });
        return response;
    }

    // Add Event
    fac.AddEvent = function (event) {
        var response = $http({
            method: "post",
            url: "Admin/AddEvent",
            data: JSON.stringify(event),
            dataType: "json"
        });
        return response;
    }

    // Update Event 
    fac.updateEvent = function (event) {
        var response = $http({
            method: "post",
            url: "Admin/UpdateEvent",
            data: JSON.stringify(event),
            dataType: "json"
        });
        return response;
    }

    // Delete User
    fac.deleteEvent = function (eventId) {
        var response = $http({
            method: "post",
            url: "Admin/DeleteEvent",
            params: {
                eventId: JSON.stringify(eventId)
            }
        });
        return response;
    }

    return fac;
});
