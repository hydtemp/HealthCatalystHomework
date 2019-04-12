(function () {
    'use strict';

    angular
        .module('app')
        .directive('fileread', fileread);

    fileread.$inject = ['$window'];

    function fileread($window) {
        var fileread = {
            scope: {
                fileread: "="
            },
            link: function (scope, element, attributes, ctrl) {
                element.bind("change", function (changeEvent) {
                    //load file bytes
                    var reader = new FileReader();
                    reader.onload = function (loadEvent) {
                        scope.$apply(function () {
                            scope.fileread = loadEvent.target.result;
                        });
                    }
                    reader.readAsDataURL(changeEvent.target.files[0]);
                });
            }
        };
        return fileread;
    }
})();