using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse
{
    class DataStorage
    {
        //Список классификаторов с товарами
        public static List<(string, List<Product>)> nodes;
        //Список идентификаторов товара
        public static List<string> codes;

        //Промежуток между автоматическими сохранениями
        public static int autoSaveTime;
        //Максимальное количество товара для сохранения в Excel
        public static int autoSaveQuantity;

        /// <summary>
        /// Инициализация стартовыми значениями.
        /// </summary>
        public DataStorage()
        {
            nodes = new List<(string, List<Product>)>();
            codes = new List<string>();
            nodes.Add(("Все товары", new List<Product>()));
            autoSaveTime = 10;
            autoSaveQuantity = 10;
        }

        /// <summary>
        /// Ищем повторения идентификаторов.
        /// </summary>
        /// <param name="code">идентификатор</param>
        /// <param name="oldCode">старый код товара</param>
        /// <returns>есть совпадения или нет</returns>
        public static bool FindTheSameCode(string code, string oldCode)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                //Проверка на то, что код совпадает и не является старым этого же товара.
                if (codes[i] == code && codes[i] != oldCode)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Получаем товар по его коду.
        /// </summary>
        /// <param name="code">код товара</param>
        /// <param name="nameOfClass">имя классификатора</param>
        /// <returns>товар</returns>
        public static Product GiveMeProduct(string code, string nameOfClass)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Item1 == nameOfClass)
                {
                    products = nodes[i].Item2;
                }
            }
            Product product = products[0];
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].code == code)
                {
                    return products[i];
                }
            }
            return product;
        }

        /// <summary>
        /// Удаляем продукт.
        /// </summary>
        /// <param name="code">код товара</param>
        /// <param name="nameOfClass">имя классификатора</param>
        public static void DeleteProduct(string code, string nameOfClass)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Item1 == nameOfClass)
                {
                    products = nodes[i].Item2;
                }
            }

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].code == code)
                {
                    products.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i] == code)
                {
                    codes.RemoveAt(i);
                }
            }
            
        }

        /// <summary>
        /// Заполняем список товаров из файла.
        /// </summary>
        /// <param name="lines">строки из файла</param>
        public static void FillFromSavedFile(string[] lines)
        {
            DataStorage.nodes = new List<(string, List<Product>)>();
            DataStorage.codes = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] curLines = line.Split(';');
                string className = curLines[0];
                List<Product> products = new List<Product>();
                string[] productsLines = curLines[1].Split('}');
                for (int j = 0; j < productsLines.Length-1; j++)
                {
                    string curProductLine = "";
                    if (j == 0)
                    {
                        curProductLine = productsLines[j].Substring(3);                       
                    }
                    else
                    {
                        curProductLine = productsLines[j].Substring(1);
                    }
                    //Создаем новый товар из параметров.
                    string[] paramsOfProduct = curProductLine.Split(',');
                    products.Add(new Product(paramsOfProduct[0], paramsOfProduct[1], paramsOfProduct[2], paramsOfProduct[3],
                        paramsOfProduct[4], double.Parse(paramsOfProduct[5]), int.Parse(paramsOfProduct[6]), paramsOfProduct[7],
                        paramsOfProduct[8], paramsOfProduct[9], paramsOfProduct[10], paramsOfProduct[11]));
                    codes.Add(paramsOfProduct[5]);
                }
                //Добавляем товары в список классификаторов.
                DataStorage.nodes.Add((className, products));
            }
        }

        /// <summary>
        /// Получаем список товаров, которые надо добавить в таблицу.
        /// </summary>
        /// <returns>Список товаров и их классификаторы</returns>
        public static List<(Product, string)> GiveMeProductsToExcel()
        {
            List<(Product, string)> products = new List<(Product, string)>();
            Form1 form = Application.OpenForms.OfType<Form1>().Single();
            for (int i = 0; i < DataStorage.nodes.Count; i++)
            {
                for (int j = 0; j < DataStorage.nodes[i].Item2.Count; j++)
                {
                    //Проверка на то, что количетсво товара не больше нормы для сохранения в таблицу.
                    if (DataStorage.nodes[i].Item2[j].quantity <= DataStorage.autoSaveQuantity)
                    {
                        string fullPath = form.GiveMeFullPathClassifier(DataStorage.nodes[i].Item1);
                        products.Add((DataStorage.nodes[i].Item2[j], fullPath));
                    }
                }
            }

            return products;

        }



    }
}
