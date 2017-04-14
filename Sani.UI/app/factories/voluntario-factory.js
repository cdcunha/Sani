(function () {
    'use strict';

    var SETTINGS = { 'SERVICE_URL': 'http://localhost:56914/' };

    angular.module('sani').factory('VoluntarioFactory', VoluntarioFactory);

    //VoluntarioFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VoluntarioFactory($http, $rootScope) {
        return {
            get: get,
            getById: getById,
            post: post
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/apoiadores', $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/apoiadores/' + id, $rootScope.header);
        }

        function post(apoiador) {
            console.log(apoiador);
            return $http.post(SETTINGS.SERVICE_URL + 'api/voluntarios', vacancy, $rootScope.header);
        }
    }
})();