using System;
using System.CodeDom;
using Terminal.Gui;
using System.Linq;
using System.Text.Json;
using System.Text;
using Pinyin4net;

namespace MCSM;

public partial class MainProc{
    public static bool openSign = true;
    public static void Main(){
        InitServer();
        Application.Init();
        while(openSign){
            try{
                Application.Run(new MainForm(){
                    ColorScheme = DispStyle
                });
            }catch (Exception e){
                MessageBox.ErrorQuery("ERROR",e.Message,"OK");
            }
        }
    }
    
}
public static class DictionaryExtensions
{
    public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
        foreach (var item in items)
        {
            dictionary[item.Key] = item.Value; // 如果键已存在，会覆盖旧值
        }
    }
}
public static class StringExtensions
{
    public static string ToPinyin(this string k)
    {
        StringBuilder ret = new StringBuilder();
        foreach (char a in k)
        {
            // 使用 Pinyin4Net 的 PinyinHelper 类获取拼音
            string[] pinyinArray = PinyinHelper.ToHanyuPinyinStringArray(a);
            if (pinyinArray != null && pinyinArray.Length > 0)
            {
                foreach (string z in pinyinArray){
                    ret.Append(z);
                }
            }
            else
            {
                // 如果不是汉字，直接追加原字符
                ret.Append(a);
            }
        }
        return ret.ToString();
    }
}