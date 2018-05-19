var SearchFeedbackController = function ($scope, $http) {



    //********** call server web api method without input paramters ************
    $http.get('/api/HomePage/GetFeedbackList/').then(function (response) {
        $scope.Items = response.data;
        //if ($scope.newUser == 1) {}

    })
}
SearchCustomersController.$inject = ['$scope', '$http'];