(function () {
    'use strict';

    angular
        .module('app', [
            'ngRoute',
            'ui.bootstrap'
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/', {
                    controller: 'peopleCtrl',
                    templateUrl: '/app/templates/people.html'
                })
                .when('/addperson', {
                    controller: 'personAddCtrl',
                    templateUrl: '/app/templates/personAdd.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();