(function() {
    var app = angular.module("naiveApp", ["booksData"]);

    app.controller("NaiveController", function($scope, Book) {
        var model = null;
        $scope.books = Book.query();
        $scope.model = null;

        $scope.select = function(book) {
            model = book;
            $scope.model = angular.copy(book);
        };

        $scope.save = function () {
            angular.copy($scope.model, model);
            $scope.model = null;
        };

        $scope.cancel = function() {
            $scope.model = null;
        };
    });
}());