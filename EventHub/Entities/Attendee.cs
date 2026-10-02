namespace EventHub.Entities
{
    public class Attendee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public Badge? Badge { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}