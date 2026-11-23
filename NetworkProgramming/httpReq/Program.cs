#pragma warning disable SYSLIB0014

using System.Net;
using System.Text;

// string uri = "https://ilyachalov.github.io/my-site/";
// HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
// request.Headers.Add("Accept-Language: ru-ru");
// HttpWebResponse response = (HttpWebResponse)request.GetResponse();

// foreach (string header in response.Headers)
// {
//     Console.WriteLine("{0}: {1}", header, response.Headers[header]);    
// }

// StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8);
// Console.WriteLine(sr.ReadToEnd());
// sr.Close();


// using HttpClient client = new();
// client.DefaultRequestHeaders.Add("Accept-Language", "ru-ru");
//client.DefaultRequestHeaders.UserAgent.ParseAdd("mozilla");

// string uri = "https://ilyachalov.github.io/my-site/";
// string result = await client.GetStringAsync(uri);
// Console.WriteLine(result);

using HttpClient client = new();

client.DefaultRequestHeaders.Add("Accept-Language", "ru-ru");
string uri = "https://ilyachalov.github.io/my-site/";
using HttpResponseMessage response = await client.GetAsync(uri);

foreach (var header in response.Headers)
    Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");


string content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);
