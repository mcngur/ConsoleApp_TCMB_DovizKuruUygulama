using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConsoleApp_TCMB_DovizKuru.Classes;
using ConsoleApp_TCMB_DovizKuru.Model;

namespace ConsoleApp_TCMB_DovizKuru
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string today = "https://tcmb.gov.tr/kurlar/today.xml";

            //var xmlDoc = new XmlDocument();
            //xmlDoc.Load(today);

            //string dolarAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;

            //string dolarSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;

            //string euroAlis= xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;

            //string euroSatis= xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;

            //Console.WriteLine("Dolar Alış Fiyatı : " + dolarAlis);
            //Console.WriteLine("Dolar Satış Fiyatı : " + dolarSatis);
            //Console.WriteLine("Euro Alış Fiyatı : " + euroAlis);
            //Console.WriteLine("Euro Satış Fiyatı : " + euroSatis);

            //Projeye veri tabanı eklendi ve alış satış uygulamasına çevirildi.

            ConsoleDbKurProjeEntities db = new ConsoleDbKurProjeEntities();
            GetCurrency getCurrency = new GetCurrency();
            Sale sale = new Sale();

            void CurrencyList()
            {
                Console.WriteLine();
                Console.WriteLine("Döviz Listesi");
                Console.WriteLine();
                var values = db.Currency.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine(item.ID + " " + item.CurrencyName);
                }
            }

            void CurrentCurrency()
            {
                Console.WriteLine();
                Console.WriteLine("Güncel Kur Listesi");
                Console.WriteLine();
                var values = db.CurrencyValue.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine("Döviz" + " " + item.Currency.CurrencyName + item.CurrencyBuying + " Alış Fiyatı : " + " Satış Fiyat : " + item.CurrencyBuying);
                }
            }

            void GetCurrencyClasses()
            {

                getCurrency.SaveCurrencyDollar();
                getCurrency.SaveCurrencyEuro();
                getCurrency.SaveCurrencyPound();
            }

            Console.WriteLine();
            Console.WriteLine("Döviz İşlemleri Ekranı");
            Console.WriteLine();
            Console.WriteLine("Mevcut Kullanıcı : Admin " + "     Tarih : " + DateTime.Now.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine("Yapmak İstediğiniz İşlemi Seçiniz");
            Console.WriteLine();
            Console.WriteLine("1 - Döviz Listesi");
            Console.WriteLine("2 - Güncel Kurlar");
            Console.WriteLine("3 - Satış Yap");
            Console.WriteLine("4 - Yapılan Müşteri Satış Hareketleri");
            Console.WriteLine("5 - Müşterilerden Alınan Dövizler Listesi");
            Console.WriteLine("6 - Kurları Veri Tabanına Kaydet");
            Console.WriteLine("7 - Yardım");
            Console.WriteLine("8 - Çıkış Yap");
            Console.WriteLine();
            Console.Write("İşlem Numarası Giriniz : ");

            string choose;
            choose = Console.ReadLine();

            if (choose == "1" || choose == "01")
            {
                CurrencyList();
            }
            if (choose == "2" || choose == "02")
            {
                CurrentCurrency();
            }
            if (choose == "3" || choose == "03")
            {
                Console.WriteLine();
                Console.Write("Müşteri Adı: ");
                string customerName = Console.ReadLine();
                Console.Write("Müşteri SoyAdı: ");
                string customerSurname = Console.ReadLine();
                Console.Write("Döviz Kodu : ");
                int currencyCode = int.Parse(Console.ReadLine());
                Console.Write("İşlem Türü : ");
                string operarionType = Console.ReadLine();
                Console.Write("Güncel Kur Değeri : ");
                decimal currentValue = decimal.Parse(Console.ReadLine());
                Console.Write("Alınacak Tutar : ");
                decimal amout = decimal.Parse(Console.ReadLine());
                Console.Write("Toplam Ücret : ");
                decimal totalAmount = decimal.Parse(Console.ReadLine());
                sale.MakeSale(customerName, customerSurname, currencyCode, operarionType, currentValue, amout, totalAmount);
            }

            if (choose == "4" || choose == "04")
            {
                SaleOperation saleOperation = new SaleOperation();
                saleOperation.CustomerSaleOperation();
                Console.WriteLine("Dövizler Başarılı Bir Şekilde Veri Tabanına Yazıldı.");
            }

            if (choose == "6" || choose == "06")
            {
                GetCurrencyClasses();
                Console.WriteLine("Dövizler Başarılı Bir Şekilde Veri Tabanına Yazıldı.");
            }

          

            Console.ReadLine();
        }
    }
}
