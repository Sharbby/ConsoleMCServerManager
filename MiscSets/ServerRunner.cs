
using System.Diagnostics;
using System.Formats.Asn1;
using System.Text;
using Terminal.Gui;

namespace MCSM;

partial class MainProc {
    public static bool IsServerRunning = false;
    public static String JavaPath = new string("java.exe");
    public static String ServerPath = new string("server.jar");
    public static String ServerPathAt = new string("");
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
                serverInfoView.ServerOutput.MoveEnd();
            }
        };
        Server.ErrorDataReceived += (s,e) => {

        };
        Server.Exited += (a,b) => {
            IsServerRunning = false;
            serverInfoView.ServerOutput.Text += "Server Stopped!";
        };//他奶奶滴，为什么不触发

    }
    public static void SendCommands(NStack.ustring s){
        if (IsServerRunning) Server.StandardInput.WriteLine(s);
        serverInfoView.ServerOutput.MoveEnd();
    }
    public static void StartServer(){
        Server.StartInfo.FileName = JavaPath;
        Server.StartInfo.Arguments = "-jar " + ServerPath + ExtraArgs;
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

