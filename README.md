# MYAcademy Portfolio Project

Modern web teknolojileri kullanılarak geliştirilen, dinamik içerik yönetimi ve yönetim paneli özelliklerine sahip kişisel portföy web sitesi.

Proje, ziyaretçilerin kişisel bilgilerimi, teknik yetkinliklerimi, deneyimlerimi ve projelerimi inceleyebileceği; aynı zamanda iletişim formu aracılığıyla benimle bağlantı kurabileceği dinamik bir web platformu olarak tasarlanmıştır.

## 🚀 Proje Hakkında

MYAcademy Portfolio Project, ASP.NET Core MVC mimarisi kullanılarak geliştirilmiştir.

Projenin temel amacı, statik bir portföy web sitesini veritabanı destekli ve yönetilebilir bir yapıya dönüştürmektir.

Yönetim paneli sayesinde web sitesindeki içerikler merkezi olarak yönetilebilir ve ziyaretçilerden gelen mesajlar takip edilebilir.

## ✨ Özellikler

### 🌐 Ön Yüz (Frontend)

- Dinamik Hakkımda bölümü
- Kişisel bilgiler ve iletişim detayları
- Dinamik yetenek ve uzmanlık alanları
- Proje ve portföy içerikleri
- Deneyim ve eğitim bilgileri
- CV indirme özelliği
- İletişim formu
- Ziyaretçilerden gelen mesajların veritabanına kaydedilmesi
- Responsive ve modern kullanıcı arayüzü

### ⚙️ Admin Paneli

- Yönetim paneli üzerinden içerik yönetimi
- Hakkımda bilgilerinin düzenlenmesi
- İletişim bilgilerinin yönetilmesi
- Portföy içeriklerinin yönetilmesi
- Gelen mesajların listelenmesi
- Mesaj detaylarının görüntülenmesi
- Okundu / okunmadı mesaj takibi
- Mesaj silme işlemleri
- SweetAlert2 ile kullanıcı işlem bildirimleri

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Kullanım Alanı |
|---|---|
| C# | Backend geliştirme |
| ASP.NET Core MVC | Web uygulama mimarisi |
| Entity Framework Core | ORM ve veritabanı işlemleri |
| Microsoft SQL Server | Veritabanı yönetimi |
| LINQ | Veri sorgulama |
| HTML5 | Sayfa yapısı |
| CSS3 | Tasarım ve stillendirme |
| JavaScript | İstemci tarafı işlemler |
| Bootstrap 5 | Responsive arayüz |
| Bootstrap Icons | İkon yönetimi |
| SweetAlert2 | Etkileşimli bildirimler |

## 🏗️ Proje Mimarisi

Proje, ASP.NET Core MVC yaklaşımına uygun olarak aşağıdaki temel klasör yapısıyla geliştirilmiştir.

```text
MYAcademy_PortfolioProject
│
├── Areas
│   └── Admin
│       ├── Controllers
│       ├── Views
│       └── ...
│
├── Components
│   └── ViewComponents
│
├── Context
│   └── PortfolioContext.cs
│
├── Controllers
│
├── Entities
│
├── Migrations
│
├── Views
│   └── Shared
│       └── Components
│
├── wwwroot
│   ├── css
│   ├── js
│   ├── images
│   ├── files
│   └── lib
│
├── appsettings.json
└── Program.cs
```

## 📩 İletişim ve Mesaj Yönetimi

Ziyaretçiler web sitesindeki iletişim formunu kullanarak mesaj gönderebilir.

Gönderilen mesajlar Entity Framework Core aracılığıyla SQL Server veritabanına kaydedilir.

Admin panelinde bu mesajlar tarih sırasına göre listelenebilir, detayları görüntülenebilir, okundu olarak işaretlenebilir veya silinebilir.

## ⚙️ Kurulum

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz.

**1. Repoyu klonlayın**

```bash
git clone https://github.com/KULLANICI_ADI/MYAcademy_PortfolioProject.git
```

**2. Proje dizinine geçin**

```bash
cd MYAcademy_PortfolioProject
```

**3. Veritabanı bağlantısını yapılandırın**

Kendi SQL Server bağlantı bilgilerinizi yerel yapılandırma dosyanızda tanımlayın.

**4. Migration işlemlerini uygulayın**

```powershell
Update-Database
```

Gerekli migration dosyaları mevcut değilse öncelikle migration oluşturulmalıdır.

**5. Projeyi çalıştırın**

```bash
dotnet restore
dotnet build
dotnet run
```

## 🔐 Güvenlik ve Yapılandırma

Veritabanı bağlantı bilgileri, kullanıcı şifreleri ve özel yapılandırma değerleri GitHub deposunda paylaşılmamalıdır.

- Hassas bilgiler kaynak koduna doğrudan yazılmamalıdır.
- `appsettings.json` içerisindeki gizli bağlantı bilgileri paylaşılmamalıdır.
- Yerel geliştirme ortamında User Secrets kullanılabilir.
- Üretim ortamında ortam değişkenleri veya güvenli yapılandırma servisleri tercih edilmelidir.

## 🎯 Projenin Amacı

Bu proje kapsamında ASP.NET Core MVC, Entity Framework Core, SQL Server ve modern frontend teknolojileri kullanılarak dinamik, yönetilebilir ve sürdürülebilir bir web uygulaması geliştirme deneyimi kazanılması hedeflenmiştir.

Aynı zamanda backend geliştirme, veritabanı tasarımı, MVC mimarisi, CRUD işlemleri ve kullanıcı etkileşimleri gibi konularda uygulamalı çalışmalar gerçekleştirilmiştir.

---

**Developer:** Kerem Altıntaş

**Project:** MYAcademy Portfolio Project

**Category:** Personal Portfolio Website

**Technology:** ASP.NET Core MVC

⭐ Projeyi faydalı bulduysanız yıldız vermeyi unutmayın!
