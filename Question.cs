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

    class Question
    {
        private Int32 _ID;
        private string _vraag;
        private string _afbeelding;
        private Int32 _tblquizID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string vraag
        {
            get { return _vraag; }
            set { _vraag = value; }
        }

        public string afbeelding
        {
            get { return _afbeelding; }
            set { _afbeelding = value; }
        }


        public Int32 tblquizID
        {
            get { return _tblquizID; }
            set { _tblquizID = value; }
        }



        SQL sql = new SQL();

        public DataSet getData(int quizID)
        {

            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen WHERE tblquiz_ID = {0}", quizID);

            return sql.getDataSet(SQL);
        }

        public DataSet getData_Delete()
        {
            string SQL = "SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen";

            return sql.getDataSet(SQL);
        }



        //CRUD
        public void Create(string vraag, string afbeelding, string tblquiz_ID)


        {
            string SQL = string.Format("INSERT INTO dbquiztime.tblvragen (Vraag, Afbeelding, tblquiz_ID) VALUES ('{0}', '{1}', '{2}')",
                         vraag, afbeelding, tblquiz_ID);


            sql.ExecuteNonQuery(SQL);
        }

       

        public void Read(Int32 ID)
        {
            string SQL = string.Format("SELECT ID, Vraag, Afbeelding, tblquiz_ID FROM dbquiztime.tblvragen WHERE tblquiz_ID = {0}", ID);
            DataTable datatable = sql.getDataTable(SQL);

            _ID = Convert.ToInt32(datatable.Rows[0]["ID"].ToString());
            _vraag = datatable.Rows[0]["Vraag"].ToString();
            _afbeelding = datatable.Rows[0]["Afbeelding"].ToString();
            _tblquizID = Convert.ToInt32(datatable.Rows[0]["tblquiz_ID"].ToString());

        }
        public void Update(string id, string vraag, string afbeelding)
        {
            string SQL = string.Format("Update dbquiztime.tblvragen " +
                                      "Set Vraag      = '{0}', " +
                                          "Afbeelding = '{1}' " +
                                            "WHERE ID =  {2}", vraag,
                                                               afbeelding,
                                                               id.ToString());
            sql.ExecuteNonQuery(SQL);
            //System.Windows.MessageBox.Show(id + " is geupdate");

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
