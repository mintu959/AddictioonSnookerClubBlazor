# 🎱 Addictioon Snooker Club — Blazor WebAssembly
Addictioon Snooker Club — Blazor WebAssembly (.NET 8)  A dark‑themed, fully responsive snooker club web app built with Blazor WebAssembly and pure CSS. Features include table booking, membership plans, tournaments, testimonials, and an admin dashboard.

Author: Mithilesh Pandey
---
## ✅ Tech Stack

| Layer        | Technology                          |
|-------------|--------------------------------------|
| Framework    | Blazor WebAssembly (.NET 8)         |
| Language     | C# + Razor                          |
| Styling      | Pure CSS (no framework dependency)  |
| State Mgmt   | Scoped C# Services (DI)             |
| Routing      | Built-in Blazor Router              |
| Hosting      | Hostinger Shared Hosting (Static)   |

---

## 📁 Project Structure

```
AddictioonSnookerClub/
├── AddictioonSnookerClub.csproj   ← .NET 8 Blazor WASM project
├── Program.cs                      ← App entry point + DI registration
├── App.razor                       ← Router root
├── _Imports.razor                  ← Global @using statements
│
├── Models/
│   └── Models.cs                   ← All data models (User, Booking, Table…)
│
├── Services/
│   ├── AppStateService.cs          ← Central state + mock data
│   └── Services.cs                 ← BookingService, MemberService, TournamentService
│
├── Layout/
│   └── MainLayout.razor            ← Navbar, Footer, Toast, Auth modal wrapper
│
├── Components/
│   ├── Footer.razor
│   ├── AuthModal.razor
│   ├── StatCard.razor
│   ├── SnookerTableCard.razor
│   ├── MembershipCard.razor
│   └── BarChart.razor              ← Pure SVG chart (no JS libs)
│
├── Pages/
│   ├── Index.razor                 ← Home (/)
│   ├── About.razor                 ← /about
│   ├── Pricing.razor               ← /pricing
│   ├── Gallery.razor               ← /gallery
│   ├── Tournaments.razor           ← /tournaments
│   ├── Book.razor                  ← /book  (3-step wizard)
│   ├── Contact.razor               ← /contact
│   ├── Dashboard.razor             ← /dashboard  (member area)
│   └── Admin.razor                 ← /admin  (admin panel)
│
└── wwwroot/
    ├── index.html                  ← Blazor host page
    ├── .htaccess                   ← Hostinger routing + HTTPS + MIME types
    ├── service-worker.js           ← PWA support
    ├── service-worker.published.js
    └── css/
        └── app.css                 ← Complete design system (~900 lines)
```

---

## 🚀 Local Setup 

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run locally

```bash
# 1. Clone / place the project folder, then:
cd AddictioonSnookerNew

# 2. Restore packages
dotnet restore

# 3. Run dev server  (hot reload included)
dotnet watch run

# 4. Open browser at:
#    http://localhost:5000
```

## 👤 Demo Credentials

| Role   | Email pattern        | Access                    |
|--------|----------------------|---------------------------|
| Admin  | `admin@anything.com` | Full admin dashboard      |
| Staff  | `staff@anything.com` | Staff-level access        |
| Member | any other email      | Member dashboard          |

---

## 🔄 Future Upgrades:

| Feature               | How to add                                        |
|----------------------|--------------------------------------------------|
| Real authentication  | Add **ASP.NET Core Identity** or **Auth0**       |
| Database             | Replace mock services with **Entity Framework** + SQL (MySQL or Azure SQL) |
| Email notifications  | **SendGrid** or **Mailgun** via API              |
| Payments             | **Razorpay** JS SDK called via `IJSRuntime`      |
| Real-time updates    | **SignalR** (requires upgrading to Hostinger VPS or Azure) |
| Image uploads        | **Cloudinary** API or Azure Blob Storage         |

---

## 📄 License
MIT — free to use, modify, and deploy.

Built for **Addictioon Snooker Club**, Nagpur 🎱
