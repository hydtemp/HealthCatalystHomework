(function () {
    'use strict';
    angular
        .module('app')
        .controller('peopleCtrl', ['$scope', '$filter', 'dataService', function ($scope, $filter, dataService) {
            $scope.personList = [];
            $scope.currentPage = 1;
            $scope.itemsPerPage = 5;
            $scope.dataLoading = false;
            $scope.searchText = "";
            $scope.isSaving = false;

            getData();

            function getData() {
                $scope.dataLoading = true;
                $scope.isSaving = true;
                dataService.getPeople().then(function (result) {
                    $scope.dataLoading = false;
                    $scope.isSaving = false;
                    $scope.personList = result;
                })
                    .finally(function () {
                        $scope.dataLoading = false;
                        $scope.isSaving = false;
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

            $scope.searchPeople = function (searchText) {
                $scope.dataLoading = true;
                $scope.isSaving = true;
                dataService.searchPeople(searchText).then(function (result) {
                    $scope.dataLoading = false;
                    $scope.isSaving = false;
                    $scope.personList = result;
                }, function () {
                    toastr.error('Error in fetching people that match search term: ' + searchText);
                }).finally(function () {
                    $scope.isSaving = false;
                    $scope.dataLoading = false;
                });
            };

            $scope.sortBy = function (column) {
                $scope.sortColumn = column;
                $scope.reverse = !$scope.reverse;
            };
        }])
        .controller('personAddCtrl', ['$scope', '$location', 'dataService', function ($scope, $location, dataService) {
            $scope.uploadme = {};
            $scope.uploadme.src = "";

            $scope.createPerson = function (persondto) {
                var base64Image = $scope.uploadme.src.substring($scope.uploadme.src.indexOf(",") + 1);
                var person = {
                    FirstName: persondto.FirstName.trim(),
                    LastName: persondto.LastName.trim(),
                    Age: persondto.Age,
                    Interests: persondto.Interests.trim(),
                    Image: base64Image,
                    address: {
                        StreetAddress: persondto.StreetAddress.trim(),
                        City: persondto.City.trim(),
                        State: persondto.State.trim(),
                        ZipCode: persondto.ZipCode,
                        Country: persondto.Country.trim()
                    }
                };
                dataService.addPerson(person).then(function () {
                    toastr.success('Person added successfully');
                    $location.path('/');
                }, function () {
                    toastr.error('Error occured while adding a person');
                });
            }
        }])
})();