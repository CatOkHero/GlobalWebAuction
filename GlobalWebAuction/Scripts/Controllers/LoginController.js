app.controller('LoginController', ['$scope', '$http', function ($scope, $http) {
    $scope.register = function () {
        $http.post('api/Account/Register', {
            "name": "Roman",
            "surname": "Hapatyn",
            "password": "!OrGW4fz",
            "confirmePassword": "!OrGW4fz"
        });
    };
}]);