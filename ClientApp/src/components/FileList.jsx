import React, { Component, useState, useEffect } from 'react';


const RemoveIcon = ({ onClick }) => {
  return (
    <div className="h-8">
      <button className="bg-red-600" onClick={onClick}>
        <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 24 24" stroke="currentColor" strokeWidth="1.5" fill="none">
          <path d="M18 6L6 18M18 18L6 6" strokeLinecap="round"></path>
        </svg>
      </button>

    </div>
  )
}

const EditIcon = ({ onClick }) => {
  return (
    <div className="h-8">
      <button className="bg-yellow-400" onClick={onClick}>
        <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" viewBox="0 0 24 24" stroke="currentColor" strokeWidth="1.5" fill="none">
          <path d="M13 7l4 4M7 21L21 7l-4-4L3 17v4h4z" strokeLinecap="round"></path>
        </svg>
      </button>

    </div>
  )
}
export const FileList = ({ files, onEdit, onRemove }) => {
  
  return (
    <div className="p-4">
      <p className="md:text-2xl  text-green-600 text-center">My files: </p>
      <ul className="flex flex-col gap-1 justify-right">
        {files.map(file => {
          return <li key={file.id} className="p-4 gap-1 flex justify-between h-14 border-2 border-black bg-gray-200 items-center">
            <p className="flex-1">  {file.fileName}</p>
            <p className="flex-0 p-1">Created: {new Date(file.createdAt).toLocaleString()}</p>
            <EditIcon onClick={() => onEdit(file)} />
            <RemoveIcon onClick={() => onRemove(file.id)} />
            <button className=""></button>
          </li>;
        })}
      </ul>
    </div>
  )
}