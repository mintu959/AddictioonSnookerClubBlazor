using AddictioonSnookerClub.Models;

namespace AddictioonSnookerClub.Services;

// ── BookingService ────────────────────────────────────────────
public class BookingService
{
    private readonly List<Booking> _bookings = new()
    {
        new() { Id="BK001", TableId=3, TableName="Table 3",    MemberName="Arjun S.",  MemberEmail="arjun@example.com",
                Date=DateTime.Today,   TimeSlot="16:00", DurationHours=2, Amount=700,  Status=BookingStatus.Confirmed },
        new() { Id="BK002", TableId=5, TableName="Table 5 VIP",MemberName="Priya D.",  MemberEmail="priya@example.com",
                Date=DateTime.Today,   TimeSlot="18:00", DurationHours=1, Amount=500,  Status=BookingStatus.Confirmed },
        new() { Id="BK003", TableId=1, TableName="Table 1",    MemberName="Karan M.",  MemberEmail="karan@example.com",
                Date=DateTime.Today.AddDays(1), TimeSlot="11:00", DurationHours=3, Amount=1050, Status=BookingStatus.Pending },
        new() { Id="BK004", TableId=2, TableName="Table 2",    MemberName="Neha R.",   MemberEmail="neha@example.com",
                Date=DateTime.Today.AddDays(1), TimeSlot="14:00", DurationHours=2, Amount=700,  Status=BookingStatus.Cancelled },
    };

    public List<Booking> GetAll() => _bookings;
    public List<Booking> GetByEmail(string email) =>
        _bookings.Where(b => b.MemberEmail == email).ToList();

    public string CreateBooking(Booking booking)
    {
        _bookings.Add(booking);
        return booking.Id;
    }

    public bool CancelBooking(string id)
    {
        var b = _bookings.FirstOrDefault(x => x.Id == id);
        if (b is null) return false;
        b.Status = BookingStatus.Cancelled;
        return true;
    }

    public bool DeleteBooking(string id)
    {
        var b = _bookings.FirstOrDefault(x => x.Id == id);
        if (b is null) return false;
        _bookings.Remove(b);
        return true;
    }

    // Revenue stats
    public int TodayRevenue => _bookings
        .Where(b => b.Date.Date == DateTime.Today && b.Status != BookingStatus.Cancelled)
        .Sum(b => b.Amount);

    public int ActiveBookingsCount => _bookings
        .Count(b => b.Status == BookingStatus.Confirmed || b.Status == BookingStatus.Pending);
}

// ── MemberService ─────────────────────────────────────────────
public class MemberService
{
    private readonly List<User> _members = new()
    {
        new() { Id=1, Name="Arjun Sharma", Email="arjun@example.com",   Role="member",  Membership="Gold",     LoyaltyPoints=1240, JoinedDate=new DateTime(2024,3,15) },
        new() { Id=2, Name="Priya Desai",  Email="priya@example.com",   Role="member",  Membership="Silver",   LoyaltyPoints=560,  JoinedDate=new DateTime(2024,7,22) },
        new() { Id=3, Name="Karan Mehta",  Email="karan@example.com",   Role="member",  Membership="Platinum", LoyaltyPoints=3200, JoinedDate=new DateTime(2023,11,1)  },
        new() { Id=4, Name="Neha Rathi",   Email="neha@example.com",    Role="member",  Membership="Bronze",   LoyaltyPoints=180,  JoinedDate=new DateTime(2025,1,10), IsActive=false },
        new() { Id=5, Name="Admin User",   Email="admin@addictioon.in", Role="admin",   Membership="Platinum", LoyaltyPoints=9999, JoinedDate=new DateTime(2023,1,1)  },
    };

    public List<User> GetAll() => _members;
    public User? GetByEmail(string email) =>
        _members.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

    public bool DeleteMember(int id)
    {
        var m = _members.FirstOrDefault(x => x.Id == id);
        if (m is null) return false;
        _members.Remove(m);
        return true;
    }

    public int TotalCount => _members.Count;
    public int ActiveCount => _members.Count(m => m.IsActive);
}

// ── TournamentService ─────────────────────────────────────────
public class TournamentService
{
    private readonly AppStateService _state;
    public TournamentService(AppStateService state) => _state = state;

    public List<Tournament> GetAll() => _state.Tournaments;
    public List<Tournament> GetUpcoming() =>
        _state.Tournaments.Where(t => t.Status == TournamentStatus.Upcoming).ToList();

    public bool Register(int tournamentId, string playerName)
    {
        var t = _state.Tournaments.FirstOrDefault(x => x.Id == tournamentId);
        if (t is null || t.RegisteredPlayers >= t.MaxPlayers) return false;
        t.RegisteredPlayers++;
        return true;
    }
}
