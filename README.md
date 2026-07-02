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

## 🚀 Local Setup (5 minutes)

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run locally

```bash
# 1. Clone / place the project folder, then:
cd AddictioonSnookerClub

# 2. Restore packages
dotnet restore

# 3. Run dev server  (hot reload included)
dotnet watch run

# 4. Open browser at:
#    http://localhost:5000
```

### Build for production

```bash
dotnet publish -c Release -o ./publish
```

The `./publish/wwwroot` folder is what you upload to Hostinger.

---

## 🌐 Deploy to Hostinger (addictionsnookerclub.in)

### Step 1 — Build
```bash
dotnet publish -c Release -o ./publish
```
Your deployable files are in: `./publish/wwwroot/`

### Step 2 — Log in to Hostinger hPanel
Go to [hpanel.hostinger.com](https://hpanel.hostinger.com) → **Manage** your hosting plan.

### Step 3 — Check DNS
**Domains → addictionsnookerclub.in → DNS Zone**

Ensure an A record points to your Hostinger IP:
```
Type  Name  Value
A     @     31.220.x.x   (your Hostinger server IP, shown on hPanel home)
```

### Step 4 — Upload files
1. Go to **Files → File Manager → public_html**
2. Delete the Hostinger placeholder `index.html`
3. Upload **all contents** of `./publish/wwwroot/` into `public_html/`

Your `public_html/` should look like:
```
public_html/
├── index.html          ← must be here at root
├── .htaccess           ← critical for SPA routing
├── service-worker.js
├── css/
│   └── app.css
└── _framework/         ← Blazor WASM runtime (auto-generated on publish)
    ├── blazor.webassembly.js
    ├── dotnet.wasm
    └── ...
```

### Step 5 — Enable SSL
**Security → SSL → addictionsnookerclub.in → Install** (free Let's Encrypt).
Wait 10–15 minutes. HTTPS is forced automatically via `.htaccess`.

### Step 6 — Test
Visit `https://addictionsnookerclub.in` and verify:
- ✅ Home page loads with animated hero
- ✅ Navigation works (About, Pricing, Book, etc.)
- ✅ Refreshing `/book` or `/dashboard` doesn't 404
- ✅ Admin login: use email containing `admin` (e.g. `admin@test.com`)
- ✅ Member login: any other email
- ✅ HTTPS padlock shown

---

## 👤 Demo Credentials

| Role   | Email pattern        | Access                    |
|--------|---------------------|---------------------------|
| Admin  | `admin@anything.com` | Full admin dashboard      |
| Staff  | `staff@anything.com` | Staff-level access        |
| Member | any other email      | Member dashboard          |

---

## 🔄 Future Upgrades (production)

| Feature               | How to add                                        |
|----------------------|--------------------------------------------------|
| Real authentication  | Add **ASP.NET Core Identity** or **Auth0**       |
| Database             | Replace mock services with **Entity Framework** + SQL (Hostinger MySQL or Azure SQL) |
| Email notifications  | **SendGrid** or **Mailgun** via API              |
| Payments             | **Razorpay** JS SDK called via `IJSRuntime`      |
| Real-time updates    | **SignalR** (requires upgrading to Hostinger VPS or Azure) |
| Image uploads        | **Cloudinary** API or Azure Blob Storage         |

---

## 📄 License
MIT — free to use, modify, and deploy.

Built for **Addictioon Snooker Club**, Mumbai 🎱
