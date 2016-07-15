(function () {
    var chat = $.connection.crmHub;

    app.controller('subscriptionController', function ($scope, $rootScope, subscriptionService) {

        // Refresh subscriptons list
        chat.client.refreshSubscriptions = function () {
            GetAllSubscription();
            console.log('all ok');
        }


        GetAllSubscription();

        // GET ALL Subscription 
        function GetAllSubscription() {
            var getData = subscriptionService.getSubscriptions();
            getData.then(function (subscription) {
                $scope.subscriptions = subscription.data
            }, function () {
                alert('Error in getting subscription record');
            });
        }

      
        $.connection.hub.start().done(function () {

            //Add or remove Subscription
            $scope.addSubscription = function (userId, eventId, action) {
                if (userId > 0) {

                    if (action == "add" && $rootScope.userEventsIds.indexOf(eventId) == -1) {
                        var getData = subscriptionService.AddSubscription(userId, eventId);
                        getData.then(function (msg) {
                            chat.server.refreshSubscriptionsList();
                            $rootScope.userEventsIds.push(eventId);

                        }, function () {
                            alert('Error in adding subscription record');
                        });

                    } else {

                        var getData = subscriptionService.deleteSubscription(userId, eventId);
                        getData.then(function (msg) {
                            chat.server.refreshSubscriptionsList();
                            var index = $rootScope.userEventsIds.indexOf(eventId);
                            $rootScope.userEventsIds.splice(index, 1);

                        }, function () {
                            alert('Error in deleting subscription record');
                        });

                    }
                    console.log(action);
                    console.log($rootScope.userEventsIds);


                } else {
                    alert("Non authorized");
                }
            }


            // Delete User
            $scope.deleteSubscription = function (sub) {
                var getData = subscriptionService.deleteSubscription(sub.user_id, sub.event_id);
                getData.then(function (msg) {
                    console.log(msg.data);
                    chat.server.refreshSubscriptionsList();
                }, function () {
                    alert('Error in deleting subscriptions record');
                });
            }

        })
        /*
        $scope.divSubscription = false;
        GetAllEventsWithCourse();

        // GET ALL USERS 
        function GetAllEventsWithCourse() {
            var getUsersData = usersService.getUsers();
            getUsersData.then(function (user) {
                $scope.users = user.data
            }, function () {
                alert('Error in getting user record');
            });
        }

        // GET UPDATE USER
        $scope.editUser = function (user) {
            var getUserData = usersService.getUser(user.id);
            getUserData.then(function (_user) {
                $scope.user = _user.data;
                $scope.userId = user.id;
                $scope.userUsername = user.username;
                $scope.userPassword = user.password;
                $scope.userEmail = user.email;
                $scope.userRole = user.role;
                $scope.Action = "Update";
                $scope.divUser = true;
            }, function () {
                alert('Error in getting book records');
            });
        }

        // Add OR UPDATE User
        chat.client.refresh = function () {
            GetAllUsers();
            console.log('all ok');
        }

        $.connection.hub.start().done(function () {

            $scope.AddUpdateUser = function () {
                var User = {
                    username: $scope.userUsername,
                    password: $scope.userPassword,
                    email: $scope.userEmail,
                    role: $scope.userRole
                };
                var getUserAction = $scope.Action;

                if (getUserAction == "Update") {
                    User.Id = $scope.userId;
                    var getUserData = usersService.updateUser(User);
                    getUserData.then(function (msg) {
                        // GetAllUsers();
                        chat.server.refreshUsersList();
                        console.log(msg.data);
                        $scope.divUser = false;
                    }, function () {
                        alert('Error in updating book record');
                    });
                } else {
                    var getUserData = usersService.AddUser(User);
                    getUserData.then(function (msg) {
                        chat.server.refreshUsersList();
                        $scope.divUser = false;
                    }, function () {
                        alert('Error in adding book record');
                    });
                }
            }

        });


        // Add Div open
        $scope.AddUserDiv = function () {
            ClearFields();
            $scope.Action = "Add";
            $scope.divUser = true;
        }

        // Delete User
        $scope.deleteUser = function (user) {
            var getUserData = usersService.deleteUser(user.id);
            getUserData.then(function (msg) {
                console.log(msg.data);
                //GetAllUsers();
                chat.server.refreshUsersList();
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

        */
    });

})();


