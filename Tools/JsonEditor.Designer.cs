
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
    using System.Text.Json.Nodes;
    using Terminal.Gui;
    
    
    public partial class JsonEditor : Terminal.Gui.Dialog {
        
        private Terminal.Gui.Label label;
        
        private Terminal.Gui.Button button;
        
        private Terminal.Gui.Button button3;
        
        private Terminal.Gui.Button button4;
        
        private Terminal.Gui.Button button2;
        
        private Terminal.Gui.Button button5;
        private Terminal.Gui.Button button6;
        private Terminal.Gui.Button button7 = new();
        private Terminal.Gui.Button button8 = new();
        
        private Terminal.Gui.Label label2;
        
        private Terminal.Gui.Label label3;
        
        private Terminal.Gui.ListView listView;
        
        private Terminal.Gui.ListView listView2;
        
        private void InitializeComponent() {
            this.listView2 = new Terminal.Gui.ListView();
            this.listView = new Terminal.Gui.ListView();
            this.label3 = new Terminal.Gui.Label();
            this.label2 = new Terminal.Gui.Label();
            this.button5 = new Terminal.Gui.Button();
            this.button6 = new Terminal.Gui.Button();
            this.button2 = new Terminal.Gui.Button();
            this.button4 = new Terminal.Gui.Button();
            this.button3 = new Terminal.Gui.Button();
            this.button = new Terminal.Gui.Button();
            this.label = new Terminal.Gui.Label();
            this.Width = Dim.Percent(85f);
            this.Height = Dim.Percent(85f);
            this.X = Pos.Center();
            this.Y = Pos.Center();
            this.Visible = true;
            this.Modal = true;
            this.IsMdiContainer = false;
            this.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.Border.Effect3D = true;
            this.Border.Effect3DBrush = null;
            this.Border.DrawMarginFrame = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Title = "JSON EDITOR";
            this.label.Width = 4;
            this.label.Height = 1;
            this.label.X = 1;
            this.label.Y = 1;
            this.label.Visible = true;
            this.label.Data = "label";
            this.label.Text = "No File Opens";
            this.label.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.label);
            this.button.Width = 8;
            this.button.Height = 1;
            this.button.X = 1;
            this.button.Y = 2;
            this.button.Visible = true;
            this.button.Data = "button";
            this.button.Text = "Open";
            this.button.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button.IsDefault = false;
            this.Add(this.button);
            this.button3.Width = 8;
            this.button3.Height = 1;
            this.button3.X = 9;
            this.button3.Y = 2;
            this.button3.Visible = true;
            this.button3.Data = "button3";
            this.button3.Text = "Save";
            this.button3.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button3.IsDefault = false;
            this.Add(this.button3);
            this.button4.Width = 11;
            this.button4.Height = 1;
            this.button4.X = 17;
            this.button4.Y = 2;
            this.button4.Visible = true;
            this.button4.Data = "button4";
            this.button4.Text = "Save as";
            this.button4.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button4.IsDefault = false;
            this.Add(this.button4);
            this.button2.Width = 17;
            this.button2.Height = 1;
            this.button2.X = 28;
            this.button2.Y = 2;
            this.button2.Visible = true;
            this.button2.Data = "button2";
            this.button2.Text = "Copy Selected";
            this.button2.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button2.IsDefault = false;
            this.Add(this.button2);
            this.button5.Width = 16;
            this.button5.Height = 1;
            this.button5.X = 45;
            this.button5.Y = 2;
            this.button5.Visible = true;
            this.button5.Data = "button5";
            this.button5.Text = "Insert Items";
            this.button5.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button5.IsDefault = false;
            this.Add(this.button5);
            this.button6.Width = 13;
            this.button6.Height = 1;
            this.button6.X = 61;
            this.button6.Y = 2;
            this.button6.Visible = true;
            this.button6.Data = "button6";
            this.button6.Text = "New Stuff";
            this.button6.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button6.IsDefault = false;
            this.Add(this.button6);
            this.button8.Width = 10;
            this.button8.Height = 1;
            this.button8.X = 74;
            this.button8.Y = 2;
            this.button8.Visible = true;
            this.button8.Data = "button8";
            this.button8.Text = "Delete";
            this.button8.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button8.IsDefault = false;
            this.Add(this.button6);
            this.JsonTree.Width = Dim.Fill();
            this.JsonTree.Height = Dim.Fill();
            this.JsonTree.X = 1;
            this.JsonTree.Y = 4;
            this.JsonTree.TreeBuilder = new JsonNodeTreeBuilder();
            this.Add(JsonTree);
            this.button7.Width = 8;
            this.button7.Height = 1;
            this.button7.Visible = true;
            this.button7.Data = "button7";
            this.button7.Text = "EXIT";
            this.button7.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.button7.IsDefault = false;
            this.AddButton(button7);
        }
    }
}
