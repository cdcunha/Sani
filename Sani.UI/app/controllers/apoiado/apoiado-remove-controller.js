(function () {
    'use strict';
    angular.module('sani').controller('ApoiadoRemoveCtrl', ApoiadoRemoveCtrl);

    ApoiadoRemoveCtrl.$inject = ['$routeParams', '$filter', '$location', 'ApoiadoFactory'];

    function ApoiadoRemoveCtrl($routeParams, $filter, $location, ApoiadoFactory) {
        var vm = this;
        var id = $routeParams.id;
        vm.apoiado = {};

        activate();
        vm.remove = remove;
        vm.cancel = cancel;

        function activate() {
            getApoiado();
        }

        function getApoiado() {
            ApoiadoFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.apoiado = response;
                var arDate = response.dataNascimento.substring(0, 10).split('-');
                vm.apoiado.dataNascimento = new Date(arDate[1] + '/' + arDate[2] + '/' + arDate[0]);
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
            ApoiadoFactory.remove(vm.apoiado)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr["success"]("Apoiado <strong>" + response.nome + "</strong> removido com sucesso<br/><button type='button' class='btn clear'>Ok</button>", 'Apoiado Removido');
                $location.path('/apoiados');
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
            $location.path('/apoiados');
        }
    };
})();