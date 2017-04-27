(function () {
    'use strict';
    angular.module('sani').controller('VoluntarioRemoveCtrl', VoluntarioRemoveCtrl);

    VoluntarioRemoveCtrl.$inject = ['$routeParams', '$filter', '$location', 'VoluntarioFactory'];

    function VoluntarioRemoveCtrl($routeParams, $filter, $location, VoluntarioFactory) {
        var vm = this;
        var id = $routeParams.id;
        vm.voluntario = {};

        activate();
        vm.remove = remove;
        vm.cancel = cancel;

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

        function remove() {
            VoluntarioFactory.remove(vm.voluntario)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr["success"]("Voluntario <strong>" + response.nome + "</strong> removido com sucesso<br/><button type='button' class='btn clear'>Ok</button>", 'Voluntario Removido');
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

        function cancel() {
            $location.path('/voluntarios');
        }
    };
})();