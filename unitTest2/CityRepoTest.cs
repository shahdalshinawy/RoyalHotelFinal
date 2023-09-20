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
    public class CityRepoTest
    {
        Context context;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
        }
        [Test]
        public void Check_GetAll_Cities()
        {
             CityRepository cityRepository=new CityRepository(context);
            var reslt=cityRepository.GetAll();
            Assert.That(reslt,Is.TypeOf<List<City>>());
           
        }
        [Test]
        public void Check_GetById_Cities_NotNull()
        {
            ICityRepository cityRepository = new CityRepository(context);
            var reslt2 = cityRepository.GetById(1);
            Assert.That(reslt2, Is.Not.Null);

        }
        [Test]
        public void Check_Type_GetById_City()
        {

            ICityRepository cityRepository = new CityRepository(context);
            var reslt2 = cityRepository.GetById(1);
            Assert.That(reslt2, Is.TypeOf<City>());


        }
    }
}
