kullanılan teknolojiler:
.net core 5.0
ef core code first (entity ve data access katmanları ile)
mssql server(local host-windows authentication)
swagger ve postman çağrılarına uygun web api ile rest servisler
önyüzde asp.net core mvc projesi
---------
1.projeyi ayağa kaldırmak için data access katmanının EcommerceContext classında connection string verilecek.
2.data access katmanında packet manager consoleda add-migration komutu ile migration oluşturulacak ardından update-database yapılacak
3.db kurulduktan sonra solution sağ click set as startup projectten api ve ui projesi birlikte start olacak şekilde ayarlanacak
4.proje derlenip start verilince ayağa kalkacaktır.
5.UI sayfası açıldığında login olmadan ürün listesi görüntülenmemektedir.
6.Kayıt olduktan sonra kullanıcı rolüne göre satıcı ürün ekleyebilir, müşteri ise ürünleri görüp sipariş oluşturabilir.
7.Oluşturulan sipariş databasede order tablosuna kaydolur.

