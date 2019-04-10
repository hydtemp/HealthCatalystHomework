(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getPeople = function () {
                var deferred = $q.defer();
                $http.get('api/people').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.searchPeople = function (term) {
                var deferred = $q.defer();
                $http.get('api/people/searchpeople', term).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addPerson = function (person) {
                var deferred = $q.defer();
                $http.post('api/people/add', person).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.deletePerson = function (id) {
                var deferred = $q.defer();
                $http.delete('api/people/delete?id=' + id).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            return service;
        }]);
})();