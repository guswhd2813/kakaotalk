using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace kakao
{
    class DBManager
    {
        private static DBManager _DBManager = null;
        public static DBManager Getinstance
        {
            get
            {
                if (_DBManager == null)
                {
                    _DBManager = new DBManager();
                }
                return _DBManager;
            }
        }
        public DataRowCollection GetDriverName()
        {
            return Sqlite().Tables[0].Rows;
        }
        public DataSet GetDriverData()
        {
            return Sqlite();
        }


        private DataSet Sqlite()
        {
            DataSet _dsResource = new DataSet();
            try
            {
                string DBPath = string.Format(Application.StartupPath + @"\DB\Test.db");
                string connString = String.Format("Data Source={0};New=False;Version=3", DBPath);
                SQLiteConnection sqlconn = new SQLiteConnection(connString);
                sqlconn.Open();
                // 20140901
                string CommandText = string.Format("SELECT * FROM T_Driver ;");
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(CommandText, sqlconn);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(dataAdapter);

                
                //2018.03.06 Gideon #22899 인사이트 개별실행
                DataTable dt_CHN_AREACODE = new DataTable("Driver");
                dataAdapter.FillSchema(dt_CHN_AREACODE, SchemaType.Source);
                foreach (DataColumn dc in dt_CHN_AREACODE.Columns)
                {
                    if (dc.DataType == typeof(long))
                    {
                        dc.DataType = typeof(Int32);
                    }
                }
                dataAdapter.Fill(dt_CHN_AREACODE);
                _dsResource.Tables.Add(dt_CHN_AREACODE);
                return _dsResource;
                //DataRowCollection dataRowCol = _dsResource.Tables["MA_CHN_AREACODE"].Rows;
            }
            catch
            {
                return null;
            }
        }
    }
}
