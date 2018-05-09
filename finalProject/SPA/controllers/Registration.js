//var HomePageController = function ($scope, $http) {

//    //********** call server web api method without input paramters ************
//    $http.get('/api/HomePage/Register/?NameContact=nimi').then(function (response) {
//        $scope.newUser = response.data;
//    })
//}
//HomePageController.$inject = ['$scope', '$http'];
function Register() {
    var $ = jQuery.noConflict();
    var uri = 'api/HomePage/Register';
    $.ajax({
        url: uri,
        dataType: 'json',
        data: { NameContact: $("#NameContact").val(), UserName: $("#UserName").val(), Company: $("#Company").val(), Pass: $("#Pass").val(), Email: $("#Email").val(), Location: $("#Location").val(), Phone: $("#Phone").val() },
        async: false,
        success: function (data) {

            $.each(data, function (key, item) {
                if (item.ErrMsg != "OK") {
                    alert("Registration Error");
                }
                return false; //get out of the loop
            });

        }
    });
}