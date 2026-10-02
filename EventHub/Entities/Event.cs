namespace EventHub.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        public Organizer Organizer { get; set; }

        public int? ParentEventId { get; set; }

        public Event? ParentEvent { get; set; }

        public ICollection<Event> Sessions { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}