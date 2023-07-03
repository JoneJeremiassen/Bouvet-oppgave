import React, { useState } from 'react';

const ProjectForm = ({ onSubmit }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [projectManager, setProjectManager] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();

    const projectData = {
      name,
      description,
      projectManager,
    };

    onSubmit(projectData);

    // Reset form fields
    setName('');
    setDescription('');
    setProjectManager('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Name:</label>
      <input type="text" value={name} onChange={(e) => setName(e.target.value)} />

      <label>Description:</label>
      <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />

      <label>Project Manager:</label>
      <input type="text" value={projectManager} onChange={(e) => setProjectManager(e.target.value)} />

      <button type="submit">Create Project</button>
    </form>
  );
};

export default ProjectForm;
