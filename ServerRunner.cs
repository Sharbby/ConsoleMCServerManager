
using System.Diagnostics;
using System.Formats.Asn1;
using System.Text;
using Terminal.Gui;

namespace MCSM;

partial class MainProc {
    public static bool IsServerRunning = false;
    public static String JavaPath = new string("java.exe");
    public static String ServerPath = new string("server.jar");
    public static String ExtraArgs = new string("");
    public static ServerInfoView serverInfoView = new ServerInfoView();
    static Process Server = new Process();
    public static void InitServer(){
        Server.StartInfo.RedirectStandardError = true;
        Server.StartInfo.RedirectStandardInput = true;
        Server.StartInfo.RedirectStandardOutput = true;
        Server.StartInfo.UseShellExecute = false;
        Server.StartInfo.CreateNoWindow = true;
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Server.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("GBK");
        Server.OutputDataReceived += (s,e) => {
            if (e.Data != null){
                serverInfoView.ServerOutput.Text += e.Data;
                serverInfoView.ServerOutput.Text += Environment.NewLine;
            }
        };
        Server.ErrorDataReceived += (s,e) => {

        };
        Server.Exited += (a,b) => {
            serverInfoView.ServerOutput.Text += "Server Stopped!";
        };

    }
    public static void SendCommands(NStack.ustring s){
        if (IsServerRunning) Server.StandardInput.WriteLine(s);
    }
    public static void StartServer(){
        Server.StartInfo.FileName = JavaPath;
        Server.StartInfo.Arguments = "-jar " + ServerPath + " -Dfile.encoding=UTF-8 " + ExtraArgs;
        try{
            Server.Start();
            IsServerRunning = true;
        }
        catch{
            MessageBox.ErrorQuery("ERROR","Fail to start server","OK");
        }
        try{
            Server.BeginOutputReadLine();
            Server.BeginErrorReadLine();
        }
        catch{
            MessageBox.ErrorQuery("ERROR","Fail to Redirect","OK");
        }
    }
    public static void StopServer(){
        try{
            Server.Kill(true);
            Server.WaitForExit();
            IsServerRunning = false;
        }
        catch{
            MessageBox.ErrorQuery("ERROR","Fail to Stop Server","OK");
        }
        Server.CancelErrorRead();
        Server.CancelOutputRead();
        serverInfoView.ServerOutput.Text += "Server Force Stopped!";
    }
}

public class ServerInfoView : Window{
    public TextView ServerOutput = new TextView();
    public CommandField ServerInput = new CommandField();
    private ColorScheme greenOnBlack;
    public Button SendCommands = new Button(){
        Text = "EXCUTE",
        Data = "SendCommands"
    }; 
    
    public ServerInfoView(){
        this.greenOnBlack = new Terminal.Gui.ColorScheme();
        this.greenOnBlack.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Black);
        this.greenOnBlack.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightGreen, Terminal.Gui.Color.Black);
        this.greenOnBlack.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Magenta);
        this.greenOnBlack.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightGreen, Terminal.Gui.Color.Magenta);
        this.greenOnBlack.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.Gray, Terminal.Gui.Color.Black);

        // this.X = 0;
        // this.Y = 0;
        // this.Height = Dim.Fill(0);
        // this.Width = Dim.Fill(0);

        ServerOutput.X = 0;
        ServerOutput.Y = 0;
        ServerInput.X = 0;
        ServerInput.Y = Pos.AnchorEnd() - 1;

        ServerOutput.Width = Dim.Fill();
        ServerOutput.Height = Dim.Fill() - 2;
        ServerInput.Width = Dim.Fill() - 9;
        ServerInput.Height = 1;

        SendCommands.X = Pos.AnchorEnd() - 9;
        SendCommands.Y = Pos.AnchorEnd() - 1;
        SendCommands.Width = 8;
        SendCommands.Height = 1;

        ServerInput.ColorScheme = greenOnBlack;
        ServerOutput.ColorScheme = greenOnBlack;
        SendCommands.Clicked += () => {
            MainProc.SendCommands(ServerInput.Text);
            ServerInput.Text = "";
        };


        this.Add(SendCommands);
        this.Add(ServerOutput);
        this.Add(ServerInput);
    }
    public class CommandField:TextField{
        public override bool ProcessHotKey(KeyEvent keyEvent)
        {
            if (keyEvent.KeyValue == (int) Key.Enter) {
                MainProc.SendCommands(this.Text);
                this.Text = "";
                return true;
            }
            else return true;
        }
    }
}
