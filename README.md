# FarmCentral

README

Prototype Web Application - Farmers Database

Overview:

The purpose of this prototype web application is to demonstrate a system that manages a database of farmers and their associated products. The application provides two user roles: farmer and employee. Farmers can add new products to their profile, while employees can add new farmers to the database, view all products supplied by a specific farmer, and filter the list based on date range or product type.

Functionality:

User roles: Farmer and Employee.
User authentication: Users must log in to access user-specific information.
Farmer functionality: Farmers can add new products to their profile.
Employee functionality: Employees can add new farmers, view all products supplied by a specific farmer, and filter the product list based on date range or product type.

Prerequisites:

To build and run the prototype, you will need the following:

Visual Studio: Download and install Visual Studio from the official Microsoft website (https://visualstudio.microsoft.com/). The Community edition should suffice for this prototype.
.NET Framework: Ensure that you have the latest version of the .NET Framework installed.

Database Setup:

Create a new SQL Server database using SQL Server Management Studio or any other tool. I named it “ProgData_ST10091525”.

Design the database schema with the following tables:

Farmers table: Fields - ID, Name, Surname, Trading Name, Phone, Cellphone, Email and Date.
Products table: Fields - ID, Product Name, Product Description, Product Price, Product Quantity, Farmer Name, Farmer Phone, Farmer Cellphone, Farmer Email and Date.
Define appropriate data types and constraints.

Connection String Configuration:

Open the Visual Studio project.
Locate the web.config or app.config file, depending on the project type.
Update the connection string in the configuration file to point to your “Database".
All tables created are connected and saved to the Database.

Build and Run Steps:

Open the Visual Studio solution file (.sln) for the prototype project.
Build the solution to ensure all dependencies are resolved.
Press F5 or use the "Start" button to run the application.
The prototype web application will launch in your default web browser.
On the Home Screen the user will have the option to click on either “Employee” or “Farmer” to log into the application.
Both Users(Employee and Farmer) will have to log in to view additional information in on the application.
Each User will be able to explore the functionality of the application according to the user role.
Employees can add new farmers to the database, view all products supplied by a specific farmer, and filter the list based on date range or product type.
Farmers can add new products to their profile.
Employees will have the opportunity to EDIT and DELETE Farmers Data.
Farmers will also have the opportunity to EDIT and DELETE Product Data.

The prototype website is designed to be easy to use, focusing on the following aspects:

Clear and intuitive navigation: The website features a well-organized navigation structure with clear and descriptive labels for menus and buttons, making it easy for users to find the desired functionality. 
Consistent layout and design: The website maintains a consistent layout and design across its pages, ensuring a cohesive user experience. Users can quickly understand and navigate different sections of the site due to the consistent visual elements. 
Responsive and accessible design: The website is optimized to adapt to different screen sizes and devices, ensuring that users can access and use it effectively on desktop and mobile devices. Content is legible, buttons and links are easily clickable, and form inputs are easy to interact with, regardless of the device being used. 
Intuitive forms: Forms are designed with clear labels and placeholders, providing helpful hints or examples when necessary. Real-time validation of user inputs and clear error messages ensure that users can easily provide accurate information and understand any issues that may occur during form submissions. 
Visual feedback and confirmation: The website provides visual feedback to users when they perform actions such as adding a new farmer or product. Confirmation messages or notifications are displayed to indicate the successful completion of tasks, providing users with a sense of confidence and assurance. 
Search and filter functionality: The website offers an intuitive search and filtering mechanism that allows employees to quickly find specific farmers or products based on their requirements. Clear labels and multiple filter criteria options make it easy for users to refine their search and get relevant results. 
Error handling: Robust error handling is implemented throughout the website. Clear and descriptive error messages guide users on how to resolve issues, helping them understand and overcome any obstacles they may encounter. 
Help and documentation: The website includes a help section and provides tooltips or contextual information to guide users on how to use different features. User documentation and tooltips explain the purpose and usage of various functionalities, enabling users to navigate the website with ease. 
Testing and user feedback: Usability testing is conducted to gather feedback on the ease of use. User feedback is taken into account to refine and improve the website's usability, ensuring that it meets the needs and expectations of its intended users. 
The prototype website has been designed with these considerations to ensure a user-friendly experience, making it easy for farmers and employees to navigate, interact with, and accomplish their tasks effectively.

Known Issues/Limitations:

Proper validation and error handling have been omitted for brevity.
The design and styling of the website may be basic and can be improved for a real-world application.
