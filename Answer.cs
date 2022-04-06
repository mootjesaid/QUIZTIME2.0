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
        private string _antwoord;
        private string _getal;
        private string _correct;
        private string _tblvragenID;


        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string antwoord
        {
            get { return _antwoord; }
            set { _antwoord = value; }
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
        public void Create(string antwoord, string correct)
        {
            string SQL = string.Format("INSERT INTO dbquiztime.tblantwoorden (Antwoord)(Getal)(Correct) VALUES ('{0}', '{1}')",
                        antwoord, correct);

            sql.ExecuteNonQuery(SQL);
        }
        public void Read(Int32 ID)
        {
            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tbaaaa WHERE ID = {0}", ID);
            DataTable datatable = sql.getDataTable(SQL);

            _ID = datatable.Rows[0]["ID"].ToString();
            _antwoord = datatable.Rows[0]["Antwoord"].ToString();
            _getal = datatable.Rows[0]["Getal"].ToString();
            _correct = datatable.Rows[0]["Correct"].ToString();
            _tblvragenID = datatable.Rows[0]["tblvragen_id"].ToString();

        }
        public void Update(string antwoord,string correct, string ID)
        {
            string SQL = string.Format("Update dbquiztime.tblvragen " +
                                        "Set Vraag     = '{0}', " +
                                                "Afbeelding = '{1}', " +
                                       "WHERE ID     =  {2}", antwoord,
                                                              correct,
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
