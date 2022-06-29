using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            ChooseImage.Click += ChooseImage_Click;

        }



        public questionAdd(Int32 _quizID)
        {

            InitializeComponent();
            _ID = _quizID;
            
           
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
            ChooseImage.Click += ChooseImage_Click;
        }


        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false };
            {
                bool? result = ofd.ShowDialog();
                if (result == true)
                {
                    string file = string.Empty;
                    file = ofd.SafeFileName;
                    txbAfbeelding.Text = file;
                }
                else
                {
                    MessageBox.Show("You didn't choose an image");
                }
            }
        }
    


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            question.Create(txbVraag.Text, txbAfbeelding.Text, _ID);
            
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
