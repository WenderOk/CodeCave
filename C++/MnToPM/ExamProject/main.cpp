#include <iostream>
#include <string>
#include <map>
#include <memory>

// 1. Продукт
class HttpRequest {
private:
    std::string method;
    std::string url;
    std::map<std::string, std::string> headers;
    std::string body;

    friend class HttpConcreteBuilder;

public:
    void print() const {
        std::cout << "--- HTTP REQUEST ---\n";
        std::cout << method << " " << url << " HTTP/1.1\n";
        for (const auto& [key, value] : headers) {
            std::cout << key << ": " << value << "\n";
        }
        if (!body.empty()) {
            std::cout << "\n[Body]: " << body << "\n";
        }
        std::cout << "--------------------\n\n";
    }
};

// 2. Интерфейс Строителя (методы возвращают void)
class HttpBuilder {
public:
    virtual ~HttpBuilder() = default;
    virtual void reset() = 0;
    virtual void buildMethod(const std::string& method) = 0;
    virtual void buildUrl(const std::string& url) = 0;
    virtual void buildHeader(const std::string& key, const std::string& value) = 0;
    virtual void buildBody(const std::string& body) = 0;
    virtual std::unique_ptr<HttpRequest> getResult() = 0;
};

// 3. Конкретный Строитель
class HttpConcreteBuilder : public HttpBuilder {
private:
    std::unique_ptr<HttpRequest> request;

public:
    HttpConcreteBuilder() { reset(); }

    void reset() override {
        request = std::unique_ptr<HttpRequest>(new HttpRequest());
    }

    void buildMethod(const std::string& method) override {
        request->method = method;
    }

    void buildUrl(const std::string& url) override {
        request->url = url;
    }

    void buildHeader(const std::string& key, const std::string& value) override {
        request->headers[key] = value;
    }

    void buildBody(const std::string& body) override {
        request->body = body;
        request->headers["Content-Length"] = std::to_string(body.length());
    }

    std::unique_ptr<HttpRequest> getResult() override {
        std::unique_ptr<HttpRequest> result = std::move(request);
        reset(); // Готовим строитель к следующему циклу
        return result;
    }
};

// 4. Директор (знает точные алгоритмы сборки типовых запросов)
class HttpDirector {
private:
    HttpBuilder* builder;

public:
    void setBuilder(HttpBuilder* b) {
        builder = b;
    }

    // Алгоритм сборки стандартного JSON GET-запроса
    void makeJsonGetRequest(const std::string& url, const std::string& token) {
        builder->buildMethod("GET");
        builder->buildUrl(url);
        builder->buildHeader("Accept", "application/json");
        builder->buildHeader("Authorization", "Bearer " + token);
    }

    // Алгоритм сборки стандартного JSON POST-запроса
    void makeJsonPostRequest(const std::string& url, const std::string& token, const std::string& jsonBody) {
        builder->buildMethod("POST");
        builder->buildUrl(url);
        builder->buildHeader("Content-Type", "application/json");
        builder->buildHeader("Authorization", "Bearer " + token);
        builder->buildBody(jsonBody);
    }
};

// Использование
int main() {
    HttpDirector director;
    HttpConcreteBuilder builder;
    director.setBuilder(&builder);

    // 1. Собираем стандартный GET-запрос через Директора
    std::cout << "Директор собирает профиль пользователя (GET):\n";
    director.makeJsonGetRequest("https://site.com", "tokenXYZ_123");
    
    std::unique_ptr<HttpRequest> getReq = builder.getResult();
    getReq->print();

    // 2. Собираем стандартный POST-запрос через Директора
    std::cout << "Директор собирает отправку данных (POST):\n";
    director.makeJsonPostRequest("https://site.com", "tokenXYZ_123", "{\"status\": \"active\"}");
    
    std::unique_ptr<HttpRequest> postReq = builder.getResult();
    postReq->print();

    // 3. Кастомный запрос (клиент может использовать строитель напрямую, минуя Директора)
    std::cout << "Клиент собирает кастомный запрос вручную:\n";
    builder.buildMethod("PUT");
    builder.buildUrl("https://site.com");
    builder.buildHeader("X-Custom-Header", "SpecialValue");
    
    std::unique_ptr<HttpRequest> customReq = builder.getResult();
    customReq->print();

    return 0;
}
