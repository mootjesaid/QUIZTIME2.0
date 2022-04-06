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
    /// Interaction logic for questions.xaml
    /// </summary>
    public partial class quizGrid : Window
    {
        Quiz quiz = new Quiz();
        public quizGrid()
        {
            InitializeComponent();
            dgQuiz.DataContext = quiz.getData();
            btnAdd.Click += BtnAdd_Click;


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            quizEdit quizEdit = new quizEdit();
            quizEdit.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgQuiz.SelectedItem;
                int ID = int.Parse((dgQuiz.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                quizEdit window = new quizEdit(ID);
                window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgQuiz.SelectedItem;
                int ID = int.Parse((dgQuiz.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (quiz.Delete(ID) == true)
                {
                    dgQuiz.DataContext = quiz.getData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnVragen(object sender, RoutedEventArgs e)
        {
            Button quizID = (Button)sender;
            Button fk = (Button)sender;
            questions window = new questions(quizID, fk);


            window.Show();
            this.Close();
        }
    }
}
