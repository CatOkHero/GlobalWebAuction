app.controller('LoginController',
[
	'$scope', '$http', '$uibModalInstance', 'isAuthorized', 'localStorageService',
	function ($scope, $http, $uibModalInstance, isAuthorized, localStorageService) {
		$scope.errorMessage = false;

		$scope.login = function () {
			$http.post('api/Account/Login', {
					"name": $scope.userName,
					"password": $scope.password
				})
				.success(function (response, status) {
						if (response != null) {
							$scope.userAgent = response;
							$http({
									url: '/token',
									method: 'POST',
									data: "userName=" + $scope.userName + "&password=" + $scope.password +
										"&grant_type=password"
								})
								.then(function (response) {
									$scope.access_token = response.data.access_token;
									localStorageService.set('access_token', $scope.access_token);
								}, function (error) {
									$scope.errorMessage = error.message;
								});
						};

						$scope.ok();
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
	}
]);