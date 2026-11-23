#pragma warning disable SYSLIB0014

using System.Net;
using System.Text;

WebClient client = new();

// string uri = "https://ilyachalov.github.io/my-site/";
// byte[] urlData = client.DownloadData("https://ilyachalov.github.io/my-site/");
// string page = Encoding.UTF8.GetString(urlData);
// Console.WriteLine(page);

string imageUri = "https://ilyachalov.github.io/my-site/images/vyborg1.jpg";
string filePath = "./Downloads/copyFile.jpg";
client.DownloadFile(imageUri, filePath);