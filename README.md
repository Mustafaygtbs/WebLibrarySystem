# WebLibrarySystem

WebLibrarySystem is a web-based library management system that allows users to search for books, borrow them, and view detailed information about each book. This project is developed using .NET Core MVC and employs Entity Framework for database operations.

## Features

- **Book Search:** Users can search for books by title, author, or category.
- **Book Details:** Detailed information about each book can be viewed.
- **Borrowing and Returning:** Users can borrow books and return them. The status of borrowed books and their return dates can be tracked.
- **User Management:** Users can register, log in, and update their profile information.
- **Admin Panel:** Administrators can add new books, edit existing ones, and manage user accounts.
- **Notification System:** Users receive notifications when the due date for returning borrowed books approaches.
- **Security:** User passwords are securely stored using the SHA-256 algorithm.

## Technologies

The project uses the following main technologies:
- **Backend:** .NET Core 5.0 MVC
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Other Tools:** Git, Visual Studio, Postman (for API testing)

## Usage

### Home Page

The home page features the most popular books, newly added books, and recommended books. Users can browse these books and access their details.

### Book Search

Use the search bar to find books by title, author, or category. The results are displayed in a filtered list.

### Book Details

Clicking on a book shows detailed information, including author, publisher, publication year, ISBN, etc. The page also displays the book's status (available or borrowed) and borrowing options.

### Borrowing

After logging in, users can borrow available books. The borrowing process depends on the book's availability and the user's current borrowing privileges.

### Admin Operations

Admins can add new books, edit existing ones, or delete them. They can also manage user accounts and create new admin accounts.

## Database Structure

The database includes the following main tables:

- **Users:** Contains user information (first name, last name, email, password hash, etc.).
- **Books:** Stores detailed information about the books.
- **Borrowing Transactions:** Tracks borrowed books and their return dates.
- **Categories:** Lists the categories to which books belong.
