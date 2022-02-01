using System;
using _20210118_DemoDocumentacio.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjecteTest
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Vehicle v = new Vehicle("8888-CCV", 2342343, "Seat" , "Leon");
            Assert.AreEqual("Seat", v.Marca);
            Assert.AreEqual("Leon", v.Model);
            Assert.AreEqual(2342343, v.NumeroBastidor);
            Assert.AreEqual("8888-CCV", v.Matricula);

            Boolean haPetat = false;
            try
            {
                v.Marca = "HU";
               
            }catch(Exception e) { haPetat = true; }
            if (!haPetat)
            {
                Assert.Fail();
            }

        }
    }
}
