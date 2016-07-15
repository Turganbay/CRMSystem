(function () {
app.controller('LoginController', function ($scope, LoginService, subscriptionService, $rootScope) {
   
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;

    $scope.LoginData = {
        username: '',
        password: ''
    }

    
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });

    $scope.Login = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            LoginService.GetUser($scope.LoginData).then(function (d) {
                if (d.data.username != null) {
                    $rootScope.IsLogedIn = true;
                    $scope.Message = "Successfully login done. Welcome " + d.data.email;
                    $rootScope.username = d.data.username;
                    $rootScope.userId = d.data.id;
                    $rootScope.userRole = d.data.role;

                    subscriptionService.getUserEventsIds(d.data.id).then(function(data){
                        $rootScope.userEventsIds = data.data;
                    });
                }
                else {
                    alert('Invalid Credential')
                }
            });
        }
    }

})
.factory('LoginService', function ($http) {
    var fac = {};
    fac.GetUser = function (d) {
        return $http({
            url: 'Home/UserLogin',
            method: 'POST',
            data: JSON.stringify(d),
            header: {'content-type':'application/json'}
        });
    }
    return fac;
});
})();


