using System;
using System.Collections.Generic;
using Tasky.BL;
using Tasky.DL.SQLiteBase;

namespace Tasky.BL.Managers
{
	public class TaskManager
    {
        #region Variáveis
        DAL.TaskRepository repository;
        #endregion

        #region Construtor
        public TaskManager (SQLiteConnection conn) 
        {
            repository = new DAL.TaskRepository(conn, "");
        }
        #endregion

        #region GetTask
        public Task GetTask(int id)
		{
            return repository.GetTask(id);
		}
        #endregion

        #region GetTasks
        public IList<Task> GetTasks ()
		{
            return new List<Task>(repository.GetTasks());
		}
        #endregion

        #region SaveTask
        public int SaveTask (Task item)
		{
            return repository.SaveTask(item);
		}
        #endregion

        #region Delete Task
        public int DeleteTask(int id)
		{
            return repository.DeleteTask(id);
        }
        #endregion
    }
}