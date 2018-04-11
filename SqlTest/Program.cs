using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDB;

namespace SqlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DBSession session = new DBSession("database.db");
            Console.ReadLine();
        }
    }
}
