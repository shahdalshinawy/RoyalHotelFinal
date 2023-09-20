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
    public class RoomRepoTest
    {
        Context context;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
        }
        [Test]
        public void Check_GetAll_RoomRepo()
        {
            IRoomRepository room = new RoomRepository(context);
            var reslt = room.GetAll();
            Assert.That(reslt, Is.TypeOf<List<Room>>());

        }

        [Test]
        public void Check_GetById_Room_NotNull()
        {


            IRoomRepository room = new RoomRepository(context);
            var reslt2 = room.GetById(1);
            Assert.That(reslt2, Is.Not.Null);


        }

    }
}
