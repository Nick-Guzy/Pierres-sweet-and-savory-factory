# Project Name
Dr. Silly String
# Contributor name
Nicholas Guzy
# Description
The application will represent a wepage to handle Dr. Silly String's database for machines, engineers, and which of each belong to each other. 
# Link to website
https://github.com/NicksFed/Dr-Silly-String.git
# Technologies used:
* C#
* .NET6
* MySQL
* EF Core
* Razor
* ASP
# Setup steps
1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory called "Dr-Silly-String". 
4. Add Entity Framework Core packages: $ dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0 
                                       $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0
5. Create the file appsettings.json file in your project directory, configure it with the following code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[databasename];uid=[username];pwd=[password];"
  }
} 
and input the database name for [databasename], your username for [username], and password for [password]
6. In the production directory run dotnet watch run to use the application
# Known bugs
None
# License information with copyright and date
Copyright <2023> <Nicholas Guzy>
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.