app.service('StudentService',function($http){
    var urlpath = "http://localhost:9810/api/Student/";

    this.GetAll = function(){
        var request = $http({
            method : "get",
            contentType : "Application/json",
            url : urlpath+"GetAll"
        })
        return request;
    };
    this.SingleOrDefault = function (Id) {
        var request = $http({
            method: "get",
            contentType: "Application/json",
            url: urlpath + "SingleOrDefault/"+Id
        })
        return request;
    };

    this.InsertStudent = function (objStudent) {
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlpath + "Insert",
            data: JSON.stringify(objStudent)
        });
        return request;
    }
});




/***************************************************Controller***************************************************/

app.controller('StudentController', function ($scope, $location,$window, StudentService) {
    $scope.$root.isEdit = false;

    $scope.LoadStudnetDetails = function(id) {
        $scope.$root.StudentId = id;
        $location.path("StudentDetails");
    }

    LoadStudents();

    function LoadStudents(){
        $("#overlay").show();
        var studnetPromise = StudentService.GetAll();
        studnetPromise.then(function(response){
            if(response.status == 200)
            {
                if(response.data != null){
                    $scope.Studentgrid.data = response.data;
                }
                $("#overlay").hide();
            }
        },
        function(error)
        {
            $scope.error = errorCc;
            $("#overlay").hide();
        });
    }

   


    $scope.Studentgrid = {
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
        { name: 'firstName', displayName: 'Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'middleName', displayName: 'Middle Name', headerCellClass: 'gridheader', width: '15%' },
        { name: 'lastName', displayName: 'Last Name.', headerCellClass: 'gridheader', width: '15%' },
        { name: 'phoneNo', displayName: 'Phone No.', headerCellClass: 'gridheader', width: '15%' },
        {
            name: 'creatDate', displayName: 'Requested Date', headerCellClass: 'gridheader',
            cellTemplate: ' <span>{{row.entity.creatDate | date:"dd/MM/yyyy"}}</span>',
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
        { name: ' ', displayName: 'Edit', enableFiltering: false, width: '25%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().ClassEditDetail()">Edit</a></span>', headerCellClass: 'gridheader' }
        ],
    };

    $scope.ClassEditDetail = function () {
        alert("Called..");
        //$scope.$root.gridData = row;
        //$scope.$root.ClassId = row.id;
        //$location.path("ClassDetails");
    };
});

app.controller('StudentDetailsController', function ($scope, $location,$window, StudentService) {
    var Id = $scope.$root.StudentId;
    LoadStudentDetails(Id);
    function LoadStudentDetails(Id) {
        $("#overlay").show();
        var studentdetailPromise = StudentService.SingleOrDefault(Id);
        studentdetailPromise.then(function (response) {
            if (response.status == 200) {
                if (response.data != null) {
                    $scope.Student = response.data;
                }
                //else {
                //    $scope.Student = $scope.$root.gridData;
                //}
                $("#overlay").hide();
            }
        }, function (error) {
            $scope.error = error;
            $("#overlay").hide();
        });
    }

    $scope.GoBack = function () {
        $window.history.back();
    }

    $scope.InsertStudent = function()
    {
        $("#overlay").show();
        var objStudent = $scope.Student
        var studentPromise = StudentService.InsertStudent(objStudent);
        studentPromise.then(function (response) {
            if (response.status == 200)
            {
                alert("Student Successfully inserted..");
                $("#overlay").hide();
                $location.path("Student");
            }
        }, function (error) {
            $scope.error = 'failure saving student', error;
            $("#overlay").hide();
        });
    }
    
});