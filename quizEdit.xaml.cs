﻿using System;
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
    public partial class quizEdit : Window
    {
        Quiz quiz = new Quiz();

        public quizEdit()
        {
            InitializeComponent();

            lblID.Visibility = Visibility.Hidden;
            txbID.Visibility = Visibility.Hidden;
            btnUpdate.Content = "Create";

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }
        public quizEdit(Int32 ID)
        {
            InitializeComponent();
            quiz.Read(ID);

            txbID.Text = quiz.ID.ToString();
            txbNaam.Text = quiz.naam;

            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txbID.Text == string.Empty)
            {
                quiz.Create(txbNaam.Text);
            }
            else
            {
                quiz.Update(txbID.Text,
                                txbNaam.Text);
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
