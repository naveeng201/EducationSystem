app.service("ESService", function ($http) {
    var urlpath = "/ESWEB/api/ESAPI/";

    this.validateLogin = function (LoginViewModel) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "Login",
            data: JSON.stringify(LoginViewModel)
        });
        return request;
    };

    ///* Class*/
    this.getClass = function () {
        var request = $http({
            method: "get",
            contentType: "Application/json",
            url: "http://localhost:9810/api/Class/" + "GetClass"
        });
        return request;
    };
    this.loadClassDropdowns = function (Id) {
        debugger;
        var request = $http({
            method: "get",
            contentType: "Application/json",
            url: "http://localhost:9810/api/Class/" + "LoadClassDropdowns/" + Id

        });
        return request;
    };
    this.AddClass = function (objclass) {
        debugger;
        var request = $http({
            method: "post",
            contentType: "Application/json",
            url: "http://localhost:9810/api/Class/" + "AddClass",
            data: JSON.stringify(objclass)
        });
        return request;
    };
});