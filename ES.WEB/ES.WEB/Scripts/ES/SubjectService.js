﻿app.service('SubjectService', function ($http) {
    var urlpath = "/ESWEB/api/Subject/";

    ///*Subject*/
    this.getSubject = function () {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "GetSubject",
        });
        return request;
    };
    this.loadSubjectDropdown = function (Id) {

        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "LoadSubjectDropdown/" + Id
        });
        return request;
    };
    this.AddSubject = function (objSubject) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "AddSubject",
            data: JSON.stringify(objSubject)
        });
        return request;
    };

});