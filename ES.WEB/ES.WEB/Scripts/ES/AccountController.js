app.controller('AccountController', function ($scope, $location, ESService, $window) {
    $scope.GoBack = function () {
            $window.history.back();
    }
    $scope.ChangePassword=function()
    {
        $("#overlay").show();
        var promiseChangePassword = ESService.ChangePassword($scope.ManageUserViewModel);
        promiseChangePassword.then(function (cc) {
            $("#overlay").hide();

            if (cc.status == 200) {
                alert("Password Changeed Successfully,Try New Password to Login");
                $('#logoutForm').submit();
            }
        },
        function (errorCc) {
            $scope.error = errorCc;

        });
    }
});