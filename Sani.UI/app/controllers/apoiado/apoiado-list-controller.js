﻿(function () {
    'use strict';
    angular.module('sani').controller('ApoiadoCtrl', ApoiadoCtrl);

    ApoiadoCtrl.$inject = ['ApoiadoFactory'];

    function ApoiadoCtrl(ApoiadoFactory) {
        var vm = this;
        vm.apoiados = [];
        
        activate();
        
        function activate() {
            getApoiados();
        }

        function getApoiados() {
            ApoiadoFactory.get()
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.apoiados = response;
            }

            function fail(error) {
                if (error.status === 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else {
                    if (error.data === '') {
                        toastr.error(error.status, error.statusText);
                    }
                    else
                    {
                        var erros = error.data;
                        for (var i = 0; i < erros.length; ++i) {
                            toastr.error(erros[i].value, 'Falha na Requisição');
                        }
                    }
                }
            }
        }
    }
})();