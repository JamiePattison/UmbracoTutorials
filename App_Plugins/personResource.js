angular.module('umbraco.resources')
    .factory('personResource', function ($http) {
        return {
            getById: function (id) {
                return $http.get("backoffice" + id);
            },
            save: function (person) {
                return $http.post("backoffice", angular.toJSON(person));
            },
            deleteById: function (id) {
                return $http.delete("backoffice" + id);
            }
        };
    });