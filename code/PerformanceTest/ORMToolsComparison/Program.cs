using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
using System.Diagnostics;

namespace ORMToolsComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NHibernate");
            NHibernateEkle();
        }

        static void NHibernateSettings()
        {
            int toplam = 0;
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = ""; // Connection String
                x.Dialect<MsSql2012Dialect>();
                x.Driver<SqlClientDriver>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var ses = cfg.BuildSessionFactory();

            Stopwatch sw = new Stopwatch();
            using (var session = ses.OpenSession())
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.Reset();
                    sw.Start();
                    session.Transaction.Begin();
                    //var whereKullanıcılar = session.Query<Kullanıcılar>().Where(x => x.Name == "Deneme");
                    var kullanıcılar = session.Query<Kullanıcılar>().ToList<Kullanıcılar>();
                    foreach (var item in kullanıcılar)
                    {
                        //Console.WriteLine(item.Name);
                    }
                    sw.Stop();
                    Console.WriteLine(i + ": Geçen Süre: " + sw.ElapsedMilliseconds);
                    toplam += (int)sw.ElapsedMilliseconds;
                }
                Console.WriteLine("Ortalama: " + (toplam / 10));
            }
            Console.ReadLine();
        }

        static void NHibernateEkle()
        {
            int id = 1000000;
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = ""; // Connection String
                x.Dialect<MsSql2012Dialect>();
                x.Driver<SqlClientDriver>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var ses = cfg.BuildSessionFactory();

            Stopwatch sw = new Stopwatch();
            using (var session = ses.OpenSession())
            {
                for (int i = 0; i < 10000; i++)
                {
                    session.Transaction.Begin();
                    Kullanıcılar kullanıcı = new Kullanıcılar();
                    //kullanıcı.Id = id+1;
                    kullanıcı.Name = "Deneme";
                    kullanıcı.Surname = "Deneme";
                    session.Save(kullanıcı);
                    session.Transaction.Commit();
                }
                sw.Stop();
                Console.WriteLine("10.000 Ekleme Sonucunda Geçen Süre: " + sw.ElapsedMilliseconds);
                Console.Read();
            }
        }
    }
}
