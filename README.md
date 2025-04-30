# 🎬 SemanticFlix

![License](https://img.shields.io/badge/license-MIT-blue)
![.NET](https://img.shields.io/badge/.NET-10.0-blueviolet)
![MongoDB](https://img.shields.io/badge/MongoDB-3.3.0-green)
![AI-Powered](https://img.shields.io/badge/AI-Powered-orange)

> **Find the perfect movie through the power of semantic search and AI embeddings**

## ✨ Overview

SemanticFlix is a modern movie discovery API that goes beyond traditional keyword searching. Using cutting-edge vector embeddings and semantic search technology, it understands the _meaning_ behind your search queries, not just the words.

Want movies like "a journey through space where astronauts face impossible odds"? Or "heartwarming stories about unlikely friendships"? SemanticFlix understands what you're looking for and finds the perfect matches.

## 🚀 Features

- **AI-Powered Semantic Search** - Find movies based on meaning, not just keywords
- **Vector Embeddings** - Uses `mxbai-embed-large` model via Ollama for high-quality embeddings
- **MongoDB Vector Search** - Leverages MongoDB's vector database capabilities for lightning-fast retrieval
- **Modern .NET 10 API** - Built on the latest .NET technology stack
- **Cross-Origin Support** - Ready for integration with frontend applications

## 🛠️ Tech Stack

- **.NET 10** - Latest framework with top performance
- **MongoDB Driver 3.3.0** - Robust database connectivity
- **Microsoft.Extensions.AI** - Seamless AI integration
- **Ollama Integration** - Local embedding generation
- **Vector Search** - Sophisticated similarity matching

## 🔍 How It Works

1. User submits a natural language search query
2. The API generates vector embeddings from the query using `mxbai-embed-large`
3. MongoDB's vector search finds movies with similar plot embeddings
4. Results are returned, sorted by semantic relevance

## 📋 Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Ollama](https://ollama.ai/) with `mxbai-embed-large` model

## 🚦 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/SemanticFlix.git
   cd SemanticFlix
   ```

2. Configure MongoDB connection:
   ```json
   // appsettings.json
   {
     "ConnectionStrings": {
       "MongoDb": "your_connection_string_here"
     }
   }
   ```

3. Ensure Ollama is running with the required model:
   ```bash
   ollama pull mxbai-embed-large
   ollama run mxbai-embed-large
   ```

4. Run the application:
   ```bash
   cd Movies.Search.Api
   dotnet run
   ```

5. The API will be available at:
   - http://localhost:5243/api/movies
   - https://localhost:7032/api/movies

## 🔌 API Usage

**Basic Search:**
```http
GET /api/movies?term=space+adventure&limit=5
```

**Without Search Term (Returns Random Movies):**
```http
GET /api/movies?limit=10
```

## 💡 Project Structure

- `Models/` - MongoDB document models
- `Services/` - Business logic and data access
  - `MovieService.cs` - Handles movie retrieval and search
  - `MovieEmbeddingsGenerator.cs` - Background service for embedding generation

## 🌱 Future Enhancements

- User profiles and personalized recommendations
- Advanced filtering options (genre, year, actors)
- Recommendation engine based on watch history
- Frontend application for seamless user experience

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- [MongoDB Sample Dataset](https://www.mongodb.com/docs/atlas/sample-data/sample-mflix/) for providing the movie data
- The team at Anthropic for Claude, which helped generate this README

---

<p align="center">
  <i>Find your next favorite movie with just a description.</i>
</p>
