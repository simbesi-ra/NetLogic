#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.OPCUAServer;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        var myPage = Owner;
        var myLabel = InformationModel.Make<Label>("Test");
        myLabel.HorizontalAlignment = HorizontalAlignment.Right;
        myLabel.Text = "Ciao mondo";
        myPage.Add(myLabel);
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("mi sto chiudendo");
    }
    [ExportMethod]
    public void CreateLabel()
    {
        var myTesto = LogicObject.GetVariable("Testo").Value;
        var myPage = Owner.Get("Panel1");
        var myLabel = InformationModel.Make<Label>("Label1");
        myLabel.Text = myTesto;
        myLabel.TextColor = Colors.Red;
        myPage.Add(myLabel);
        Log.Info("Label creata");
    }
    [ExportMethod]
    public void CreaTipi(int NumIstanze)
    {
        for (int i = 0; i < NumIstanze; i++)
        {
            var myWidget = InformationModel.Make<ToggleLed>(NomeIstanza(i));
            Owner.Get("VerticalLayout").Add(myWidget);
        }

    }

    public string NomeIstanza(int i)
    {
        return "Widget" + i;
    }

   
}
