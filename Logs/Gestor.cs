using System;
using Log.DbModels;

namespace Log.Gestor
{
    public static class GestorLogs
    {
        public static void Log(Logs log)
        {
            LogsContext db = new LogsContext();

            db.Logs.Add(log);

            db.SaveChanges();
            db.Dispose();
        }
    }
}
