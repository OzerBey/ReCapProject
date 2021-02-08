# ReCapProject
With Layered Structure
 Sistemim üç katman oluşuyor:
1. Entities
2. Data Access
3. Business
Her katmanda ise soyut işlemleri tanımlamak için Abstract, somut işlemleri tanımlamak için Concrete klasörü bulunmakta.

*Entities
Bu katmanın soyut kısmında tüm varlıkların referansını tutabilecek bir IEntity interface' i; somut kısmında ise oluşturulacak Car (araba varlıgı için ) entity class'ları bulunmakta.

*Data Access
Bu katmanda ileride belli koşullara göre kullanılacak/değiştirişlecek database yöntem çeşitlerine yer verilen kısımdır.
*Business
Bu katman Abstract soyut kısım, Concrete somut kısım olmak üzere iki kısımndan oluşmaktadır.

Soyut kısımdaki ICarService interface' i, somut kısımda bulunan CarManager.cs  referanslarını tutmak ve eş görevleri paylaştırmak üzere üretilmiştir.

CarManager.cs' de bulunan getAll() metodunda tüm bilgileri çağırma yapılmıştır.
Son olarakta ConsoleUI da sistem simülasyonu yapılmıştır.
