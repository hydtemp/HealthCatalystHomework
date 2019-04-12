(function () {
    'use strict';

    angular
        .module('app')
        .directive('validFile', validFile);

    validFile.$inject = ['$window'];

    function validFile($window) {
        return {
            require: 'ngModel',
            link: function (scope, el, attrs, ngModel) {
                ngModel.$setViewValue("");
                //change event is fired when file is selected
                el.bind('change', function () {
                    scope.$apply(function () {
                        ngModel.$setViewValue(el.val());
                        ngModel.$render();
                    });
                });
            }
        }
    }

})();