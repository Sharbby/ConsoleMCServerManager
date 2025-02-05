using System.Net.Quic;
using Terminal.Gui;

namespace MCSM;

partial class MainProc{
    public static Terminal.Gui.Label label = new ();
    public static QuickCommand QCV = new QuickCommand();
    public static List<NStack.ustring> quickCommands = new List<NStack.ustring>{};//快速命令

    public static ServerPropertiesEditor SPE = new();
    public static List<String> serverProperties = new List<string>{};
    public static List<String> serverPropertiesValue = new List<string>{};
    public static List<String> disableMods = new List<string>{};
    public static List<String> enableMods = new List<string>{};

    public static Dictionary<string,string> 
        enItemDic = new(),
        zhItemDic = new();

    public static OpenDialog FileOpens;
    public static SaveDialog FileSave;
    public static Terminal.Gui.ColorScheme DispStyle = new();
    public static ItemDataBase IDB = new();
    public static void ChangeStyle(int k){
        switch(k){
            default:
                DispStyle.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Black);//正常
                DispStyle.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Black);//子视图聚焦
                DispStyle.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.DarkGray);//激活但失焦，后者为输入区底色
                DispStyle.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Gray);//选中
                DispStyle.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.DarkGray, Terminal.Gui.Color.Black);//输入区域内部颜色，后者选中时底色
                //黑白灰
                break;
            case 1:
                DispStyle.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Blue);
                DispStyle.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Blue);
                DispStyle.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Blue, Terminal.Gui.Color.White);
                DispStyle.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.White, Terminal.Gui.Color.Blue);
                DispStyle.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.Blue, Terminal.Gui.Color.Black);
                //蓝白
                break;
            case 2:
                DispStyle.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Black);
                DispStyle.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Black);
                DispStyle.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.DarkGray);
                DispStyle.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Black);
                DispStyle.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.DarkGray, Terminal.Gui.Color.Black);
                //黑红灰
                break;
            case 3:
                DispStyle.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Black);
                DispStyle.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightGreen, Terminal.Gui.Color.Black);
                DispStyle.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.DarkGray);
                DispStyle.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightYellow, Terminal.Gui.Color.DarkGray);
                DispStyle.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightYellow, Terminal.Gui.Color.DarkGray);
                //黑绿黄
                break;
        }
    }
}