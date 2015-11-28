/// <reference path="../angular/angular.min.js" />
var app = angular.module('WebAuctionApp', ['ngRoute', 'ui.bootstrap']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'SliderWrapperController',
            templateUrl: 'Views/SlideWraper.html'
        })
        .when('/About', {
            templateUrl: "/Views/About.html"
        })
        .when('/ProductDetails', {
            templateUrl: "/Views/ProductDetails.html"
        })
        .when('/FAQ', {
            templateUrl: "/Views/FAQ.html"
        })
        .when('/ShoppingCart', {
            templateUrl: "/Views/ShoppingCart.html"
        })
        .when('/Contact', {
            templateUrl: "/Views/Contact.html"
        });
});