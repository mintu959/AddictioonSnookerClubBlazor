using AddictioonSnookerClub.Models;

namespace AddictioonSnookerClub.Services;

/// <summary>
/// Central application state service — replaces React useState/context.
/// Components subscribe to OnChange to re-render when state updates.
/// </summary>
public class AppStateService
{
    // ── Current User ─────────────────────────────────────────
    public User? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;
    public bool IsAdmin => CurrentUser?.Role == "admin";
    public bool IsMember => CurrentUser?.Role is "member" or "admin" or "staff";

    public void Login(User user)
    {
        CurrentUser = user;
        NotifyStateChanged();
    }

    public void Logout()
    {
        CurrentUser = null;
        NotifyStateChanged();
    }

    // ── Toast Notifications ──────────────────────────────────
    public string? ToastMessage { get; private set; }
    public string ToastType { get; private set; } = "success";

    public void ShowToast(string message, string type = "success")
    {
        ToastMessage = message;
        ToastType = type;
        NotifyStateChanged();
        // Auto-clear after 3 seconds
        _ = Task.Delay(3000).ContinueWith(_ =>
        {
            ToastMessage = null;
            NotifyStateChanged();
        });
    }

    // ── Static Data ──────────────────────────────────────────
    public List<SnookerTable> Tables { get; } = new()
    {
        new() { Id=1, Name="Table 1", Status=TableStatus.Available, Type=TableType.Standard },
        new() { Id=2, Name="Table 2", Status=TableStatus.Occupied,  Type=TableType.Standard },
        new() { Id=3, Name="Table 3", Status=TableStatus.Available, Type=TableType.Standard },
        new() { Id=4, Name="Table 4", Status=TableStatus.Maintenance, Type=TableType.Standard },
        new() { Id=5, Name="Table 5", Status=TableStatus.Available, Type=TableType.VIP },
        new() { Id=6, Name="Table 6", Status=TableStatus.Occupied,  Type=TableType.VIP },
        new() { Id=7, Name="Table 7", Status=TableStatus.Available, Type=TableType.Standard },
        new() { Id=8, Name="Table 8", Status=TableStatus.Available, Type=TableType.Standard },
    };

    public List<MembershipPlan> MembershipPlans { get; } = new()
    {
        new() { Tier="Bronze",   Icon="🥉", MonthlyPrice=499,  Color="#795548",
            Perks=new(){"5% discount on bookings","Member-only hours","Monthly newsletter"} },
        new() { Tier="Silver",   Icon="🥈", MonthlyPrice=999,  Color="#90A4AE",
            Perks=new(){"10% discount","Priority booking","2 free hours/month","Café discount"} },
        new() { Tier="Gold",     Icon="🥇", MonthlyPrice=1799, Color="#C9A84C", IsPopular=true,
            Perks=new(){"20% discount","VIP table access","5 free hours/month","2 guest passes","Personal locker"} },
        new() { Tier="Platinum", Icon="💎", MonthlyPrice=2999, Color="#2ECC71",
            Perks=new(){"30% discount","Unlimited VIP access","10 free hours/month","5 guest passes","Private locker","Monthly coaching"} },
    };

    public List<Tournament> Tournaments { get; } = new()
    {
        new() { Id=1, Name="Summer Championship 2026", Date=new DateTime(2026,7,15),
            Status=TournamentStatus.Upcoming, PrizeMoney="₹50,000", MaxPlayers=16, RegisteredPlayers=12,
            Description="Annual flagship tournament open to all members. Frame-based knockout format." },
        new() { Id=2, Name="Monthly Open – June",     Date=new DateTime(2026,6,20),
            Status=TournamentStatus.Completed, PrizeMoney="₹20,000", MaxPlayers=8,  RegisteredPlayers=8, Winner="Rahul M.",
            Description="June edition of the monthly open series." },
        new() { Id=3, Name="Masters Series Q3",       Date=new DateTime(2026,8,10),
            Status=TournamentStatus.Upcoming, PrizeMoney="₹1,00,000", MaxPlayers=32, RegisteredPlayers=7,
            Description="Prestigious quarter-final series for Gold & Platinum members." },
    };

    public List<Testimonial> Testimonials { get; } = new()
    {
        new() { Name="Arjun Sharma",  Role="Gold Member",     Text="The atmosphere here is unmatched. Tables are immaculate, staff professional, and the VIP rooms feel like a proper snooker hall." },
        new() { Name="Priya Desai",   Role="Silver Member",   Text="I love the booking system — easy to use, instant confirmation. The loyalty points add up fast too!" },
        new() { Name="Karan Mehta",   Role="Platinum Member", Text="Been coming here for 3 years. The tournaments are well-organised and competitive. Nothing like it in Nagpur." },
    };

    public List<RevenueData> RevenueHistory { get; } = new()
    {
        new() { Month="Jan", Amount=82000 },
        new() { Month="Feb", Amount=91000 },
        new() { Month="Mar", Amount=105000 },
        new() { Month="Apr", Amount=98000 },
        new() { Month="May", Amount=120000 },
        new() { Month="Jun", Amount=134000 },
    };

    public List<GalleryItem> GalleryItems { get; } = new()
    {
        new() { Emoji="🎱", Label="Championship Table",  Category="facility" },
        new() { Emoji="👑", Label="VIP Lounge",          Category="facility" },
        new() { Emoji="🏆", Label="Tournament Finals",   Category="events"   },
        new() { Emoji="☕", Label="Members Café",        Category="facility" },
        new() { Emoji="💡", Label="Pro Lighting",        Category="facility" },
        new() { Emoji="🎮", Label="Training Session",    Category="events"   },
        new() { Emoji="🥂", Label="Prize Night",         Category="events"   },
        new() { Emoji="🎯", Label="Practice Corner",     Category="facility" },
        new() { Emoji="🌆", Label="Club Entrance",       Category="facility" },
    };

    public List<string> TimeSlots { get; } = new()
    {
        "10:00","11:00","12:00","13:00","14:00",
        "15:00","16:00","17:00","18:00","19:00","20:00","21:00"
    };

    // ── Business / Contact Info (single source of truth) ─────
    public BusinessInfo Business { get; } = new()
    {
        Address     = "Plot No. 13 Vaibhav Anand Society, Near Vandan Lawn, Behind Mauli Restaurant and Bar, Besa Chowk, Pipla Road, Nagpur, Maharashtra - 440034",
        Phone       = "+91 73500 00630",
        PhoneRaw    = "917350000630",
        Email       = "contact@addictionsnookerclub.in",
        Hours       = "Monday – Sunday: 10:00 AM – 2:00 AM",
        InstagramHandle = "@addictionsnookerclub",
        InstagramUrl    = "https://instagram.com/addictionsnookerclub",
        GoogleMapsUrl   = "https://maps.google.com/?q=21.084408,79.098663",
        Latitude    = 21.084408,
        Longitude   = 79.098663,
    };

    // ── Change notification (like EventEmitter) ──────────────
    public event Action? OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();
}
