# 🍃 MongoDB Training

MongoDB ve C# .NET kullanarak NoSQL veritabanı yönetimini öğrenmek için hazırlanmış kapsamlı bir eğitim projesi.

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [CRUD İşlemleri](#-crud-i̇şlemleri)
- [Proje Yapısı](#-proje-yapısı)
- [Örnek Kod Parçacıkları](#-örnek-kod-parçacıkları)
- [Öğrenilenler](#-öğrenilenler)
- [Kaynaklar](#-kaynaklar)
- [Lisans](#-lisans)

## 🎯 Proje Hakkında

Bu proje, MongoDB NoSQL veritabanı ile C# .NET platformu arasında entegrasyon kurmayı ve temel veritabanı işlemlerini gerçekleştirmeyi öğretmek amacıyla geliştirilmiştir. Proje, modern web uygulamalarında sıkça kullanılan MongoDB'nin .NET ekosistemi içindeki kullanımını pratik örneklerle açıklamaktadır.

### Kimler İçin?

- MongoDB'ye yeni başlayan geliştiriciler
- C# ile NoSQL deneyimi kazanmak isteyenler
- Backend geliştirme becerilerini geliştirmek isteyenler
- CRUD operasyonlarını MongoDB üzerinde uygulamak isteyenler

## ✨ Özellikler

- ✅ MongoDB bağlantı yönetimi
- ✅ Koleksiyon oluşturma ve yönetme
- ✅ Temel CRUD (Create, Read, Update, Delete) işlemleri
- ✅ Veri filtreleme ve sorgulama
- ✅ MongoDB .NET Driver kullanımı
- ✅ Best practices ve örnek kod yapısı

## 🛠 Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|-----------|----------|
| **C# (.NET)** | Backend programlama dili ve framework |
| **MongoDB** | NoSQL veritabanı sistemi |
| **MongoDB .NET Driver** | MongoDB için resmi .NET sürücüsü |
| **Visual Studio** | Geliştirme ortamı |

## 📦 Kurulum

### Gereksinimler

- .NET 6.0 veya üzeri
- MongoDB Community Edition veya MongoDB Atlas hesabı
- Visual Studio 2022 veya VS Code

### Adım Adım Kurulum

1. **MongoDB Kurulumu**
   
   MongoDB'yi yerel makinenize kurun veya MongoDB Atlas'ta ücretsiz bir cluster oluşturun.
   
   ```bash
   # Windows için MongoDB indirme:
   # https://www.mongodb.com/try/download/community
   
   # MongoDB servisini başlatma:
   net start MongoDB
   ```

2. **Projeyi Klonlama**
   
   ```bash
   git clone https://github.com/emirhan-coban/MongoDB_Training.git
   cd MongoDB_Training
   ```

3. **NuGet Paketlerini Yükleme**
   
   ```bash
   dotnet restore
   ```

4. **Bağlantı Ayarları**
   
   `appsettings.json` veya ilgili yapılandırma dosyasında MongoDB bağlantı stringini güncelleyin:
   
   ```json
   {
     "MongoDbSettings": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "TrainingDB"
     }
   }
   ```

5. **Projeyi Çalıştırma**
   
   ```bash
   dotnet run
   ```

## 🚀 Kullanım

### Temel Bağlantı Kurulumu

```csharp
using MongoDB.Driver;

var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("TrainingDB");
var collection = database.GetCollection<BsonDocument>("Customers");
```

### Koleksiyon ile Çalışma

```csharp
// Koleksiyon referansı alma
var customersCollection = database.GetCollection<Customer>("Customers");

// Koleksiyonun var olup olmadığını kontrol etme
var collectionExists = database.ListCollectionNames()
    .ToList()
    .Contains("Customers");
```

## 📝 CRUD İşlemleri

### Create (Veri Ekleme)

```csharp
// Tekil veri ekleme
var customer = new Customer
{
    Name = "Ahmet Yılmaz",
    Email = "ahmet@example.com",
    City = "İstanbul"
};
await collection.InsertOneAsync(customer);

// Çoklu veri ekleme
var customers = new List<Customer>
{
    new Customer { Name = "Ayşe Kaya", Email = "ayse@example.com" },
    new Customer { Name = "Mehmet Demir", Email = "mehmet@example.com" }
};
await collection.InsertManyAsync(customers);
```

### Read (Veri Okuma)

```csharp
// Tüm verileri getirme
var allCustomers = await collection.Find(_ => true).ToListAsync();

// Filtreleme ile veri getirme
var filter = Builders<Customer>.Filter.Eq(c => c.City, "İstanbul");
var istanbulCustomers = await collection.Find(filter).ToListAsync();

// ID ile tek veri getirme
var customer = await collection.Find(c => c.Id == customerId).FirstOrDefaultAsync();

// Sıralama ve limit
var topCustomers = await collection
    .Find(_ => true)
    .Sort(Builders<Customer>.Sort.Descending(c => c.CreatedDate))
    .Limit(10)
    .ToListAsync();
```

### Update (Veri Güncelleme)

```csharp
// Tek alan güncelleme
var filter = Builders<Customer>.Filter.Eq(c => c.Id, customerId);
var update = Builders<Customer>.Update.Set(c => c.Email, "yeni@email.com");
await collection.UpdateOneAsync(filter, update);

// Tüm dokümanı değiştirme
var updatedCustomer = new Customer
{
    Id = customerId,
    Name = "Güncellenmiş İsim",
    Email = "guncellenmis@email.com"
};
await collection.ReplaceOneAsync(c => c.Id == customerId, updatedCustomer);

// Çoklu güncelleme
var updateMany = Builders<Customer>.Update.Set(c => c.City, "Ankara");
await collection.UpdateManyAsync(c => c.City == "İstanbul", updateMany);
```

### Delete (Veri Silme)

```csharp
// Tek veri silme
await collection.DeleteOneAsync(c => c.Id == customerId);

// Filtreye göre silme
var deleteFilter = Builders<Customer>.Filter.Eq(c => c.City, "İstanbul");
await collection.DeleteManyAsync(deleteFilter);

// Koleksiyon tamamen silme
await database.DropCollectionAsync("Customers");
```

## 📁 Proje Yapısı

```
MongoDB_Training/
│
├── CSharpEgitimKampi601/
│   ├── Entities/
│   │   └── Customer.cs              # Veri modelleri
│   │
│   ├── Services/
│   │   ├── MongoDbConnection.cs     # Veritabanı bağlantı yönetimi
│   │   └── CustomerService.cs       # CRUD işlemleri
│   │
│   ├── Program.cs                   # Ana program dosyası
│   └── appsettings.json             # Yapılandırma ayarları
│
├── .gitignore
├── .gitattributes
├── CSharpEgitimKampi601.slnx        # Solution dosyası
└── README.md
```

## 💻 Örnek Kod Parçacıkları

### Customer Model Örneği

```csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Customer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("email")]
    public string Email { get; set; }
    
    [BsonElement("city")]
    public string City { get; set; }
    
    [BsonElement("createdDate")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
```

### MongoDB Connection Service

```csharp
public class MongoDbConnection
{
    private readonly IMongoDatabase _database;
    
    public MongoDbConnection()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        _database = client.GetDatabase("TrainingDB");
    }
    
    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
```

### Customer Service Örneği

```csharp
public class CustomerService
{
    private readonly IMongoCollection<Customer> _customers;
    
    public CustomerService(MongoDbConnection connection)
    {
        _customers = connection.GetCollection<Customer>("Customers");
    }
    
    public async Task<List<Customer>> GetAllAsync()
    {
        return await _customers.Find(_ => true).ToListAsync();
    }
    
    public async Task<Customer> GetByIdAsync(string id)
    {
        return await _customers.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task CreateAsync(Customer customer)
    {
        await _customers.InsertOneAsync(customer);
    }
    
    public async Task UpdateAsync(string id, Customer customer)
    {
        await _customers.ReplaceOneAsync(c => c.Id == id, customer);
    }
    
    public async Task DeleteAsync(string id)
    {
        await _customers.DeleteOneAsync(c => c.Id == id);
    }
}
```

## 📚 Öğrenilenler

Bu proje ile aşağıdaki konularda deneyim kazanılmıştır:

- MongoDB ile .NET uygulaması entegrasyonu
- NoSQL veritabanı tasarım prensipleri
- MongoDB BSON veri modelleme
- Asenkron veritabanı işlemleri
- Repository pattern implementasyonu
- Filtreleme ve sorgulama teknikleri
- Connection string yönetimi
- Best practices ve kod organizasyonu

## 🔗 Kaynaklar

- [MongoDB Resmi Dokümantasyonu](https://www.mongodb.com/docs/)
- [MongoDB .NET Driver Dokümantasyonu](https://mongodb.github.io/mongo-csharp-driver/)
- [MongoDB Atlas (Ücretsiz Cloud DB)](https://www.mongodb.com/atlas)
- [MongoDB University (Ücretsiz Eğitimler)](https://university.mongodb.com/)
- [C# MongoDB Tutorial](https://www.mongodb.com/languages/c-sharp)

## 📄 Lisans

Bu proje eğitim amaçlı olarak hazırlanmıştır ve açık kaynak kodludur. Herkes tarafından kullanılabilir ve geliştirilebilir.

---

## 👤 Geliştirici

**Emirhan ÇOBAN**
- GitHub: [@emirhan-coban](https://github.com/emirhan-coban)

---

## 🤝 Katkıda Bulunma

Katkılarınızı memnuniyetle karşılıyoruz! Lütfen pull request göndermeden önce bir issue açarak önerinizi paylaşın.

1. Projeyi fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'feat: Add amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

---

⭐ Bu projeyi faydalı bulduysanız yıldız vermeyi unutmayın!

**Happy Coding!** 🚀
