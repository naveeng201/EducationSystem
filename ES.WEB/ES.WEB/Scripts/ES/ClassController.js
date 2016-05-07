app.controller('ClassIndexController', function ($scope, $location, ESService) {
    $scope.$root.isEdit = false;
    $scope.LoadClassDetails = function (Id) {
        $scope.$root.ClassId = Id;
        $location.path("ClassDetails");
    }
    loadAllClass();
    function loadAllClass() {
        $("#overlay").show();
        var promiseCostCenter = ESService.getClass();
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
        { name: 'className', displayName: 'Class Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'description', displayName: 'Description', headerCellClass: 'gridheader', width: '15%' },
        
        {
            name: 'createDate', displayName: 'Requested Date', headerCellClass: 'gridheader',
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
     { name: ' ', displayName: 'Edit', enableFiltering: false, width: '25%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().ClassEditDetail(row.entity)">Edit</a></span>', headerCellClass: 'gridheader' }
        ],
    };
    $scope.ShowClassStatusDetail = function (row) {
        alert('Class');

    };
    $scope.ClassEditDetail = function (row) {
        $scope.$root.gridData = row;
        $scope.$root.ClassId = row.id;
        $location.path("ClassDetails");
    };
});

app.controller('ClassDetailController', function ($scope, $location, $window, ESService) {
    var Id = 0;
    //$scope.submitted = false;
    if ($scope.$root.ClassId == 0) {
        Id = $scope.$root.ClassId;
    }
    else {
        var Id = 1;
    }
    loadClassDropdowns(Id);
    function loadClassDropdowns(Id) {
        debugger;
        $("#overlay").show();

        var promiseClassDropdownList = ESService.loadClassDropdowns(Id);
        promiseClassDropdownList.then(function (respons) {
            debugger;
            if (respons.status == 200) {
                if (respons.data != null) {
                    $scope.Class = respons.data;
                }
                else {
                    $scope.Class = $scope.$root.gridData;
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
    $scope.addClass = function () {
        debugger;
        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        var objclass = $scope.Class
        var promisePost = ESService.AddClass(objclass);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Class Saved Successfully.");
                $("#overlay").hide();
                $location.path("Class");
            }
            else {
                alert("Class Not Saved ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Class', errorPl;
            $("#overlay").hide();

        });
        //}
    };

});
