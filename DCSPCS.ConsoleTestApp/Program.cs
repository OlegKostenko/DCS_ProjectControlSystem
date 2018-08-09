using DCSPCS.DAL.DBWarehouse.DbLayer;
using DCSPCS.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContextFactory factory = new MyContextFactory();
            var test = factory.GetWarehouseContext();
            foreach(var item in test.Set<WREquipment>().ToList())
            {
                Console.WriteLine(item.WREquipUnits);
            }
        }
    }
}
