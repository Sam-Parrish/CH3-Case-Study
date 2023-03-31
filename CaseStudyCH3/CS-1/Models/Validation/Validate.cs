namespace CS_1.Models.Validation
{
    public class Validate
    {
        public static string CheckEmail(SportsProContext context, Customer c1)
        {
            Customer? dbCust = context.Customers.FirstOrDefault(s =>
            s.Email == c1.Email);

            if (dbCust == null)
            {
                return "";
            }
            else
            {
                var emp = context.Customers.Find(c1.CustomerId);
                return $"The email you entered is being used by another user";
            }
        }
    }
}
