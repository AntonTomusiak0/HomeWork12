namespace ConsoleApp33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Firm> firms = new List<Firm>
            {
            new Firm("FoodHub", new DateTime(2018, 5, 12), "Food", "John White", 150, "London"),
            new Firm("TechWorld", new DateTime(2021, 4, 23), "IT", "Alice Black", 200, "New York"),
            new Firm("MarketMakers", new DateTime(2017, 11, 8), "Marketing", "Bob White", 80, "London"),
            new Firm("Foodies", new DateTime(2015, 3, 15), "Food", "Charlie Green", 120, "Paris"),
            new Firm("ITSolutions", new DateTime(2019, 6, 30), "IT", "David Black", 250, "Berlin"),
            new Firm("MarketPros", new DateTime(2020, 2, 20), "Marketing", "Eve Brown", 90, "London")
            };
            Console.WriteLine("All firms:");
            foreach (var firm in firms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms with 'Food' in the name:");
            var foodFirms = firms.Where(f => f.Name.Contains("Food"));
            foreach (var firm in foodFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms in the marketing business:");
            var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing");
            foreach (var firm in marketingFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms in the marketing or IT business:");
            var marketingOrItFirms = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
            foreach (var firm in marketingOrItFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms with more than 100 employees:");
            var largeFirms = firms.Where(f => f.EmployeeCount > 100);
            foreach (var firm in largeFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms with 100 to 300 employees:");
            var midSizeFirms = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);
            foreach (var firm in midSizeFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms located in London:");
            var londonFirms = firms.Where(f => f.Address.Contains("London"));
            foreach (var firm in londonFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms with director's surname 'White':");
            var whiteDirectorFirms = firms.Where(f => f.Director.Contains("White"));
            foreach (var firm in whiteDirectorFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms founded more than two years ago:");
            var oldFirms = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 365 * 2);
            foreach (var firm in oldFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms founded exactly 123 days ago:");
            var exact123DaysFirms = firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays == 123);
            foreach (var firm in exact123DaysFirms)
            {
                Console.WriteLine(firm);
            }
            Console.WriteLine("\nFirms with director's surname 'Black' and 'White' in the name:");
            var blackDirectorWhiteNameFirms = firms.Where(f => f.Director.Contains("Black") && f.Name.Contains("White"));
            foreach (var firm in blackDirectorWhiteNameFirms)
            {
                Console.WriteLine(firm);
            }
        }
    }
}
public class Firm
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string BusinessProfile { get; set; }
    public string Director { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }
    public Firm(string name, DateTime foundationDate, string businessProfile, string director, int employeeCount, string address)
    {
        Name = name;
        FoundationDate = foundationDate;
        BusinessProfile = businessProfile;
        Director = director;
        EmployeeCount = employeeCount;
        Address = address;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Foundation Date: {FoundationDate.ToShortDateString()}, Business Profile: {BusinessProfile}, " +
               $"Director: {Director}, Employee Count: {EmployeeCount}, Address: {Address}";
    }
}
public static class FirmExtensions
{
    public static IEnumerable<Firm> GetFirmsWithFoodInName(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.Name.Contains("Food"));
    }
    public static IEnumerable<Firm> GetMarketingFirms(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.BusinessProfile == "Marketing");
    }
    public static IEnumerable<Firm> GetMarketingOrItFirms(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
    }
    public static IEnumerable<Firm> GetLargeFirms(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.EmployeeCount > 100);
    }
    public static IEnumerable<Firm> GetMidSizeFirms(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);
    }
    public static IEnumerable<Firm> GetFirmsInLondon(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.Address.Contains("London"));
    }
    public static IEnumerable<Firm> GetFirmsWithDirectorWhite(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.Director.Contains("White"));
    }
    public static IEnumerable<Firm> GetOldFirms(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 365 * 2);
    }
    public static IEnumerable<Firm> GetFirmsFounded123DaysAgo(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays == 123);
    }
    public static IEnumerable<Firm> GetBlackDirectorWhiteNameFirms(this IEnumerable<Firm> firms)
    {
        return firms.Where(f => f.Director.Contains("Black") && f.Name.Contains("White"));
    }
}
public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
    public Employee(string fullName, string position, string phone, string email, decimal salary)
    {
        FullName = fullName;
        Position = position;
        Phone = phone;
        Email = email;
        Salary = salary;
    }
    public override string ToString()
    {
        return $"Full Name: {FullName}, Position: {Position}, Phone: {Phone}, Email: {Email}, Salary: {Salary}";
    }
}