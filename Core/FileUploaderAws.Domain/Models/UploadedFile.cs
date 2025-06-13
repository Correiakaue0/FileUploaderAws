namespace FileUploaderAws.Domain.Models;

public class UploadedFile (string key, string fileName, string url)
{
    public string Key { get; set; } = key;
    public string FileName { get; set; } = fileName;
    public string Url { get; set; } = url;
}