/// <reference path="../../node_modules/angular/angular.js" />
var myApp = angular.module('myModule', []);
myApp.controller("myController", myController);
myApp.$inject = ['$scope'];

function myController($scope) {
    $scope.message = "This is a message from myController";
}
