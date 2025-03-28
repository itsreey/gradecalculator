// This is the database services, like from our labs. The code is mostly taken from our labs bc i understand it and it works

using SQLite;
using gradecalculator.Models;
using Microsoft.Maui.Storage;

namespace gradecalculator
{
    internal static class GCDatabase
    {
        private static string _databaseFile;
        public static string DatabaseFile
        {
            get
            {
                if (_databaseFile == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "data");
                    System.IO.Directory.CreateDirectory(databaseDir);

                    _databaseFile = Path.Combine(databaseDir, "gradedatabase.sqlite");
                }
                return _databaseFile;
            }
        }

        private static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(DatabaseFile);
                    _connection.CreateTable<CourseEntry>();
                }
                return _connection;
            }
        }
    }
}
