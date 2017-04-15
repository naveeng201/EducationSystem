//"use strict";
var app = angular.module("ApplicationModule", ['ngRoute', 'ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.edit', 'ui.grid.cellNav', 'ui.grid.pagination', 'ui.grid.pinning', 'ui.grid.selection', 'ui.grid.moveColumns', 'ui.grid.resizeColumns', 'ui.bootstrap']).directive('numbersOnly',
    function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, modelCtrl) {
                modelCtrl.$parsers.push(function (inputValue) {
                    // this next if is necessary for when using ng-required on your input. 
                    // In such cases, when a letter is typed first, this parser will be called
                    // again, and the 2nd time, the value will be undefined
                    if (inputValue == undefined) return ''
                    var transformedInput = inputValue.replace(/[^0-9]/g, '');
                    if (transformedInput != inputValue) {
                        modelCtrl.$setViewValue(transformedInput);
                        modelCtrl.$render();
                    }

                    return transformedInput;
                });
            }
        };
    });
app.directive('ngConfirmClick', [function () {
    return {
        link: function (scope, element, attr) {
            //var msg = attr.ngConfirmClick || "Are you sure?";
            var clickAction = attr.confirmedClick;
            element.bind('click', function (event) {
                $.confirm({
                    title: "Reject confirmation",
                    text: "Do you really want to reject ? ",
                    confirm: function (button) {
                        scope.$eval(clickAction);
                    },
                    cancel: function (button) {

                    },
                    confirmButton: "Yes",
                    cancelButton: "No"
                });
                //if ( window.confirm(msg) ) {
                //    
                //}
            });
        }
    };
}]);
app.directive('restrict', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {
            modelCtrl.$parsers.push(function (inputValue) {
                // this next if is necessary for when using ng-required on your input. 
                // In such cases, when a letter is typed first, this parser will be called
                // again, and the 2nd time, the value will be undefined
                if (inputValue == undefined) return ''
                var transformedInput = inputValue.replace('|', '');//replace(/[^0-9]/g, '');
                if (transformedInput != inputValue) {
                    modelCtrl.$setViewValue(transformedInput);
                    modelCtrl.$render();
                }

                return transformedInput;
            });
        }
    };
});
app.directive('ngCompare', [function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            var firstPassword = '#' + attrs.ngCompare;
            elem.add(firstPassword).on('keyup', function () {
                scope.$apply(function () {
                    var v = elem.val() === $(firstPassword).val();
                    ctrl.$setValidity('notmatch', v);
                });
            });
        }
    }
}]);

//kiran add
app.directive('tableDate', function ($filter) {
    function parseDateString(dateString) {
        if (typeof (dateString) === 'undefined' || dateString === '') {
            return null;
        }
        var parts = dateString.split('/');
        if (parts.length !== 3) {
            return null;
        }
        var year = parseInt(parts[2], 10);
        var month = parseInt(parts[1], 10);
        var day = parseInt(parts[0], 10);

        if (month < 1 || year < 1 || day < 1) {
            return null;
        }
        return new Date(year, (month - 1), day);
    }
    function pad(s) { return (s < 10) ? '0' + s : s; }
    return {
        priority: -100, // run after default uiGridEditor directive
        require: '?ngModel',
        link: function (scope, element, attrs, ngModel) {
            scope.istableDate = false;

            scope.$on('uiGridEventBeginCellEdit', function () {
                scope.istableDate = true;
            });

            element.on("click", function () {
                scope.istableDate = true;
            });

            element.bind('blur', function () {
                if (!scope.istableDate) {
                    scope.$emit('uiGridEventEndCellEdit');
                } else {
                    scope.istableDate = false;
                }
            }); //when leaving the input element, emit the 'end cell edit' event

            if (ngModel) {
                ngModel.$formatters.push(function (modelValue) {
                    var modelValue = new Date(modelValue);
                    ngModel.$setValidity(null, (!modelValue || !isNaN(modelValue.getTime())));
                    return $filter('date')(modelValue, 'dd/MM/yyyy');
                });

                ngModel.$parsers.push(function (viewValue) {
                    if (viewValue) {
                        var dateString = [pad(viewValue.getDate()), pad(viewValue.getMonth() + 1), viewValue.getFullYear()].join('/')
                        var dateValue = parseDateString(dateString);
                        ngModel.$setValidity(null, (dateValue && !isNaN(dateValue.getTime())));
                        return dateValue;
                    }
                    else {
                        ngModel.$setValidity(null, true);
                        return null;
                    }
                });
            }
        }
    };
});

//kiran add end

app.directive('modal', function () {
    return {
        template: '<div class="modal fade">' +
            '<div class="modal-dialog">' +
              '<div class="modal-content">' +
                '<div class="modal-header">' +
                  '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                  '<h4 class="modal-title">History</h4>' +
                '</div>' +
                '<div class="modal-body" ng-transclude></div>' +
              '</div>' +
            '</div>' +
          '</div>',
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.title = attrs.title;

            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });

            $(element).on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    };
});
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    var routeURL = "/ESWEB/";
    $locationProvider.html5Mode(true).hashPrefix('!');

    $routeProvider.when('/Login',
     {
         templateUrl: routeURL + 'Account/Login'

     });
    $routeProvider.when('/Class',
        {
            templateUrl: routeURL + 'Class/Index'
        });

   $routeProvider.when('/ClassDetails',
    {
       templateUrl: routeURL + 'Class/Details',
       controler: "ClassController"

    });
    $routeProvider.when('/Section',
        {
            templateUrl: routeURL + 'Section/Index'
        });

    $routeProvider.when('/SectionDetails',
    {
       templateUrl: routeURL + 'Section/Details',
       controler: "SectionController"

    });
    $routeProvider.when('/Subject',
        {
            templateUrl:routeURL+'Subject/Index'
        });
    $routeProvider.when('/SubjectDetails',
        {
            templateUrl: routeURL + 'Subject/Details',
            controler: "SubjectContoller"
        });
    $routeProvider.when('/InstitutionInfo',
        {
            templateUrl: routeURL + 'InstitutionInfo/Index'

        });
    $routeProvider.when('/InstitutionInfoDetails',
        {
            templateUrl: routeURL + 'InstitutionInfo/Details',
            controler: "InstitutionInfoController"
        });
    $routeProvider.when('/StudentInfo',
        {
            templateUrl: routeURL + 'StudentInfo/Details',
            controler: "StudentInfoController"
        });
    $routeProvider.when('/StudentEdit',
        {
            templateUrl: routeURL + 'StudentInfo/Edit',
            controler: "StudentInfoController"
        });
    $routeProvider.when('/ClassSubject',
    {
        templateUrl: routeURL + 'ClassSubject/Index'
    });
    $routeProvider.when('/ClassSection',
    {
       templateUrl: routeURL + 'ClassSection/Index'
    });
    $routeProvider.when('/Student',
    {
        templateUrl: routeURL + 'Student/Index'
    });
    $routeProvider.when('/StudentDetails',
    {
        templateUrl: routeURL + 'Student/Details'
    });
}])