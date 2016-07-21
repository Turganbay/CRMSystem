(function () {
    var usersHub = $.connection.crmHub;

    app.controller('usersController', function ($scope, usersService) {

        $scope.divUser = false;
        GetAllUsers();

        // GET ALL USERS 
        function GetAllUsers() {
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
                alert('Error in getting user records');
            });
        }

        
        usersHub.client.refresh = function () {
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
                        usersHub.server.refreshUsersList();
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
                        alert('Error in adding user record');
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
                alert('Error in deleting user record');
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


