using System;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;

namespace database
{
    class Program
    {
        static void Main()
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Online_Shop.mdb"))
            {
                string selectString = @"SELECT Клиент.КОДКЛИЕНТА, Клиент.НАИМЕНОВАНИЕ, Клиент.АДРЕС, Клиент.КОНТАКТ FROM Клиент";
                OleDbCommand command = new OleDbCommand(selectString, connection);
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! Невозможно получить искомые данные! " + ex.Message);
                    return;
                }
                OleDbDataReader reader = command.ExecuteReader();
                Console.WriteLine("***Информация о клиентах и их заказах***\n\n");
                while (reader.Read())
                {
                    Console.WriteLine("Код: " + reader[0]);
                    Console.WriteLine("Наименование: " + reader[1]);
                    Console.WriteLine("Адрес: " + reader[2]);
                    Console.WriteLine("Контакт: " + reader[3]);
                    Console.Write("Заказы: ");
                    string query2 = @"SELECT Заказ.НомерЗаказа, Заказ.ДатаЗаказа, Заказ.ДатаПоставки FROM Заказ WHERE КодКлиента=" + reader[0].ToString();
                    OleDbCommand command2 = new OleDbCommand(query2, connection);
                    OleDbDataReader reader2 = command2.ExecuteReader();
                    int k = 0;
                    while (reader2.Read())
                    {
                        Console.WriteLine("\n\nНомер заказа: " + reader2[0]);
                        Console.WriteLine("Дата заказа: " + reader2[1]);
                        Console.WriteLine("Дата поставки: " + reader2[2]);
                        k++;
                    }
                    reader2.Close();
                    if (k == 0) Console.WriteLine("отсутствуют");
                    Console.WriteLine("________________________________________\n\n");
                }
                reader.Close();
            }
            Console.Write("Нажмите любую клавишу . . .");
            Console.ReadKey();
        }
    }
}