app.controller('RegisterController', ['$scope', '$http', '$uibModalInstance', function ($scope, $http, $uibModalInstance) {
    $scope.register = function () {
        $http.post('api/Account/Register', {
            "name": $scope.userName,
            "surname": $scope.surName,
            "password": $scope.password,
            "confirmePassword": $scope.confPassword
        });
    };
    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}])