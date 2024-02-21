namespace Business.Requests.Customer
{
    public class AddCustomerRequest
    {
        public AddCustomerRequest(int userId)
        {
            UserId = userId;
            
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }

    }
}