using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ADO.Net");
            ADOEkle();
        }

        static void ADOSettings()
        {
            int toplam = 0;
            string connStr = ""; // Connection String
            using (SqlConnection baglanti = new SqlConnection(connStr))
            {
                Stopwatch sw = new Stopwatch();
                sw.Reset();
                sw.Start();
                baglanti.Open();
                for (int i = 0; i < 10; i++)
                {
                    string sql = "SELECT * FROM Kullanıcılar"; // SELECT işlemi
                    //string whereSql = "SELECT * FROM Kullanıcılar WHERE Name = 'Deneme'";
                    SqlCommand comm = new SqlCommand(sql, baglanti);
                    SqlDataReader rd = comm.ExecuteReader();
                    while (rd.Read())
                    {
                        //
                    }
                    rd.Close();
                    sw.Stop();
                    Console.WriteLine(i + ": Geçen Süre: " + sw.ElapsedMilliseconds);
                    toplam += (int)sw.ElapsedMilliseconds;
                }
                Console.WriteLine("Ortalama: " + (toplam / 10));
                
            }
            Console.Read();
        }

        static void ADOEkle()
        {
            string connStr = ""; // Connection String
            using (SqlConnection baglanti = new SqlConnection(connStr))
            {
                Stopwatch sw = new Stopwatch();
                baglanti.Open();
                
                for (int i = 0; i < 3; i++)
                {
                    sw.Reset();
                    sw.Start();
                    for (int y = 0; y < 1000; y++)
                    {
                        string sql = "INSERT INTO Kullanıcılar(Name,Surname) VALUES('Deneme','Deneme')";
                        SqlCommand komut = new SqlCommand(sql, baglanti);
                        komut.ExecuteNonQuery();
                    }
                    sw.Stop();
                    Console.WriteLine(i + ":Geçen Süre: " + sw.ElapsedMilliseconds);
                }
                
                Console.Read();
            }
        }
    }
}
