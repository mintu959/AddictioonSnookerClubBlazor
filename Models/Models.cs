namespace AddictioonSnookerClub.Models;

// ── User & Auth ──────────────────────────────────────────────
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "member"; // guest | member | staff | admin
    public string Membership { get; set; } = "Silver";
    public int LoyaltyPoints { get; set; } = 0;
    public DateTime JoinedDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public string Initials => Name.Length >= 2
        ? $"{Name[0]}{Name.Split(' ').Last()[0]}".ToUpper()
        : Name.Length > 0 ? Name[0].ToString().ToUpper() : "?";
}

// ── Snooker Table ────────────────────────────────────────────
public enum TableStatus { Available, Occupied, Maintenance }
public enum TableType { Standard, VIP }

public class SnookerTable
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public TableStatus Status { get; set; } = TableStatus.Available;
    public TableType Type { get; set; } = TableType.Standard;
    public int HourlyRate => Type == TableType.VIP ? 500 : 350;
}

// ── Booking ──────────────────────────────────────────────────
public enum BookingStatus { Pending, Confirmed, Cancelled, Completed }

public class Booking
{
    public string Id { get; set; } = $"BK{Random.Shared.Next(10000, 99999)}";
    public int TableId { get; set; }
    public string TableName { get; set; } = "";
    public string MemberName { get; set; } = "";
    public string MemberEmail { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Today;
    public string TimeSlot { get; set; } = "";
    public int DurationHours { get; set; } = 1;
    public int Amount { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

// ── Membership ───────────────────────────────────────────────
public class MembershipPlan
{
    public string Tier { get; set; } = "";
    public string Icon { get; set; } = "";
    public int MonthlyPrice { get; set; }
    public List<string> Perks { get; set; } = new();
    public bool IsPopular { get; set; }
    public string Color { get; set; } = "";
}

// ── Tournament ───────────────────────────────────────────────
public enum TournamentStatus { Upcoming, Live, Completed }

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime Date { get; set; }
    public TournamentStatus Status { get; set; }
    public string PrizeMoney { get; set; } = "";
    public int MaxPlayers { get; set; }
    public int RegisteredPlayers { get; set; }
    public string? Winner { get; set; }
    public string? Description { get; set; }
}

// ── Testimonial ──────────────────────────────────────────────
public class Testimonial
{
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Text { get; set; } = "";
    public string Initials => Name.Length >= 2
        ? $"{Name[0]}{Name.Split(' ').Last()[0]}".ToUpper()
        : Name[0].ToString().ToUpper();
}

// ── Revenue ──────────────────────────────────────────────────
public class RevenueData
{
    public string Month { get; set; } = "";
    public int Amount { get; set; }
}

// ── Contact Message ──────────────────────────────────────────
public class ContactMessage
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Message { get; set; } = "";
}

// ── Gallery Item ─────────────────────────────────────────────
public class GalleryItem
{
    public string Emoji { get; set; } = "";
    public string Label { get; set; } = "";
    public string Category { get; set; } = "all";
}

// ── Business Info (single source of truth for contact details) ─
public class BusinessInfo
{
    public string Address { get; set; } = "";
    public string Phone { get; set; } = "";
    public string PhoneRaw { get; set; } = "";       // digits only, for tel: links
    public string Email { get; set; } = "";
    public string Hours { get; set; } = "";
    public string InstagramHandle { get; set; } = "";
    public string InstagramUrl { get; set; } = "";
    public string GoogleMapsUrl { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    // Embeddable Google Maps URL (no API key required)
    public string EmbedMapUrl =>
        $"https://maps.google.com/maps?q={Latitude},{Longitude}&z=16&output=embed";
}
