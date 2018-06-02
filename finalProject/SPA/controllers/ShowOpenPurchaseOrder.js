var ShowOpenPurchaseOrder = function ($scope, $http) {



    //********** call server web api method without input paramters ************
    $http.get('/api/Purchase/OpenPurchase/').then(function (response) {
        $scope.OpenPurchases = response.data;
        //if ($scope.newUser == 1) {}

    })
}
SearchCustomersController.$inject = ['$scope', '$http'];