app.service("ClassSubjectService", function ($http) {
    var urlpath = "http://localhost:9810/api/ClassSubject/";

    ///*Section*/
    this.getAllClassSubject = function () {
        
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath,
        });
        return request;
    };
    this.getClassSubject = function (Id) {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + Id
        });
        return request;
    };
    this.addClassSubject = function (objClassSubject) {
        
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath,
            data: JSON.stringify(objClassSubject)
        });
        return request;
    };
    // add multiple subjects to single class.
    this.addClassSubjects = function (arrClassSubject) {
        
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "AddClassSubjects",
            data: JSON.stringify(arrClassSubject)
        });
        return request;
    };

    this.getMappedClassSubjects = function () {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "GetMappedClassSubjects"
        });
        return request;
    };

});

app.controller("ClassSubjectIndexController", function ($scope, $location, ClassSubjectService, ESService, SubjectService) {
    //$scope.$root.isEdit = false;
    //$scope.GetAllClassSubjects = function(Id){
    //    $scope.$root.ClassSubjectId = Id;
    //    $location.path("ClassSubject");
    //}
    GetAllClasses();
    GetAllSubjects();
    getClassSubject(0);
    getMappedClassSubjects();
    function getClassSubject(id) {
        $("#overlay").show();
        var promiseClassSubject = ClassSubjectService.getClassSubject(id);
        promiseClassSubject.then(function (response) {
            if(response.status==200)
            {
                $scope.ClassSubject = response.data;
                $("#overlay").hide();
            }
        },
        function(errorc){
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

    function GetAllSubjects() {
        $("#overlay").show();
        var promiseAllSubjects = SubjectService.getSubject();
        promiseAllSubjects.then(function (response) {
            if(response.status == 200){
                $scope.subjects2 = response.data;
                $("#overlay").hide();
            }
        },function(errorc){
            $scope.error =errorc;
            $("#overlay").hide();
        });
    }

    function getMappedClassSubjects() {
        $("#overlay").show();
        var promiseAllClassSubjects = ClassSubjectService.getMappedClassSubjects();
        promiseAllClassSubjects.then(function (response) {
            if (response.status == 200) {
                $scope.ClassSubjectsGrid.data = response.data;
                $("#overlay").hide();
            }
        }, function (errorc) {
            $scope.error = errorc;
            $("#overlay").hide();
        });
    }
    $scope.SaveClassSubjects = function(classid, subjectids) {
        $("#overlay").show();
        var arrClassSubject = [];
        
        for(i=0; i<subjectids.length; i++){
            var objClassSubject = $scope.ClassSubject;
            objClassSubject.classID = classid;
            objClassSubject.subjectID = subjectids[i];
            arrClassSubject.push(objClassSubject);
        };
       
        var promiseClassSubjectsSave = ClassSubjectService.addClassSubjects(arrClassSubject);
        promiseClassSubjectsSave.then(function (response) {
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

    $scope.ClassSubjectsGrid = {
        enableCellEdit: true,
        enableSorting: true,
        enableFiltering: true,
        paginationPageSizes: [50, 100, 500],
        paginationPageSize: 50,
        enablePaginationControls: true,
        enableGridMenu: true,
        enableColumnResizing: true,
        columnDefs: [
        { name: 'id', displayName: 'Sr.No', headerCellClass: 'gridheader', width: '5%', enableCellEdit: false },
        { name: 'className', displayName: 'Class Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'subjectName', displayName: 'Subject Name', headerCellClass: 'gridheader', width: '15%' },
        ],
    };
});