app.service('InstitutionInfoService', function ($http) {
    var urlpath = "http://localhost:9810/api/InstitutionInfo/";

    this.getInstitutionInfo = function () {
        var response = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "getInstitutionInfo"
        });
        return response;
    };

    this.loadInstitutionInfoDropown = function (id) {
        var response = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "LoadInstituteDropdown/"+id
        });
        return response;
    };


    this.addInstitute = function (objInstitute) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "AddInstitute",
            data: JSON.stringify(objInstitute)
        });
        return request;
    };
});