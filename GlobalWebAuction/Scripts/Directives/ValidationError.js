app.directive('myValidationError', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctl) {
            scope.$watch(attrs['myValidationError'], function (errorMsg) {
                elm[0].setCustomValidity(errorMsg);
                ctl.$setValidity('myValidationError', errorMsg ? false : true);
            });
        }
    };
});