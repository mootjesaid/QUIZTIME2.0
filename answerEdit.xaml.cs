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
    public partial class answerEdit: Window
    {
        Answer answer = new Answer();

        public answerEdit()
        {
            InitializeComponent();

            lblID.Visibility = Visibility.Hidden;
            txbID.Visibility = Visibility.Hidden;
            btnUpdate.Content = "Create";

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }
        public answerEdit(Int32 ID)
        {
            InitializeComponent();
            answer.Read(ID);

            txbID.Text = answer.ID.ToString();
            txbAntwoord.Text = answer.antwoord;
            txbOrder.Text = answer.order;
            txbCorrect.Text = answer.correct;

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txbID.Text == string.Empty)
            {
                answer.Create(txbAntwoord.Text, txbCorrect.Text);
            }
            else
            {
                answer.Update(txbID.Text,
                                txbAntwoord.Text, txbCorrect.Text);
            }

            quizGrid quizGrid = new quizGrid();
            quizGrid.Show();
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
