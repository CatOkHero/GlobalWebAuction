app.controller('AddNewLotController', [
	'$scope', '$uibModal', '$window', '$http', 'localStorageService',
	function ($scope, $uibModal, $window, $http, localStorageService) {
		$scope.selectedCategory = undefined;
		$scope.selectedSubCategory = undefined;
		$scope.subCategoryModels = undefined;

		var errorOccured = function () {
			$uibModal.open({
				templateUrl: '../Views/ErrorPage.html',
				controller: 'ErrorPageController',
				size: 'sm'
			});
		};

		var cleanAllInput = function () {
			$scope.lotAddress = null;
			$scope.lotPrice = null;
			$scope.selectedCategory = null;
			$scope.selectedSubCategory = null;
			$scope.lotName = null;
			$scope.lotDescription = null;
			$scope.selectedStatus = null;
		}

		$scope.category = function () {
			angular.forEach($scope.states, function (value) {
				if (value.categoryName === $scope.selectedCategory) {
					$scope.subCategoryModels = value.subCategoryModels;
				}
			});
		};

		$http.get('api/Categories/GetCategories')
			.success(function (response) {
				$scope.states = response;
			})
			.error(function (error, status) {
				localStorageService.set('errorMessage', error + status);
				errorOccured();
			});

		$http.get('api/Status/GetStatus')
			.success(function (response) {
				$scope.status = response;
			})
			.error(function (error, status) {
				localStorageService.set('errorMessage', error + status);
				errorOccured();
			});

		$scope.closeAlert = function (index) {
			$scope.alerts.splice(index, 1);
		};

		$scope.ok = function () {
			$http.defaults.headers.common.ContentType = 'application/json';
			$http.defaults.headers.common.Authorization = 'Bearer ' + localStorageService.get('access_token').toString();
			var model = {
				'address': $scope.lotAddress,
				'price': $scope.lotPrice,
				'category': $scope.selectedCategory,
				'subCategory': $scope.selectedSubCategory,
				'name': $scope.lotName,
				'description': $scope.lotDescription,
				'status': $scope.selectedStatus
			};

			$http.post('api/Lot/AddNewLot', model)
				.success(function (response) {
					$scope.alerts = [
						{ type: 'success', msg: 'Well done! You successfully add new Lot.' }
					];
					$scope.complitedAction = false;
					$scope.states = response;
					cleanAllInput();
				})
				.error(function (error, status) {
					localStorageService.set('errorMessage', error + status);
					$scope.alerts = [
						{ type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again.' + error.message }
					];
					$scope.complitedAction = false;
					errorOccured();
				});
		};
	}
]);