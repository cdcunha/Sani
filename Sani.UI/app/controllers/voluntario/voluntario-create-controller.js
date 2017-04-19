(function () {
    'use strict';
    angular.module('sani').controller('VoluntarioCreateCtrl', VoluntarioCreateCtrl);

    VoluntarioCreateCtrl.$inject = ['$scope', '$location', 'VoluntarioFactory'];

    function VoluntarioCreateCtrl($scope, $location, VoluntarioFactory) {
        var vm = this;
        vm.voluntarios = [];
        vm.voluntario = {
            id: '',
            nome: '',
        };
        vm.save = save;

        /*activate();

        function activate() {
            getTechnologies();
        }

        function getTechnologies() {
            TechnologyFactory.get()
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.technologies = response;
            }

            function fail(error) {
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else
                    toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }*/

        function save() {
            VoluntarioFactory.post(vm.voluntario)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Voluntário <strong>' + response.name + '</strong> cadastrado com sucesso', 'Voluntário Cadastrado');
                $location.path('/voluntarios');
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
                    vm.voluntario.image = evt.target.result;
                });
            };
            reader.readAsDataURL(file);
        };
        angular.element(document.querySelector('#file')).on('change', handleFileSelect);
        */
    };
})();