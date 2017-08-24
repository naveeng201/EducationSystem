app.service("ClassSectionsService", function ($http) {
    var urlpath = "http://localhost:9810/api/ClassSection/";

    ///*Section*/
    this.getAllClassSection = function () {
        
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath,
        });
        return request;
    };
    this.getClassSection = function (Id) {
        
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + Id
        });
        return request;
    };
    this.addClassSection = function (objClassSection) {
        
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath,
            data: JSON.stringify(objClassSection)
        });
        return request;
    };
    // add multiple sections to single class.
    this.addClassSection = function (arrClassSection) {
        
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "AddClassSections",
            data: JSON.stringify(arrClassSection)
        });
        return request;
    };

});

app.controller("ClassSectionIndexController", function ($scope, $location, ClassSectionsService, ESService, SectionService) {
    GetAllClasses();
    GetAllSections();
    getClassSection(0);
    function getClassSection(id) {
        
        $("#overlay").show();
        var promiseClassSection = ClassSectionsService.getClassSection(id);
        promiseClassSection.then(function (response) {
            if (response.status == 200) {
                $scope.ClassSection = response.data;
                $("#overlay").hide();
            }
        },
        function (errorc) {
            $scope.error = errorc;
            $("#overlay").hide();
        });
    }
    function GetAllClasses() {
        $("#overlay").show();
        var promiseAllClasses = ESService.getClass();
        promiseAllClasses.then(function (response) {
            if (response.status == 200) {
                $scope.classes2 = response.data;
                $scope.$scope.Classes = response.data;
                $("#overlay").hide();
            }
        }, function (errorc) {
            $scope.error = errorc;
            $("#overlay").hide();
        });
    }
    //$scope.GoBack = function () {
    //    $window.history.back();
    //}

    function GetAllSections() {
        $("#overlay").show();
        var promiseAllSections = SectionService.getSection();
        promiseAllSections.then(function (response) {
            if (response.status == 200) {
                $scope.sections2 = response.data;
                $("#overlay").hide();
            }
        }, function (errorc) {
            $scope.error = errorc;
            $("#overlay").hide();
        });
    }

    $scope.SaveClassSections = function (classid, sectionids) {
        $("#overlay").show();
        var arrClassSections = [];
        var arrClassSections1 = [];
        //for (i = 0; i < sectionids.length; i++) {
        //    var objClassSection = $scope.ClassSection;
        //    objClassSection.sectionID = sectionids[i].id;
        //    objClassSection.classID = classid;
        //    arrClassSections.push(objClassSection);
        //
        var objClassSectionCopy = $scope.ClassSection;
        angular.forEach(sectionids, function(value, key) {
            var objClassSection = $scope.ClassSection;
            objClassSection.sectionID = value;
            objClassSection.classID = classid;
            var objClassSectionCopy = $scope.ClassSection;
            angular.copy(objClassSection, arrClassSections1);
            arrClassSections.push(arrClassSections1);

        });

        var promiseClassSectionSave = ClassSectionsService.addClassSection(arrClassSections);
        promiseClassSectionSave.then(function (response) {
            if (response.status == 200) {
                alert("Saved Successfully.");
                $("#overlay").hide();
            }
        },
        function (errorc) {
            $scope.error = errorc;
            $("#overlay").hide();
        });
        $("#overlay").hide();
    }
});