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

        public answerEdit()
        {
            InitializeComponent();

            btnUpdate.Content = "Create";
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;


        }
        public answerEdit(Int32 ID)
        {
            InitializeComponent();
            answer.Read(ID);

            _ID = ID;
            vraag.Content = "Vraag " + answer.getal;
            txb.Text = answer.antwoord;
            
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            answer.Update(_ID, txb.Text );

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
