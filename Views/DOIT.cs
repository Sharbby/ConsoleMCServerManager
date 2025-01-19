using System.Net.Quic;

namespace MCSM;

partial class MainProc{
    public static Terminal.Gui.Label label = new ();
    public static QuickCommand QCV = new QuickCommand();
    public static List<NStack.ustring> quickCommands = new List<NStack.ustring>{};
    public static Terminal.Gui.ColorScheme DispStyle = new (){
        Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Black),
        HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Black),
        Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Black),
        HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightGreen, Terminal.Gui.Color.Black),
        Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.Gray, Terminal.Gui.Color.Black)
    };//完成，而且布置到所有地方
}