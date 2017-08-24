app.service('SubjectService', function ($http) {
    var urlpath = "http://localhost:9810/api/Subject/";

    ///*Subject*/
    this.getSubject = function () {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath,
        });
        return request;
    };
    this.loadSubjectDropdown = function (Id) {

        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + Id
        });
        return request;
    };
    this.AddSubject = function (objSubject) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath,
            data: JSON.stringify(objSubject)
        });
        return request;
    };

});