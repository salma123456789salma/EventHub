namespace EventHub.Entities
{
    public class Registration
    {
        public int Id { get; set; }

        public string? Note { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Attendee Attendee { get; set; }

        public Event Event { get; set; }
    }
}