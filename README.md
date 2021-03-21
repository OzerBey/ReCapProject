# ReCapProject 

![rentacar](https://user-images.githubusercontent.com/49093196/108184338-20e78980-711c-11eb-83f6-32aefea7f707.jpg)

 ``'Rent A Car'``
 
'Katmanlı' 'OOP'
 Sistemim dört katman oluşuyor:
 
**1. Entities**

**2. Data Access**

**3. Business**

**4. Core**

Her katmanda ise soyut işlemleri tanımlamak için Abstract, somut işlemleri tanımlamak için Concrete klasörü bulunmakta.

``Entities``

Bu katmanın soyut kısmında tüm varlıkların referansını tutabilecek bir IEntity interface' i; somut kısmında ise oluşturulacak Car (araba varlıgı için ) entity class'ları bulunmakta. Veritabanı tablolarına denk gelen entitylerin API, Console veya UI projeleri için kullanılan request/response modellerinin ve DTO(Data transfer object) larının bulunduğu katmandır

``Data Access``

Bu katmanda ileride belli koşullara göre kullanılacak/değiştirişlecek database yöntem çeşitlerine yer verilen kısımdır. Veri erişim katmanıdır. Veritabanı işlemlerinin (CRUD Operations) gerçekleştirildiği katmandır.

``Business``

Bu katman Abstract soyut kısım, Concrete somut kısım olmak üzere iki kısımndan oluşmaktadır. İş kodlarımızı bu katmanda yazıyoruz. DataAccess in veritabanından aldığı verileri işleyip kontrolden geçiren katmandır.

Soyut kısımdaki ICarService interface' i, somut kısımda bulunan CarManager.cs  referanslarını tutmak ve eş görevleri paylaştırmak üzere üretilmiştir.

CarManager.cs' de bulunan getAll() metodunda tüm bilgileri çağırma yapılmıştır.
Son olarakta ConsoleUI da sistem simülasyonu yapılmıştır.

``Core``

Bu katmanda genel olarak ilgili proje veya farklı yapılarla ortak kullanlan bölümdür.
Evrensel kodlarimizi (tüm projelerde kullanilacak kodlarimizi) yazdigimiz kisimdir Core katmani;
	burada hangi katman ile ilgilenceksek onunla ilgili bir klasor ekliyoruz..
	//core katmanina bir kere kod yazariz bütün projelerde kullanabilriiz
	
	``! Core : Evrensel katmanimizdir ve Core katmanı diger katmanları referans almaz !``
 ``Content Of This Project``
 
**Generic Repository Design**

**Generic Constraint**

**LINQ**

**Entity Framework**

**Core Layer**

**Web API**

**Autofac**

**FluentValidation**

**AOP Support**

**Validation**
