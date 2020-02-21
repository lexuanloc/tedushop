(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.error != undefined) {
                        notificationService.displayError("Đăng nhập không đúng.");
                    }
                    else {
                        // Cơ chế inject động mà không cần tiêm $state
                        // Nếu tiêm $state ngay từ đầu thì gặp lỗi Liên kết vòng
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            }
        }]);
})(angular.module('tedushop'));