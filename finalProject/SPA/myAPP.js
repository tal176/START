var myAPP = angular.module('myAPP', ['ngRoute', 'ui.bootstrap']);
myAPP.controller('HomePageController', HomePageController);

//Handle Routing to be set only within client side (no server)
var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider
        .when('/HomePage',
        {
            templateUrl: 'SPA/views/HomePage.html',
            controller: HomePageController
        })
        .when('/Test',
        {
            templateUrl: 'SPA/views/test.html',
            controller: HomePageController
        })
        .otherwise({
            redirectTo: '/HomePage'
        });
};
//$locationProvider.html5Mode(true);
configFunction.$inject = ['$routeProvider', '$httpProvider'];
myAPP.config(configFunction);



