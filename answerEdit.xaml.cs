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
    public partial class answerEdit : Window
    {
        Answer answer = new Answer();
        public string _questionID;
        public Int32 _ID;
        public Button _vraagID;
        public Button _quizID;

        public answerEdit()
        {
            InitializeComponent();

            
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;


        }
        public answerEdit(Int32 ID, Button vraagID, Button quizID)
        {
            InitializeComponent();
            answer.Read(ID);
            _quizID = quizID;
            _vraagID = vraagID;
            _ID = ID;
            vraag.Content = "Vraag " + answer.getal;
            txb.Text = answer.antwoordA;
            
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            answer.Update(_ID, txb.Text );

            answersGrid answersGrid = new answersGrid(_vraagID, _quizID);
            answersGrid.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            answersGrid answersGrid = new answersGrid(_vraagID, _quizID);
            answersGrid.Show();
            this.Close();
        }
    }
}
