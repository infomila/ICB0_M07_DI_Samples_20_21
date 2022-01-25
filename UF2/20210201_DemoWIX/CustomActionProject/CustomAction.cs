using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace CustomActionProject
{
    public class CustomActions
    {
        private static ManualResetEvent semafor = new ManualResetEvent(false);

        [CustomAction]
        public static ActionResult CAOpcions(Session session)
        {
            session.Log("Begin CustomAction1");
            Thread t = new Thread(engegaFinestra);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            semafor.WaitOne();
            return ActionResult.Success;
        }


        static void engegaFinestra()
        {
            try {
                Dialeg d = new Dialeg();
                d.ShowDialog();
            }
            finally {
                semafor.Set();
            }
        }

    }
}
