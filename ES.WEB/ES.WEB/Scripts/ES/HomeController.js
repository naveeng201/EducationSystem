app.controller('HomeController', function ($scope, $location ) {
    $scope.$scope = $scope;
    var rootURL = "ESWEB"
    $scope.LoadDashboard = function () {
        $location.path("DashBoard");
        $scope.$root.Title = "DashBoard";
    }
    $scope.LoadClass = function () {
        
        $location.path("Class");
        $scope.$root.Title = "New Requests -> Class";
    }
    $scope.LoadSection = function () {
        $location.path("Section");
        $scope.$root.Title = "New Requests -> Section";
    }
    $scope.LoadSubject = function () {
        $location.path("Subject");
        $scope.$root.Title = "New Requests -> Subject";
    }
    $scope.LoadInstitute = function () {
        $location.path("InstitutionInfo");
        $scope.$root.Title="New Request->Institute"
    }
    $scope.LoadStudentInfo = function () {
        $location.path("StudentInfo");
        $scope.$root.Title = "New Request->Student Info"
    }
    //$scope.LoadStudent=function()
    //{
    //    $location.path("Student");
    //    $scope.$root.Title = "New Request->Student Additional Details"
    //}
   
});