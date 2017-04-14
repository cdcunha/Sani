(function () {
    'use strict';
    angular.module('sani').controller('VoluntarioEditCtrl', VoluntarioEditCtrl);

    VoluntarioEditCtrl.$inject = ['$routeParams', 'VoluntarioFactory'];

    function VoluntarioEditCtrl($routeParams, VoluntarioFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.voluntario = {};

        activate();

        function activate() {
            getVoluntario();
        }

        function getVoluntario() {
            VoluntarioFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.voluntario = response;
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