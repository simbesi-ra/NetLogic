#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.OPCUAServer;
#endregion

public class LampeggioLed : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        myPeriodicTask = new PeriodicTask(BlinkLed, 100, LogicObject);
        myPeriodicTask.Start();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        myPeriodicTask.Dispose(); //ferma il periodic task
    }
    private void BlinkLed()
    {
        var myLed = Owner.Get<Led>("LED1");
        myLed.Active = !myLed.Active;
    }

    private PeriodicTask myPeriodicTask;
}
