var app = angular.module('CRMSystem', ['ui.router', 'angular.filter']);
var chat = $.connection.crmHub;

app.run(function ($rootScope) {
    $rootScope.IsLogedIn = false;
    $rootScope.username = false;
    $rootScope.userId = -1;
    $rootScope.userRole = 1;
    $rootScope.userEventsIds = {};
});
