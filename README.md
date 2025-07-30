# TaskMaster Pro - Professional Todo Application

A modern, feature-rich task management application built with ASP.NET Core 8.0, Entity Framework Core, and Bootstrap 5. This project demonstrates professional software development practices and modern web application architecture.

## 🚀 Features

### Core Functionality

- **User Authentication** - Secure registration and login system
- **Task Management** - Create, edit, delete, and toggle task completion
- **Advanced Task Properties**:
  - Categories for organization
  - Priority levels (Low, Medium, High, Urgent)
  - Due dates with overdue tracking
  - Detailed descriptions
  - Completion timestamps

### User Experience

- **Modern UI** - Professional Bootstrap 5 interface with Font Awesome icons
- **Responsive Design** - Works seamlessly on desktop, tablet, and mobile
- **Real-time Search** - Instant task filtering by title and description
- **Category Filtering** - Organize tasks by custom categories
- **Statistics Dashboard** - Visual overview of task completion metrics
- **AJAX Interactions** - Smooth task toggling without page refreshes

### Technical Features

- **Database Persistence** - SQLite database with Entity Framework Core
- **Service Layer Architecture** - Clean separation of concerns
- **Data Validation** - Comprehensive input validation and error handling
- **Security** - CSRF protection, authentication, and authorization
- **RESTful API Endpoints** - JSON API for AJAX operations

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 8.0 MVC
- **Database**: SQLite with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Frontend**: Bootstrap 5, Font Awesome, jQuery
- **Architecture**: MVC with Service Layer pattern

## 📋 Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- Git (for version control)

## 🚀 Getting Started

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd TodoApp
   ```

2. **Restore packages**

   ```bash
   dotnet restore
   ```

3. **Run the application**

   ```bash
   dotnet run
   ```

4. **Access the application**
   - Open your browser and navigate to `https://localhost:7xxx` (port will be displayed in console)
   - Register a new account or use the demo credentials

## 🏗️ Project Structure

```
TodoApp/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   └── TodoController.cs
├── Data/                 # Database Context
│   └── ApplicationDbContext.cs
├── Models/               # Data Models
│   ├── TodoItem.cs
│   └── ErrorViewModel.cs
├── Services/             # Business Logic Layer
│   ├── ITodoService.cs
│   └── TodoService.cs
├── Views/                # Razor Views
│   ├── Home/
│   ├── Todo/
│   └── Shared/
├── wwwroot/              # Static Files
└── Program.cs            # Application Entry Point
```

## 🎯 Key Features Showcase

### Dashboard & Statistics

- Visual task completion metrics
- Category-based organization
- Priority-based task sorting
- Overdue task tracking

### Advanced Task Management

- Rich task creation with multiple properties
- Inline editing capabilities
- Bulk operations support
- Search and filtering

### Professional UI/UX

- Modern gradient design
- Intuitive navigation
- Responsive layout
- Accessibility features

## 🔧 Configuration

### Database

The application uses SQLite by default. To use a different database:

1. Update the connection string in `appsettings.json`
2. Install the appropriate Entity Framework provider
3. Update `Program.cs` to use the new provider

### Authentication

Identity settings can be customized in `Program.cs`:

- Password requirements
- Account confirmation settings
- Lockout policies

## 🧪 Testing

The application includes comprehensive validation and error handling:

- Model validation with data annotations
- Client-side validation with jQuery
- Server-side validation and sanitization
- CSRF protection

## 📈 Performance Features

- Database indexing for optimal query performance
- Lazy loading for related entities
- Efficient AJAX operations
- Optimized Bootstrap and Font Awesome loading

## 🔒 Security

- ASP.NET Core Identity for authentication
- Anti-forgery tokens for CSRF protection
- Input validation and sanitization
- Secure password hashing
- Authorization-based access control

## 🎨 Customization

The application is designed for easy customization:

- CSS custom properties for theming
- Modular service architecture
- Configurable validation rules
- Extensible model properties

## 📱 Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)
- Mobile browsers (iOS Safari, Chrome Mobile)

## 🤝 Contributing

This is a portfolio project, but suggestions and improvements are welcome:

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👨‍💻 Developer

**[Your Name]**

- LinkedIn: linkedin.com/in/echem-izakahr-07456927a/
- GitHub: github.com/Crackr25
- Email: izakahr25@gmail.com

---

_This project demonstrates modern web development practices including clean architecture, responsive design, database integration, authentication, and professional UI/UX design. It showcases proficiency in ASP.NET Core, Entity Framework, Bootstrap, and full-stack web development._
