
# Loger

Social network for sharing logos, designs etc.

![Logo](https://raw.githubusercontent.com/MTrajK/Loger/master/images/logo.png "Logo")

## Installing

To run/install this application, you'll need:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
- After installing these tools, you'll need a database structure. You can uncomment [this code](https://github.com/MTrajK/Loger/blob/master/src/Loger.DAL/Setup/LogerInitializer.cs) when the app is started for the first time, or you can execute [this SQL command](https://github.com/MTrajK/Loger/blob/master/src/Loger.DAL/Setup/logerSeed.sql) by yourself.

## Description

Simple social network with responsive design for sharing and exploring logos, designs, etc. Inspired by [Dribbble](https://dribbble.com/) and [Behance](https://www.behance.net/).

Functionalities:

- Create a new user
- Update the user profile (upload a profile picture, change the password, etc)
- Upload a new post (logo, design) with a title and a description
- Comment and like/fave posts
- Visit and follow some other users (all user's profiles are public)
- 3 main tabs: Home (all newest posts), Following (the newest posts from the following users), Favorites (all liked posts)

## Repo structure

- [images](images) - several screenshots from the application
- [src](src) - the source code of the application

## Tech/frameworks

- [N-tier architecture](https://en.wikipedia.org/wiki/Multitier_architecture) - Implemented with three-tier architecture: [Presentation tier](https://github.com/MTrajK/Loger/blob/master/src/Loger.UI) (UI level, all front-end things), [Application tier](https://github.com/MTrajK/Loger/blob/master/src/Loger.BLL) (Business logic), [Data tier](https://github.com/MTrajK/Loger/blob/master/src/Loger.DAL) (Database access)
- [ASP.NET MVC](https://dotnet.microsoft.com/apps/aspnet/mvc) - Web application framework developed by Microsoft
- [Entity Framework](https://docs.microsoft.com/en-us/ef/) - Framework used for interaction between .NET applications and relational databases
- [Knockout.js](https://knockoutjs.com/) - JavaScript framework, MVVM pattern
- [Bootstrap](http://materializecss.com/) - Responsive front-end framework
- [jQuery AJAX](http://api.jquery.com/jquery.ajax/) - Perform an asynchronous HTTP (Ajax) request (used for communication between the backend APIs and the client)

## License

This project is licensed under the MIT - see the [LICENSE](LICENSE) file for details

## Screenshots

![Log in](https://raw.githubusercontent.com/MTrajK/Loger/master/images/login_form.png "Log in")

![Home page](https://raw.githubusercontent.com/MTrajK/Loger/master/images/home_page.png "Home page")

![User page](https://raw.githubusercontent.com/MTrajK/Loger/master/images/user_page.png "User page")

![Logo review](https://raw.githubusercontent.com/MTrajK/Loger/master/images/logo_review.png "Logo review")

![Upload picture"](https://raw.githubusercontent.com/MTrajK/Loger/master/images/upload_picture.png "Upload picture")

![User settings page](https://raw.githubusercontent.com/MTrajK/Loger/master/images/user_settings_page.png "User settings page")