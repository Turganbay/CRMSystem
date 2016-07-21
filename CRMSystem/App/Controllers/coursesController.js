(function () {
    var chat = $.connection.crmHub;

    app.controller('coursesController', function ($scope, coursesService) {

        $scope.divCourse = false;
        GetAllCourses();

        // GET ALL Courses 
        function GetAllCourses() {
            var getCoursesData = coursesService.getCourses();
            getCoursesData.then(function (course) {
                $scope.courses = course.data
            }, function () {
                alert('Error in getting user record');
            });
        }

        // GET UPDATE USER
        $scope.editCourse = function (course) {
            var getCourseData = coursesService.getCourse(course.id);
            getCourseData.then(function (_course) {
                //$scope.course = _course.data;
                $scope.courseId = course.id;
                $scope.courseName = course.name;
                $scope.courseDescription = course.description;
                $scope.Action = "Update";
                $scope.divCourse = true;
            }, function () {
                alert('Error in getting book records');
            });
        }

        // Add OR UPDATE User
        chat.client.refreshCourses = function () {
            GetAllCourses();
            console.log('all ok');
        }

        $.connection.hub.start().done(function () {

            $scope.AddUpdateCourse = function () {
                var Course = {
                    name: $scope.courseName,
                    description: $scope.courseDescription
                };
                var getCourseAction = $scope.Action;

                if (getCourseAction == "Update") {
                    Course.Id = $scope.courseId;
                    var getCourseData = coursesService.updateCourse(Course);
                    getCourseData.then(function (msg) {
                        // GetAllUsers();
                        chat.server.refreshCoursesList();
                        console.log(msg.data);
                        $scope.divCourse = false;
                    }, function () {
                        alert('Error in updating book record');
                    });
                } else {
                    var getCourseData = coursesService.AddCourse(Course);
                    getCourseData.then(function (msg) {
                        chat.server.refreshCoursesList();
                        $scope.divCourse = false;
                    }, function () {
                        alert('Error in adding book record');
                    });
                }
            }

        });


        // Add Div open
        $scope.AddCourseDiv = function () {
            ClearFields();
            $scope.Action = "Add";
            $scope.divCourse = true;
        }

        // Delete User
        $scope.deleteCourse = function (course) {
            var getCourseData = coursesService.deleteCourse(course.id);
            getCourseData.then(function (msg) {
                console.log(msg.data);
                //GetAllUsers();
                chat.server.refreshCoursesList();
            }, function () {
                alert('Error in deleting book record');
            });
        }


        // clear field
        function ClearFields() {
            $scope.userId = "";
            $scope.userUsername = "";
            $scope.userPassword = "";
            $scope.userEmail = "";
            $scope.userRole = "";
        }
        // cancel
        $scope.Cancel = function () {
            $scope.divUser = false;
        };


    });

})();


