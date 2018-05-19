var myAPP = angular.module('myAPP', ['ngRoute', 'ui.bootstrap']);
myAPP.controller('HomePageController', HomePageController);
myAPP.controller('SearchCustomersController', SearchCustomersController);
myAPP.controller('SearchItemController', SearchItemController);
myAPP.controller('SearchFeedbackController', SearchFeedbackController);
myAPP.controller('SearchVendorController', SearchVendorController);


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

        //.when('/Login',
        //{
        //    templateUrl: 'SPA/views/Login.html',
        //    controller: HomePageController
        //})
      
        .when('/NewItem',
        {
            templateUrl: 'SPA/views/AddItem.html',
            //controller: AddProduct
        })

        .when('/SearchItems',
        {
            templateUrl: 'SPA/views/SearchItem.html',
            controller: SearchItemController
        })

        .when('/NewCustomer',
        {
            templateUrl: 'SPA/views/AddCustomer.html',
            //controller: HomePageController
        })

        .when('/SearchCustomers',
        {
            templateUrl: 'SPA/views/SearchCustomers.html',
            controller: SearchCustomersController
        })



        .when('/CustomerOrder',
        {
            templateUrl: 'SPA/views/CustomerOrder.html',
            //controller: HomePageController
        })

        .when('/AddFeedback',
        {
            templateUrl: 'SPA/views/AddFeedback.html',
            //controller: HomePageController
        })

        .when('/ViewFeedback',
        {
            templateUrl: 'SPA/views/SearchFeedback.html',
            controller: SearchFeedbackController
        })


        .when('/NewVendor',
        {
            templateUrl: 'SPA/views/AddVendor.html',
            //controller: HomePageController
        })


        .when('/SearchVendors',
        {
            templateUrl: 'SPA/views/SearchVendor.html',
            controller: SearchVendorController
        })

        .when('/AddRecordVendor',
        {
            templateUrl: 'SPA/views/AddRecordVendor.html',
            //controller: SearchVendorController
        })


        .otherwise({
            redirectTo: '/HomePage'
        });
};
//$locationProvider.html5Mode(true);
configFunction.$inject = ['$routeProvider', '$httpProvider'];
myAPP.config(configFunction);



