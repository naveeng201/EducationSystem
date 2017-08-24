app.service("SectionService", function ($http) {
    var urlpath = "http://localhost:9810/api/Section/";

      ///*Section*/
    this.getSection = function () {
        
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath,
        });
        return request;
    };
    this.loadSectionDropdown = function (Id) {
        
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + Id
        });
        return request;
    };
    this.AddSection = function (objSection) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath,
            data: JSON.stringify(objSection)
        });
        return request;
    };

});