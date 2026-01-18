# movgame.Wpf

This is a WPF application for the movgame project.

## Features

- **Game Play:** The main feature of the application is the game itself. The user can control a character using the arrow keys.
- **Title Screen:** The application starts with a title screen.
- **Game View:** The main game is played in this view.
- **Configuration:** The application has a configuration screen to adjust settings.
- **Game Over and Stage Clear:** The game displays dialogs for game over and stage clear conditions.

## Architecture

The application is built using the **Prism** framework, following the **MVVM (Model-View-ViewModel)** design pattern.

- **Views:** The UI is defined in XAML files (`.xaml`).
- **ViewModels:** The logic for the views is implemented in ViewModel classes.
- **Models:** The data and business logic are encapsulated in Model classes.
- **Services:** Services are used to provide functionality to ViewModels, such as game logic (`GameService`).
- **Dependency Injection:** Prism's dependency injection container is used to manage the creation and lifetime of objects, such as services and ViewModels.
- **Navigation:** Prism's region-based navigation is used to switch between different views.
