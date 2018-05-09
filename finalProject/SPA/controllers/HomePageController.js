
var HomePageController = function ($scope, $http) {

    $scope.homePageHeader = "Welcome to Homepage";
    $scope.button = "Login";

    //********** call server web api method without input paramters ************
    $http.get('/api/HomePage/GetSomeData/').then(function (response) {
        $scope.newUser = response.data;
    })
}
HomePageController.$inject = ['$scope', '$http'];


//?NameContact=nimi' -> ????
