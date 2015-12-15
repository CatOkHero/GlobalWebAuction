app.controller('IndexController', ['$scope', '$uibModal', '$log', '$http', '$location', '$window', 'localStorageService',
	function ($scope, $uibModal, $log, $http, $location, $window, localStorageService) {
		var categoryIndex = null;

		var errorOccured = function () {
			$uibModal.open({
				templateUrl: '../Views/ErrorPage.html',
				controller: 'ErrorPageController',
				size: 'sm'
			});
		};

		var openModal = function (templateUrl, controller) {
			var modalInstance = $uibModal.open({
				templateUrl: templateUrl,
				controller: controller,
				size: 'sm'
			});

			modalInstance.result.then(function (success) {

			}, function (error, status) {
				localStorageService.set('errorMessage', error + status);
				errorOccured();
			});
		}

		$scope.isAuthorized = localStorageService.get('access_token') ? true : false;
        $scope.isCollapsed = true;
        $scope.oneAtATime = true;

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
        		localStorageService.set('errorMessage', error + status);
		        errorOccured();
	        });
        };

        $scope.register = function (size) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '../Views/Register.html',
                controller: 'RegisterController',
                size: size
            });

            modalInstance.result.then(function () {

            }, function () {
            	localStorageService.set('errorMessage', error + status);
	            errorOccured();
            });
        };

        $scope.logOut = function () {
	        localStorageService.set('access_token', null);
			$scope.isAuthorized = false;
			$scope.userAgent = null;
		};

		$scope.addNewLot = function () {
			$window.location.href = '#/AddNewLot';
		};

		$scope.deleteLot = function () {
			$window.location.href = '#/DeleteLot';
		};

		$http.get('api/Categories/GetCategories')
			.success(function (response) {
				$scope.groups = response;
			})
			.error(function (error, status) {
				localStorageService.set('errorMessage', error + status);
				errorOccured();
			});

		$scope.searchSelected = function (subIndex) {
			var categoryName = $scope.groups[categoryIndex].categoryName;
			var subCategoryName = $scope.groups[categoryIndex].subCategoryModels[subIndex].subCategoryName;

			var model = {
				"categoryName": categoryName,
				"subCategoryName": subCategoryName
			};

			$http.post('/api/Categories/GetSelectedCategory/', model)
				.success(function (response) {
					localStorageService.set('selectedCategory', JSON.stringify(response));
					$window.location.href = '#/SearchPage';
				}).error(function (error) {
					$scope.errorMessage = error.message;
					localStorageService.set('errorMessage', JSON.stringify(error.message));
					errorOccured();
				});
		};

		$scope.selectCategory = function (index) {
			categoryIndex = index;
		};

        $scope.status = {
            isFirstOpen: true,
            isFirstDisabled: false,
            isopen: false
        };
	}
]);
