(function () {
    'use strict';
    var SETTINGS = { 'SERVICE_URL': 'http://localhost:56914/' };

    angular.module('sani').factory('ApoiadoFactory', ApoiadoFactory);

    //ApoiadoFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    //function ApoiadoFactory($http, $rootScope, SETTINGS) {
    function ApoiadoFactory($http, $rootScope) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/Apoiado', $rootScope.header);
        }

        function post(apoiado) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/Apoiado', apoiado, $rootScope.header);
        }

        function put(apoiado) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/Apoiado/' + apoiado.id, apoiado, $rootScope.header);
        }

        function remove(apoiado) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/Apoiado/' + apoiado.id, $rootScope.header);
        }
    }
})();