using System;
using System.Collections.Generic;
using System.IO;
using Tasky.BL;
using Tasky.DL.SQLiteBase;

namespace Tasky.DAL {
	public class TaskRepository {
		DL.TaskDatabase db = null;
		protected static string dbLocation;

        #region Construtor
        public TaskRepository(SQLiteConnection conn, string dbLocation)
		{
			db = new Tasky.DL.TaskDatabase(conn, dbLocation);
		}
        #endregion

        #region Retorna uma tarefa passando i Id
        public Task GetTask(int id)
		{
            return db.GetItem<Task>(id);
		}
        #endregion

        #region Retorna todas as taferas
        public IEnumerable<Task> GetTasks ()
		{
			return db.GetItems<Task>();
		}
        #endregion

        #region Salva a tarefa
        public int SaveTask (Task item)
		{
			return db.SaveItem<Task>(item);
		}
        #endregion

        #region Deleta a tarefa
        public int DeleteTask(int id)
		{
			return db.DeleteItem<Task>(id);
        }
        #endregion
    }
}

