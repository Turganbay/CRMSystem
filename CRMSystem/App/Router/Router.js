app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/events');

    $stateProvider

    .state('events', {
        url: '/events',
        templateUrl: 'Home/Events/',
        controller: 'eventsContentController'
    })

    .state('login', {
        url: '/login',
        templateUrl: 'Home/Login/',
        controller: 'loginController'
    })

    .state('logout', {
        url: '/logout',
        controller: function ($rootScope) {
             window.location = '#/main';
             $rootScope.IsLogedIn = false;
             $rootScope.username = false;
             $rootScope.userId = -1;
             $rootScope.userRole = 1;
             $rootScope.userEventsIds = {};
        }
    })

    .state('admin', {
        url: '/admin',
        templateUrl: 'Admin/Index/',
    })

    .state('admin.users', {
        url: '/users',
        templateUrl: 'Admin/Users/',
        controller: 'usersController',
    })

    .state('admin.courses', {
        url: '/courses',
        templateUrl: 'Admin/Courses/',
        controller: 'coursesController',
    })

    .state('admin.events', {
        url: '/events',
        templateUrl: 'Admin/Events/',
        controller: 'eventsController',
    })

    .state('admin.eventsContent', {
        url: '/eventsContent',
        templateUrl: 'Admin/EventsContents/',
        controller: 'eventsContentController',
    })

    .state('admin.subscription', {
        url: '/subscription',
        templateUrl: 'Admin/Subscriptions/',
        controller: 'subscriptionController',
    });

});