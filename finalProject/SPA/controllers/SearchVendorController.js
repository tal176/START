var SearchVendorController = function ($scope, $http) {



    //********** call server web api method without input paramters ************
    $http.get('/api/Vendor/SearchVendors/').then(function (response) {
        $scope.Vendors = response.data;
        //if ($scope.newUser == 1) {}

    })
}
SearchCustomersController.$inject = ['$scope', '$http'];