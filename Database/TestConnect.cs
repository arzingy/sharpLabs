using System;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;

namespace Example_OLEDB
{
    class TestConnect
    {
        static void Main(string[] args)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                      "Data Source=online_shop.accdb";

            string strSelect = "SELECT НомерЗаказа, ДатаЗаказа FROM Заказ WHERE КодСостояния = 4";

            string strProduct = "SELECT Товар.НАИМЕНОВАНИЕ, Товар.МАРКА, Товар.ОПИСАНИЕ СоставЗаказа. FROM Заказ INNER JOIN " +
                "(СоставЗаказа  INNER JOIN Товар ON СоставЗаказа.КодТовара = Товар.КодТовара) ON Заказ.НомерЗаказа = СоставЗаказа.НомерЗаказа;";

            OleDbConnection connectAccess = null;

            OleDbCommand cmdSelect;
            OleDbCommand cmdProduct;
            // источник данных
            DataSet shopDataSet1 = new DataSet();
            DataSet shopDataSet2 = new DataSet();
            // адаптер данных для запроса на выборку
            OleDbDataAdapter adapterSel, adapterProd;

            // подключение к базе данных с использованием строки подключения
            try
            {
                connectAccess = new OleDbConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! Невозможно подключиться к базе данных!");
                return;
            }

            // формирование адаптера данных из результирующего набора строк запроса
            try
            {
                cmdSelect = new OleDbCommand(strSelect, connectAccess); // передача запроса к БД
                adapterSel = new OleDbDataAdapter(cmdSelect);           // адаптер данных для результирующего набора


                connectAccess.Open();
                Console.WriteLine("Подключение открыто...");
                adapterSel.Fill(shopDataSet1, "Поставщик"); // передача строк таблицы в набор данных


            }
            catch (Exception ex)
            {
                Console.WriteLine("ошибка! невозмпожно получить запрошенные данные\n", ex.Message);
                return;
            }
            finally
            {
                connectAccess.Close();
            }


            Console.WriteLine("Информация о всех поставщиках:", shopDataSet1.Tables[0].TableName);
            Browse(shopDataSet1);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                cmdProduct = new OleDbCommand(strProduct, connectAccess);
                adapterProd = new OleDbDataAdapter(cmdProduct);
                adapterProd.Fill(shopDataSet2, "Товар");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ошибка! невозмпожно получить запрошенные данные\n", ex.Message);
                return;
            }
            finally
            {
                connectAccess.Close();
            }
            Console.WriteLine("Информация о поставляемых каждым поставщиком товарах:", shopDataSet2.Tables[0].TableName);

            DataRowCollection dtr = shopDataSet1.Tables[0].Rows;

            foreach (DataRow dr in dtr)
            {
                int key = (int)dr[0];
                for (int i = 0; i < 2; i++)
                    Console.Write("{0}\t", dr[i]);
                Console.WriteLine();
                strProduct = "SELECT Товар.НАИМЕНОВАНИЕ, Товар.МАРКА, Товар.ОПИСАНИЕ FROM Товар" +
                    " WHERE(((Товар.КОД_ПОСТАВЩИКА) =" + key + ")); ";
                try
                {
                    cmdProduct = new OleDbCommand(strProduct, connectAccess);
                    adapterProd = new OleDbDataAdapter(cmdProduct);
                    shopDataSet2.Clear();
                    adapterProd.Fill(shopDataSet2, "Товар");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ошибка! невозмпожно получить запрошенные данные\n", ex.Message);
                    return;
                }
                finally
                {
                    connectAccess.Close();
                }

                Browse(shopDataSet2);
                Console.WriteLine();
            }

            connectAccess.Close();
            Console.WriteLine("Подключение закрыто...");
        }


        static void Browse(DataSet dt)
        {
            if (dt.Tables[0].Rows.Count == 0)
                Console.WriteLine("NO DATA");
            DataRowCollection dtr = dt.Tables[0].Rows;
            foreach (DataRow dr in dtr)
            {

                for (int i = 0; i < dt.Tables[0].Columns.Count; i++)
                    Console.Write("{0}\t", dr[i]);
                Console.WriteLine();
            }
        }

    }
}