import React, { Component, useState, useEffect } from 'react';


export const FileEditor = ({ selectedFile, isEditMode, text, onTextChanged, onSave }) => {

    const [buttonColor, setColor] = useState("bg-green-200");
    const onChange = (w) => {
        onTextChanged(w.target.value)
    }

    if (isEditMode)
        return (
            <div className="flex flex-col justify-center  gap-2">
                <textarea className="w-100" name="textarea" cols="150" rows="10" value={text} onChange={onChange} />
                <button className={buttonColor + " p-4"} onClick={onSave}>{selectedFile == null ? "Create" : "Update " + selectedFile.fileName}</button>
            </div>
        );
    else return <div>

    </div>
}