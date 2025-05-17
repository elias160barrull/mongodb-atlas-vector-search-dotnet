# 🌟 MongoDB Atlas Vector Search .NET 🌟

![GitHub release](https://img.shields.io/github/release/elias160barrull/mongodb-atlas-vector-search-dotnet.svg?style=flat-square)
![GitHub issues](https://img.shields.io/github/issues/elias160barrull/mongodb-atlas-vector-search-dotnet.svg?style=flat-square)
![GitHub forks](https://img.shields.io/github/forks/elias160barrull/mongodb-atlas-vector-search-dotnet.svg?style=flat-square)

Welcome to the **MongoDB Atlas Vector Search .NET** repository! This project provides an AI-powered movie discovery API that understands natural language queries. It leverages vector embeddings and semantic search to enhance the movie recommendation experience.

## 🚀 Features

- **Natural Language Processing**: Understand user queries in plain language.
- **Vector Embeddings**: Utilize advanced embeddings for accurate results.
- **Semantic Search**: Find relevant movies based on meaning, not just keywords.
- **Recommendation Engine**: Get personalized movie suggestions.
- **Integration with MongoDB Atlas**: Store and manage your data efficiently.

## 📦 Getting Started

To start using the API, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/elias160barrull/mongodb-atlas-vector-search-dotnet.git
   cd mongodb-atlas-vector-search-dotnet
   ```

2. **Install Dependencies**:
   Make sure you have .NET 10 installed. You can install the necessary packages by running:
   ```bash
   dotnet restore
   ```

3. **Configure MongoDB Atlas**:
   Set up your MongoDB Atlas cluster and get your connection string. Update your application settings to include this connection string.

4. **Run the API**:
   Start the application with:
   ```bash
   dotnet run
   ```

5. **Access the API**:
   You can access the API at `http://localhost:5000`. 

For the latest releases, visit [Releases](https://github.com/elias160barrull/mongodb-atlas-vector-search-dotnet/releases).

## 🛠️ Technologies Used

- **.NET 10**: The framework for building the API.
- **MongoDB**: The database for storing movie data.
- **Ollama**: A library for natural language processing.
- **AI Embeddings**: Techniques for transforming text into vectors.
- **Vector Database**: For storing and retrieving vector data efficiently.

## 📚 How It Works

### Natural Language Processing

The API uses NLP to parse user queries. It understands context and intent, making it easier for users to find movies they want to watch. 

### Vector Embeddings

By converting movie descriptions and user queries into vector representations, the API can compare their meanings. This allows for more relevant search results.

### Semantic Search

The semantic search capability enables the API to return results based on the meaning of the query rather than exact matches. This improves user satisfaction and engagement.

### Recommendation Engine

The recommendation engine analyzes user behavior and preferences. It suggests movies that users are likely to enjoy based on their past interactions.

## 🎨 API Endpoints

### Search Movies

- **Endpoint**: `/api/movies/search`
- **Method**: `POST`
- **Request Body**:
  ```json
  {
    "query": "A thrilling adventure"
  }
  ```
- **Response**:
  ```json
  [
    {
      "title": "Adventure in the Jungle",
      "description": "A thrilling tale of survival."
    }
  ]
  ```

### Get Recommendations

- **Endpoint**: `/api/movies/recommendations`
- **Method**: `GET`
- **Query Parameters**:
  - `userId`: The ID of the user for personalized recommendations.
- **Response**:
  ```json
  [
    {
      "title": "Mystery of the Lost Treasure",
      "description": "An engaging mystery movie."
    }
  ]
  ```

## 🔍 Example Usage

### Search for Movies

You can send a POST request to the search endpoint with a natural language query. For example, to search for a movie with a thrilling adventure theme:

```bash
curl -X POST http://localhost:5000/api/movies/search -H "Content-Type: application/json" -d '{"query": "A thrilling adventure"}'
```

### Get Movie Recommendations

To get recommendations for a specific user, send a GET request:

```bash
curl -X GET "http://localhost:5000/api/movies/recommendations?userId=123"
```

## 📈 Performance

The API is designed to handle multiple requests efficiently. By utilizing vector databases and optimized queries, it ensures quick response times even under heavy load.

## 🔒 Security

Security is a priority in this project. Ensure you implement proper authentication and authorization for your API endpoints. Consider using JWT tokens for user sessions.

## 📝 Contribution Guidelines

We welcome contributions to improve the project. Here’s how you can help:

1. **Fork the Repository**: Create your own copy of the repository.
2. **Create a Branch**: Use a descriptive name for your branch.
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make Changes**: Implement your changes and commit them.
   ```bash
   git commit -m "Add your message here"
   ```
4. **Push to Your Fork**: Push your changes back to your fork.
   ```bash
   git push origin feature/your-feature-name
   ```
5. **Create a Pull Request**: Submit your changes for review.

## 🗣️ Community

Join our community to discuss features, report issues, or just chat about movies and technology. 

- [GitHub Discussions](https://github.com/elias160barrull/mongodb-atlas-vector-search-dotnet/discussions)
- [Stack Overflow](https://stackoverflow.com/questions/tagged/mongodb)

## 🔗 Resources

- [MongoDB Documentation](https://docs.mongodb.com/)
- [Ollama Documentation](https://ollama.com/docs)
- [Natural Language Processing](https://en.wikipedia.org/wiki/Natural_language_processing)

## 📅 Roadmap

We have exciting plans for future updates:

- Integrate more advanced AI algorithms for better recommendations.
- Add support for multiple languages.
- Improve the user interface for easier interaction.

## 📢 Acknowledgments

Thank you to all contributors and users who make this project possible. Your feedback and support help us grow and improve.

For the latest releases, visit [Releases](https://github.com/elias160barrull/mongodb-atlas-vector-search-dotnet/releases).

---

This project aims to provide a seamless experience for movie discovery through AI and natural language processing. Your contributions and feedback are invaluable. Happy coding!