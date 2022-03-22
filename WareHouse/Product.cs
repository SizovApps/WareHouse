using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse
{
    public class Product
    {
        //Имя, комания, страна, унк, идентификатор, гарантия, спец. предложение, статус, ед.измерения, ссылка.
        public string name, company, country, unk, code, guarantee, extra, status, unit, reff;
        //Количетсво.
        public int quantity;
        //Цена.
        public double price;

        /// <summary>
        /// Инициализация.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="company"></param>
        /// <param name="country"></param>
        /// <param name="unk"></param>
        /// <param name="code"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="guarantee"></param>
        /// <param name="extra"></param>
        /// <param name="status"></param>
        /// <param name="unit"></param>
        /// <param name="reff"></param>
        public Product(string name, string company, string country, string unk, string code, double price, int quantity, string guarantee, string extra, string status, string unit, string reff )
        {
            this.name = name;
            this.company = company;
            this.country = country;
            this.code = code;
            this.unk = unk;
            this.code = code;
            this.price = price;
            this.quantity = quantity;
            this.guarantee = guarantee;
            this.extra = extra;
            this.status = status;
            this.unit = unit;
            this.reff = reff;
        }

        public override string ToString()
        {
            return $"{{{name}, {company}, {country}, {code}, {unk}, {code}, {price}, {quantity}, {guarantee}, {extra}, {status}, {unit}, {reff}}}";
        }
    }
}
