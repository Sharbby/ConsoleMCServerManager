
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.1.0.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace MCSM {
    using System;
    using Terminal.Gui;
    
    
    public partial class ServerPropertiesEditor : Terminal.Gui.View {
        
        private Terminal.Gui.ListView listView;
        
        private void InitializeComponent() {
            this.listView = new Terminal.Gui.ListView();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Visible = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.listView.Width = Dim.Fill();
            this.listView.Height = Dim.Fill();
            this.listView.X = 1;
            this.listView.Y = 0;
            this.listView.Visible = true;
            this.listView.Data = "listView";
            this.listView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.listView.AllowsMarking = false;
            this.listView.AllowsMultipleSelection = true;
            this.Add(this.listView);
        }
    }
}
