namespace CATaskTracker
{

    class Task
    {
        public Task(string title, string description, DateTime dueDate, Periority periority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            status = Status.Pending;
            this.periority = periority;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Periority periority;
        public Status status;

        public override string ToString()
        {
            return $"Title : {Title}\t\t{status}\t\t{periority.ToString()}";
        }
        
    }
}
