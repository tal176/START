var ShowClosePurchaseOrder = function ($scope, $http) {



    //********** call server web api method without input paramters ************
    $http.get('/api/PurchaseCloseOrder/ClosePurchase/').then(function (response) {
        $scope.ClosePurchase = response.data;
        //if ($scope.newUser == 1) {}

    })
}
SearchCustomersController.$inject = ['$scope', '$http'];