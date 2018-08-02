using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entity Framework");
            EFEkle();
        }

        static void EFSettings()
        {
            int toplam = 0;
            using (TestEntities connection = new TestEntities())
            {
                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < 10; i++)
                {
                    sw.Reset();
                    sw.Start();
                    var kullanıcılar = connection.Kullanıcılar.ToList();
                    //var whereKullanıcılar = connection.Kullanıcılar.Where(x => x.Name == "Deneme");
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

            Console.Read();
        }

        static void EFEkle()
        {
            using (TestEntities connection = new TestEntities())
            {
                Stopwatch sw = new Stopwatch();
                
                for (int i = 0; i < 3; i++)
                {
                    sw.Reset();
                    sw.Start();
                    for (int x = 0; x < 1000; x++)
                    {
                        Kullanıcılar kullanıcı = new Kullanıcılar();
                        kullanıcı.Name = "Deneme";
                        kullanıcı.Surname = "Deneme";
                        connection.Kullanıcılar.Add(kullanıcı);
                        connection.SaveChanges();
                    }
                    sw.Stop();
                    Console.WriteLine(i + ": Geçen Süre: " + sw.ElapsedMilliseconds);
                }
                
                Console.Read();
            }
        }
    }
}
