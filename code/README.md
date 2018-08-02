Code
-----------------------------------------
İçerisinde ORM örnekleri ve performans testleri yapılması için hazır kodlar bulunan klasördür.

NHibernateDeneme
-----------------------------------------
"NHibernate" ve "Dapper ORM" araçlarının örneklerini içerir. Veritabanı Yönetim Sistemi olarak "PostgreSQL" kullanılmıştır.Uygulamanın çalışması için "Connection String" ve "Tablo" gereklidir.

Tablo ve veri tabanı hakkındaki bilgiler aşağıda yer almaktadır.

- "kullanicilar" adındaki tablomda "id" ve "name" olmak üzere iki sütun yer almaktadır.

- "id" "integer NOT NULL PRIMARY KEY" olarak, "name" ise "varchar(25) NOT NULL" olarak tanımlanmıştır.

PerformanceTest
-----------------------------------------
İçerisinde ORM araçlarını performans bakımından test edebileceğiniz kodlar bulunmaktadır. Testlerin çalışması için uygun Veritabanı ve Tablo gerekmektedir.
