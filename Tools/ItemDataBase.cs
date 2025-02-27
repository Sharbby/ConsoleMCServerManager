
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.1.0.0
//      You can make changes to this file and they will not be overwritten when saving.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace MCSM {
    using System.Formats.Asn1;
    using Terminal.Gui;
    using System.Linq;
    

    public partial class ItemDataBase {
        public NStack.ustring returnItemLable;
        private List<string> Lookuplist = new();
        private string type = "item.";
        public ItemDataBase() {
            int i;
            InitializeComponent();
            this.ColorScheme = MainProc.DispStyle;
            listView.OpenSelectedItem += (a) =>{
                if (Lookuplist.Count != 0) {
                    Lookuplist.Clear();
                    switch(radioGroup2.SelectedItem){
                        case 0:
                            Lookuplist = MainProc.enItemDic
                                .Where(k => k.Key.StartsWith(type) && k.Value.Contains(textField.Text.ToString()))
                                .Select(k => k.Key)
                                .ToList();
                            break;
                        case 1:
                            Lookuplist = MainProc.zhItemDic
                                .Where(k => k.Key.StartsWith(type) && k.Value.Contains(textField.Text.ToString()))
                                .Select(k => k.Key)
                                .ToList();//需要改！
                            break;
                        case 2:
                            Lookuplist = MainProc.zhItemDic
                                .Where(
                                    k => k.Key.StartsWith(type) 
                                    && (k.Value.ToPinyin()).Contains(textField.Text.ToString())
                                    )
                                .Select(k => k.Key)
                                .ToList();
                            break;
                        default:
                            break;
                    }
                listView.SetSourceAsync(Lookuplist);
                    returnItemLable = Lookuplist[listView.SelectedItem];
                }
                else returnItemLable = "";
                Application.RequestStop();
            };
            button.Clicked += () =>{
                returnItemLable = "";
                Application.RequestStop();
            };
            radioGroup.SelectedItemChanged += (a) => {
                switch(radioGroup.SelectedItem){
                    case 0:
                        type = "item.";
                        break;
                    case 1:
                        type = "block.";
                        break;
                    case 2:
                        type = "fluid.";
                        break;
                    default:
                        type = "";
                        break;
                }
            };
            textField.TextChanged += (a) =>{
                Lookuplist.Clear();
                switch(radioGroup2.SelectedItem){
                    case 0:
                        Lookuplist = MainProc.enItemDic
                            .Where(k => k.Key.StartsWith(type) && k.Value.Contains(textField.Text.ToString()))
                            .Select(k => k.Key + " --- " + k.Value)
                            .ToList();
                        break;
                    case 1:
                        Lookuplist = MainProc.zhItemDic
                            .Where(k => k.Key.StartsWith(type) && k.Value.Contains(textField.Text.ToString()))
                            .Select(k => k.Key + " --- " + k.Value)
                            .ToList();//需要改！
                        break;
                    case 2:
                        Lookuplist = MainProc.zhItemDic
                            .Where(
                                k => k.Key.StartsWith(type) 
                                && (k.Value.ToPinyin()).Contains(textField.Text.ToString())
                                )
                            .Select(k => k.Key + " --- " + k.Value)
                            .ToList();
                        break;
                    default:
                        break;
                }
                listView.SetSourceAsync(Lookuplist);
            }; 
        }
        
    }
}
