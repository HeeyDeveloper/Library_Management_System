# 📚 Library Management System

> A complete **Library Management System** built using **C#**, **ADO.NET**, **SQL Server**, and **Stored Procedures**. This project demonstrates real-world CRUD operations, database relationships, object-oriented programming, SQL joins, and console application development through Reader and Book Management modules.

---

# ✨ Features

## 👤 Reader Management

### ➕ Add Reader
Store reader information including:

- Reader ID
- Reader Name
- Phone Number
- Residential Address
- Issued Book
- Return Date

### ✏️ Update Reader
Update existing reader details:

- Reader Name
- Phone Number
- Address
- Issued Book
- Return Date

### 📋 View All Readers
Display:

- Reader Information
- Issued Book Details
- Author Name
- Category
- Return Date

### 🔍 Search Reader By ID
Retrieve a reader record instantly using:

```text
Reader ID
```

### ❌ Delete Reader
Delete reader records safely using:

```text
Record Preview
Confirmation Prompt
Permanent Deletion
```

---

## 📖 Book Management

### ➕ Add Book

Store:

- Book ID
- Book Name
- Author Name
- Category

### ✏️ Update Book

Modify:

- Book Name
- Author Name
- Category

### 📋 View All Books

Display:

- Book Information
- Reader Information
- Return Date

### 🔍 Search Book By ID

Search using:

```text
Book ID
```

### ❌ Delete Book

Features:

```text
Book Preview
Confirmation Prompt
Permanent Deletion
```

---

# 🛠️ Technical Stack

## 💻 Language & Framework

| Technology | Description |
|------------|-------------|
| C# | Programming Language |
| .NET Framework | Application Runtime |
| Console Application | User Interface |
| Visual Studio 2022 | Development Environment |

---

## 🗄️ Database

| Component | Purpose |
|------------|---------|
| SQL Server | Data Storage |
| Stored Procedures | CRUD Operations |
| Foreign Keys | Relationship Management |
| SQL Joins | Data Retrieval |

### Database Relationship

```text
Book
 │
 │ (BookID)
 ▼
Readers
```

One Book can be associated with multiple Reader records.

---

## 🔌 ADO.NET Components

| Class | Purpose |
|---------|---------|
| SqlConnection | Database Connection |
| SqlCommand | Execute Procedures |
| SqlParameter | Parameter Handling |
| SqlDataReader | Read Records |

---

## 📦 Generic Collections

The project uses:

```csharp
List<T>
```

to store records retrieved from SQL Server before displaying them.

---

## 🧠 OOP Concepts Applied

### ✅ Classes & Objects

Models used:

```text
AddReaders
ViewAllReader
SearchReaderByID
DeleteReader

AddBook
ViewBook
SearchBook
DeleteBook
```

### ✅ Constructors

Used for object initialization.

### ✅ Encapsulation

Data wrapped into strongly typed objects.

### ✅ Resource Management

```csharp
using()
```

used with:

- SqlConnection
- SqlCommand
- SqlDataReader

---

# 🗂️ Project Structure

```text
Library_Management_System
│
├── Program.cs
│
├── Models
│   ├── AddReaders.cs
│   ├── ViewAllReader.cs
│   ├── SearchReaderByID.cs
│   ├── DeleteReader.cs
│   ├── AddBook.cs
│   ├── ViewBook.cs
│   ├── SearchBook.cs
│   └── DeleteBook.cs
│
├── SQL Scripts
│   ├── Readers & Book Table.sql
│   ├── sp_Reader_Management_System.sql
│   ├── sp_Book_Management_System.sql
│   └── sp_Library_Management_System.sql
│
└── Database
```

---

# 🗄️ Database Setup

## Create Database

```sql
CREATE DATABASE Library_Management_System;
GO

USE Library_Management_System;
GO
```

---

## 📖 Book Table

```sql
CREATE TABLE Book
(
    BookID INT PRIMARY KEY,
    Book_Name VARCHAR(50),
    Author_Name VARCHAR(100),
    Category VARCHAR(50)
);
```

---

## 👤 Readers Table

```sql
CREATE TABLE Readers
(
    ReaderID INT,
    Reader_Name VARCHAR(150),
    Reader_Phone_Number BIGINT,
    Reader_Address VARCHAR(300),
    BookID INT FOREIGN KEY REFERENCES Book(BookID),
    Return_Date DATE
);
```

---

## 📚 Sample Book Records

