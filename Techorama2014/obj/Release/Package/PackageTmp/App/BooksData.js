(function () {
    var module = angular.module("booksData", ["ngResource"]);
    function Books($resource) {
        return $resource("/api/books/:id", { id: "@id" }, { save: { method: 'PUT' } });
    }

    Books.$inject = ["$resource"];

    module.factory("Books", Books);
}());
