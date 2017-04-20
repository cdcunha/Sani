﻿(function () {
    'use strict';
    angular.module('sani').controller('ApoiadoCreateCtrl', ApoiadoCreateCtrl);

    ApoiadoCreateCtrl.$inject = ['$scope', '$location', 'ApoiadoFactory'];

    function ApoiadoCreateCtrl($scope, $location, ApoiadoFactory) {
        var vm = this;
        vm.apoiados = [];
        vm.apoiado = {
            id: '',
            nome: '',
            nomeMae: '',
            nomePai: '',
            logradouro: '',
            numeroLogradouro: '',
            complementoLogradouro: '',
            bairro: '',
            cidade: '',
            uf: '',
            estadoCivil: '',
            qtdeDependentes: 0,
            dataNascimento: '',
            ramoAtividade: '',
            possuiVinculoCarteira: false,
            tempoExperiencia: 0,
            observacao: ''
        };
        vm.save = save;
        vm.cancel = cancel;
        
        
        function save() {
            ApoiadoFactory.post(vm.apoiado)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Apoiado <strong>' + response.name + '</strong> cadastrado com sucesso', 'Apoiado Cadastrado');
                $location.path('/apoiados');
            }

            function fail(error){
                if (error.status === 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else {
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
        }

        /*var handleFileSelect = function (evt) {
            var file = evt.currentTarget.files[0];
            var reader = new FileReader();
            reader.onload = function (evt) {
                $scope.$apply(function ($scope) {
                    vm.apoiado.image = evt.target.result;
                });
            };
            reader.readAsDataURL(file);
        };
        angular.element(document.querySelector('#file')).on('change', handleFileSelect);
        */
        function cancel() {
            clearApoiado();
        }

        function clearApoiado() {
            vm.apoiado = {
                id: 0,
                name: '',
                telefone: '',
                celular: '',
                nomeMae: '',
                nomePai: '',
                logradouro: '',
                numeroLogradouro: '',
                complementoLogradouro: '',
                bairro: '',
                cidade: '',
                uf: '',
                estadoCivil: '',
                qtdeDependentes: 0,
                dataNascimento: '',
                ramoAtividade: '',
                possuiVinculoCarteira: false,
                tempoExperiencia: 0,
                observacao: '',
                ativo: '',
                dataCriacao: '',
                dataAlteracao: ''
            };
        }
    };
})();