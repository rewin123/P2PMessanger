using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDB
{
    public interface IObjectTable<T>
    {
        /// <summary>
        /// Подключает таблицу лбхектов к БД
        /// </summary>
        /// <param name="session"></param>
        /// <param name="table_name"></param>
        void Init(DBSession session, string table_name);
        T[] GetObjects();

    }
}
