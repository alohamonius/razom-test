import React, { Component, useState } from 'react';
import axios from 'axios';
var globalConfig = require('./../config.json');

export const FileUploader = ({onNewFile}) => {
  
  const handleFileInput = (e) => {
    e.preventDefault();

    var form = new FormData();
    const file = e.target.files[0]
    form.append("file", file);
    axios({
      method: "post",
      url: globalConfig.BASE_URL + 'File',
      data: form,
      headers: { "Content-Type": "multipart/form-data" },
    })
      .then(function (res) {
        const newFile = res.data;
        onNewFile(newFile);
      })
      .catch(function (response) {
        console.error(response)
      });
  }

  return (
    <div className="file-uploader p-4 ">
      <p className="md:text-2xl  text-green-600 text-center">Upload you files here: </p>
      <form className="bg-green-500 p-4" onChange={handleFileInput} >
        <input className="flex-1" type="file" accept=".pdf, .txt" />
      </form>
    </div>
  )
}
