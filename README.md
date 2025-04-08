# 📘 Book Management Console App (C# .NET Core)

A simple yet powerful console-based Book Management System built using **C# and .NET Core**. This project demonstrates core C# concepts such as OOP, LINQ, Dependency Injection, AutoMapper, async/await, and input validation. Two versions are implemented: **In-Memory Storage** and **Persistent JSON File Storage**.

---

## 🚀 Features

✅ Add New Book  
✅ Search Book by ID or (Title + Author)  
✅ Borrow Book  
✅ Return Book  
✅ Edit Book  
✅ Delete Book  
✅ List All Books  
✅ Input Validation & Error Handling  
✅ Dual Storage: In-Memory & JSON File  
✅ Follows Clean Architecture Principles

---

## 🛠️ Technologies Used

- **.NET Core 6**
- **C#**
- **LINQ**
- **Async/Await**
- **AutoMapper**
- **Dependency Injection**
- **Visual Studio 2022**

---

## 📁 Project Structure
/BookManagementApp │ ├── Models/ │ └── Book.cs │
├── DTOs/ │ └── BookDTO.cs │ ├── Services/ │ ├── IBookService.cs │ 
├── BookService.cs # For In-Memory │ └── JsonBookService.cs # For JSON Storage │
├── books.json # For JSON data storage │ ├── Program.cs # Main app logic & DI config │ └── README.md

---

## 💡 Concepts Covered

- **Object-Oriented Programming (OOP)**  
- **Interfaces & Abstraction**  
- **LINQ for Data Querying**  
- **Async File I/O**  
- **AutoMapper for DTO ↔ Model mapping**  
- **Dependency Injection (DI)**  
- **User Input Validation & Exception Handling**  
- **Modular & Maintainable Code**

---

## 🧪 Sample Scenarios

1. **Add a Book:**
   - Enter ID, Title, and Author.
2. **Search by ID or Title+Author:**
   - Smart input system detects what you provide.
3. **Borrow/Return:**
   - Tracks availability using `IsAvailable` flag.
4. **Edit/Delete:**
   - Modify or remove a book entry.

---

## 📌 How to Run

1. Open the solution in **Visual Studio 2022**.
2. Choose the version (`BookService` or `JsonBookService`) by registering it in `Program.cs`.
3. Run the project.
4. Follow the interactive menu in the console.

---

## 🙋‍♂️ Author

**Pratik Lakade .**  
.NET Developer | WPF | MVVM | C# | SQL | Backend Systems  

---
