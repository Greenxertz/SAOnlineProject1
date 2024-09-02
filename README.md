# SAOnlineProject1
# SA Online Mart

## Project Overview

SA Online Mart is an e-commerce platform designed to promote local South African products by providing an intuitive online shopping experience. The application allows users to browse products, manage their shopping cart, and complete purchases while ensuring a seamless experience. With a focus on user-friendly design and efficient product management, SA Online Mart aims to support local businesses and make shopping convenient for customers.

### Key Features
- User authentication and account management
- Product browsing and search functionality
- Shopping cart management
- Admin panel for product management
- Responsive design for desktop users

## Setup Instructions

To get started with the SA Online Mart project, follow these steps:

### Prerequisites
- .NET 6 or later
- SQL Server or compatible database
- Visual Studio

### Installation Steps

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Greenxertz/SAOnlineProject1.git
   cd SAOnlineProject1
   ```



2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure the database**:
   - Open the `appsettings.json` file and update the `DefaultConnection` string with your database connection details.
   - Create the database using Entity Framework migrations:
   ```bash
   dotnet ef database update
   ```
incase I have created a script for the [Database](Database_script) but there is no data.
I hav also inlcuded the script to insert the [Database Data](resources.sql).

4. **Run the application**:
   ```bash
   dotnet run
   ```
   - Navigate to `https://localhost:5001` in your web browser to access the application, however visual studio should automatically open the browser to the page.

## Contribution Guidelines

We welcome contributions to SA Online Mart! To get involved, please follow these guidelines:

1. **Fork the repository**: Create a personal copy of the repository on GitHub.
2. **Create a feature branch**: 
   ```bash
   git checkout -b feature/YourFeatureName
   ```
3. **Make your changes**: Implement your feature or fix.
4. **Commit your changes**:
   ```bash
   git commit -m "Add your commit message here"
   ```
5. **Push to the branch**:
   ```bash
   git push origin feature/YourFeatureName
   ```
6. **Open a Pull Request**: Submit a pull request detailing your changes and why they should be merged.

### Code of Conduct

Please adhere to our [Code of Conduct](CODE_OF_CONDUCT) in all interactions and contributions to this project.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
