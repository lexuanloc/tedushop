(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.product = {};

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.updateProduct = updateProduct;
        $scope.getSeoTitle = getSeoTitle;
        $scope.chooseImage = chooseImage;

        $scope.moreImages = [];
        $scope.chooseMoreImage = chooseMoreImage;

        function chooseMoreImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }

            finder.popup();
        }

        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }

            finder.popup();
        }

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductDetail() {
            apiService.get('api/product/getbyid?id=' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);

                //fix lỗi chưa có ảnh nào thêm thì moreImages = null và ko push thêm ảnh vào được.
                $scope.moreImages = $scope.moreImages || 0;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function updateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công');
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadProductCategory();
        loadProductDetail();
    }


})(angular.module('tedushop.products'));