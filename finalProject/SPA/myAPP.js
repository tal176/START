var myAPP = angular.module('myAPP', ['ngRoute', 'ui.bootstrap']);
myAPP.controller('HomePageController', HomePageController);
myAPP.controller('SearchCustomersController', SearchCustomersController);

//Handle Routing to be set only within client side (no server)
var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider
        .when('/HomePage',
        {
            templateUrl: 'SPA/views/HomePage.html',
            controller: HomePageController
        })
        .when('/Register',
        {
            templateUrl: 'SPA/views/Register.html'
            //controller: HomePageController
        })

        .when('/Login',
        {
            templateUrl: 'SPA/views/Login.html',
            controller: HomePageController
        })
      
        .when('/NewItem',
        {
            templateUrl: 'SPA/views/AddItem.html'
            //controller: HomePageController
        })

        .when('/NewCustomer',
        {
            templateUrl: 'SPA/views/Register.html',
            controller: HomePageController
        })
        .when('/SearchCustomers',
        {
            templateUrl: 'SPA/views/SearchCustomers.html',
            controller: SearchCustomersController
        })

        .when('/Items',
        {
            templateUrl: 'SPA/views/Register.html',
            controller: HomePageController
        })

        .when('/Orders',
        {
            templateUrl: 'SPA/views/Register.html',
            controller: HomePageController
        })

        .when('/Po',
        {
            templateUrl: 'SPA/views/Register.html',
            controller: HomePageController
        })

        .otherwise({
            redirectTo: '/HomePage'
        });
};
//$locationProvider.html5Mode(true);
configFunction.$inject = ['$routeProvider', '$httpProvider'];
myAPP.config(configFunction);



