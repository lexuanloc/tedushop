using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService, IProductService productService, ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        // Việc dùng Cache Location Server chỗ này sẽ gặp một số bug chỗ phần Đăng nhập người dùng
        // mặc dù đã đăng xuất nhưng server vẫn lưu cache và chưa nhận đăng xuất
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);

            var lastestProductModel = _productService.GetLastest(3);
            var topSaleProductModel = _productService.GetHotProduct(3);

            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);

            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;
            homeViewModel.LastestProducts = lastestProductViewModel;
            homeViewModel.TopSaleProducts = topSaleProductViewModel;

            try
            {
                homeViewModel.Title = _commonService.GetSystemConfig(CommonConstants.HomeTitle).ValueString;
                homeViewModel.MetaKeyword = _commonService.GetSystemConfig(CommonConstants.HomeMetaKeyword).ValueString;
                homeViewModel.MetaDescription = _commonService.GetSystemConfig(CommonConstants.HomeMetaDescription).ValueString;
            }
            catch (Exception)
            {
                homeViewModel.Title = "";
                homeViewModel.MetaKeyword = "";
                homeViewModel.MetaDescription = "";
            }


            return View(homeViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            //return PartialView("Header1");
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}