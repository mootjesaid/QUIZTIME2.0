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
    public partial class questions : Window
    {
        Question question = new Question();
        public questions(Button quizID)
        {
            InitializeComponent();
            dgVragen.DataContext = question.getData((int)quizID.Tag);
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
                object item = dgVragen.SelectedItem;
                int ID = int.Parse((dgVragen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

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
                object item = dgVragen.SelectedItem;
                int ID = int.Parse((dgVragen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (question.Delete(ID) == true)
                {
                    dgVragen.DataContext = question.getData_Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btn_Antwoorden(object sender, RoutedEventArgs e)
        {
            Button vraagID = (Button)sender;



            answersGrid window = new answersGrid(vraagID);


            window.Show();
            this.Close();
        }
    }
}
