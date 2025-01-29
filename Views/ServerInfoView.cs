
namespace MCSM;

using System.Drawing;
using System.Runtime.InteropServices;
using Terminal.Gui;

public class ServerInfoView : Window{
    public TextView ServerOutput = new TextView(){
        X=0,
        Y=0,
        Width = Dim.Fill() - 2,
        Height = Dim.Fill() - 2,
        Text = "CONSOLE IS ENABLE NOW!",
        AutoSize = true,
        ReadOnly = true,
        WordWrap = true
    };
    private CommandField ServerInput = new CommandField(){
        X = 0,
        Y = Pos.AnchorEnd() - 1,
        Width = Dim.Fill() - 8,
        Height = 1
    };
    public Button SendC = new Button(){
        Text = "CLEAR",
        Data = "SendC",
        X = Pos.AnchorEnd() - 8,
        Y = Pos.AnchorEnd() - 1,
        Width = 7,
        Height = 1
    }; 
    
    public ServerInfoView(){

        ServerInput.ColorScheme = MainProc.DispStyle;
        ServerOutput.ColorScheme = MainProc.DispStyle;
        SendC.Clicked += () => {
            MainProc.serverInfoView.ServerOutput.Text = "";
        };
        this.Add(SendC);
        this.Add(ServerOutput);
        this.Add(ServerInput);
    }
    private class CommandField:TextField{
        public override bool ProcessHotKey(KeyEvent keyEvent){
            if (keyEvent.KeyValue == (int) Key.Enter && this.HasFocus) {
                try{
                    if (MainProc.IsServerRunning) MainProc.SendCommands(this.Text);
                }
                catch{
                    MessageBox.ErrorQuery("ERROR","Command Send Fail","OK");
                }
                this.Text = "";
                return true;
            }
            else return false;
        }
    }

}
