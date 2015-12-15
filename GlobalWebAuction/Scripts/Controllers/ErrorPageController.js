app.controller('ErrorPageController', [
	'$scope', '$uibModalInstance', '$location', 'localStorageService',
	function ($scope, $uibModalInstance, $location, localStorageService) {
		$scope.errorMessage = angular.fromJson(localStorageService.get('errorMessage'));

		$scope.cancel = function () {
			$uibModalInstance.close();
			$location.replace('/');
		};
	}]);
