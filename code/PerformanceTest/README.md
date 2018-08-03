PerformanceTest
---------------

Bu dosyalar üzerinden ORM araçlarıyla ilgili performans testleri yapabilirsiniz.

ADONetComparison üzerinden ADO.Net'e performans testi,
DapperComparison üzerinden Dapper'a performans testi,
EFComparison üzerinden Entity Framework'e performans testi,
ORMToolsComparison üzerinden NHibernate'e performans testi uygulayabilirsiniz.

Kodların Çalışması İçin Gerekenler
----------------------------------

- Veritabanını bağlamak için "ConnectionString".

- Uygun bir veritabanı. (Sınıflarla uygun.)

NOT: Oluşturduğunuz veritabanında 'Id', 'Name', 'Surname' sütunları bulunmalıdır.


Örnek
------
Veritabanımız aşağıdaki görüldüğü şekildedir ve veritabanı üzerinde 161,443 kayıt vardır.

Veritabanı:

![ScreenShot](https://github.com/ataberkdag/Object-Relational-Mapping/blob/master/code/PerformanceTest/Screenshots/Database.png)

NHibernate 'SELECT' İşlemi Performans Testi Sonuçları:

![ScreenShot](https://github.com/ataberkdag/Object-Relational-Mapping/blob/master/code/PerformanceTest/Screenshots/NHibernate-Performance.png)

Entity Framework 'SELECT' İşlemi Performans Testi Sonuçları:

![ScreenShot](https://github.com/ataberkdag/Object-Relational-Mapping/blob/master/code/PerformanceTest/Screenshots/EF-Performance.png)

Dapper 'SELECT' İşlemi Performans Testi Sonuçları:

![ScreenShot](https://github.com/ataberkdag/Object-Relational-Mapping/blob/master/code/PerformanceTest/Screenshots/Dapper-Performance.png)

ADO.NET 'SELECT' İşlemi Performans Testi Sonuçları:

![ScreenShot](https://github.com/ataberkdag/Object-Relational-Mapping/blob/master/code/PerformanceTest/Screenshots/ADO-Performance.png)
