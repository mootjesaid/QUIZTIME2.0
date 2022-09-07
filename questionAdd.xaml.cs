using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Path = System.IO.Path;

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
            btnUpdate.Click += BtnUpdate_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSelectImage.Click += BtnSelectImage_Click;
        }

        

        public questionAdd(Int32 _quizID)
        {

            InitializeComponent();
            _ID = _quizID;

            btnUpdate.Click += BtnUpdate_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSelectImage.Click += BtnSelectImage_Click;
        }

  

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false };
            {
                bool? result = ofd.ShowDialog();
                if (result == true)
                {
                    txbAfbeelding.Text = ofd.FileName;

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(ofd.FileName);
                    image.EndInit();

                    imgQuestion.Source = image;
                }
                else
                {
                    MessageBox.Show("You didn't choose an image");
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            question.Create(txbVraag.Text, txbAfbeelding.Text, _ID);

            MainWindow questions = new MainWindow();
            questions.Show();
            this.Close();
        }


    }
}
