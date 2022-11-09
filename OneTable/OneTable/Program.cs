using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace OneTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Configuration();
            c.Configure();
            c.AddAssembly("OneTable");
            new SchemaExport(c).Execute(true, true, false);

            ISession session = c.BuildSessionFactory().OpenSession();

            var vasya = new Employee();
            vasya.Imya = "Sami ponimaete vasya";
            vasya.Age = 40;
            session.Save(vasya);
            session.Flush();

            var kolya = new Employee();
            kolya.Imya = "A eto Kolya";
            kolya.Age = 10;
            session.Save(kolya);
            session.Flush();

            IList<Employee> list = session.QueryOver<Employee>().Where(x => x.Age > 5).List<Employee>();
            foreach (Employee emp in list)
                Console.WriteLine(emp.ID + " " + emp.Imya);


            Console.ReadLine();
        }
    }
}
