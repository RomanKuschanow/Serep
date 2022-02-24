using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using Windows.Storage;
using IniParser;
using IniParser.Model;

namespace Serep.Uno
{
    class DataBase
    {
  
        public DataBase()
        {
            InitializeDB();
        }

        public async static void InitializeDB()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("userData.db", CreationCollisionOption.OpenIfExists);
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "userData.db");

            using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
            {
                con.Open();
                string initCMD = "CREATE TABLE IF NOT EXISTS reports(id UNIQUEIDENTIFIER, date DATETIME, publications INT, video INT, hour INT, minute INT, pp INT, studies INT, note NTEXT, PRIMARY KEY(id))";
            
                SqliteCommand CMDcreateTable = new SqliteCommand(initCMD, con);
                CMDcreateTable.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void SetRecord(DateTime date, int publications, int video, int hour, int minute, int pp, int studies, string note)
        {
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "userData.db");            

            using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
            {
                con.Open();
                SqliteCommand CMD_Insert = new SqliteCommand();
                CMD_Insert.Connection = con;

                CMD_Insert.CommandText = "INSERT INTO reports VALUES (@id, @date, @publications, @video, @hour, @minute, @pp, @studies, @note)";
                CMD_Insert.Parameters.AddWithValue("@id", Guid.NewGuid());
                CMD_Insert.Parameters.AddWithValue("@date", date);
                CMD_Insert.Parameters.AddWithValue("@publications", publications);
                CMD_Insert.Parameters.AddWithValue("@video", video);
                CMD_Insert.Parameters.AddWithValue("@hour", hour);
                CMD_Insert.Parameters.AddWithValue("@minute", minute);
                CMD_Insert.Parameters.AddWithValue("@pp", pp);
                CMD_Insert.Parameters.AddWithValue("@studies", studies);
                CMD_Insert.Parameters.AddWithValue("@note", note);

                CMD_Insert.ExecuteReader();

                con.Close();
            }
        }

        public class reports
        {
            public DateTime date { get; set; }
            public int publications { get; set; }
            public int video { get; set; }
            public string time { get; set; }
            public int pp { get; set; }
            public int studies { get; set; }
            public string note { get; set; }

            public reports(DateTime date, int publications, int video, int hour, int minute, int pp, int studies, string note)
            {
                this.date = date;
                this.publications = publications;
                this.video = video;
                this.time = $"{hour}:{minute}";
                this.pp = pp;
                this.studies = studies;
                this.note = note;
            }
        }

        public static List<reports> GetReports()
        {
            List<reports> reportsList = new List<reports>();
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "userData.db");

            using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
            {
                con.Open();

                string selectCMD = "SELECT date, publications, video, hour, minute, pp, studies, note FROM reports";
                SqliteCommand cmd_getRec = new SqliteCommand(selectCMD, con);

                SqliteDataReader reader = cmd_getRec.ExecuteReader();

                while (reader.Read())
                {
                    reportsList.Add(new reports(reader.GetDateTime(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)));
                }

                con.Close();
            }

            return reportsList;
        }
    }
}
 