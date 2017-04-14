(function () {
    'use strict';
    angular.module('sani').controller('ApoiadorListCtrl', ApoiadorListCtrl);

    ApoiadorListCtrl.$inject = ['ApoiadorFactory'];

    function ApoiadorListCtrl(ApoiadorFactory) {
        var vm = this;
        vm.apoiadores = [];

        activate();

        function activate() {
            getVacancies();
        }

        function getVacancies() {
            ApoiadorFactory.get()
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.apoiadores = response;
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