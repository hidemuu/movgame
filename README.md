# movgame

This is the repository for the movgame application.

## Solution Structure

The solution is organized into several projects, following a layered architecture pattern.

### Presentation Layer

-   `app/movgame.Web`: ASP.NET Core web application.
-   `app/movgame.WinForm`: Windows Forms application.
-   `app/movgame.Wpf`: WPF application (main entry point).
-   `src/presentations/movgame.Wpf.Views`: Contains the views for the WPF application.
-   `src/presentations/movgame.Wpf.ViewModels`: Contains the view models for the WPF application.
-   `src/presentations/movgame.Wpf.Models`: Contains the models for the WPF application.
-   `src/presentations/movgame.WinForm.ViewModels`: Contains the view models for the WinForm application.

### Application Layer

-   `src/applications/movgame.Service`: Contains the core application logic and services.
-   `src/applications/movgame.Repository`: Defines the repository interfaces for data access.

### Domain Layer

-   `src/domains/movgame.Models`: Contains the core domain models and business logic.

### Infrastructure Layer

-   `src/infrastructures/movgame.Utilities`: Provides common utility functions.
-   `src/infrastructures/movgame.ViewControls.Wpf`: Contains custom WPF view controls.
-   `src/infrastructures/movgame.ViewDesigns.Wpf`: Contains WPF design assets.
-   `app/movgame/movgame.csproj`: A console application, purpose to be determined.
