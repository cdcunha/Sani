(function () {
    'use strict';
    angular.module('sani').controller('ApoiadoEditCtrl', ApoiadoEditCtrl);

    ApoiadoEditCtrl.$inject = ['$routeParams', 'ApoiadoFactory'];

    function ApoiadoEditCtrl($routeParams, ApoiadoFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.apoiado = {};

        activate();

        function activate() {
            getApoiado();
        }

        function getApoiado() {
            ApoiadoFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.apoiado = response;
            }

            function fail(error) {
                if (error.data === '') {
                    toastr.error(error.status, error.statusText)
                }
                else {
                    var erros = error.data;
                    for (var i = 0; i < erros.length; ++i) {
                        toastr.error(erros[i].value, 'Falha na Requisição')
                    }
                }
            }
        }
    };
})();