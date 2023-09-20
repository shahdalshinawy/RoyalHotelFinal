using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTest2
{
    [TestFixture]
    public class ImageRepoTest
    {
        Context context;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
        }
        [Test]
        public void Check_GetAll_ImageRepo()
        {
            IImageRepository image = new ImageRepo(context);
            var reslt = image.GetAll();
            Assert.That(reslt, Is.TypeOf<List<Images>>());

        }
        [Test]
        public void Check_GetById_Image_NotNull()
        {

            IImageRepository image = new ImageRepo(context);
            var reslt = image.GetAll();
            var reslt2 = image.GetById(6);
            Assert.That(reslt2, Is.Not.Null);


        }
    }
}
