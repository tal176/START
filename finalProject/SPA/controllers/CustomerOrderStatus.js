var CustomerOrderStatus = function ($scope, $http) {


    //********** call server web api method without input paramters ************
    $http.get('/api/CustomerOrderStatus/StatusOrder/').then(function (response) {
        $scope.StatusOrder = response.data;
        //if ($scope.newUser == 1) {}

    })
}
SearchCustomersController.$inject = ['$scope', '$http'];