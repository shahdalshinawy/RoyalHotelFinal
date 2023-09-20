using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTest.test
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void CheckPropertyName()
        {
            LoginVM l = new LoginVM();
            Assert.That(l, Has.Property("Username"));
        }
    }
}
