app.controller('StudentInfoDetailsController', function ($scope, $location,  StudentInfoService){

     LoadStudentInfo(3);
     function LoadStudentInfo(Id) {
         $("#overlay").show();
         var promiseSubjectDropdownList = StudentInfoService.loadStudentInfo(Id);
         promiseSubjectDropdownList.then(function (respons) {
             if (respons.status == 200) {
                 if (respons.data != null) {
                     $scope.Student = respons.data;
                     $scope.$root.Student = respons.data;
                 }
                 else {
                     //$scope.Subject = $scope.$root.gridData;
                 }
                 $("#overlay").hide();
             }
         },
         function (errorCc) {
             $scope.error = errorCc;
             $("#overlay").hide();
         });
     }

    
    $scope.EditStudentInfo = function () {
        $location.path("StudentEdit");
    };
});


 app.controller('StudentInfoEditController', function ($scope, $location,$window, StudentInfoService) {
     LoadStudentInfo();
     function LoadStudentInfo() {
         $scope.Student = $scope.$root.Student;
     }

     $scope.GoBack = function () {
         $window.history.back();
     }

     $scope.addStudentInfo = function () {
         $("#overlay").show();
         //$scope.$broadcast('show-errors-check-validity');
         // $scope.submitted = true;
         // if ($scope.MDMForm.$valid) {
         var objStudent = $scope.Student;
         objStudent.MemberID = 1;
         var promisePost = StudentInfoService.AddStudentInfo(objStudent);
         promisePost.then(function (pl) {
             if (pl.status == 200) {
                 alert("Subject Saved Successfully.");
                 $("#overlay").hide();
                 $location.path("StudentInfo");
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