```sql
INSERT INTO Book VALUES
(1,'C# Programming','John Smith','Programming'),
(2,'SQL Basics','Mike Ross','Database'),
(3,'Python for Beginners','David Miller','Programming'),
(4,'Data Structures','Robert Brown','Computer Science'),
(5,'Java Fundamentals','James Wilson','Programming'),
(6,'The Alchemist','Paulo Coelho','Fiction'),
(7,'Wings of Fire','A P J Abdul Kalam','Biography'),
(8,'Rich Dad Poor Dad','Robert Kiyosaki','Finance'),
(9,'Think and Grow Rich','Napoleon Hill','Self Help'),
(10,'Atomic Habits','James Clear','Self Help');
```

---

## 👥 Sample Reader Records

```sql
INSERT INTO Readers VALUES
(1,'Rahul Kumar',9876543210,'Bengaluru',1,'2026-06-20'),
(2,'Priya Singh',9876543211,'Bengaluru',3,'2026-06-22'),
(3,'Aman Verma',9876543212,'Bengaluru',5,'2026-06-18');
```

---

# ⚙️ Stored Procedure Architecture

## 👤 Reader Management Procedure

### Procedure Name

```sql
sp_Reader_Management_System
```

### Operations

| Option | Operation |
|----------|-----------|
| 1 | Add Reader |
| 2 | Update Reader |
| 3 | View All Readers |
| 4 | Delete Reader |
| 5 | Search Reader By ID |

### SQL Logic

```text
INSERT
UPDATE
INNER JOIN
DELETE
SEARCH
```

---

## 📖 Book Management Procedure

### Procedure Name

```sql
sp_Book_Management_System
```

### Operations

| Option | Operation |
|----------|-----------|
| 1 | Add Book |
| 2 | Update Book |
| 3 | View All Books |
| 4 | Delete Book |
| 5 | Search Book By ID |

### SQL Logic

```text
INSERT
UPDATE
LEFT JOIN
DELETE
SEARCH
```

---

## 🏛️ Main Procedure

### Procedure Name

```sql
sp_Library_Management_System
```

Acts as central controller.

```text
1 → Reader Management
2 → Book Management
3 → Exit Application
```

---

# 🖥️ Application Flow

## Main Menu

```text
╔══════════════════════════════════════════════════════════════════════════╗
║                         LIBRARY MANAGEMENT SYSTEM                       ║
╚══════════════════════════════════════════════════════════════════════════╝

[1] Reader Management
[2] Book Management
[3] Exit Application
```

---

## Reader Menu

```text
[1] Add Reader
[2] Update Reader
[3] View All Readers
[4] Delete Reader
[5] Search Reader By ID
[6] Exit Reader Management
```

---

## Book Menu

```text
[1] Add Book
[2] Update Book
[3] View All Books
[4] Delete Book
[5] Search Book By ID
[6] Exit Book Management
```

---

# 🚀 How To Run

## Clone Repository

```bash
git clone https://github.com/HeeyDeveloper/Library_Management_System.git
```

---

## Configure SQL Server

Update connection string:

```csharp
SqlConnection cn = new SqlConnection(
"DATA SOURCE=YOUR_SERVER_NAME;
INITIAL CATALOG=Library_Management_System;
INTEGRATED SECURITY=SSPI");
```

---

## Execute SQL Scripts

Run in order:

```text
1. Readers & Book Table.sql
2. sp_Reader_Management_System.sql
3. sp_Book_Management_System.sql
4. sp_Library_Management_System.sql
```

---

## Build Project

```text
Ctrl + Shift + B
```

---

## Run Application

```text
F5
```

---

# 🎯 Concepts Demonstrated

✅ CRUD Operations

✅ SQL Server Integration

✅ Stored Procedures

✅ SQL Joins

✅ ADO.NET

✅ SqlDataReader

✅ Generic Collections

✅ Object-Oriented Programming

✅ Parameterized Queries

✅ Foreign Keys

✅ Console Application Development

---

# 🔮 Future Enhancements

### 📅 Fine Management

```text
Late Return Tracking
Automatic Fine Calculation
Payment Tracking
```

### 📊 Reports Module

```text
Most Issued Books
Available Books
Reader Activity
Overdue Books
```

### 🔐 Authentication

```text
Admin Login
Librarian Login
Role-Based Access
```

### 🌐 Enterprise Upgrade

```text
ASP.NET Core MVC
REST APIs
JWT Authentication
Entity Framework Core
Azure Deployment
```

---

# ⭐ Support

If this project helped you:

⭐ Star Repository

🍴 Fork Repository

🛠️ Contribute

📢 Share With Others

---

# 👨‍💻 Author

## Ayush Singh

💻 Software Developer

📚 C# | .NET | SQL Server

🚀 Building Enterprise Applications Through Hands-On Projects

---

# 📜 License

This project is intended for educational and learning purposes.
