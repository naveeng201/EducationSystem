app.service('InstitutionInfoService', function ($http) {
    var urlpath = "/ESWEB/api/InstitutionInfo/";

    this.getInstitutionInfo = function () {
        debugger;
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