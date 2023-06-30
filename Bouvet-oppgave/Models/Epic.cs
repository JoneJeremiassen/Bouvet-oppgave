namespace Bouvet_oppgave.Models
{
    public class Epic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
