namespace MCSM;

using System.Runtime.CompilerServices;
using Terminal.Gui;

partial class MainForm{
    void InitMenuNTabs(){
        InitializeComponent();
        InitHintArea();
        InitTabs();
        InitServMenu();
        InitEnvMenu();
        InitQuickTab();
    }
    void InitServMenu(){
        Start = new MenuItem(){
            Title = "Start Server",
            Action = () => {
                if (!MainProc.IsServerRunning){
                    MainProc.StartServer();
                }
            }
        };
        Stop = new MenuItem(){
            Title = "Stop Server",
            Action = () => {
                if (MainProc.IsServerRunning)
                    MainProc.StopServer();
            }
        };
        serverMenu.Children = new MenuItem[]{
            Start,
            Stop
        };
    }
    void InitEnvMenu(){
        SetJava = new MenuItem(){
            Title = "Set Java Path",
            Action = () => {
                FileOpens = new OpenDialog(){
                    AllowedFileTypes = new String[]{
                        "java.exe"
                    },
                    CanChooseDirectories = false,
                    CanChooseFiles = true,
                    Title = "Select java.exe"
                };
                Application.Run(this.FileOpens);
            }
        };
        SetServer = new MenuItem(){
            Title = "Set Server Path",
            Action = () => {
                FileOpens = new OpenDialog(){
                    AllowedFileTypes = new string[]{
                        "jar"
                    },
                    CanChooseFiles = true,
                    CanChooseDirectories = false,
                    Title = "Select Your Server jar File"
                };
                Application.Run(this.FileOpens);
            }
        };
        enviormentsMenu.Children = new MenuItem[]{
            SetJava,
            SetServer
        };
    }
    void InitToolMenu(){
        
    }
    void InitAboutMenu(){

    }
    void InitTabs(){
        Terminal.Gui.TabView.Tab tabViewtab1;
        tabViewtab1 = new Terminal.Gui.TabView.Tab("ServerConsole", MainProc.serverInfoView);
        tabViewtab1.View.Width = Dim.Fill();
        tabViewtab1.View.Height = Dim.Fill();
        tabView.AddTab(tabViewtab1, false);
        Terminal.Gui.TabView.Tab tabViewtab2;
        tabViewtab2 = new Terminal.Gui.TabView.Tab("FileEditor", new View());
        tabViewtab2.View.Width = Dim.Fill();
        tabViewtab2.View.Height = Dim.Fill();
        tabView.AddTab(tabViewtab2, false);
    }
    void InitQuickTab(){
        Terminal.Gui.TabView.Tab tabView2tab1;
        tabView2tab1 = new Terminal.Gui.TabView.Tab("QuickCommands", new QuickCommand());
        tabView2tab1.View.Width = Dim.Fill();
        tabView2tab1.View.Height = Dim.Fill();
        tabView2.AddTab(tabView2tab1, false);
        Terminal.Gui.TabView.Tab tabView2tab2;
        tabView2tab2 = new Terminal.Gui.TabView.Tab("Mods", new View());
        tabView2tab2.View.Width = Dim.Fill();
        tabView2tab2.View.Height = Dim.Fill();
        tabView2.AddTab(tabView2tab2, false);
    }
    void InitHintArea(){
        MainProc.label.Width = 47;
        MainProc.label.Height = 7;
        MainProc.label.X = 1;
        MainProc.label.Y = 0;
        MainProc.label.Visible = true;
        MainProc.label.Data = "label";
        MainProc.label.Text = "Welcome to MCSM";
        MainProc.label.Text += Environment.NewLine;
        MainProc.label.Text += "Menu = Alt + (Highlight Letters)";
        MainProc.label.TextAlignment = Terminal.Gui.TextAlignment.Left;
        this.frameView.Add(MainProc.label);
    }
}