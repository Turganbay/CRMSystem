(function () {
    var chat = $.connection.crmHub;

    app.controller('eventsContentController', function ($scope, eventsContentService, eventsService, coursesService) {


        // frontend  get All Event With Course
        GetAllEventsWithCourse();
        function GetAllEventsWithCourse() {
            var getData = eventsContentService.getEventsWithCourse();
            getData.then(function (data) {
                $scope.eventsWithCourse = data.data
            }, function () {
                alert('Error in getting data record');
            });
        }

        //  \frontend //


        $scope.divEventsContent = false;
        GetAllEventsContents();

        var getEventsListData = eventsService.getEvents();
        getEventsListData.then(function (event) {
            $scope.eventsList = event.data
        }, function () {
            alert('Error in getting events record');
        });

        var getCoursesListData = coursesService.getCourses();
        getCoursesListData.then(function (course) {
            $scope.coursesList = course.data
        }, function () {
            alert('Error in getting course record');
        });


        // GET ALL EventsContents
        function GetAllEventsContents() {
            var getEventsContentsData = eventsContentService.getEventsContents();
            getEventsContentsData.then(function (eventsContent) {
                $scope.eventsContents = eventsContent.data
            }, function () {
                alert('Error in getting content record');
            });
        }

        // GET UPDATE Content
        $scope.editContent = function (content) {
            var getContentData = eventsContentService.getContent(content.id);
            getContentData.then(function (_content) {
                //$scope.content = _content.data;
                $scope.contentId = content.id;
                $scope.event_id = content.event_id;
                $scope.course_id = content.course_id;
                $scope.Action = "Update";
                $scope.divEventsContent = true;
            }, function () {
                alert('Error in getting content records');
            });
        }

        // Add OR UPDATE User
        chat.client.refreshContents = function () {
            GetAllEventsContents();
            GetAllEventsWithCourse();
            console.log('all ok');
        }

        $.connection.hub.start().done(function () {

            $scope.AddUpdateContent = function () {
                var Content = {
                    id: $scope.contentId,
                    event_id: $scope.event_id,
                    course_id: $scope.course_id,
                };
                var getContentAction = $scope.Action;

                if (getContentAction == "Update") {
                    Content.id = $scope.contentId;
                    var getContentData = eventsContentService.updateContent(Content);
                    getContentData.then(function (msg) {
                        // GetAllUsers();
                        chat.server.refreshContentsList();
                        console.log(msg.data);
                        $scope.divEventsContent = false;
                    }, function () {
                        alert('Error in updating content record');
                    });
                } else {
                    var getContentData = eventsContentService.AddContent(Content);
                    getContentData.then(function (msg) {
                        chat.server.refreshContentsList();
                        $scope.divEventsContent = false;
                    }, function () {
                        alert('Error in adding content record');
                    });
                }
            }

        });


        // Add Div open
        $scope.AddEventsContentDiv = function () {
            ClearFields();
            $scope.Action = "Add";
            $scope.divEventsContent = true;
            
           



        }

        // Delete Content
        $scope.deleteContent = function (content) {
            var getContentData = eventsContentService.deleteContent(content.id);
            getContentData.then(function (msg) {
                console.log(msg.data);
                //GetAllUsers();
                chat.server.refreshContentsList();
            }, function () {
                alert('Error in deleting content record');
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


