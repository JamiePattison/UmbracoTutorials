﻿angular.module('umbraco').controller('Example.editcontroller', function ($scope,
    $routeParams,
    personResource,
    notificationsService) {
    $scope.loaded = false;

    if ($routeParams.id == -1) {
        $scope.person = {};
        $scope.loaded = true;
    } else {
        personResource.getById($routeParams.id).then(function (response) {
            $scope.person = response.data;
            $scope.loaded = true;
        });
    }

    $scope.save = function(person) {
        personResource.save(person).then(function(response) {
            $scope.person = response.data;

            notificationsService.success("Success", person.firstName + " " + person.lastName + " has been saved.");
        });
    };
});