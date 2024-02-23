namespace Business.Requests.Customer
{
    public class GetCustomerByIdRequest
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
    }
}