using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dapper");
            DapperEkle();
        }

        static void DapperSettings()
        {
            int toplam = 0;
            string connStr = ""; // Connection String
            using (var connection = new SqlConnection(connStr))
            {
                Stopwatch sw = new Stopwatch();
                connection.Open();
                for (int i = 0; i < 10; i++)
                {
                    sw.Reset();
                    sw.Start();
                    //var whereKullanıcılar = connection.Query<Kullanıcılar>("Select * From Kullanıcılar").Where(x => x.Name == "Deneme");
                    var kullanıcılar = connection.Query<Kullanıcılar>("Select * FROM Kullanıcılar").ToList();
                    foreach (var item in kullanıcılar)
                    {
                        //Console.WriteLine(item.Name);
                    }
                    sw.Stop();
                    Console.WriteLine(i + ": Geçen Süre: " + sw.ElapsedMilliseconds);
                    toplam += (int)sw.ElapsedMilliseconds;
                }
                Console.WriteLine("Ortalama: " + (toplam / 10));
                Console.Read();
            }
        }

        static void DapperEkle()
        {
            Stopwatch sw = new Stopwatch();
            string connStr = ""; // Connection String
            using (var connection = new SqlConnection(connStr))
            {
                connection.Open();
                
                for (int i = 0; i < 3; i++)
                {
                    sw.Reset();
                    sw.Start();
                    for (int x = 0; x < 1000; x++)
                    {
                        Kullanıcılar kullanıcı = new Kullanıcılar();
                        kullanıcı.Name = "Deneme";
                        kullanıcı.Surname = "Deneme";
                        string sql = "INSERT INTO Kullanıcılar(Name,Surname) VALUES(@Name,@Surname)";
                        connection.Execute(sql, kullanıcı);
                    }
                    sw.Stop();
                    Console.WriteLine(i + ": Geçen Süre: " + sw.ElapsedMilliseconds);
                }
                
                Console.Read();
            }
        }
    }
}
