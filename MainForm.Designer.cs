
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
    
    
    public partial class MainForm : Terminal.Gui.Toplevel {
        
        private Terminal.Gui.FrameView frameView;
        
        private Terminal.Gui.TabView tabView;
        
        private Terminal.Gui.TabView tabView2;
        
        private Terminal.Gui.MenuBar menuBar;
        
        private Terminal.Gui.MenuBarItem serverMenu;
        
        private Terminal.Gui.MenuItem editMeMenuItem;
        
        private Terminal.Gui.MenuBarItem enviormentsMenu;
        
        private Terminal.Gui.MenuItem editMeMenuItem2;
        
        private Terminal.Gui.MenuBarItem toolsMenu;
        
        private Terminal.Gui.MenuItem editMeMenuItem3;
        
        private Terminal.Gui.MenuBarItem settIngsMenu;
        
        private Terminal.Gui.MenuItem editMeMenuItem4;
        
        private void InitializeComponent() {
            this.menuBar = new Terminal.Gui.MenuBar();
            this.tabView2 = new Terminal.Gui.TabView();
            this.tabView = new Terminal.Gui.TabView();
            this.frameView = new Terminal.Gui.FrameView();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Visible = true;
            this.Modal = false;
            this.IsMdiContainer = false;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Width = 50;
            this.frameView.Height = 9;
            this.frameView.X = 0;
            this.frameView.Y = 1;
            this.frameView.Visible = true;
            this.frameView.Data = "frameView";
            this.frameView.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.frameView.Border.Effect3D = false;
            this.frameView.Border.Effect3DBrush = null;
            this.frameView.Border.DrawMarginFrame = true;
            this.frameView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Title = "Minecraft Server Console Manager";
            this.Add(this.frameView);
            
            this.tabView.Width = Dim.Fill(0);
            this.tabView.Height = Dim.Fill(0);
            this.tabView.X = 50;
            this.tabView.Y = 1;
            this.tabView.Visible = true;
            this.tabView.Data = "tabView";
            this.tabView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.tabView.MaxTabTextWidth = 30u;
            this.tabView.Style.ShowBorder = true;
            this.tabView.Style.ShowTopLine = true;
            this.tabView.Style.TabsOnBottom = false;
            this.tabView.ApplyStyleChanges();
            this.Add(this.tabView);
            this.tabView2.Width = 50;
            this.tabView2.Height = Dim.Fill(0);
            this.tabView2.X = 0;
            this.tabView2.Y = 10;
            this.tabView2.Visible = true;
            this.tabView2.Data = "tabView2";
            this.tabView2.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.tabView2.MaxTabTextWidth = 30u;
            this.tabView2.Style.ShowBorder = true;
            this.tabView2.Style.ShowTopLine = true;
            this.tabView2.Style.TabsOnBottom = false;
            this.tabView2.ApplyStyleChanges();
            this.Add(this.tabView2);
            this.menuBar.Width = Dim.Fill(0);
            this.menuBar.Height = 1;
            this.menuBar.X = 0;
            this.menuBar.Y = 0;
            this.menuBar.Visible = true;
            this.menuBar.Data = "menuBar";
            this.menuBar.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.serverMenu = new Terminal.Gui.MenuBarItem();
            this.serverMenu.Title = "_Server";
            this.editMeMenuItem = new Terminal.Gui.MenuItem();
            this.editMeMenuItem.Title = "Edit Me";
            this.editMeMenuItem.Data = "editMeMenuItem";
            this.serverMenu.Children = new Terminal.Gui.MenuItem[] {
                    this.editMeMenuItem};
            this.enviormentsMenu = new Terminal.Gui.MenuBarItem();
            this.enviormentsMenu.Title = "_Enviorments";
            this.editMeMenuItem2 = new Terminal.Gui.MenuItem();
            this.editMeMenuItem2.Title = "Edit Me";
            this.editMeMenuItem2.Data = "editMeMenuItem2";
            this.enviormentsMenu.Children = new Terminal.Gui.MenuItem[] {
                    this.editMeMenuItem2};
            this.toolsMenu = new Terminal.Gui.MenuBarItem();
            this.toolsMenu.Title = "_Tools";
            this.editMeMenuItem3 = new Terminal.Gui.MenuItem();
            this.editMeMenuItem3.Title = "Edit Me";
            this.editMeMenuItem3.Data = "editMeMenuItem3";
            this.toolsMenu.Children = new Terminal.Gui.MenuItem[] {
                    this.editMeMenuItem3};
            this.settIngsMenu = new Terminal.Gui.MenuBarItem();
            this.settIngsMenu.Title = "Sett_ings";
            this.editMeMenuItem4 = new Terminal.Gui.MenuItem();
            this.editMeMenuItem4.Title = "Edit Me";
            this.editMeMenuItem4.Data = "editMeMenuItem4";
            this.settIngsMenu.Children = new Terminal.Gui.MenuItem[] {
                    this.editMeMenuItem4};
            this.menuBar.Menus = new Terminal.Gui.MenuBarItem[] {
                    this.serverMenu,
                    this.enviormentsMenu,
                    this.toolsMenu,
                    this.settIngsMenu};
            this.Add(this.menuBar);
        }
    }
}
