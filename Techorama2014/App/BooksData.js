(function() {
    var module = angular.module("booksData", ["ngResource"]);

    function Book($resource) {
        return $resource("/api/books/:id", {
            id: "@id"
        }, {
            save: {
                method: 'PUT'
            }
        });
    }

    Book.$inject = ["$resource"];

    module.factory("Book", Book);
}());