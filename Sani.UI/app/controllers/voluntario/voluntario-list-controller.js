(function () {
    'use strict';
    angular.module('sani').controller('VoluntarioListCtrl', VoluntarioListCtrl);

    VoluntarioListCtrl.$inject = ['VoluntarioFactory'];

    function VoluntarioListCtrl(VoluntarioFactory) {
        var vm = this;
        vm.voluntarios = [];

        activate();

        function activate() {
            getVoluntarios();
        }

        function getVoluntarios() {
            VoluntarioFactory.get()
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.voluntarios = response;
                vm.voluntarios.forEach(function (voluntario) {
                    if (voluntario.dataNascimento != null) {
                        var arDate = voluntario.dataNascimento.substring(0, 10).split('-');
                        voluntario.dataNascimento = new Date(arDate[1] + '/' + arDate[2] + '/' + arDate[0]);
                    }
                });
            }

            function fail(error) {
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
    };
})();