(function () {
    'use strict';
    angular.module('sani').controller('GitHubUserRepoCtrl', function ($rootScope, $location, $http, $routeParams) {
        $rootScope.loading = true;
        $rootScope.RepoNotFound = false;
        $rootScope.activetab = $location.path();
        $http.get("https://api.github.com/users/" + $routeParams.login + "/repos?visibility=public&type=public&sort=created&direction=asc")
            .success(function (data) {
                $rootScope.RepoData = data;
            })
            .error(function () {
                $rootScope.RepoNotFound = true;
            });
        $rootScope.loading = false;
    });
})();