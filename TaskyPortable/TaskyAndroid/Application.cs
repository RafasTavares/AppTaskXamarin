using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Tasky.BL.Managers;
using Tasky.DL.SQLite;
using System.IO;

namespace TaskyAndroid {
    [Application]
    public class TaskyApp : Application
    {
        #region Variáveis
        public static TaskyApp Current { get; private set; }

        public TaskManager TaskMgr { get; set; }
        Connection conn;

        #endregion

        #region Construtor
        public TaskyApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer) {
                Current = this;
        }
        #endregion

        #region On Create
        public override void OnCreate()
        {
            base.OnCreate();

            var sqliteFilename = "TaskDB.db3";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            conn = new Connection(path);

            TaskMgr = new TaskManager(conn);
        }
        #endregion
    }
}
