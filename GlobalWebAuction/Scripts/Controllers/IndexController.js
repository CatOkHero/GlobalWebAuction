app.controller('IndexController', ['$scope', '$uibModal', '$log', '$http', function ($scope, $uibModal, $log, $http) {
        $scope.login = function (size) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '../Views/Login.html',
                controller: 'LoginController',
                size: size,
                resolve: {
                	isAuthorized: function () {
		                return $scope.isAuthorized;
	                }
                }
            });

            modalInstance.result.then(function (success) {
	            $scope.isAuthorized = true;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.isAuthorized = false;
        $scope.isCollapsed = false;
        $scope.oneAtATime = true;

        $scope.register = function (size) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '../Views/Register.html',
                controller: 'RegisterController',
                size: size
            });

            modalInstance.result.then(function () {

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

		$scope.logOut = function () {
			$scope.isAuthorized = false;
			$scope.userAgent = null;
		};

        $http.get('api/Categories/GetCategories')
            .success(function (response) {
                $scope.groups = response;
            })
            .error(function (error, status) {
            });

        $scope.status = {
            isFirstOpen: true,
            isFirstDisabled: false
        };
	}
]);
