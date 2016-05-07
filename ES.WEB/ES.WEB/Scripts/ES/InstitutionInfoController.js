app.controller('InstitutionInfoIndexController', function ($scope, $location, InstitutionInfoService) {
    debugger;
   // $scope.$root.isEdit = false;        
    $scope.LoadInstituteDetails = function (Id) {
        debugger;
        $scope.$root.InstituteId = Id;
        $location.path("InstitutionInfoDetails");
    }
    loadAllInstitutes();
    function loadAllInstitutes() {
        debugger;
        $("#overlay").show();
        var institutecenter = InstitutionInfoService.getInstitutionInfo();
        debugger;
        institutecenter.then(function(response){
            if(response.status==200)
            {
                $scope.Classgrid.data=response.data;
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
        { name: 'name', displayName: 'Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'shortName', displayName: 'Short Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'city', displayName: 'City', headerCellClass: 'gridheader', width: '15%' },

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
     { name: 'edit', displayName: 'Edit', enableFiltering: false, width: '15%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().InstituteEditDetail(row.entity)">Edit</a></span>', headerCellClass: 'gridheader' },
        { name: 'delete ', displayName: 'Delete', enableFiltering: false, width: '15%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().deleteInstitute(row.entity)">Delete</a></span>', headerCellClass: 'gridheader' }

        ],
    };
    $scope.ShowInstitutionInfoStatusDetail = function (row) {
        alert('Institution');

    };
    $scope.InstituteEditDetail = function (row) {
        $scope.$root.gridData = row;
        $scope.$root.InstituteId = row.id;
        $location.path("InstitutionInfoDetails");
    };
    //Delete Function
    $scope.deleteInstitute = function (row) {

        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        row.isBlocked = true;
        var objInstitute = row;
        var promisePost = InstitutionInfoService.addInstitute(objInstitute);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Institute Deleted Successfully.");
                $("#overlay").hide();
                $location.path("InstitutionInfo");
            }
            else {
                alert("Institute Not Deleted ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Institute', errorPl;
            $("#overlay").hide();

        });
        //}
    };
});

app.controller('InstitutionInfoDetailsController', function ($scope, $location, $window, InstitutionInfoService) {
    var Id = 0;
    //$scope.submitted = false;
    if ($scope.$root.InstituteId == 0) {
        Id = $scope.$root.InstituteId;
    }
    else {
        var Id = 1;
    }
    loadInstitutionInfoDropdown(Id);
    function loadInstitutionInfoDropdown(Id) {
        debugger;
        $("#overlay").show();

        var promiseInstitutionInfoDropdownList = InstitutionInfoService.loadInstitutionInfoDropown(Id);
        promiseInstitutionInfoDropdownList.then(function (respons) {
            debugger;
            if (respons.status == 200) {
                if (respons.data != null) {
                    $scope.InstitutionInfo = respons.data;
                }
                else {
                    $scope.InstitutionInfo = $scope.$root.gridData;
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
    $scope.addInstitute = function () {
        debugger;
        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        var objInstitute = $scope.InstitutionInfo;
        var promisePost = InstitutionInfoService.addInstitute(objInstitute);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Institute Saved Successfully.");
                $("#overlay").hide();
                $location.path("InstitutionInfo");
            }
            else {
                alert("Institute Not Saved ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Institute', errorPl;
            $("#overlay").hide();

        });
        //}
    };

});