using ConsoleApp_TCMB_DovizKuru.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_TCMB_DovizKuru.Classes
{
    public class Sale
    {
        ConsoleDbKurProjeEntities db = new ConsoleDbKurProjeEntities();
        public void MakeSale(string customerName, string customerSurname, int currencyCode, string operationType, decimal currentValue, decimal amount, decimal totalPrice)
        {
            Operation t = new Operation();
            t.CustomerName = customerName;
            t.CustomerSurname=customerSurname;
            t.CurrencyID = currencyCode;
            t.OperationType = operationType;
            t.CurrentValue=currentValue;
            t.Amount = amount;
            t.TotalPrice = totalPrice;
            t.Date = DateTime.Parse( DateTime.Now.ToShortDateString());
            db.Operation.Add(t);
            db.SaveChanges();

            Console.WriteLine("Satış İşlemi Gerçekleştirildi");
        }
    }
}
