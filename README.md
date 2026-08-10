BeyondTheBarcode
│
├── BeyondTheBarcode.API              → Presentation Layer (Entry Point)
│   ├── Controllers
│   ├── Extensions
│   │   ├── ServiceCollectionExtensions.cs
│   │   └── ApplicationBuilderExtensions.cs   (optional - for middleware later)
│   ├── Middleware (future - Global Exception)
│   ├── Program.cs
│   └── appsettings.json
│
├── BeyondTheBarcode.Application      → Business Logic Layer
│   ├── DTOs
│   ├── Interfaces
│   │   ├── IServices
│   │   ├── IRepositories
│   │   └── IUnitOfWork
│   ├── Services
│   └── DependencyInjection (optional)
│
├── BeyondTheBarcode.Domain           → Core Entities
│   ├── Entities
│   └── Common (BaseEntity, etc.)
│
├── BeyondTheBarcode.Persistence      → Data Access Layer
│   ├── Data (DbContext)
│   ├── Repositories
│   ├── UnitOfWork
│   └── DependencyInjection (optional)
│
└── BeyondTheBarcode.UI (React)       → Frontend (Completed ✅)
    ├── Components
    ├── Pages
    ├── Services (Axios)
    ├── Routes
    └── Layout
