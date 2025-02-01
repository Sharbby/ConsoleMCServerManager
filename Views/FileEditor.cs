
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.1.0.0
//      You can make changes to this file and they will not be overwritten when saving.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace MCSM {
    using System.Runtime.CompilerServices;
    using Terminal.Gui;
    
    
    public partial class FileEditor {
        private bool IsFileOpen = false;
        public FileEditor() {
            InitializeComponent();
            textView.ReadOnly = true;
            button.Clicked += () =>{
                MainProc.FileOpens = new OpenDialog(){
                    AllowsMultipleSelection = false,
                    CanChooseDirectories = false,
                    CanChooseFiles = true,
                    Title = "Open a File"
                };
                Application.Run(MainProc.FileOpens);
                textView.Text = File.ReadAllText(Path.GetFileName(MainProc.FileOpens.FilePath.ToString()));
                label.Text = MainProc.FileOpens.FilePath;
            };
            button2.Clicked += () => {
                File.WriteAllText(Path.GetFileName(label.Text.ToString()),textView.Text.ToString());
            };
            button3.Clicked += () => {
                textView.Text = "";
                label.Text = "";
            };
            button4.Clicked += () => {
                if (button4.Text == "LOCKED") {
                    textView.ReadOnly = false;
                    button4.Text = "UNLOCK";
                }
                else {
                    textView.ReadOnly = true;
                    button4.Text = "LOCKED";
                }
            };
            button5.Clicked += () =>{
                MainProc.FileSave = new SaveDialog(){
                    CanCreateDirectories = false,
                    Title = "Save the File"
                };
                Application.Run(MainProc.FileSave);
                File.WriteAllText(Path.GetFileName(MainProc.FileSave.FilePath.ToString()),textView.Text.ToString());
            };
            button6.Clicked += () =>{
                if (File.Exists(Path.GetFileName(textView.Text.ToString()))) 
                    textView.Text = File.ReadAllText(Path.GetFileName(label.Text.ToString()));
            };
        }
    }
}
