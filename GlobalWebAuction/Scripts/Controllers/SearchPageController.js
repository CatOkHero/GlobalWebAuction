app.controller('SearchPageController', [
	'$scope', '$uibModal', '$log', '$http', '$location', '$window', 'localStorageService',
	function ($scope, $uibModal, $log, $http, $location, $window, localStorageService) {
		$scope.searchElements = angular.fromJson(localStorageService.get('selectedCategory'));
	}]);
