(function () {
    'use strict';
    angular
        .module('app')
        .controller('peopleCtrl', ['$scope', '$filter', 'dataService', function ($scope, $filter, dataService) {
            $scope.personList = [];
            $scope.currentPage = 1;
            $scope.itemsPerPage = 5;

            getData();

            function getData() {
                dataService.getPeople().then(function (result) {
                    $scope.$watch('searchText', function (term) {
                        $scope.personList = $filter('filter')(result, term);
                    });
                });
            }

            $scope.deletePerson = function (id) {
                dataService.deletePerson(id).then(function () {
                    toastr.success('Person deleted successfully');
                    getData();
                }, function () {
                    toastr.error('Error in deleting person with Id: ' + id);
                });
            };

            $scope.sortBy = function (column) {
                $scope.sortColumn = column;
                $scope.reverse = !$scope.reverse;
            };
        }])
        .controller('personAddCtrl', ['$scope', '$location', 'dataService', function ($scope, $location, dataService) {
            $scope.createPerson = function (persondto) {
                var person = {
                    FirstName: persondto.FirstName,
                    LastName: persondto.LastName,
                    Age: persondto.Age,
                    Interests: persondto.Interests,
                    address: {
                        StreetAddress: persondto.StreetAddress,
                        City: persondto.City,
                        State: persondto.State,
                        ZipCode: persondto.ZipCode,
                        Country: persondto.Country
                    }
                };
                dataService.addPerson(person).then(function () {
                    toastr.success('Person added successfully');
                    $location.path('/');
                }, function () {
                    toastr.error('Error occured while adding a person');
                });
            };
        }])
})();