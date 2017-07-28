
app.service('StudentService', function ($http) {
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
    this.GetStudentAdditionalInfo = function(Id)
    {
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlpath + "GetStudentAdditionalInfo/"+Id
        });
        return request;
    }
    this.InsertStudentAdditionalInfo = function(objStudentAdditionalInfo)
    {
        var urlp = "http://localhost:9810/api/StudentInfo/";
        var request = $http({
            method: "post",
            contentType: "application/json",
            url: urlp + "AddStudentInfo",
            data: JSON.stringify(objStudentAdditionalInfo)
        });
        return request;
    }

    this.GetParent = function(Id)
    {
        var urlp = "http://localhost:9810/api/Student/";
        var request = $http({
            method: "get",
            contentType: "application/json",
            url: urlp+"GetParent/" + Id,
        });
        return request;
    }
    this.InsertParent = function (objParent) {
        var urlp = "http://localhost:9810/api/Parent/";
        var request = $http({
            method: "post",
            contentType: "application/json",
            url:  urlp + "Insert",
            data: JSON.stringify(objParent)
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
            $log.error(error);
            $("#overlay").hide();
        });
    }

    $scope.$scope = $scope;
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
        { name: ' ', displayName: 'Edit', enableFiltering: false, width: '25%', cellTemplate: '<span style="text-align:center"><a class="gridButton" ng-click="getExternalScopes().StudentEditDetail(row.entity)">Edit</a></span>', headerCellClass: 'gridheader' }
        ],
    };

    $scope.StudentEditDetail = function (row) {
        $scope.$root.gridData = row;
        $scope.$root.StudentId = row.id;
        $location.path("StudentDetails");
    };
});

 


app.controller('StudentDetailsController', function ($scope,$log, $location, $window, StudentService) {
    $scope.data = {
        selectedIndex: 0,
        secondLocked: true,
        secondLabel: "Item Two",
        bottom: false
    };
 // Tabs relatetd code
    $scope.tab = 0;
    $scope.steps = [
     'Basic Details',
     'Additional Details',
     'Parent Details',
     'Communication Details',
     'Emmergency Contact'
    ];
    $scope.selection = $scope.steps[0];

    $scope.getCurrentStepIndex = function () {
        // Get the index of the current step given selection
        return _.indexOf($scope.steps, $scope.selection);
    };

    // Go to a defined step index
    $scope.goToStep = function (index) {
        if (!_.isUndefined($scope.steps[index])) {
            //$scope.selection = $scope.steps[index];
            $scope.selection = $scope.steps[index];
            $scope.tab = index
        }
    };

    $scope.hasNextStep = function () {
        var stepIndex = $scope.getCurrentStepIndex();
        var nextStep = stepIndex + 1;
        // Return true if there is a next step, false if not
        return !_.isUndefined($scope.steps[nextStep]);
    };

    $scope.hasPreviousStep = function () {
        var stepIndex = $scope.getCurrentStepIndex();
        var previousStep = stepIndex - 1;
        // Return true if there is a next step, false if not
        return !_.isUndefined($scope.steps[previousStep]);
    };


    $scope.incrementStep = function () {
        if ($scope.hasNextStep()) {
            var stepIndex = $scope.getCurrentStepIndex();
            var nextStep = stepIndex + 1;
            $scope.selection = $scope.steps[nextStep];
        }
    };

    $scope.decrementStep = function () {
        if ($scope.hasPreviousStep()) {
            var stepIndex = $scope.getCurrentStepIndex();
            var previousStep = stepIndex - 1;
            $scope.selection = $scope.steps[previousStep];
        }
    };
    //End tabs related code

    // below two may not required
    $scope.next = function () {
        $scope.data.selectedIndex = Math.min($scope.data.selectedIndex + 1, 2);
    };
    $scope.previous = function () {
        $scope.data.selectedIndex = Math.max($scope.data.selectedIndex - 1, 0);
    }; 

    $scope.GoBack = function () {
        $window.history.back();
    }

    var Id = $scope.$root.StudentId;

    if($scope.tab == 0)
    {
        LoadStudentDetails(Id);
        LoadStudnetAdditionalDetails(Id);
        GetParent(Id);
    }
   
    //Student Basic Details
    function LoadStudentDetails(Id) {
        //$scope.firsttabshow = true;
        //$scope.secondtabshow = false;
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
            $log.error(error);
            $("#overlay").hide();
        });
    }
    $scope.InsertStudent = function()
    {
        $("#overlay").show();
        var objStudent = $scope.Student;
        var studentPromise = StudentService.InsertStudent(objStudent);
        studentPromise.then(function (response) {
            if (response.status == 200)
            {
                if ($scope.$root.StudentId == 0)
                    $scope.$root.StudentId = response.data;
                alert("Basic Details Saved/Updated Successfully..")
                //After student insertion insert additional details
                $scope.InsertStudentAdditionalInfo($scope.$root.StudentId);
               
                //$location.path("Student");
            }
        }, function (error) {
            $scope.error = 'failure saving student', error;
            $("#overlay").hide();
        });
    }

    //Additional Info
    function LoadStudnetAdditionalDetails(Id) {
        //$scope.secondtabshow = true;
        //$scope.firsttabshow = false;
        $("#overlay").show();
        var studentpromise = StudentService.GetStudentAdditionalInfo(Id);
        studentpromise.then(function (response) {
            if (response.status == 200) {
                $scope.StudentAdditionalInfo = response.data;
                $("#overlay").hide();
            }
        },
        function (error) {
            $log.error(error);
            $("#overlay").hide();
        });
    }
    $scope.InsertStudentAdditionalInfo = function (studentID) {
        $("#overlay").show();
        var objStudent = $scope.Student;
        var objStudentAdditionalInfo = $scope.StudentAdditionalInfo;
        objStudentAdditionalInfo.studentId = studentID;
        objStudentAdditionalInfo.dob = new Date();
        var studentPromise = StudentService.InsertStudentAdditionalInfo(objStudentAdditionalInfo);
        studentPromise.then(function (response) {
            if(response.status == 200)
            {
                $scope.AdditionalDetailsId = response.data;
                //After inserting Student additional information insert parent
                alert("Student Additional Info Successfully Inserted/Updated..");
                $scope.InsertParent($scope.$root.StudentId);
                $("#overlay").hide();
            }
        }, function (error) {
            $log.error(error);
            $("#overlay").hide();
        });
    }

    //Parent
    function GetParent(Id) {
        $("#overlay").show();
        var parentPromise = StudentService.GetParent(Id); // get default parent of the student
        parentPromise.then(function (response) {
            if (response.status == 200) {
                $scope.Parent = response.data;
                $("#overlay").hide();
            }
        }, function (error) {
            $log.error(error);
            $("#overlay").hide();
        })
    }
    $scope.InsertParent = function (StudentID)
    {
        $("#overlay").show();
        var objParent = $scope.Parent;
        var parentPromise = StudentService.InsertParent(objParent);
        parentPromise.then(function (response) {
            if(response.status == 200)
            {
                $scope.ParentId = response.data;
                alert("Parent Saved Successfully..");
                $("#overlay").hide();
            }
        }, function (error) {
            $log.error(error.data);
            //console.log(error.data);
            $("#overlay").hide();
        })
    }
     
});