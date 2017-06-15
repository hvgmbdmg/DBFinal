using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using Mono.Data.Sqlite;
using MySQLDriverCS;
using UnityEngine;
using UnityEngine.UI;

public class connectDataBase : MonoBehaviour {
    public Text winInformation;
    public static string user_name = "Albert";
    public static int rank = 0;
    public static int death = 2;
    public static int time = 33;
    public static int score = 1000;


    // Use this for initialization
    void Start () {

        getNewData();
        //insertData();
        string conn = "URI=file:" + Application.dataPath + "/DBscore.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlInsert = "INSERT INTO Score4 VALUES ('" + user_name + "'," + rank + ","
            + death + "," + time + "," + score + ");";
        dbcmd.CommandText = sqlInsert;
        IDataReader write = dbcmd.ExecuteReader();
        write.Close();
        write = null;

        string sqlQuery = "SELECT *" + "FROM Score4";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string user_name2 = reader.GetString(0);
            int rank2 = reader.GetInt32(1);
            int death2 = reader.GetInt32(2);
            int time2 = reader.GetInt32(3);
            int score2 = reader.GetInt32(4);

            Debug.Log("user_name2= " + user_name2 + "  rank2 =" + rank2 + "  death2 =" + death2
                + "  time2 =" + time2 + "  score2 =" + score2);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    /*public static string user_name = "Albert";
    public static int rank = 0;
    public static int death = 2;
    public static int time = 33;
    public static int score = 1000;
    */
    void getNewData() {
        int timeScore = 0;

        user_name = "Albert";
        rank = 1;
        death = playerController.deathNumber;
        time = (int)Mathf.Round(playerController.timeNumber);
        if (time > 999) {
            timeScore = 0;
        }
        else {
            timeScore = 1000 - time;
        }
        score = (100 - death) * 10 + timeScore;

        winInformation.text = "Name:  " + user_name + "\n" + "Time: " + time + "\n" +
            "Death: " + death + "\n" + "Score: " + score + "\n";
    }
    /*
    void insertData(){
string conn = "URI=file:" + Application.dataPath + "/DBscore.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlInsert = "INSERT INTO Score4 VALUES ('" + user_name + "'," + rank + ","
            + death + "," + time + "," + score + ");";
        dbcmd.CommandText = sqlInsert;
        IDataReader write = dbcmd.ExecuteReader();
        write.Close();
        write = null;

        string sqlQuery = "SELECT *" + "FROM Score4";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string user_name2 = reader.GetString(0);
            int rank2 = reader.GetInt32(1);
            int death2 = reader.GetInt32(2);
            int time2 = reader.GetInt32(3);
            int score2 = reader.GetInt32(4);

            Debug.Log("user_name2= " + user_name2 + "  rank2 =" + rank2 + "  death2 =" + death2
                + "  time2 =" + time2 + "  score2 =" + score2);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }*/

	// Update is called once per frame
	void Update () {
        
    }
}

 /*
    using System.Data.Odbc;  
    using System.Drawing;  
    using System.Windows.Forms;  


    namespace mysql	
    {  
15	
        public partial class Form1 : Form  
16	
        {  
17	
            public Form1()
18	
            {  
19	
                InitializeComponent();  
20	
            }  
21	
 
22	
            private void Form1_Load(object sender, EventArgs e)
23	
            {  
24	
            //Unity3D教程手册：www.manew.com
25	
                MySQLConnection conn = null;  
26	
                conn = new MySQLConnection(new MySQLConnectionString("localhost", "inv", "root", "831025").AsString);  
27	
                conn.Open();  
28	
                //Unity3D教程手册：www.manew.com
29	
                MySQLCommand commn = new MySQLCommand("set names gb2312", conn);  
30	
                commn.ExecuteNonQuery();  
31	
 
32	
                string sql = "select * from exchange ";  
33	
                MySQLDataAdapter mda = new MySQLDataAdapter(sql, conn);  
34	
 
35	
                DataSet ds = new DataSet();  
36	
                mda.Fill(ds, "table1");  
37	
 
38	
                this.dataGrid1.DataSource = ds.Tables["table1"];  
39	
                conn.Close();  
40	
 
41	
            }
42	
 
43	
 
44	
        }  
45	
    }  
    */