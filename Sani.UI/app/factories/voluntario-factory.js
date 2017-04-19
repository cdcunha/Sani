(function () {
    'use strict';

    var SETTINGS = { 'SERVICE_URL': 'http://localhost:56914/api/Voluntario' };

    angular.module('sani').factory('VoluntarioFactory', VoluntarioFactory);

    //VoluntarioFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VoluntarioFactory($http, $rootScope) {
        return {
            get: get,
            getById: getById,
            post: post,
            put: put,
            remove: remove
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + '/' + id, $rootScope.header);
        }

        function post(voluntario) {
            console.log(voluntario);
            return $http.post(SETTINGS.SERVICE_URL, voluntario, $rootScope.header);
        }

        function put(voluntario) {
            return $http.put(SETTINGS.SERVICE_URL + '/' + voluntario.id, voluntario, $rootScope.header);
        }

        function remove(voluntario) {
            return $http.delete(SETTINGS.SERVICE_URL + '/' + voluntario.id, $rootScope.header);
        }
    }
})();