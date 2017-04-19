(function () {
    'use strict';
    angular.module('sani').controller('ApoiadoCtrl', ApoiadoCtrl);

    ApoiadoCtrl.$inject = ['ApoiadoFactory'];

    function ApoiadoCtrl(ApoiadoFactory) {
        var vm = this;
        vm.apoiados = [];
        vm.apoiado = {
            id: '',
            nome: ''
        };
        vm.saveApoiado = saveApoiado;
        vm.loadApoiado = loadApoiado;
        vm.cancel = cancel;
        vm.removeApoiado = removeApoiado;

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

        function saveApoiado() {
            if (vm.apoiado.id === 0) {
                addApoiado();
            } else {
                updateApoiado();
            }
        }

        function addApoiado() {
            ApoiadoFactory.post(vm.apoiado)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.apoiados.push(response);
            }

            function fail(error) {
                if (error.data === '') {
                    toastr.error(error.status, error.statusText);
                }
                else {
                    var erros = error.data;
                    for (var i = 0; i < erros.length; ++i) {
                        toastr.error(erros[i].value, 'Falha na Requisição');
                    }
                }
            }
            clearApoiado();
        }

        function updateApoiado() {
            ApoiadoFactory.put(vm.apoiado)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Apoiado <strong>' + apoiado.nome + '</strong> alterada com sucesso', 'Sucesso');
            }

            function fail(error) {
                var erros = error.data;
                for (var i = 0; i < erros.length; ++i) {
                    toastr.error(erros[i].value, 'Falha na Requisição');
                }
            }
            clearApoiado();
        }

        function removeApoiado(apoiado) {
            loadApoiado(apoiado);
            ApoiadoFactory.remove(vm.apoiado)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Apoiado <strong>' + apoiado.name + '</strong> removida com sucesso', 'Sucesso');
                var index = vm.apoiados.indexOf(apoiado);
                vm.apoiados.splice(index, 1);
            }

            function fail(error) {
                var erros = error.data;
                for (var i = 0; i < erros.length; ++i) {
                    toastr.error(erros[i].value, 'Falha na Requisição');
                }
            }

            clearApoiado();
        }

        function loadApoiado(apoiado) {
            vm.apoiado = apoiado;
        }

        function cancel() {
            clearApoiado();
        }

        function clearApoiado() {
            vm.apoiado = {
                id: 0,
                name: ''
            };
        }
    }
})();