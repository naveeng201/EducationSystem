app.service('StudentInfoService', function ($http) {
    var urlpath = "http://localhost:9810/api/StudentInfo/";

    this.loadStudentInfo = function (Id) {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "loadStudentInfo/" + Id
        });
        return request;
    };

    this.AddStudentInfo = function (objStudent) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "AddStudentInfo",
            data: JSON.stringify(objStudent)
        });
        return request;
    };
});