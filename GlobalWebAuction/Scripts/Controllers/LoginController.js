app.controller('LoginController',
	['$scope', '$http', '$uibModalInstance', 'isAuthorized', function ($scope, $http, $uibModalInstance, isAuthorized) {
	$scope.errorMessage = false;

	$scope.login = function () {
		$http.post('api/Account/Login', {
			"name": $scope.userName,
			"password": $scope.password
		})
			.success(function (response, status) {
				if (status === 200) {
					if (response != null) {
						$scope.userAgent = response;
					}

					$scope.ok();
				}			
			}).error(function (error, status) {
				if (status === 401) {
					$scope.errorMessage = true;
				}
						
				$scope.errorMessage = true;
			});
	};

    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);