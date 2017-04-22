app.controller('SubjectIndexController', function ($scope, $location, SubjectService) {
    $scope.$root.isEdit = false;
    $scope.LoadSubjectDetails = function (Id) {
        $scope.$root.SubjectId = Id;
        $location.path("SubjectDetails");
    }
    loadAllSubjects();
    function loadAllSubjects() {
        $("#overlay").show();
        var promiseCostCenter = SubjectService.getSubject();
        promiseCostCenter.then(function (respons) {
            if (respons.status == 200) {
                $scope.Classgrid.data = respons.data;
                $("#overlay").hide();
            }
        },
        function (errorCc) {
            $scope.error = errorCc;
            $("#overlay").hide();
        });
    }
    $scope.$scope = $scope;
    $scope.Classgrid = {
        enableCellEdit: false,
        enableSorting: true,
        enableFiltering: true,
        paginationPageSizes: [50, 100, 500],
        paginationPageSize: 50,
        enablePaginationControls: true,
        enableGridMenu: true,
        enableColumnResizing: true,
        columnDefs: [
        { name: 'id', displayName: 'Sr.No', headerCellClass: 'gridheader', width: '5%', enableCellEdit: false },
        { name: 'subjectName', displayName: 'Subject Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'shortName', displayName: 'Short Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'description', displayName: 'Description', headerCellClass: 'gridheader', width: '15%' },

        {
            name: 'createDate', displayName: 'Create Date', headerCellClass: 'gridheader',
            cellTemplate: ' <span>{{row.entity.createDate | date:"dd/MM/yyyy"}}</span>',
            filter: {
                condition: function (searchTerm, cellValue) {
                    var from = cellValue.split("-");
                    var strippedValue = from[2].slice(0, 2) + '/' + from[1] + '/' + from[0];
                    var searchString = searchTerm.replace(/[&\\\#,+()$~%.'":*?<>{}]/g, '');
                    return strippedValue.indexOf(searchString) >= 0;
                }
            },
            width: '20%'
        },
        //, cellTemplate: ' <span>{{row.entity.CreatedDate | date:"dd-MMM-yyyy"}}</span>' },
    // { name: 'generalName', displayName: 'Status', width: '25%', cellTemplate: '<span style="text-align:center">{{row.entity.generalName}}</span>', headerCellClass: 'gridheader' },
     { name: 'edit', displayName: 'Edit', enableFiltering: false, width: '15%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().SubjectEditDetail(row.entity)">Edit</a></span>', headerCellClass: 'gridheader' },
        { name: 'delete ', displayName: 'Delete', enableFiltering: false, width: '15%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().deleteSubject(row.entity)">Delete</a></span>', headerCellClass: 'gridheader' }

        ],
    };
    $scope.ShowSubjectStatusDetail = function (row) {
        alert('Subject');

    };
    $scope.SubjectEditDetail = function (row) {
        $scope.$root.gridData = row;
        $scope.$root.SubjectId = row.id;
        $location.path("SubjectDetails");
    };
    //Delete Function
    $scope.deleteSubject = function (row) {

        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        row.blocked = true;
        var objSubject = row;
        var promisePost = SubjectService.AddSubject(objSubject);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Subject Deleted Successfully.");
                $("#overlay").hide();
                $location.path("Subject");
            }
            else {
                alert("Subject Not Deleted ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Subject', errorPl;
            $("#overlay").hide();

        });
        //}
    };
});

app.controller('SubjectDetailsController', function ($scope, $location, $window, SubjectService) {
    var Id = 0;
    //$scope.submitted = false;
    if ($scope.$root.SubjectId == 0) {
        Id = $scope.$root.SubjectId;
    }
    else {
        var Id = 1;
    }
    loadSubjectDropdown(Id);
    function loadSubjectDropdown(Id) {

        $("#overlay").show();

        var promiseSubjectDropdownList = SubjectService.loadSubjectDropdown(Id);
        promiseSubjectDropdownList.then(function (respons) {
            if (respons.status == 200) {
                if (respons.data != null) {
                    $scope.Subject = respons.data;
                }
                else {
                    $scope.Subject = $scope.$root.gridData;
                }
                $("#overlay").hide();
            }
        },
        function (errorCc) {
            $scope.error = errorCc;
            $("#overlay").hide();
        });
    }
    $scope.GoBack = function () {
        $window.history.back();
    }
    $scope.addSubject = function () {
        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        var objSubject = $scope.Subject;
        var promisePost = SubjectService.AddSubject(objSubject);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Subject Saved Successfully.");
                $("#overlay").hide();
                $location.path("Subject");
            }
            else {
                alert("Subject Not Saved ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Subject', errorPl;
            $("#overlay").hide();

        });
        //}
    };

});
