using Ejercicio_2_4_Movil2_2doP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2_4_Movil2_2doP.Controllers
{
    public class DBProcess
    {
        readonly SQLiteAsyncConnection _connection;

        public DBProcess(String dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<Signatures>().Wait();
        }

        public Task<int> AddPhoto(Signatures sign)
        {
            if (sign.Id == 0)
            {
                return _connection.InsertAsync(sign);
            }
            else
            {
                return _connection.UpdateAsync(sign);
            }
        }

        public Task<List<Signatures>> GetAll()
        {
            return _connection.Table<Signatures>().ToListAsync();
        }

    }
}
