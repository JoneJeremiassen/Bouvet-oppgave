import React, { useState } from 'react';

const ProjectTaskForm = ({ onSubmit }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [responsible, setResponsible] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();

    const taskData = {
      name,
      description,
      responsible,
    };

    onSubmit(taskData);

    // Reset form fields
    setName('');
    setDescription('');
    setResponsible('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Name:</label>
      <input type="text" value={name} onChange={(e) => setName(e.target.value)} />

      <label>Description:</label>
      <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />

      <label>Responsible:</label>
      <input type="text" value={responsible} onChange={(e) => setResponsible(e.target.value)} />

      <button type="submit">Create Project Task</button>
    </form>
  );
};

export default ProjectTaskForm;
