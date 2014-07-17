using System;
using Tasky.BL.Contracts;
using Tasky.DL.SQLite;

namespace Tasky.BL
{
	
	//classe de tarefa
	public class Task : IBusinessEntity
    {
        #region contrutor vazio
        public Task ()
		{
		}
        #endregion

        #region variáveis
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		// new property
		public bool Done { get; set; }
        #endregion
    }
}

