using System;
using Tasky.DL.SQLite;

namespace Tasky.BL.Contracts {
	
	// Classe basica de negocio que fornece o id
	public abstract class BusinessEntityBase : IBusinessEntity
    {
        #region construtor vazio
        public BusinessEntityBase ()
		{
		}
        #endregion

        /// <summary>
		/// Gets or sets o id do banco de dadsos
		/// </summary>
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
	}
}

