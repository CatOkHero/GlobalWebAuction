app.controller('DeleteLotController', [
	'$scope', '$uibModal', '$window', '$http', 'localStorageService',
	function ($scope, $uibModal, $window, $http, localStorageService) {
		$scope.searchElements = angular.fromJson(localStorageService.get('selectedCategory'));

		$scope.closeAlert = function (index) {
			$scope.alerts.splice(index, 1);
		};

		$scope.delete = function (lotDetailsId) {
			$http.defaults.headers.common.ContentType = 'application/json';
			$http.defaults.headers.common.Authorization = 'Bearer ' + localStorageService.get('access_token').toString();
			$http.delete('api/DeleteLot/Delete?lotDetailsId=' +
					lotDetailsId 
					
				)
				.success(function (response) {
					$scope.alerts = [
						{ type: 'success', msg: 'Well done! You successfully delete Lot.' }
					];
				})
				.error(function (error) {
					$scope.alerts = [
						{ type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again. ' + error.message }
					];
				});
		};
	}
]);