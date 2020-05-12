using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana6_Lab
{
    class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();

        static void Main(string[] args)
        {
            Grouping_lambda();
            Console.Read();
        }
        static void IntoToLINQ()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach (int num in numQuery)
            {
                Console.Write("{0,1}", num);
            }
        }

        static void DataSource()
        {
            var queryAllCustomers = from cust in context.clientes
                                    select cust;

            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void DataSource_lambda()
        {
            var listar = context.clientes.ToList();
            foreach(var nom in listar)
            {
                Console.WriteLine(nom.NombreCompañia);
            }
        }

        static void Filtering()
        {
            var queryLondonCustomers = from cust in context.clientes
                                       where cust.Ciudad == "Londres"
                                       select cust;

            foreach (var item in queryLondonCustomers)
            {
                Console.Write(item.Ciudad);
            }
        }

        static void Ordering()
        {
            var queryLondonCustomers3 =
                from cust in context.clientes
                where cust.Ciudad == "London"
                orderby cust.NombreCompañia ascending
                select cust;

            foreach (var item in queryLondonCustomers3)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Grouping()
        {
            var queryCustomersByCity =
                from cust in context.clientes
                group cust by cust.Ciudad;

            foreach (var group in queryCustomersByCity)
            {
                Console.WriteLine(group.Key);
                foreach (clientes cus in group)
                {
                    Console.WriteLine("   {0}", cus.NombreCompañia);
                }
            }
        }

        static void Grouping_lambda()
        {
            var agrupar = context.clientes.GroupBy(x => x.Ciudad);

           foreach(var ciudad in agrupar)
            {
                Console.WriteLine(ciudad.Key);
                foreach(clientes cus in ciudad)
                {
                    Console.WriteLine("  {0}", cus.NombreCompañia);
                }
            }
        }

        static void Grouping2()
        {
            var custQuery =
                from cust in context.clientes
                group cust by cust.Ciudad into custGroup
                where custGroup.Count() > 2
                orderby custGroup.Key
                select custGroup;

            foreach (var item in custQuery)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Joining()
        {
            var innerJoinGuery =
                from cust in context.clientes
                join dist in context.Pedidos on cust.idCliente equals dist.IdCliente
                select new { CustomerName = cust.NombreCompañia, DistributorName = dist.PaisDestinatario };

            foreach (var item in innerJoinGuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }

        static void Joining_lambda()
        {
            
        }


    }
}
