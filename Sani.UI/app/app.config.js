angular.module('sani').config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);

angular.module('sani')
    .config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider
            /****************************************
            * Apoiado
            *****************************************/
            .when('/apoiados', {
                controller: 'ApoiadoCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiado/index.html'
            })
            .when('/apoiados/create', {
                controller: 'ApoiadoCreateCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiado/create.html'
            })
            .when('/apoiados/edit/:id', {
                controller: 'ApoiadoEditCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiado/edit.html'
            })
            .when('/apoiados/remove/:id', {
                controller: 'ApoiadoRemoveCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiado/remove.html'
            })
            /****************************************
            * Voluntarios
            *****************************************/
            .when('/voluntarios', {
                controller: 'VoluntarioListCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/voluntario/index.html'
            })
            .when('/voluntarios/create', {
                controller: 'VoluntarioCreateCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/voluntario/create.html'
            })
            .when('/voluntarios/edit/:id', {
                controller: 'VoluntarioEditCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/voluntario/edit.html'
            })
            .when('/voluntarios/remove/:id', {
                controller: 'VoluntarioRemoveCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/voluntario/edit.html'
            })
            .otherwise({
                redirectTo: '/'
            });
        }
    ]);
