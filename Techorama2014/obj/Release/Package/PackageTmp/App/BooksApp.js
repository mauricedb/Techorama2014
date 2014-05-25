

(function () {
    function config($routeProvider, $locationProvider) {
        $routeProvider.when("/Books", {
            controller: "BooksListController",
            templateUrl: "/Templates/Books/List",
            resolve: {
                books: [
                    "Books", function (Books) {
                        return Books.query();
                    }
                ]
            }
        });

        $routeProvider.when("/Books/:id", {
            controller: "BooksEditController",
            templateUrl: "/Templates/Books/Editor",
            resolve: {
                book: [
                    "$route", "Books", function ($route, Books) {
                        return Books.get({ id: $route.current.params.id });
                    }
                ]
            }
        });

        $locationProvider.html5Mode(true);
    }

    config.$inject = ["$routeProvider", "$locationProvider"];

    function BooksListController($scope, $location, books) {
        $scope.books = books;

        $scope.gridOptions = {
            data: 'books',
            columnDefs: [
                { field: 'title', displayName: 'Title' },
                { field: 'author', displayName: 'Author' }
            ],
            afterSelectionChange: function (rowItem) {
                if (rowItem.selected) {
                    $location.path("/Books/" + rowItem.entity.id);
                }
            }
        };
    }

    BooksListController.$inject = ["$scope", "$location", "books"];

    function getModelStateErrors(modelState) {
        var errors = [];

        function addError(error) {
            if (error.errorMessage) {
                errors.push(error.errorMessage);
            }
        }

        for (var prop in modelState) {
            if (modelState.hasOwnProperty(prop)) {
                var value = modelState[prop];
                if (value.errors && value.errors.forEach) {
                    value.errors.forEach(addError);
                }
            }
        }

        return errors;
    }

    function BooksEditController($scope, $location, book) {
        $scope.book = book;
        $scope.errors = [];

        $scope.save = function () {
            book.$save().then(
                function () {
                    $scope.errors = [];
                    $location.path("/Books");
                },
                function (e) {
                    $scope.errors = getModelStateErrors(e.data);
                });
        };

        $scope.cancel = function () {
            $location.path("/Books");
        };
    }

    BooksEditController.$inject = ["$scope", "$location", "book"];

    var app = angular.module("booksApp", ["booksData", "appDirectives", "ngRoute", "ngGrid"]);
    app.config(config);
    app.controller("BooksListController", BooksListController);
    app.controller("BooksEditController", BooksEditController);
}());
