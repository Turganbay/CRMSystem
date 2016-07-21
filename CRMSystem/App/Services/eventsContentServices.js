app.factory('eventsContentService', function ($http) {
    var fac = {};


    // get All events with course for users

    fac.getEventsWithCourse = function (d) {
        return $http({ url: 'Admin/GetEventsWithCourse' });
    }


    // get all EventsContent
    fac.getEventsContents = function (d) {
        return $http({ url: 'Admin/GetAllEventsContents' });
    }

    // get Content by ContentId
    fac.getContent = function (contentId) {
        var response = $http({
            method: "post",
            url: "Admin/GetContentById",
            params: {
                id: JSON.stringify(contentId)
            }
        });
        return response;
    }

    // Add Content
    fac.AddContent = function (content) {
        var response = $http({
            method: "post",
            url: "Admin/AddContent",
            data: JSON.stringify(content),
            dataType: "json"
        });
        return response;
    }

    // Update Content 
    fac.updateContent = function (content) {
        var response = $http({
            method: "post",
            url: "Admin/UpdateContent",
            data: JSON.stringify(content),
            dataType: "json"
        });
        return response;
    }

    // Delete Content
    fac.deleteContent = function (contentId) {
        var response = $http({
            method: "post",
            url: "Admin/DeleteContent",
            params: {
                contentId: JSON.stringify(contentId)
            }
        });
        return response;
    }

    return fac;
});
