﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.common
{
    class Constants
    {
        public static string connectionStringOffline = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SantaLocalDb.mdf;Integrated Security=True");
        public static string connectionStringOnline = "host='db-mysql-sgp1-66064-do-user-9937190-0.b.db.ondigitalocean.com';" +
            "Database='SantaDb';" +
           "port='25060';" +
            "UID='Santaadmin';" +
            "PWD='RXTs2ppzH2kXEwUd';";

        public static string filename2 = @"C:\New folder\tricy1.docx";
        public static string filename1 = @"C:\New folder\tricy.docx";
        public static string file = "";

        public static string fileContent = string.Empty;
        public static string filePath = string.Empty;
        public static string ext = string.Empty;

    }
}
