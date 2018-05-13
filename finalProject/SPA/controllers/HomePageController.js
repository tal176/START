
var HomePageController = function ($scope, $http) {

    $scope.homePageHeader = "Welcome to login area";

    //********** call server web api method without input paramters ************
    $http.get('/api/HomePage/LoginToSystem/').then(function (response) {
        $scope.newUser = response.data;
        //if ($scope.newUser == 1) {}
            
    })
}
HomePageController.$inject = ['$scope', '$http'];


//?NameContact=nimi' -> ????
