﻿namespace Bouvet_oppgave.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }

        // Foreign key
        public int EpicId { get; set; }
    }
}
