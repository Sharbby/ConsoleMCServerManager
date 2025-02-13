namespace MCSM;

using System.IO;
using System.IO.Compression;
using Terminal.Gui;
using System.Text.Json;

partial class MainForm{
    //服务器菜单
    private MenuItem Start;
    private MenuItem Stop;
    
    //环境菜单
    private MenuItem SetJava;
    private MenuItem SetServer;

    //工具
    private MenuItem ActiveTools;
    private MenuItem KubeJsEditor;
    private MenuItem itemDatBse;
    private MenuItem jsonEditor;
    private MenuItem TranslateMaker;
    //设置
    private MenuItem SetColor;
    void InitMenuNTabs(){
        InitializeComponent();
        InitHintArea();
        InitTabs();
        InitServMenu();
        InitEnvMenu();
        InitSettingsMenu();
        InitToolMenu();
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
                MainProc.FileOpens = new OpenDialog(){
                    AllowedFileTypes = new String[]{
                        "java.exe"
                    },
                    AllowsMultipleSelection = false,
                    CanChooseDirectories = false,
                    CanChooseFiles = true,
                    Title = "Select java.exe"
                };
                Application.Run(MainProc.FileOpens);
                if (MainProc.FileOpens.FilePath != null) {
                    MainProc.ServerPath = Path.GetFileName(MainProc.FileOpens.FilePath.ToString());
                    MainProc.ServerPathAt = Path.GetDirectoryName(MainProc.FileOpens.FilePath.ToString());
                }
            }
        };
        SetServer = new MenuItem(){
            Title = "Set Server Path",
            Action = () => {
                MainProc.FileOpens = new OpenDialog(){
                    AllowedFileTypes = new string[]{
                        "jar"
                    },
                    AllowsMultipleSelection = false,
                    CanChooseFiles = true,
                    CanChooseDirectories = false,
                    Title = "Select Your Server jar File"
                };
                Application.Run(MainProc.FileOpens);
                if (MainProc.FileOpens.FilePath != null) {
                    MainProc.JavaPath = Path.GetFileName(MainProc.FileOpens.FilePath.ToString());
                }
            }
        };
        enviormentsMenu.Children = new MenuItem[]{
            SetJava,
            SetServer
        };
    }
    void InitToolMenu(){
        ActiveTools = new MenuItem(){
            Title = "Active Tools",
            Action = () =>{
                int select;
                select = MessageBox.Query("ACTIVE TOOLS?","WARNING:THIS ACTION NEED TO UNPACK ALL MODS!","YES","CONTINUE WITHOUT UNPACK","NO");
                if (select == 0) {
                    Thread bgp = new(() =>{
                        string backPath;
                        if (String.IsNullOrEmpty(MainProc.ServerPathAt)) backPath = @"backupmods";
                        else backPath = Path.Combine(MainProc.ServerPathAt,@"backupmods");
                        foreach (string file in Directory.GetFiles(backPath,"*.jar")){
                            ZipFile.ExtractToDirectory(file,Path.Combine(backPath,Path.GetFileNameWithoutExtension(file)),true); 
                        }
                        InitItemData();
                        Application.MainLoop.Invoke(()=>{
                            Application.RequestStop();
                        });
                    });
                    bgp.Start();
                    Application.Run(new WaitDialog());
                    MessageBox.Query("DONE","DataInit Finished","OK");
                }
                if (select == 1){
                    Thread bgp = new(() =>{
                        InitItemData();
                        Application.MainLoop.Invoke(()=>{
                            Application.RequestStop();
                        });
                    });
                    bgp.Start();
                    Application.Run(new WaitDialog());
                    MessageBox.Query("DONE","Unpack & DataInit Finished","OK");
                }
            }
        };
        itemDatBse = new MenuItem(){
            Title = "Item Database",
            Action = () =>{
                MainProc.IDB = new();
                Application.Run(MainProc.IDB);
            }
        };
        jsonEditor = new MenuItem(){
            Title = "Json Editor",
            Action = () =>{
                Application.Run(new JsonEditor());
            }
        };
        toolsMenu.Children = new MenuItem[]{
            ActiveTools,
            itemDatBse,
            jsonEditor
        };
    }
    void InitSettingsMenu(){
        SetColor = new MenuItem(){
            Title = "Set Color Scheme",
            Action = () =>{
                int select;
                select = MessageBox.Query("STYLE","Select a Style","White","Blue","Dark Red","Dark Green");
                MainProc.ChangeStyle(select);
            }
        };

        settIngsMenu.Children = new MenuItem[]{
            SetColor
        };
    }
    void InitTabs(){
        Terminal.Gui.TabView.Tab tabViewtab1;
        tabViewtab1 = new Terminal.Gui.TabView.Tab("ServerConsole", MainProc.serverInfoView);
        tabViewtab1.View.Width = Dim.Fill();
        tabViewtab1.View.Height = Dim.Fill();
        tabView.AddTab(tabViewtab1, false);
        Terminal.Gui.TabView.Tab tabViewtab2;
        tabViewtab2 = new Terminal.Gui.TabView.Tab("FileEditor", new FileEditor());
        tabViewtab2.View.Width = Dim.Fill();
        tabViewtab2.View.Height = Dim.Fill();
        tabView.AddTab(tabViewtab2, false);
        Terminal.Gui.TabView.Tab tabViewtab3;
        tabViewtab3 = new Terminal.Gui.TabView.Tab("ModManager", new ModManage());
        tabViewtab3.View.Width = Dim.Fill();
        tabViewtab3.View.Height = Dim.Fill();
        tabView.AddTab(tabViewtab3, false);
    }
    void InitQuickTab(){
        Terminal.Gui.TabView.Tab tabView2tab1;
        tabView2tab1 = new Terminal.Gui.TabView.Tab("Q.Commands", new QuickCommand());
        tabView2tab1.View.Width = Dim.Fill();
        tabView2tab1.View.Height = Dim.Fill();
        tabView2.AddTab(tabView2tab1, false);
        Terminal.Gui.TabView.Tab tabView2tab2;
        tabView2tab2 = new Terminal.Gui.TabView.Tab("Serv.Properties", new ServerPropertiesEditor());
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
    private string UnPackPath;
    void InitItemData(){
        if (String.IsNullOrEmpty(MainProc.ServerPathAt)) UnPackPath = "backupmods";
        else UnPackPath = Path.Combine(MainProc.ServerPathAt,"backupmods");
        foreach (string dir in Directory.GetDirectories(UnPackPath)){
            string filepath = "",filepathch = "";
            if (Directory.Exists(Path.Combine(dir,@"assets")))
                foreach(string indir in Directory.GetDirectories(Path.Combine(dir,@"assets"))){
                    if (File.Exists(Path.Combine(indir,@"lang\en_us.json"))) {
                        filepath = Path.Combine(indir,@"lang\en_us.json");
                        filepathch = Path.Combine(indir,@"lang\zh_cn.json");
                        break;
                    }
                }
            //导入翻译文件
            if (File.Exists(filepath) && !String.IsNullOrWhiteSpace(File.ReadAllText(filepath))) try{
                MainProc.enItemDic.AddRange(JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(filepath)));
            }catch{
                MessageBox.ErrorQuery("DESERILIZE FAIL!","Source:" + filepath,"SKIP");
            }
            if (File.Exists(filepathch) && !String.IsNullOrWhiteSpace(File.ReadAllText(filepathch))) try{
                MainProc.zhItemDic.AddRange(JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText(filepathch)));//需要进行debug
            }catch{
                MessageBox.ErrorQuery("DESERILIZE FAIL!","Source:" + filepathch,"SKIP");
            }
        }
    }
}
