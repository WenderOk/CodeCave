// #pragma warning disable SYSLIB0014

// using System.Net;

// string uri = "https://ilyachekalov.github.io/my-site/";
// HttpWebRequest request = (HttpWebRequest).WebRequest.Create(uri);
// request.Headers.Add("Accept-Language: ru-ru")
// HttpWebResponse response = (HttpWebResponse).WebResponse.Create(uri);


using HttpClient client = new();

client.DefaultRequestHeaders.Add("Accept-Language", "ru-ru");


string uri = "https://ilyachalov.github.io/my-site/";
string result = await client.GetStringAsync(uri);
Console.WriteLine(result);