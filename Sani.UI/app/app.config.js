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
            .when('/apoiadores', {
                controller: 'ApoiadorListCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiador/index.html'
            })
            .when('/apoiadores/create', {
                controller: 'ApoiadorCreateCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiador/create.html'
            })
            .when('/apoiadores/edit/:id', {
                controller: 'ApoiadorEditCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiador/edit.html'
            })
            .when('/apoiadores/remove/:id', {
                controller: 'ApoiadorRemoveCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/apoiador/edit.html'
            })
            .otherwise({
                redirectTo: '/'
            });
        }
    ]);
