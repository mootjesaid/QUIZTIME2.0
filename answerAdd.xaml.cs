using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QUIZTIME2._0
{
    /// <summary>
    /// Interaction logic for answerAdd.xaml
    /// </summary>
    public partial class answerAdd : Window
    {
        Answer answer = new Answer();
        public int _ID;

        public answerAdd(int ID)
        {
            InitializeComponent();
            _ID = ID;
            btnAdd.Click += BtnAdd_Click; ;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string correctA = "";
            if (rbA.IsChecked == true)
            {
                correctA = "true";
            }
            else { correctA = "false"; }

            answer.Create(txbA.Text, correctA, "A", _ID);

            string correctB = "";
            if (rbB.IsChecked == true)
            {
                correctB = "true";
            }
            else { correctB = "false"; }

            answer.Create(txbB.Text, correctB, "B", _ID);

            string correctC = "";
            if (rbD.IsChecked == true)
            {
                correctC = "true";
            }
            else { correctC = "false"; }

            answer.Create(txbC.Text, correctC, "C", _ID);

            string correctD = "";
            if (rbD.IsChecked == true)
            {
                correctD = "true";
            }
            else { correctD = "false"; }

            answer.Create(txbD.Text, correctD, "D", _ID);

            this.Close();

        }
        
    }
}
