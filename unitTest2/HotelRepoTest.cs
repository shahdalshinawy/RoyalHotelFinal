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
    public class HotelRepoTest
    {
        Context context;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
        }
        [Test]
        public void Check_GetAll_HotelsRepo()
        {
         IHotelRepository hotel = new  HotelRepository(context)
             ;
            var reslt = hotel.GetAll();
            Assert.That(reslt, Is.TypeOf<List<Hotels>>());

        }
        [Test]
        public void Check_GetById_Hotels_NotNull()
        {

            IHotelRepository hotel = new HotelRepository(context);
            var reslt2 = hotel.GetById(2);
            Assert.That(reslt2, Is.Not.Null);


        }
        [Test]
        public void Check_Type_GetById_Hotels()
        {

            IHotelRepository hotel = new HotelRepository(context);
            var reslt2 = hotel.GetById(2);
            Assert.That(reslt2, Is.TypeOf<Hotels>());


        }
    }
}
