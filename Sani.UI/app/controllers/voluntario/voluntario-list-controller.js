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
            }

            function fail(error) {
                if (error.data === '') {
                    toastr["error"](error.status + "<br/><button type='button' class='btn clear'>Ok</button>", error.statusText);
                }
                else
                {
                    var erros = error.data;
                    for (var i = 0; i < erros.length; ++i) {
                        toastr["error"](erros[i].value + "<br/><button type='button' class='btn clear'>Ok</button>", 'Falha na Requisição');
                    }
                }
            }
        }
    };
})();