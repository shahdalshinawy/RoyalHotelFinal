using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Controllers;
using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;
using mvcprojectfinal.VM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTest2
{
    [TestFixture]
    public class LoginTest
    {
        private readonly UserManager<AppliacationUser> userManager;
        private readonly SignInManager<AppliacationUser> signInManager;

        [Test]
        public void Check_That_contain_Name_Property()
        {
            LoginVM user = new LoginVM();
            Assert.That(user, Has.Property("Username"));

        }
        [Test]
        public void Check_That_contain_Password_Property()
        {
            LoginVM user = new LoginVM();
            var pass = user.Password;
            Assert.That(pass, Is.Null);

        }
        //[Test]
        //public void Chek_Account_Controller_Test()
        //{
        //    Hotels h = new Hotels();
        //    Context context = new Context();
        //    IHotelRepository hotelRepository = new HotelRepository(context);
        //    ICityRepository cityRepository = new   CityRepository(context);
        //    IImageRepository imageRepository = new ImageRepo(context);
        //    HotelController account = new HotelController(hotelRepository,cityRepository,imageRepository);

        //    ViewResult r = account.Index() as ViewResult;
        //    Assert.That(r, Is.TypeOf(List<Hotels>));//Has.Property("Location"));

        //}
        //تمااااااااااام
        [Test]

        public void TestLoginViewData()
        {
            var controller = new AccountController(userManager, signInManager);
            var result = controller.Login() as ViewResult;
            var AppliacationUser = (AppliacationUser)result.ViewData.Model;
            Assert.AreEqual("shahd", AppliacationUser.UserName);
        }

    }
}
