namespace Business.Responses.Customer
{
    public class AddCustomerResponse
    {
        public AddCustomerResponse(int? id, DateTime createdAt)
        {
            Id = id;
            
            CreatedAt = createdAt;
        }

        public int? Id { get; set; } 
       
        public DateTime CreatedAt { get; set; }
    }
}