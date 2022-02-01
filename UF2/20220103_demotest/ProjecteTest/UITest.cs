using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace ProjecteTest
{
    [TestClass]
    public class UITest
    {
        [TestMethod]
        public void testejaUISuma()
        {
            Window w = StartApplicationAndGetWindow();

            TextBox txtOp1 = w.Get<TextBox>("txtOp1");
            TextBox txtOp2 = w.Get<TextBox>("txtOp2");
            txtOp1.Text ="2";
            txtOp2.Text="3";
            Button btnProva = w.Get<Button>("btnProva");
            btnProva.Click();
            TextBox txtResultat = w.Get<TextBox>("txtResultat");
            String res = txtResultat.Text;
            Assert.AreEqual("5", res);
            w.Close();
        }
        [TestMethod]
        public void testejaUISeleccionaCotxe()
        {
            Window w = StartApplicationAndGetWindow();
            ListView lv = w.Get<ListView>("dtgVehicles");
            lv.Rows[2].Click();
            TextBox txtMatricula = w.Get<TextBox>("txtMatricula");
            TextBox txtMarca = w.Get<TextBox>("txtMarca");
            Assert.AreEqual("5234HGH", txtMatricula.Text);
            Assert.AreEqual("Porsche", txtMarca.Text);
            w.Close();
        }

        private static Window StartApplicationAndGetWindow()
        {
            Application a;
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory;
            ruta += @"\20210118_DemoDocumentacio.exe";
            Console.WriteLine(">" + ruta);
            Application app = Application.Launch(ruta);
            Window w = app.GetWindows()[0];
            return w;
        }




    }
}
