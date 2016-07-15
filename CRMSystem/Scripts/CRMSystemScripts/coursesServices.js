app.factory('coursesService', function ($http) {
    var fac = {};

    // get all courses
    fac.getCourses = function (d) {
        return $http({ url: 'Admin/GetAllCourses' });
    }

    // get Course by CourseId
    fac.getCourse = function (courseId) {
        var response = $http({
            method: "post",
            url: "Admin/GetCourseById",
            params: {
                id: JSON.stringify(courseId)
            }
        });
        return response;
    }

    // Add Course
    fac.AddCourse = function (course) {
        var response = $http({
            method: "post",
            url: "Admin/AddCourse",
            data: JSON.stringify(course),
            dataType: "json"
        });
        return response;
    }

    // Update Course 
    fac.updateCourse = function (course) {
        var response = $http({
            method: "post",
            url: "Admin/UpdateCourse",
            data: JSON.stringify(course),
            dataType: "json"
        });
        return response;
    }

    // Delete User
    fac.deleteCourse = function (courseId) {
        var response = $http({
            method: "post",
            url: "Admin/DeleteCourse",
            params: {
                courseId: JSON.stringify(courseId)
            }
        });
        return response;
    }

    return fac;
});
