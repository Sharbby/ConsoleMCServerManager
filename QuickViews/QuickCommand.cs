
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.1.0.0
//      You can make changes to this file and they will not be overwritten when saving.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace MCSM {
    using Terminal.Gui;
    public partial class QuickCommand {
        private AddField AddCommands = new AddField(){
            X = 0,
            Y = Pos.AnchorEnd() - 1,
            Width = Dim.Fill(),
            Height = 1
        };
        public QuickCommand() {
            InitializeComponent();
            this.Add(AddCommands);
            this.Enter += (a) =>{
                MainProc.label.Text = "Quick Commands";
                MainProc.label.Text += Environment.NewLine;
                MainProc.label.Text += "Delete = Shift + D";
            };//需改进
            this.listView.OpenSelectedItem += (a) => {
                MainProc.SendCommands((NStack.ustring)a.Value);
            };
        }


        private class AddField:TextField{
            public override bool ProcessHotKey(KeyEvent keyEvent){
                if (keyEvent.KeyValue == (int) Key.Enter && this.HasFocus) {
                    try{
                        MainProc.quickCommands.Add(this.Text);
                    }catch{
                        MessageBox.ErrorQuery("ERROR","Quickcommand Send fail","OK");
                    }
                    this.Text = "";
                    return true;
                }
                else return false;
            }
        }
        private class QuickCommandTable:ListView{
            public override bool ProcessHotKey(KeyEvent keyEvent)
            {
                if (this.HasFocus){
                    if (keyEvent.KeyValue == (int) Key.D) {
                        try{
                            MainProc.quickCommands.RemoveAt(this.SelectedItem);
                        }
                        catch{
                            MessageBox.ErrorQuery("ERROR","Delete Failed","OK");
                        }
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
        }
    }

    
}
