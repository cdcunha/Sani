angular.module('sani')
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
            .when('/github/users/:id', {
                templateUrl: 'app/templates/GitHub.Users/Users.html',
                controller: 'GitHubUsersCtrl',
            })
            .when('/github/user/detail/:login', {
                templateUrl: 'app/templates/GitHub.Users/Details.html',
                controller: 'GitHubUserDetCtrl'
            })
            .when('/github/users/repo/:login', {
                templateUrl: 'app/templates/GitHub.Users/Repo.html',
                controller: 'GitHubUserRepoCtrl'
            })
            /****************************************
            * Apoiado/Apoiado
            *****************************************/
            .when('/apoiados', {
                controller: 'ApoiadoCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiado/index.html'
            })
            /****************************************
            * Vaga
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
