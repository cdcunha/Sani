(function () {
    'use strict';
    angular.module('sani').controller('ApoiadoCreateCtrl', ApoiadoCreateCtrl);
        /*.directive('ngModel', function attributeNgModelDirective() {
            return {
                require: 'ngModel',
                link: function (scope, el, attrs, ctrl) {
                    ctrl.$attributes = attrs;
                }
            };
    });*/
    
    ApoiadoCreateCtrl.$inject = ['$scope', '$location', 'ApoiadoFactory'];

    function ApoiadoCreateCtrl($scope, $location, ApoiadoFactory) {
        var vm = this;
        vm.apoiados = [];
        vm.apoiado = {
            id: 0,
            name: '',
            nomeMae: '',
            nomePai: '',
            logradouro: '',
            numeroLogradouro: '',
            complementoLogradouro: '',
            bairro: '',
            cidade: '',
            uf: '',
            estadoCivil: '',
            telefone: '',
            celular: '',
            email: '',
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
        vm.save = save;
        vm.cancel = cancel;

        var today = new Date();
        today.setYear(today.getFullYear() - 16);
        vm.minBirthDate = new Date(today.getFullYear(), today.getMonth(), today.getDate());
        today.setYear(today.getFullYear() - 90);
        vm.maxBirthDate = new Date(today.getFullYear(), today.getMonth(), today.getDate());
        
        function save() {
            ApoiadoFactory.post(vm.apoiado)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success("Apoiado <strong>" + response.nome + "</strong> cadastrado com sucesso<br/><br/><button type='button' class='btn clear'>Yes</button>", "Apoiado Cadastrado");
                $location.path('/apoiados');
            }

            function fail(error){
                if (error.status === 401)
                    toastr.error("Você não tem permissão para ver esta página<br/><button type='button' class='btn clear'>Ok</button>", 'Requisição não autorizada');
                else {
                    if (error.data === '') {
                        toastr.error(error.status + "<br/><button type='button' class='btn clear'>Ok</button>", error.statusText);
                    }
                    else {
                        var erros = error.data;
                        for (var i = 0; i < erros.length; ++i) {
                            toastr.error(erros[i].value + "<br/><button type='button' class='btn clear'>Ok</button>", 'Falha na Requisição');
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
                nomeMae: '',
                nomePai: '',
                logradouro: '',
                numeroLogradouro: '',
                complementoLogradouro: '',
                bairro: '',
                cidade: '',
                uf: '',
                estadoCivil: '',
                telefone: '',
                celular: '',
                email: '',
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