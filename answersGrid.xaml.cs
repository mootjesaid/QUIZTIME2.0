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
    public partial class answersGrid : Window
    {
        Answer answer = new Answer();
        public answersGrid(Button vraagID)
        {
            InitializeComponent();
            dgAnswers.DataContext = answer.getData((int)vraagID.Tag);
            btnAdd.Click += BtnAdd_Click;


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            answerEdit answerEdit = new answerEdit();
            answerEdit.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgAnswers.SelectedItem;
                int ID = int.Parse((dgAnswers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                answerEdit window = new answerEdit(ID);
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
                object item = dgAnswers.SelectedItem;
                int ID = int.Parse((dgAnswers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (answer.Delete(ID) == true)
                {
                    dgAnswers.DataContext = answer.getData_Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        
    }
}
