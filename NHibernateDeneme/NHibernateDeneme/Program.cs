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
using Npgsql;
using Dapper;
using System.Data.SqlClient;

namespace NHibernateDeneme
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ""; // Connection String
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                DapperEkle(connection);
                var liste = connection.Query<kullanicilar>("Select * From kullanicilar").ToList();
                foreach (var item in liste)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.Read();
        }

        static void DapperEkle(NpgsqlConnection connection)
        {
            kullanicilar kullanici = new kullanicilar();
            kullanici.Id = 16;
            kullanici.Name = "DapperKullanıcı";
            string sql = "INSERT INTO kullanicilar(Id,Name) VALUES(@Id,@Name)";
            connection.Execute(sql,kullanici);
        }

        static void DapperSil(NpgsqlConnection connection)
        {
            kullanicilar kullanici = new kullanicilar();
            kullanici.Name = "DapperKullanıcı";
            string sql = "DELETE FROM kullanicilar WHERE Name = @Name";
            connection.Execute(sql,kullanici);
        }

        static void NHibernateBaglanti()
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = ""; // Connection String
                x.Driver<NpgsqlDriver>();
                x.Dialect<PostgreSQLDialect>();
            }); // Configuration, kullanılan veri tabanı yönetim sistemine göre ayarlandı.

            cfg.AddAssembly(Assembly.GetExecutingAssembly()); // O an çalışan gömülü kaynağı alıp configuration
            // dosyasına yükledi. (mapping dosyasına configuration dosyasına yükledi.)
            var sessionFact = cfg.BuildSessionFactory(); // ISession nesne oluşturmak için gereken komut.
            VeriEkle(sessionFact);
        }
        static void VeriEkle(ISessionFactory sessionFact)
        {
            using (var session = sessionFact.OpenSession()) // Veritabanı Bağlantısı Açıldı
            {
                session.Transaction.Begin(); // İşlem başlatıldı
                var user1 = new kullanicilar { Name = "NHibernateKullanıcı" };
                session.Save(user1); // Veri tabanına kaydedildi ancak henüz işlenmedi.
                session.Transaction.Commit(); // Değişiklikler veri tabanına işlendi.
            }
        }

        static void VeriOku(ISessionFactory sessionFact)
        {
            using (var session = sessionFact.OpenSession())
            {
                session.Transaction.Begin();
                var kullanicilarListesi = session.CreateCriteria<kullanicilar>().List<kullanicilar>();
                foreach (var item in kullanicilarListesi)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.Read();
        }

        static void VeriSil(ISessionFactory sessionFact)
        {
            string silinecek = "";
            using (var session = sessionFact.OpenSession())
            {
                session.Transaction.Begin();
                var kullanicilarListesi = session.CreateCriteria<kullanicilar>().List<kullanicilar>();
                
                foreach (var veri in kullanicilarListesi)
                {
                    if (veri.Name == silinecek) session.Delete(veri);
                    else Console.WriteLine(veri.Name);
                }

            }
        }
    }
}
