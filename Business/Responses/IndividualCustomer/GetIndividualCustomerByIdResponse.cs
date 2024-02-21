namespace Business.Responses.IndividualCustomer
{
    public class GetIndividualCustomerByIdResponse
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }
}