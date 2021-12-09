import React, { Component, useEffect, useState } from 'react';
import axios from 'axios';
import { FileList } from './FileList'
import { FileEditor } from './FileEditor'
import { FileUploader } from './FileUploader'
import { Buffer } from 'buffer';

var config = require('./../config.json');

export const Home = () => {

  const [isFileOpened, setFileOpened] = useState(true);
  const [text, setText] = useState("");
  const [files, setFiles] = useState([]);
  const [selectedFile, setSelectedFile] = useState(null)

  useEffect(() => {
    loadFiles();

  }, [])

  const loadFiles = () => {
    axios.get(config.BASE_URL + 'File').then(res => {
      setFiles(res.data);
    })
  }

  const newFileUploaded = (file) => {
    setFiles([...files, file]);
  }

  const onFileEdited = (file) => {
    axios.get(ServerUrl(file.id)).then(res => {
      var fileContent = res.data.content;

      setText(fileContent.substr(0, 100));
      setSelectedFile(file);
      setFileOpened(true)
      //  setTimeout(() => { setText(fileContent) }, 1000)
    })
  }

  const onFileSaved = (fileId, content) => {
    var base64 = Buffer.from(content).toString('base64')

    var config = {
      method: 'put',
      url: EditUrl(fileId),
      headers: {
        'Content-Type': 'text/plain'
      },
      responseType: 'text',
      data: base64
    };

    axios(config)
      .then(res => {

      });
  }

  const onFileRemoved = (fileId) => {
    axios.delete(ServerUrl(fileId))
      .then(res => {
        if (selectedFile && selectedFile.id === fileId) { selectedFile = null; }
        setFiles(files.filter(file => { return file.id !== fileId }))
      });
  }

  const ServerUrl = (fileId) => `${config.BASE_URL}File/${fileId}`;
  const EditUrl = (fileId) => `${config.BASE_URL}File?fileId=${fileId}`;

  return (
    <div>
      <div className="grid grid-cols-2 gap-4 bg-gray-100">

        <div className="flex flex-col gap-4 col-span-2 justify-center bg-gray-300">
          <p className="text-red-600 text-center">Files saves automatic</p>
        </div>
        <div className="flex col-span-2 justify-center bg-gray-200">
          <FileEditor
            selectedFile={selectedFile}
            isEditMode={isFileOpened}
            text={text}
            onTextChanged={(e) => setText(e)}
            onSave={() => onFileSaved(selectedFile.id, text)} />
        </div>

        <div className="flex col-span-2 md:col-span-1 justify-center">
          <FileUploader onNewFile={newFileUploaded} />
        </div>
        <div className="flex col-span-2 md:col-span-1 justify-center">
          <FileList files={files} onEdit={onFileEdited} onRemove={onFileRemoved} />
        </div>

      </div>
    </div>
  )
}