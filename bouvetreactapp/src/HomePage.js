import React, { useState, useEffect } from 'react';
import axios from 'axios';

const HomePage = () => {
  const [projects, setProjects] = useState([]);
  const [newProject, setNewProject] = useState({
    name: '',
    description: '',
    projectManager: '',
  });

  useEffect(() => {
    fetchProjects();
  }, []);

  const fetchProjects = async () => {
    try {
      const response = await axios.get('https://localhost:7072/api/Projects');
      setProjects(response.data);
    } catch (error) {
      console.error('Error fetching projects:', error);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post('https://localhost:7072/api/Projects', newProject);
      fetchProjects(); // Refresh the project list after submission
      setNewProject({ name: '', description: '', projectManager: '' }); // Clear the form
    } catch (error) {
      console.error('Error creating project:', error);
    }
  };

  const handleChange = (e) => {
    setNewProject((prevProject) => ({
      ...prevProject,
      [e.target.name]: e.target.value,
    }));
  };

  return (
    <div>
      <h2>Projects</h2>
      {projects.map((project) => (
        <div key={project.id}>
          <h3>{project.name}</h3>
          <p>Description: {project.description}</p>
          <p>Project Manager: {project.projectManager}</p>
        </div>
      ))}

      <h2>Create New Project</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="name">Name:</label>
          <input type="text" id="name" name="name" value={newProject.name} onChange={handleChange} />
        </div>
        <div>
          <label htmlFor="description">Description:</label>
          <textarea id="description" name="description" value={newProject.description} onChange={handleChange} />
        </div>
        <div>
          <label htmlFor="projectManager">Project Manager:</label>
          <input type="text" id="projectManager" name="projectManager" value={newProject.projectManager} onChange={handleChange} />
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default HomePage;
