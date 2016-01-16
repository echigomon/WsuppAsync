using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using LRSkipAsync;
using WsuppAsync;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyWindows
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region 初期設定
        private CS_WsuppAsync wsupp;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            wsupp = new CS_WsuppAsync();

            TextBox01.Text = "";

            // 初期表示をクリアする
            ClearResultTextBox();
        }

        #region ［Ｗｓｕｐｐ］ボタン押下
        private async void button1_Click(object sender, RoutedEventArgs e)
        {   // [Wsupp]ボタン押下

            String KeyWord = TextBox01.Text;

            await wsupp.ExecAsync(KeyWord);
            WriteLineResult("\nResult : Wbuf[{0}] => [{1}]", KeyWord, wsupp.Wbuf);
        }
        #endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private async void button3_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();           // 初期表示をクリアする

            await wsupp.ClearAsync();       // Wsuppの内容を初期化する

            TextBox01.Text = "";
        }
        #endregion
    }
}
