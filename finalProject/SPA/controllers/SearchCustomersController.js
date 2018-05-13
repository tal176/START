var SearchCustomersController = function ($scope, $http) {

    

    //********** call server web api method without input paramters ************
    $http.get('/api/HomePage/SearchCustomers/').then(function (response) {
        $scope.customers = response.data;
        //if ($scope.newUser == 1) {}

    })
}
SearchCustomersController.$inject = ['$scope', '$http'];