(function () {
    var module = angular.module("appDirectives", []);

    function appTextInput() {
        function link(scope) {
            scope.form = scope.$parent.form;
        }

        return {
            restrict: "E",
            templateUrl: "/Templates/Directives/EditorTextInput",
            scope: {
                ngModel: "=",
                ngDisabled: "@",
                caption: "@",
                name: "@"
            },
            link: link
        };
    }

    module.directive("appTextInput", appTextInput);

}());