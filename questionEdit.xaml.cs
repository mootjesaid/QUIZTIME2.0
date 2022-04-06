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
    public partial class questionEdit : Window
    {
        Question question = new Question();
        

        public questionEdit()
        {

          

            InitializeComponent();
            
            lblID.Visibility = Visibility.Hidden;
            txbID.Visibility = Visibility.Hidden;
            
            btnUpdate.Content = "Create";

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }
        public questionEdit(Int32 ID)
        {
            InitializeComponent();
            question.Read(ID);
           

            txbID.Text = question.ID.ToString();
            txbVraag.Text = question.vraag;
            txbAfbeelding.Text = question.afbeelding;
            txbquizID.Text = question.tblquizID;
         

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }

       

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            

            if (txbID.Text == string.Empty)
            {

                question.Create(txbVraag.Text, txbAfbeelding.Text, txbquizID.Text);
            }
            else
            {
                question.Update(txbID.Text,
                                txbVraag.Text, txbAfbeelding.Text);
            }

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
