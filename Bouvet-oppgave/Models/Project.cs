﻿namespace Bouvet_oppgave.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectManager { get; set; }

        public ICollection<Epic> Epics { get; set; }
    }
}