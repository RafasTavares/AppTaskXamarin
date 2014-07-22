using System;
using System.Linq;
using Tasky.BL;
using System.Collections.Generic;
using Tasky.DL.SQLiteBase;

namespace Tasky.DL
{
	/// <summary>
	/// TaskDatabase cria um DB sqlite. 
    /// O contém os métodos de recuperação e de persistência, bem como a criação de db.
	/// </summary>
	public class TaskDatabase
    {
        #region Variáveis
        static object locker = new object ();
        //criando o db
        SQLiteConnection database;
        #endregion

        #region Iniciando a instancia do DB
        /// <summary>
		/// inicializando a nova instancia do DB <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// se não existe uma instancia ele cria outra e as tabelas.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
        public TaskDatabase(SQLiteConnection conn, string path)
		{
            database = conn;
			// criando as tabelas
            database.CreateTable<Task>();
		}
        #endregion

        #region Retorna todos os itens
        public IEnumerable<T> GetItems<T> () where T : BL.Contracts.IBusinessEntity, new ()
		{
            lock (locker) {
                return (from i in database.Table<T>() select i).ToList();
            }
		}
        #endregion

        #region Retorna o item específico
        public T GetItem<T> (int id) where T : BL.Contracts.IBusinessEntity, new ()
		{
            lock (locker) {
                return database.Table<T>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
		}
        #endregion

        #region Salvando o item
        public int SaveItem<T> (T item) where T : BL.Contracts.IBusinessEntity
		{
            lock (locker) {
                if (item.ID != 0) {
                    database.Update(item);
                    return item.ID;
                } else {
                    return database.Insert(item);
                }
            }
		}
        #endregion

        #region Delete Item
        public int DeleteItem<T>(int id) where T : BL.Contracts.IBusinessEntity, new ()
		{
            lock (locker) {
                return database.Delete<T>(new T() { ID = id });
            }
        }
        #endregion
    }
}