
Where I have some problems?
In  public async Task<IActionResult> GetContent(Guid fileId).
  
If file really big, UI goes down.

Docket contains : postgres, pgadmin and in one docker asp+react.

  
  
In DB I store byte[].
  
My files return {FileName, Id} (no content)
  
For retrieving content, getContent(fileId).
  
