using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Translate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_translate_Click(object sender, RoutedEventArgs e)
        {
            tr();
        }

        public void tr()
        {
            string from_str;
            string to_str;
            Match match;
            string result = "Text is error or empty";
            if ((bool)checkBox_cn.IsChecked)
            {
                from_str = textBox_from.Text.ToString().Trim();
                to_str = TranslateHelper.translateToCN(from_str);
                match = Regex.Match(to_str, "(?<=\"dst\":\").+(?=\")");
                if (match.Length > 0)
                {
                    result = Regex.Unescape(match.Value);
                }
                textBox1_to.Text = result;

            }
            else if ((bool)checkBox_en.IsChecked)
            {
                from_str = textBox_from.Text.ToString().Trim();
                to_str = TranslateHelper.translateToEN(from_str);
                match = Regex.Match(to_str, "(?<=\"dst\":\").+(?=\")");
                if (match.Length > 0)
                {
                    result = match.Value;
                }
                textBox1_to.Text = result;
            }
            else
            {
                MessageBox.Show("Please check the language.");
            }
        }

        private void chk_Click(object sender, RoutedEventArgs e)
        {
            var checkBoxes = new[] { checkBox_cn, checkBox_en };
            var current = (CheckBox)sender;
            foreach (var checkBox in checkBoxes)
            {
                if (checkBox != current)
                {
                    checkBox.IsChecked = !current.IsChecked;
                }
            }
        }
    }
}
