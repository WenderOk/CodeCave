using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

const string ApiKey = ""; 
const string LangDirection = "ru-en"; // Направление перевода (например: en-ru или ru-en)

using var httpClient = new HttpClient();

Console.WriteLine("=== Учебный словарь-переводчик ===");
Console.WriteLine($"Направление перевода: {LangDirection}");
Console.WriteLine("Введите слово для перевода (или пустую строку для выхода):\n");

while (true)
{
    Console.Write("> ");
    string? word = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(word))
        break;

    await TranslateWordAsync(httpClient, word, LangDirection, ApiKey);
    Console.WriteLine();
}

static async Task TranslateWordAsync(HttpClient client, string word, string lang, string key)
{
    // Формируем URL запроса с экранированием введенного слова
    string url = $"https://dictionary.yandex.net/api/v1/dicservice.json/lookup" +
                 $"?key={key}&lang={lang}&text={Uri.EscapeDataString(word)}";

    try
    {
        HttpResponseMessage response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Ошибка HTTP: {(int)response.StatusCode} ({response.ReasonPhrase})");
            return;
        }

        string json = await response.Content.ReadAsStringAsync();
        
        // Десериализуем JSON-ответ в C#-объекты
        var result = JsonSerializer.Deserialize<DictionaryResponse>(json);

        if (result?.Def == null || result.Def.Count == 0)
        {
            Console.WriteLine("Варианты перевода не найдены.");
            return;
        }

        // Выводим найденные словарные статьи и варианты перевода
        foreach (var definition in result.Def)
        {
            Console.WriteLine($"\nСлово: {definition.Text} [{definition.Pos ?? "неизв."}]");

            if (definition.Tr == null) continue;

            for (int i = 0; i < definition.Tr.Count; i++)
            {
                var translation = definition.Tr[i];
                Console.Write($"  {i + 1}. {translation.Text}");

                // Если у варианта есть синонимы, выводим их в скобках
                if (translation.Syn != null && translation.Syn.Count > 0)
                {
                    var synonyms = string.Join(", ", translation.Syn.Select(s => s.Text));
                    Console.Write($" ({synonyms})");
                }

                Console.WriteLine();
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Произошла ошибка при запросе: {ex.Message}");
    }
}

// --- Классы для разбора JSON-ответа от API ---

public class DictionaryResponse
{
    [JsonPropertyName("def")]
    public List<Definition>? Def { get; set; }
}

public class Definition
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("pos")]
    public string? Pos { get; set; } // Часть речи (noun, verb и т.д.)

    [JsonPropertyName("tr")]
    public List<Translation>? Tr { get; set; }
}

public class Translation
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("syn")]
    public List<Synonym>? Syn { get; set; }
}

public class Synonym
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
