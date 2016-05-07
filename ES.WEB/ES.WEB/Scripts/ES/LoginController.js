app.controller('LoginController', function ($scope, $location, ESService) {
    $scope.error = "";
    $scope.loadingLogin = false;
    var LoginViewModel = {
        UserName: $scope.UserName,

        Password: $scope.Password,

        RememberMe: $scope.RememberMe
    };    
    $scope.login = function () {
        $scope.loadingLogin = true;
        LoginViewModel.UserName = $scope.UserName;
        LoginViewModel.Password = $scope.Password;
        
        var promiseLogin = ESService.validateLogin(LoginViewModel);
        promiseLogin.then(function (result) {
            if (result.data == "Success") {
                var url = "/ESWEB/Home/Index";
                window.location.href = url;
                $scope.loadingLogin = false;
            }
            else if (result.data == "Failure") {
                $scope.error = 'Invalid Username/Password';
                $scope.loadingLogin = false;
            }
            else if (result.data == "API Failure") {
                $scope.error = 'Api call Failed';
                $scope.loadingLogin = false;
            }
            else if ((result.data == "Invalid Username/Password") && ($scope.UserName == undefined || $scope.Password == undefined)) {
                $scope.error = 'Please enter User Name and Password.';
                $scope.loadingLogin = false;
            }
            else if (result.data == "Invalid Username/Password") {
                $scope.error = 'Invalid Username/Password';
                $scope.loadingLogin = false;
            }
        },
        function (errorRresult) {

            $scope.loadingLogin = false;
        });

    };
});
app.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });

                event.preventDefault();
            }
        });
    };
});