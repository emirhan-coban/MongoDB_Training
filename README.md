````markdown
# MongoDB Training

Bu proje, MongoDB kullanarak C# (.NET) ile veritabanı bağlantısı kurmayı ve temel CRUD (Create, Read, Update, Delete) işlemlerini öğrenmek amacıyla hazırlanmış bir eğitim projesidir.

---

## Proje Amacı

- MongoDB ile bağlantı kurmayı öğrenmek  
- Koleksiyonlar üzerinde CRUD işlemleri yapmak  
- MongoDB .NET Driver kullanımını kavramak  
- Backend tarafında NoSQL mantığını anlamak  

---

## Kullanılan Teknolojiler

- C# (.NET)
- MongoDB
- MongoDB .NET Driver

---

## Kurulum

1. MongoDB kurulu ve çalışır durumda olmalıdır  
   - Local MongoDB veya MongoDB Atlas kullanılabilir
2. Repoyu klonlayın:
   ```bash
   git clone https://github.com/emirhan-coban/MongoDB_Training.git
````

3. Projeyi Visual Studio veya VS Code ile açın.
4. MongoDB bağlantı stringini kendi ortamınıza göre düzenleyin.
5. Projeyi çalıştırın.

---

## Proje Yapısı

```
MongoDB_Training
├── MongoDB_Training.sln
├── README.md
├── Database
│   └── MongoDbContext.cs
├── Models
│   └── SampleModel.cs
├── Services
│   └── MongoService.cs
└── Program.cs
```

---

## MongoDB Bağlantısı

```csharp
var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("TrainingDB");
```

---

## CRUD İşlemleri

### Veri Ekleme (Create)

```csharp
collection.InsertOne(data);
```

### Veri Okuma (Read)

```csharp
var list = collection.Find(_ => true).ToList();
```

### Veri Güncelleme (Update)

```csharp
collection.ReplaceOne(filter, updatedData);
```

### Veri Silme (Delete)

```csharp
collection.DeleteOne(filter);
```

---

## Kaynaklar

* [https://www.mongodb.com/docs/](https://www.mongodb.com/docs/)
* [https://www.mongodb.com/atlas](https://www.mongodb.com/atlas)


## Lisans
Bu proje eğitim amaçlı olarak hazırlanmıştır.
