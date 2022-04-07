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
    /// Interaction logic for quizEdit.xaml
    /// </summary>
    public partial class questionAdd : Window
    {
        Question question = new Question();
        private Int32 _ID;

        public questionAdd()
        {

            InitializeComponent();
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }
        public questionAdd(Int32 _quizID)
        {

            InitializeComponent();
            _ID = _quizID;
            txbquizID.Text = _ID.ToString();
            lblID.Visibility = Visibility.Hidden;
            txbID.Visibility = Visibility.Hidden;
            lblQID.Visibility = Visibility.Hidden;
            txbquizID.Visibility = Visibility.Hidden;
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }

       

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            question.Create(txbVraag.Text, txbAfbeelding.Text, txbquizID.Text);
            
            quizGrid questions = new quizGrid();
            questions.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            quizGrid window = new quizGrid();
            window.Show();
            this.Close();
        }
    }
}
