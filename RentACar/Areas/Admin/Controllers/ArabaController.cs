using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "admin")]
    public class ArabaController : Controller
    {
        private readonly ICarService service;
        private readonly ICategoryService categoriesService;
        private readonly IMapper mapper;

        public ArabaController(ICarService service, ICategoryService categoriesService, IMapper mapper)
        {
            this.service = service;
            this.categoriesService = categoriesService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(service.GetAllCars().Result);
        }
        public IActionResult Insert()
        {
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result; 
            return View();
        }

        [HttpPost]
        public IActionResult Insert(IFormFile MainImages, DtoCarsCrud data, IList<IFormFile> resimler)
        {
            string AnaResimResponse = Helpers.ImageLoad.Load(MainImages);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse == "1")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
            }
            else
            {
                data.Image = AnaResimResponse;
            }
            int i = 0;
            string[] isimler = { "", "", "" };
            foreach (var item in resimler)
            {
                string ResimAdi = Helpers.ImageLoad.Load(item);
                if (ResimAdi != "0" && ResimAdi != "1")
                {
                    isimler[i] = ResimAdi;
                    i++;
                }
            }
            if (isimler[0] != "") { data.SubImage1 = isimler[0]; }
            if (isimler[1] != "") { data.SubImage2 = isimler[1]; }
            if (isimler[2] != "") { data.SubImage3 = isimler[2]; }

            ViewBag.Message = service.AddAsync(data).Result;
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View();
        }
        [Route("/admin/araba/update/{Id}")]
        public IActionResult Update(int Id)
        {
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View(service.GetRelationCar(Id).Result);
        }
        [Route("/admin/araba/update/{Id}")]
        [HttpPost]
        public IActionResult Update(int Id, IFormFile MainImages, CarsUpdateDTO data, IList<IFormFile> resimler)
        {
            #region
            //string AnaResimResponse = Helpers.ImageLoad.Load(MainImages);
            //if (AnaResimResponse == "0")
            //{
            //    ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            //}
            //else if (AnaResimResponse != "1")
            //{
            //    Helpers.ImageLoad.ImagesDelete(data.Image);
            //    data.Image = AnaResimResponse;
            //}
            //int i = 0;
            //string[] isimler = { "", "", "", "" };
            //foreach (var item in resimler)
            //{
            //    string ResimAdi = Helpers.ImageLoad.Load(item);
            //    if (ResimAdi != "0" && ResimAdi != "1")
            //    {
            //        isimler[i] = ResimAdi;
            //        i++;
            //    }
            //}
            //if (isimler[0] != "") { Helpers.ImageLoad.ImagesDelete(data.Image); data.SubImage1 = isimler[0]; }
            //if (isimler[1] != "") { Helpers.ImageLoad.ImagesDelete(data.Image); data.SubImage2 = isimler[1]; }
            //if (isimler[2] != "") { Helpers.ImageLoad.ImagesDelete(data.Image); data.SubImage3 = isimler[2]; }
            #endregion
            ViewBag.Message = service.UpdateAsync(data).Result;
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View(service.GetRelationCar(Id).Result);
        }

        [Route("/admin/araba/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {           
            TempData["Message"] = service.DeleteAsync(Id).Result.StatusCode;
            return Redirect("/admin/Araba");
        }
        [Route("/admin/araba/CarImages/{carID}")]
        public IActionResult CarImages(int carID)
        {
            return View(service.GetRelationCar(carID).Result);
        }
        [Route("/admin/araba/ImageUpdate/{Id}")]
        public IActionResult CarImages(int Id,IFormFile MainImages,CarsImageDTO data,IFormFile SubImage1,IFormFile SubImage2, IFormFile SubImage3)
        {
            CarsImageDTO car = mapper.Map<CarsImageDTO>(service.GetRelationCar(Id).Result);
            data.ID = Id;
            if ( MainImages!=null)
            {
                if (car.Image != MainImages.FileName)
                {
                    Helpers.ImageLoad.ImagesDelete(car.Image);
                    string ImageName = Helpers.ImageLoad.Load(MainImages);
                    data.Image = ImageName;
                }
                else
                {
                    data.Image = car.Image;
                }
            }
            else
            {
                data.Image = car.Image;
            }
            if ( SubImage1 != null)
            {
                if (car.SubImage1 != SubImage1.Name)
                {
                    Helpers.ImageLoad.ImagesDelete(car.SubImage2);
                    string ImageName = Helpers.ImageLoad.Load(SubImage1);
                    data.SubImage1 = ImageName;
                }
                else
                {
                    data.SubImage1 = car.SubImage1;
                }
            }
            else
            {
                data.SubImage1 = car.SubImage1;
            }
            if (SubImage2 != null)
            {
                if (car.SubImage2 != SubImage2.Name)
                {


                    Helpers.ImageLoad.ImagesDelete(car.SubImage2);
                    string ImageName = Helpers.ImageLoad.Load(SubImage2);
                    data.SubImage2 = ImageName;
                }
                else
                {
                    data.SubImage2 = car.SubImage2;
                }
            }
            else
            {
                data.SubImage2 = car.SubImage2;
            }
            if ( SubImage3 != null)
            {
                if (car.SubImage3 != SubImage3.Name )
                {
                    Helpers.ImageLoad.ImagesDelete(car.SubImage3);
                    string ImageName = Helpers.ImageLoad.Load(SubImage3);
                    data.SubImage3 = ImageName;
                }
                else
                {
                    data.SubImage3 = car.SubImage3;
                }           
            }
            else
            {
                data.SubImage3 = car.SubImage3;
            }

            ViewBag.Message = service.UpdateCarImagesAsync(data).Result;
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View(service.GetRelationCar(Id).Result);
        }

        //[Route("/admin/araba/DeleteCarImage/{Id}")]
        //public IActionResult Delete(int Id ,string ImageId)
        //{
        //    Helpers.ImageLoad.ImagesDelete(ImageId);

        //    TempData["Message"] = service.DeleteAsync(Id).Result.StatusCode;
        //    return Redirect("/admin/Araba");
        //}
    }
}
