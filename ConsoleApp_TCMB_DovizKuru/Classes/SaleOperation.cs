using ConsoleApp_TCMB_DovizKuru.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_TCMB_DovizKuru.Classes
{
    public class SaleOperation
    {
        ConsoleDbKurProjeEntities db = new ConsoleDbKurProjeEntities();

        public void CustomerSaleOperation()
        {
            var values = db.Operation.ToList();
            foreach (var item in values)
            {
                Console.WriteLine("ID : " + item.ID + " " + item.CustomerName + " " + item.CustomerSurname + "Döviz : " + item.Currency.CurrencyName + "İşlem Türü : " + item.OperationType + "Kur Birim Tutarı : " + item.CurrentValue + "Alınan Tutar : " + item.Amount + "Toplam Tutar : " + item.TotalPrice );
            }
        }
    }
}
