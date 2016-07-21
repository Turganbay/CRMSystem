(function () {
    var chat = $.connection.crmHub;

    app.controller('eventsController', function ($scope, eventsService) {

        $scope.divEvent = false;
        GetAllEvents();

        // GET ALL USERS 
        function GetAllEvents() {
            var getEventsData = eventsService.getEvents();
            getEventsData.then(function (event) {
                $scope.events = event.data
            }, function () {
                alert('Error in getting events record');
            });
        }

        // GET UPDATE USER
        $scope.editEvent = function (event) {
            var getEventData = eventsService.getEvent(event.id);
            getEventData.then(function (_event) {
                //$scope.event = _event.data;
                $scope.eventId = event.id;
                $scope.eventName = event.name;
                $scope.eventDescription = event.description;
                $scope.eventEventDate = event.event_date;
                $scope.Action = "Update";
                $scope.divEvent = true;
            }, function () {
                alert('Error in getting event records');
            });
        }

        // Add OR UPDATE User
        chat.client.refreshEvents = function () {
            GetAllEvents();
            console.log('all ok');
        }

        $.connection.hub.start().done(function () {

            $scope.AddUpdateEvent = function () {
                var Event = {
                    name: $scope.eventName,
                    description: $scope.eventDescription,
                    event_date: $scope.eventEventDate,
                };
                var getEventAction = $scope.Action;

                if (getEventAction == "Update") {
                    Event.Id = $scope.eventId;
                    var getEventData = eventsService.updateEvent(Event);
                    getEventData.then(function (msg) {
                        // GetAllUsers();
                        chat.server.refreshEventsList();
                        console.log(msg.data);
                        $scope.divEvent = false;
                    }, function () {
                        alert('Error in updating event record');
                    });
                } else {
                    var getEventData = eventsService.AddEvent(Event);
                    getEventData.then(function (msg) {
                        chat.server.refreshEventsList();
                        $scope.divEvent = false;
                    }, function () {
                        alert('Error in adding event record');
                    });
                }
            }

        });


        // Add Div open
        $scope.AddEventDiv = function () {
            ClearFields();
            $scope.Action = "Add";
            $scope.divEvent = true;
        }

        // Delete Event
        $scope.deleteEvent = function (event) {
            var getEventData = eventsService.deleteEvent(event.id);
            getEventData.then(function (msg) {
                console.log(msg.data);
                //GetAllUsers();
                chat.server.refreshEventsList();
            }, function () {
                alert('Error in deleting event record');
            });
        }


        // clear field
        function ClearFields() {
            $scope.eventId = "";
            $scope.eventName = "";
            $scope.eventDescription = "";
            $scope.eventEventDate = "";
        }
        // cancel
        $scope.Cancel = function () {
            $scope.divEvent = false;
        };


    });

})();


