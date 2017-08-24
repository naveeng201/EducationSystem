app.service("ESService", function ($http) {
    var urlpath = "http://localhost:9810/api/Class/";
    var urloldpath = "/ESWEB/api/ESAPI/";

    this.validateLogin = function (LoginViewModel) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urloldpath + "Login",
            data: JSON.stringify(LoginViewModel)
        });
        return request;
    };

    ///* Class*/
    this.getClass = function () {
        var request = $http({
            method: "get",
            contentType: "Application/json",
            url: "urlpath"
        });
        return request;
    };
    this.loadClassDropdowns = function (Id) {
        var request = $http({
            method: "get",
            contentType: "Application/json",
            url: urlpath + Id

        });
        return request;
    };
    this.AddClass = function (objclass) {
        var request = $http({
            method: "post",
            contentType: "Application/json",
            url: urlpath,
            data: JSON.stringify(objclass)
        });
        return request;
    };
});