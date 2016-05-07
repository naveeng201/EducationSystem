app.service("SectionService", function ($http) {
    var urlpath = "/ESWEB/api/Section/";

      ///*Section*/
    this.getSection = function () {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "GetSection",
        });
        return request;
    };
    this.loadSectionDropdown = function (Id) {
        
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "LoadSectionDropdown/" + Id
        });
        return request;
    };
    this.AddSection = function (objSection) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "AddSection",
            data: JSON.stringify(objSection)
        });
        return request;
    };

});