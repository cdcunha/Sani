(function () {
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
                vm.apoiados.forEach(function (apoiado) {
                    if (apoiado.dataNascimento != null) {
                        var arDate = apoiado.dataNascimento.substring(0, 10).split('-');
                        apoiado.dataNascimento = new Date(arDate[1] + '/' + arDate[2] + '/' + arDate[0]);
                    }
                });
            }

            function fail(error) {
                if (error.status === 401)
                    toastr["error"]("Você não tem permissão para ver esta página<br/><button type='button' class='btn clear'>Ok</button>", 'Requisição não autorizada');
                else {
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
        }
    }
})();