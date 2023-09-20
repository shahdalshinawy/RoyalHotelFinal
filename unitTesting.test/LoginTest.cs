using NUnit.Framework;
using mvcprojectfinal.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTesting.test
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void Check_That_contain_Name_Property()
        {
            LoginVM loginVM = new LoginVM();
            Assert.That(loginVM, Has.Property("Name"));

        }
    }
}
