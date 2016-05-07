app.controller('SectionIndexController', function ($scope, $location, SectionService) {
    $scope.$root.isEdit = false;
    $scope.LoadSectionDetails = function (Id) {
        $scope.$root.SectionId = Id;
        $location.path("SectionDetails");
    }
    loadAllSections();
    function loadAllSections() {
        $("#overlay").show();
        var promiseCostCenter = SectionService.getSection();
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
        { name: 'sectionName', displayName: 'Section Name', headerCellClass: 'gridheader', width: '15%' },
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
     { name: 'edit', displayName: 'Edit', enableFiltering: false, width: '15%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().SectionEditDetail(row.entity)">Edit</a></span>', headerCellClass: 'gridheader' },
        { name: 'delete', displayName: 'Delete', enableFiltering: false, width: '15%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().deleteSection(row.entity)">Delete</a></span>', headerCellClass: 'gridheader' }

        ],
    };
    $scope.ShowSectionStatusDetail = function (row) {
        alert('Section');

    };
    $scope.SectionEditDetail = function (row) {
        $scope.$root.gridData = row;
        $scope.$root.ClassId = row.id;
        $location.path("SectionDetails");
    };
    //Delete Function
    $scope.deleteSection = function (row) {
        debugger;
        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        row.blocked = true;
        var objSection = row;
        var promisePost = SectionService.AddSection(objSection);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Section Deleted Successfully.");
                $("#overlay").hide();
                $location.path("Section");
            }
            else {
                alert("Section Not Deleted ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Section', errorPl;
            $("#overlay").hide();

        });
        //}
    };
});

app.controller('SectionDetailController', function ($scope, $location, $window, SectionService) {
    var Id = 0;
    //$scope.submitted = false;
    if ($scope.$root.SectionId == 0) {
        Id = $scope.$root.SectionId;
    }
    else {
        var Id = 1;
    }
    loadSectionDropdown(Id);
    function loadSectionDropdown(Id) {
       
        $("#overlay").show();

        var promiseSectionDropdownList = SectionService.loadSectionDropdown(Id);
        promiseSectionDropdownList.then(function (respons) {
            debugger;
            if (respons.status == 200) {
                if (respons.data != null) {
                    $scope.Section= respons.data;
                }
                else {
                    $scope.Section = $scope.$root.gridData;
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
    $scope.addSection = function () {
        
        $("#overlay").show();
        //$scope.$broadcast('show-errors-check-validity');
        // $scope.submitted = true;
        // if ($scope.MDMForm.$valid) {
        var objSection = $scope.Section;
        var promisePost = SectionService.AddSection(objSection);
        promisePost.then(function (pl) {
            if (pl.status == 200) {
                alert("Section Saved Successfully.");
                $("#overlay").hide();
                $location.path("Section");
            }
            else {
                alert("Section Not Saved ( Error : " + pl.data + " )")
            }
        },
        function (errorPl) {
            $scope.error = 'failure loading Section', errorPl;
            $("#overlay").hide();

        });
        //}
    };

});
