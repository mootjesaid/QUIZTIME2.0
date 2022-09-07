using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QUIZTIME2
{

    //dit is een vraag

    class Answer
    {
        private string _ID;
        private Int32 _lastID;
        private string _antwoordA;
        private string _antwoordB;
        private string _antwoordC;
        private string _antwoordD;
        private string _getal;
        private string _correct;
        private string _tblvragenID;


        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public Int32 lastID
        {
            get { return _lastID; }
            set { _lastID = value; }
        }

        public string antwoordA
        {
            get { return _antwoordA; }
            set { _antwoordA = value; }
        }
        public string antwoordB
        {
            get { return _antwoordB; }
            set { _antwoordB = value; }
        }
        public string antwoordC
        {
            get { return _antwoordC; }
            set { _antwoordC = value; }
        }
        public string antwoordD
        {
            get { return _antwoordD; }
            set { _antwoordD = value; }
        }

        public string getal
        {
            get { return _getal; }
            set { _getal = value; }
        }

        public string tblquizID
        {
            get { return _tblvragenID; }
            set { _tblvragenID = value; }
        }

        public string correct
        {
            get { return _correct; }
            set { _correct = value; }
        }

        public string tblvragenID
        {
            get { return _tblvragenID; }
            set { _tblvragenID = value; }
        }

        

        SQL sql = new SQL();

        public DataSet getData(int vraagID)
        {

            string SQL = string.Format("SELECT ID, Antwoord, Getal, Correct, tblvragen_id FROM dbquiztime.tblantwoorden WHERE tblvragen_id = {0}", vraagID);


            return sql.getDataSet(SQL);
        }

        public DataSet getData_Delete()
        {
            string SQL = "SELECT ID, Antwoord, Getal, Correct, tblvragen_id FROM dbquiztime.tblantwoorden";

            return sql.getDataSet(SQL);
        }

        //CRUD
        public void Create(string antwoord, string correct, string getal, int tblvragenID)
        {
            string SQL = string.Format("INSERT INTO dbquiztime.tblantwoorden (Antwoord, Getal, Correct, tblvragen_id) VALUES ('{0}', '{1}', '{2}', '{3}')",
                        antwoord, getal, correct, tblvragenID);




            sql.ExecuteNonQuery(SQL);
        }
        public void Read(Int32 ID)
        {
            string SQL = string.Format("SELECT ID, Antwoord, Getal, Correct, tblvragen_id FROM dbquiztime.tblantwoorden WHERE ID = {0}", ID);
            DataTable datatable = sql.getDataTable(SQL);

            _ID = datatable.Rows[0]["ID"].ToString();
            _antwoordA = datatable.Rows[0]["Antwoord"].ToString();
            _getal = datatable.Rows[0]["Getal"].ToString();
            _correct = datatable.Rows[0]["Correct"].ToString();
            _tblvragenID = datatable.Rows[0]["tblvragen_id"].ToString();

        }

        public void aID()
        {
            string SQL = string.Format("SELECT MAX(ID) AS last_id FROM tblanwtoorden");
            DataTable datatable = sql.getDataTable(SQL);

            _lastID = Convert.ToInt32(datatable.Rows[0]["last_id"].ToString());
            

        }

        public void showAnswers(long question_ID)
        {
             
            string SQL = string.Format("SELECT ID, Antwoord, Getal, Correct, tblvragen_id FROM dbquiztime.tblantwoorden WHERE tblvragen_id = {0}", question_ID);
            DataTable datatable = sql.getDataTable(SQL);

            _ID = datatable.Rows[0]["ID"].ToString();
            _antwoordA = datatable.Rows[0]["Antwoord"].ToString();
            _antwoordB = datatable.Rows[1]["Antwoord"].ToString();
            _antwoordC = datatable.Rows[2]["Antwoord"].ToString();
            _antwoordD = datatable.Rows[3]["Antwoord"].ToString();
            _getal = datatable.Rows[0]["Getal"].ToString();
            _correct = datatable.Rows[0]["Correct"].ToString();
            _tblvragenID = datatable.Rows[0]["tblvragen_id"].ToString();

        }

       /* public void showB(Int32 question_ID)
        {

            string SQL = string.Format("SELECT ID, Antwoord, Getal, Correct, tblvragen_id FROM dbquiztime.tblantwoorden WHERE tblvragen_id = {0} LIMIT 1, 3", question_ID);
            DataTable datatable = sql.getDataTable(SQL);

            _ID = datatable.Rows[0]["ID"].ToString();
            _antwoord = datatable.Rows[0]["Antwoord"].ToString();
            _getal = datatable.Rows[0]["Getal"].ToString();
            _correct = datatable.Rows[0]["Correct"].ToString();
            _tblvragenID = datatable.Rows[0]["tblvragen_id"].ToString();

        }*/
        public void Update(Int32 ID, /*string QuestionID*/ string antwoord)
        {
            string SQL = string.Format("Update dbquiztime.tblantwoorden " +
                                        "Set Antwoord     = '{0}' " +
                                        "WHERE ID     = '{1}'", antwoord,
                                                           ID.ToString());

            sql.ExecuteNonQuery(SQL);
            // System.Windows.MessageBox.Show(customerName + " is geupdate");
        }

        public bool Delete(Int32 ID)
        {
            bool isDeleted = false;
            if (System.Windows.MessageBox.Show("Moet ik deze gegevens verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM dbquiztime.tblvragen WHERE ID = {0};", ID);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;

                // System.Windows.MessageBox.Show("gegevens zijn verwijderd");
            }
            return isDeleted;
        }



    }
}
