namespace Bouvet_oppgave.Models
{
    public class Epic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Foreign key
        public int ProjectId { get; set; }
    }
}
