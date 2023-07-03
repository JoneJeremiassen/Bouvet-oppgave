import React, { useState } from 'react';

const EpicForm = ({ onSubmit }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();

    const epicData = {
      name,
      description,
    };

    onSubmit(epicData);

    // Reset form fields
    setName('');
    setDescription('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Name:</label>
      <input type="text" value={name} onChange={(e) => setName(e.target.value)} />

      <label>Description:</label>
      <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />

      <button type="submit">Create Epic</button>
    </form>
  );
};

export default EpicForm;
