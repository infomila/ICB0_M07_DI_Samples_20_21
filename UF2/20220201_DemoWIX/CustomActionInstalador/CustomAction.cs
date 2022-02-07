using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CustomActionInstalador
{
    public class CustomActions
    {
        private static Thread _fil;
        private static ManualResetEvent _semafor;
        private static ActionResult resultat;
        [CustomAction]
        public static ActionResult MostraDialegConfiguracio(Session session)
        {
            resultat = ActionResult.Failure;
            session.Log("Begin CustomAction1");
            _fil = new Thread(funcioDelFil);
            _fil.SetApartmentState(ApartmentState.STA);
            _semafor = new ManualResetEvent(false);
            _fil.Start();
            _semafor.WaitOne();

            return resultat;
        }

        [STAThread]
        private static void funcioDelFil()
        {
            //això s'executa dins del fil
            DialegConfiguracio dialeg = new DialegConfiguracio();
            bool? haAnatBe = dialeg.ShowDialog();
            if (haAnatBe.Value)
            {
                resultat = ActionResult.Success;
            }
            else
            {
                resultat = ActionResult.Failure;
            }
            _semafor.Set();// marca que el semàfor s'alliberi
        }
    }
}
