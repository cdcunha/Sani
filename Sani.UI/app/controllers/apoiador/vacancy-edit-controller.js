(function () {
    'use strict';
    angular.module('sani').controller('ApoiadorEditCtrl', ApoiadorEditCtrl);

    ApoiadorEditCtrl.$inject = ['$routeParams', 'ApoiadorFactory'];

    function ApoiadorEditCtrl($routeParams, ApoiadorFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.apoiador = {};

        activate();

        function activate() {
            getApoiador();
        }

        function getApoiador() {
            ApoiadorFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.apoiador = response;
            }

            function fail(error) {
                var erros = error.data.errors;
                for (var i = 0; i < erros.length; ++i) {
                    toastr.error(erros[i].value, 'Falha na Requisição')
                }
            }
        }
    };
})();