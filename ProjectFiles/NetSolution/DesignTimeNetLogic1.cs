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

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void Create100Variables()
    {
        // Insert code to be executed by the method
        var myFolder = Project.Current.Get("Model");
        for (int i = 0; i < 100; i++)
        {
            var myVar = InformationModel.MakeVariable("Variable" + i, OpcUa.DataTypes.Int32);
            myFolder.Add(myVar);
        }

    }

    [ExportMethod]
    public void CreateLabel()
    {
        var myPage = Project.Current.Get("UI/MainWindow");
        var myLabel = InformationModel.Make<Label>("Label1");
        myLabel.Text = "Etichetta creata da NetLogic";
        myLabel.TextColor = Colors.Red;
        myPage.Add(myLabel);
    }

    [ExportMethod]
    public void ModificaLabel()
    {
        var myLabel = Project.Current.Get<Label>("UI/MainWindow/Label1");
        myLabel.Text = "testo modificato";
        myLabel.TextColor = Colors.Blue;

    }

    [ExportMethod]
    public void ModificaValNative()
    {
        var myVar = Project.Current.GetVariable("Model/Variable1");
        var myVar2 = Project.Current.Get<IUAVariable>("Model/Variable2"); //equivalente alla riga sopra

        myVar.Value = 100;
    }

    [ExportMethod]
    public void AggiungiButton()
    {
        var myFolder = Project.Current.Get("UI/MainWindow");
        var myButton = InformationModel.Make<Button>("Button1");
        myButton.Text = "Button";
        myButton.LeftMargin = 200;
        myFolder.Add(myButton);
    }

    [ExportMethod]
    public void Aggiungi10Pulsanti()
    {
        var myFolder = Project.Current.Get("UI/MainWindow");
        for (int i = 0; i < 10; i++)
        {
            var myButton = InformationModel.Make<Button>("Button" + i);
            myButton.Text = "Button" + i;
            myButton.BackgroundColor = Colors.Coral;
            myButton.LeftMargin = 100 + 20 * i;
            myButton.TopMargin = 100 + 20 * i;
            myFolder.Add(myButton);
        }
    }

    [ExportMethod]
    public void CancellaVarDispari()
    {
        var myFolder = Project.Current.Get("Model");
        foreach (IUAVariable item in myFolder.Children)
        {
            string varName = item.BrowseName;
            int varNum = Convert.ToInt32(varName.Substring(varName.Length - 1));
            if (varNum % 2 != 0)
            {
                item.Delete();
            }
        }
    }
}
