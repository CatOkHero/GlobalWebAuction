/// <reference path="../angular/angular.min.js" />
var app = angular.module('WebAuctionApp',
	['LocalStorageModule', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.modal', 'ui.bootstrap.accordion']);

app.config(function ($routeProvider) {
	$routeProvider
		.when('/', {
			controller: 'SliderWrapperController',
			templateUrl: 'Views/SlideWraper.html'
		})
		.when('/About', {
			templateUrl: '/Views/About.html'
		})
		.when('/ProductDetails', {
			templateUrl: '/Views/ProductDetails.html'
		})
		.when('/FAQ', {
			templateUrl: '/Views/FAQ.html'
		})
		.when('/ShoppingCart', {
			templateUrl: '/Views/ShoppingCart.html'
		})
		.when('/Contact', {
			templateUrl: '/Views/Contact.html'
		})
		.when('/SelectedCategory', {
			templateUrl: '/Views/SearchPage.html'
		})
		.when('/ErrorOccured', {
			controller: 'ErrorPageController',
			templateUrl: '/Views/ErrorPage.html'
		})
		.when('/SearchPage', {
			controller: 'SearchPageController',
			templateUrl: '/Views/SearchPage.html'
		})
		.when('/AddNewLot', {
			controller: 'AddNewLotController',
			templateUrl: '/Views/AddNewLot.html'
		})
		.when('/DeleteLot', {
			controller: 'DeleteLotController',
			templateUrl: '/Views/DeleteLot.html'
		});
});