/// <reference path="../app/app.js" />
app.controller('SliderWrapperController', [
    '$scope', '$window', function ($scope, $window) {
        $scope.myInterval = 5000;
        $scope.noWrapSlides = false;
        var slides = $scope.slides = [];

        $scope.addSlide = function (i) {
        	var newWidth = 600 + slides.length + 1;
	        if (i === 0) {
		        slides.push({
			        image: '//lorempixel.com/' + newWidth + '/300/' + 'technics'
		        });
	        } else if (i === 1 ) {
	        	slides.push({
	        		image: '//lorempixel.com/' + newWidth + '/300/' + 'business'
	        	});
	        } else if (i === 2) {
		        slides.push({
			        image: '//lorempixel.com/' + newWidth + '/300/' + 'fashion'
		        });
	        } else {
	        	slides.push({
	        		image: '//lorempixel.com/' + newWidth + '/300/' + 'sports'
	        	});
	        }
        };

        for (var i = 0; i < 4; i++) {
            $scope.addSlide(i);
        }
    }
]);
