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
    /// Interaction logic for quizStart.xaml
    /// </summary>
    public partial class quizStart : Window

    {
        Quiz quiz = new Quiz();
        Question question = new Question();
        Answer answer = new Answer();
        int row = 0;
        
        
        public quizStart(Int32 quizID)
        {

            InitializeComponent();
            quizAdmin quizadmin = new quizAdmin(this);
            quizadmin.Show();

            quiz.Read(quizID);
            lblquiz.Content = quiz.naam;
            
            question.showQuestion(quizID);
            lblvraag.Content = question.ID;

            answer.showAnswers(question.ID);
            lblA.Content = answer.antwoordA;
            lblB.Content = answer.antwoordB;
            lblC.Content = answer.antwoordC;
            lblD.Content = answer.antwoordD;



           

        }

        public void NextQuestion()
        {
            
            try
            {
                int quiz = 2;
                row++;

                question.showQuestion1(quiz, row);
                lblvraag.Content = question.ID;


                answer.showAnswers(question.ID);
                lblA.Content = answer.antwoordA;
                lblB.Content = answer.antwoordB;
                lblC.Content = answer.antwoordC;
                lblD.Content = answer.antwoordD;
            } 
            catch 
            {
                quizEnd quizEnd = new quizEnd();
                quizEnd.Show();
                this.Close();
            }

        }


    }
       
}

