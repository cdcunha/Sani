(function () {
    'use strict';
    angular.module('sani').controller('VoluntarioEditCtrl', VoluntarioEditCtrl);

    VoluntarioEditCtrl.$inject = ['$routeParams', 'VoluntarioFactory'];

    function VoluntarioEditCtrl($routeParams, VoluntarioFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.voluntario = {};

        activate();
        vm.save = save;

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
                if (error.data === '') {
                    toastr["error"](error.status + "<br/><button type='button' class='btn clear'>Ok</button>", error.statusText);
                }
                else {
                    var erros = error.data;
                    for (var i = 0; i < erros.length; ++i) {
                        toastr["error"](erros[i].value + "<br/><button type='button' class='btn clear'>Ok</button>", 'Falha na Requisição');
                    }
                }
            }
        }

        function save() {
            VoluntarioFactory.put(vm.voluntario)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr["success"]("Voluntário <strong>" + response.nome + "</strong> cadastrado com sucesso<br/><button type='button' class='btn clear'>Ok</button>", "Voluntário Cadastrado");
                $location.path('/voluntarios');
            }

            function fail(error) {
                if (error.status === 401)
                    toastr["error"]("Você não tem permissão para ver esta página<br/><button type='button' class='btn clear'>Ok</button>", 'Requisição não autorizada');
                else {
                    if (error.data === '') {
                        toastr["error"](error.status + "<br/><button type='button' class='btn clear'>Ok</button>", error.statusText);
                    }
                    else {
                        var erros = error.data;
                        for (var i = 0; i < erros.length; ++i) {
                            toastr["error"](erros[i].value + "<br/><button type='button' class='btn clear'>Ok</button>", 'Falha na Requisição');
                        }
                    }
                }
            }
        }
    };
})();