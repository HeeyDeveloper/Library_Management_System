using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                         LIBRARY MANAGEMENT SYSTEM                        ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("Welcome! Please choose an option to continue:");
                Console.WriteLine();
                Console.WriteLine("[1] ----> Reader Management");
                Console.WriteLine("[2] ----> Book Management");
                Console.WriteLine("[3] ----> Exit Application");
                Console.WriteLine();

                using (SqlConnection cn = new SqlConnection("data source = YASH\\SQLEXPRESS; initial catalog = Library_Management_System; integrated security = sspi"))
                {
                    cn.Open();
                    //---------------------- Library Managemenet Command System ----------------------
                    using (SqlCommand cmd = new SqlCommand("sp_Library_Management_System", cn))
                    {
                        Console.Write("Enter your choice (1-3): ");
                        int UserChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //---------------------- Reader Managemenet Command System ----------------------
                        using (SqlCommand ReaderCommand = new SqlCommand("sp_Reader_Management_System", cn))
                        {
                            ReaderCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            List<AddReaders> addReaders = new List<AddReaders>();

                            ReaderCommand.Parameters.Clear();

                            if (UserChoice == 1)
                            {
                                //---------------------- Reader Management System ----------------------
                                Console.Clear();
                                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("║                         READER MANAGEMENT SYSTEM                         ║");
                                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                Console.WriteLine();
                                Console.WriteLine("Select an operation:");
                                Console.WriteLine();
                                Console.WriteLine("[1] ----> Add Reader");
                                Console.WriteLine("[2] ----> Update Reader Information");
                                Console.WriteLine("[3] ----> View All Readers");
                                Console.WriteLine("[4] ----> Delete Reader");
                                Console.WriteLine("[5] ----> Search Reader By ID");
                                Console.WriteLine("[6] ----> Exit from Reader Management");
                                Console.WriteLine();
                                Console.Write("Enter your Choice (1-5): ");
                                int ReaderChoice = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                if (ReaderChoice == 1)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                                ADD NEW READER                            ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

                                    Console.WriteLine("\nEnter Reader Details");
                                    Console.WriteLine("--------------------------------------------------");

                                    Console.Write("Reader ID           : ");
                                    int ReaderID = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Reader Name         : ");
                                    string ReaderName = Console.ReadLine();

                                    Console.Write("Phone Number        : ");
                                    string ReaderPhoneNumber = Convert.ToString(Console.ReadLine());

                                    Console.Write("Residential Address : ");
                                    string ReaderAddress = Console.ReadLine();

                                    Console.Write("Enter Book ID Issued: ");
                                    int BookID = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Book Return Date (In the Format of YYYY-MM-DD): ");
                                    string BookReturnDate = Console.ReadLine();

                                    Console.WriteLine("--------------------------------------------------\n");

                                    SqlParameter[] AddReadersParameter =
                                    {
                                        new SqlParameter("@ReaderChoice", System.Data.SqlDbType.Int)
                                        {
                                            Value = ReaderChoice
                                        },
                                        new SqlParameter("@ReaderID", System.Data.SqlDbType.Int)
                                        {
                                            Value = ReaderID
                                        },
                                        new SqlParameter("@Reader_Name", System.Data.SqlDbType.VarChar, 150)
                                        {
                                            Value = ReaderName
                                        },
                                        new SqlParameter("@Reader_Phone_Number", System.Data.SqlDbType.BigInt)
                                        {
                                            Value = ReaderPhoneNumber
                                        },
                                        new SqlParameter("@Reader_Address", System.Data.SqlDbType.VarChar, 300)
                                        {
                                            Value = ReaderAddress
                                        },
                                        new SqlParameter("@BookID", System.Data.SqlDbType.Int)
                                        {
                                            Value = BookID
                                        },
                                        new SqlParameter("@Return_Date", System.Data.SqlDbType.Date)
                                        {
                                            Value = BookReturnDate
                                        }
                                    };
                                    ReaderCommand.Parameters.AddRange(AddReadersParameter);
                                    ReaderCommand.ExecuteNonQuery();
                                    Console.WriteLine();
                                    Console.WriteLine("==================================================");
                                    Console.WriteLine("      Reader details captured successfully.       ");
                                    Console.WriteLine("==================================================");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to return to the Main Menu...");
                                    continue;
                                }
                                else if (ReaderChoice == 2)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                          UPDATE EXISTING READER                          ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                    Console.WriteLine();
                                    Console.WriteLine("\nEnter Reader Details");
                                    Console.WriteLine("--------------------------------------------------");

                                    Console.Write("Reader Name         : ");
                                    string ReaderName = Console.ReadLine();

                                    Console.Write("Phone Number        : ");
                                    string ReaderPhoneNumber = Convert.ToString(Console.ReadLine());

                                    Console.Write("Residential Address : ");
                                    string ReaderAddress = Console.ReadLine();

                                    Console.Write("Enter Book ID Issued: ");
                                    int BookID = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Book Return Date (In the Format of YYYY-MM-DD): ");
                                    string BookReturnDate = Console.ReadLine();

                                    Console.WriteLine("--------------------------------------------------\n");

                                    SqlParameter[] UpdateReadersParameter =
                                    {
                                        new SqlParameter("@ReaderChoice", System.Data.SqlDbType.Int)
                                        {
                                            Value = ReaderChoice
                                        },
                                        new SqlParameter("@Reader_Name", System.Data.SqlDbType.VarChar, 150)
                                        {
                                            Value = ReaderName
                                        },
                                        new SqlParameter("@Reader_Phone_Number", System.Data.SqlDbType.BigInt)
                                        {
                                            Value = ReaderPhoneNumber
                                        },
                                        new SqlParameter("@Reader_Address", System.Data.SqlDbType.VarChar, 300)
                                        {
                                            Value = ReaderAddress
                                        },
                                        new SqlParameter("@BookID", System.Data.SqlDbType.Int)
                                        {
                                            Value = BookID
                                        },
                                        new SqlParameter("@Return_Date", System.Data.SqlDbType.Date)
                                        {
                                            Value = BookReturnDate
                                        }
                                    };

                                    ReaderCommand.Parameters.AddRange(UpdateReadersParameter);
                                    ReaderCommand.ExecuteNonQuery();
                                    Console.WriteLine();
                                    Console.WriteLine("==================================================");
                                    Console.WriteLine("       Reader details updated successfully.       ");
                                    Console.WriteLine("==================================================");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to return to the Main Menu...");
                                    continue;
                                }
                                else if (ReaderChoice == 3)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                               VIEW ALL READERS                           ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                    Console.WriteLine();

                                    SqlParameter[] ViewAllReadersParameters =
                                    {
                                        new SqlParameter("@ReaderChoice", System.Data.SqlDbType.Int)
                                        {
                                            Value = ReaderChoice
                                        }
                                    };
                                    ReaderCommand.Parameters.AddRange(ViewAllReadersParameters);

                                    using (SqlDataReader dr = ReaderCommand.ExecuteReader())
                                    {
                                        List<ViewAllReader> viewAllReaders = new List<ViewAllReader>();

                                        while (dr.Read())
                                        {
                                            int ReaderID = Convert.ToInt32(dr["ReaderID"]);
                                            string ReaderName = Convert.ToString(dr["Reader_Name"]);
                                            string ReaderPhoneNumber = Convert.ToString(dr["Reader_Phone_Number"]);
                                            string ReaderAddress = Convert.ToString(dr["Reader_Address"]);
                                            int BookID = Convert.ToInt32(dr["BookID"]);
                                            string BookName = Convert.ToString(dr["Book_Name"]);
                                            string AuthorName = Convert.ToString(dr["Author_Name"]);
                                            string Category = Convert.ToString(dr["Category"]);
                                            string ReturnDate = Convert.ToString(dr["Return_Date"]);

                                            ViewAllReader ReaderView = new ViewAllReader(ReaderID, ReaderName, ReaderPhoneNumber, 
                                                ReaderAddress,BookID, ReturnDate ,BookName, AuthorName, Category);
                                            viewAllReaders.Add(ReaderView);
                                        }
                                        foreach(ViewAllReader ReaderView in viewAllReaders)
                                        {
                                            Console.WriteLine($"Reader ID           : {ReaderView.ReaderID}");
                                            Console.WriteLine($"Reader Name         : {ReaderView.ReaderName}");
                                            Console.WriteLine($"Phone Number        : {ReaderView.ReaderPhoneNumber}");
                                            Console.WriteLine($"Residential Address : {ReaderView.ReaderAddress}");
                                            Console.WriteLine($"Issued Book ID      : {ReaderView.BookID}");
                                            Console.WriteLine($"Return Date of Book : {ReaderView.ReturnDate}");
                                            Console.WriteLine($"Issued Book Name    : {ReaderView.BookName}");
                                            Console.WriteLine($"Author Name         : {ReaderView.AuthorName}");
                                            Console.WriteLine($"Category            : {ReaderView.Category}");
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Press any key to return to the Main Menu...");
                                        Console.ReadLine();
                                        continue;
                                    }
                                }
                                else if (ReaderChoice == 4)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                               DELETE A READER                            ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                    Console.WriteLine();
                                    Console.Write("Enter Reader ID to delete: ");
                                    int ReaderID = Convert.ToInt32(Console.ReadLine());

                                    ReaderCommand.Parameters.Clear();

                                    SqlParameter[] DeleteReaderParameters =
                                    {
                                        new SqlParameter("@ReaderID", System.Data.SqlDbType.Int)
                                        {
                                            Value = ReaderID
                                        },
                                        new SqlParameter("@ReaderChoice", System.Data.SqlDbType.Int)
                                        {
                                            Value = 5
                                        }
                                    };
                                    ReaderCommand.Parameters.AddRange(DeleteReaderParameters);

                                    using (SqlDataReader DeleteDr = ReaderCommand.ExecuteReader())
                                    {
                                        List<DeleteReader> deleteReaders = new List<DeleteReader>();
                                        while (DeleteDr.Read())
                                        {
                                            int ReaderId = Convert.ToInt32(DeleteDr["ReaderID"]);
                                            string ReaderName = Convert.ToString(DeleteDr["Reader_Name"]);
                                            string ReaderPhoneNumber = Convert.ToString(DeleteDr["Reader_Phone_Number"]);
                                            string ReaderAddress = Convert.ToString(DeleteDr["Reader_Address"]);
                                            int BookID = Convert.ToInt32(DeleteDr["BookID"]);
                                            string ReturnDate = Convert.ToString(DeleteDr["Return_Date"]);
                                            string BookName = Convert.ToString(DeleteDr["Book_Name"]);
                                            string AuthorName = Convert.ToString(DeleteDr["Author_Name"]);
                                            string Category = Convert.ToString(DeleteDr["Category"]);

                                            DeleteReader deleteReader = new DeleteReader(ReaderID, ReaderName, ReaderPhoneNumber, ReaderAddress,
                                                BookID, ReturnDate, BookName, AuthorName, Category);

                                            deleteReaders.Add(deleteReader);
                                        }

                                        if(deleteReaders.Count > 0)
                                        {
                                            foreach (DeleteReader deleteReader in deleteReaders)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Reader ID           : {deleteReader.ReaderID}");
                                                Console.WriteLine($"Reader Name         : {deleteReader.ReaderName}");
                                                Console.WriteLine($"Phone Number        : {deleteReader.ReaderPhoneNumber}");
                                                Console.WriteLine($"Residential Address : {deleteReader.ReaderAddress}");
                                                Console.WriteLine($"Issued Book ID      : {deleteReader.BookID}");
                                                Console.WriteLine($"Return Date of Book : {deleteReader.ReturnDate}");
                                                Console.WriteLine($"Issued Book Name    : {deleteReader.BookName}");
                                                Console.WriteLine($"Author Name         : {deleteReader.AuthorName}");
                                                Console.WriteLine($"Category            : {deleteReader.Category}");
                                                Console.WriteLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No reader found with the provided ID. Deletion cannot proceed.");
                                            Console.WriteLine("Press any key to return to the Main Menu...");
                                            Console.ReadLine();
                                            continue;
                                        }

                                        Console.WriteLine("Are you sure you want to delete this Reader? (Y/N): ");
                                        string Confirmation = Console.ReadLine();

                                        if (Confirmation == "Y" || Confirmation == "y")
                                        {
                                            DeleteDr.Close();
                                            ReaderCommand.Parameters.Clear();

                                            SqlParameter[] ConfirmDeleteParameters =
                                            {
                                                new SqlParameter("@ReaderChoice", System.Data.SqlDbType.Int)
                                                {
                                                    Value = 4
                                                },
                                                new SqlParameter("@ReaderID", System.Data.SqlDbType.Int)
                                                {
                                                    Value = ReaderID
                                                }
                                            };
                                            ReaderCommand.Parameters.AddRange(ConfirmDeleteParameters);
                                            ReaderCommand.ExecuteNonQuery();

                                            Console.WriteLine();
                                            Console.WriteLine("==================================================");
                                            Console.WriteLine("       Reader details deleted successfully.       ");
                                            Console.WriteLine("==================================================");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to return to the Main Menu...");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Deletion cancelled. Returning to Main Menu...");
                                            Console.WriteLine("Press any key to return to the Main Menu...");
                                            Console.ReadLine();
                                            continue;
                                        }
                                    }
                                }
                                else if (ReaderChoice == 5)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                             SEARCH READER BY ID                          ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                    Console.WriteLine();
                                    Console.Write("Enter Reader ID to search: ");
                                    int ReaderID = Convert.ToInt32(Console.ReadLine());

                                    ReaderCommand.Parameters.Clear();

                                    SqlParameter[] SearchReaderByIDParameters =
                                    {
                                        new SqlParameter("@ReaderID", System.Data.SqlDbType.Int)
                                        {
                                            Value = ReaderID
                                        },
                                        new SqlParameter("@ReaderChoice", System.Data.SqlDbType.Int)
                                        {
                                            Value = 5
                                        }
                                    };
                                    ReaderCommand.Parameters.AddRange(SearchReaderByIDParameters);

                                    using(SqlDataReader SearchDr = ReaderCommand.ExecuteReader())
                                    {
                                        Console.WriteLine(SearchDr.HasRows);
                                        List<SearchReaderByID> searchReaders = new List<SearchReaderByID>();

                                        while (SearchDr.Read())
                                        {
                                            int ReaderId = Convert.ToInt32(SearchDr["ReaderID"]);
                                            string ReaderName = Convert.ToString(SearchDr["Reader_Name"]);
                                            string ReaderPhoneNumber = Convert.ToString(SearchDr["Reader_Phone_Number"]);
                                            string ReaderAddress = Convert.ToString(SearchDr["Reader_Address"]);
                                            int BookID = Convert.ToInt32(SearchDr["BookID"]);
                                            string ReturnDate = Convert.ToString(SearchDr["Return_Date"]);
                                            string BookName = Convert.ToString(SearchDr["Book_Name"]);
                                            string AuthorName = Convert.ToString(SearchDr["Author_Name"]);
                                            string Category = Convert.ToString(SearchDr["Category"]);

                                            SearchReaderByID searchReaderByID = new SearchReaderByID(ReaderID, ReaderName, ReaderPhoneNumber, ReaderAddress,
                                                BookID, ReturnDate, BookName, AuthorName, Category);

                                            searchReaders.Add(searchReaderByID);
                                        }
                                        if(searchReaders.Count > 0)
                                        {
                                            Console.WriteLine("Displaying Reader Data....\n");

                                            foreach (SearchReaderByID searchReader in searchReaders)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine($"Reader ID           : {searchReader.ReaderID}");
                                                Console.WriteLine($"Reader Name         : {searchReader.ReaderName}");
                                                Console.WriteLine($"Phone Number        : {searchReader.ReaderPhoneNumber}");
                                                Console.WriteLine($"Residential Address : {searchReader.ReaderAddress}");
                                                Console.WriteLine($"Issued Book ID      : {searchReader.BookID}");
                                                Console.WriteLine($"Return Date of Book : {searchReader.ReturnDate}");
                                                Console.WriteLine($"Issued Book Name    : {searchReader.BookName}");
                                                Console.WriteLine($"Author Name         : {searchReader.AuthorName}");
                                                Console.WriteLine($"Category            : {searchReader.Category}");
                                                Console.WriteLine();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No reader found with the provided ID.");
                                        }
                                    }
                                    Console.WriteLine("Press any key to return to Main Menu");
                                    Console.ReadLine();
                                    continue;
                                }
                                else if (ReaderChoice == 6)
                                {
                                    Console.WriteLine("Thank you for using Library Management System, GoodBye....!!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Choice! Please try again.");
                                    Console.ReadLine();
                                    continue;
                                }
                            }
                            //---------------------- Exit Application ----------------------
                            else if (UserChoice == 3)
                            {
                                Console.WriteLine("Thank you for using Library Management System, GoodBye....!!");
                                break;
                            }
                            //---------------------- Invalide Option ----------------------
                            else
                            {
                                Console.WriteLine("Invalid Choice! Please try again.");
                                Console.WriteLine("Press any key to return to the Main Menu...");
                                Console.ReadLine();
                                continue;
                            }
                        }

                        //---------------------- Book Managemenet Command System ----------------------
                        using (SqlCommand BookCommand = new SqlCommand("sp_Book_Management_System", cn))
                        {
                            BookCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            List<AddReaders> addBooks = new List<AddReaders>();

                            if (UserChoice == 2)
                            {
                                //---------------------- Book Managemenet System ----------------------
                                Console.Clear();
                                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("║                          BOOK MANAGEMENT SYSTEM                          ║");
                                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                Console.WriteLine();
                                Console.WriteLine("Select an operation:");
                                Console.WriteLine();
                                Console.WriteLine("[1] ----> Add Book");
                                Console.WriteLine("[2] ----> Update Book Information");
                                Console.WriteLine("[3] ----> View All Books");
                                Console.WriteLine("[4] ----> Delete Book");
                                Console.WriteLine("[5] ----> Search Book By ID");
                                Console.WriteLine("[6] ----> Exit from Book Management");
                                Console.WriteLine();
                                Console.Write("Enter your choice (1-5): ");
                                int BookChoice = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                if (BookChoice == 1)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                                  ADD NEW BOOK                            ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                }
                                else if (BookChoice == 2)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                           UPDATE EXISTING BOOK                           ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                }
                                else if (BookChoice == 3)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                                 VIEW ALL BOOKS                           ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                }
                                else if (BookChoice == 4)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                                 DELETE A BOOK                            ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                }
                                else if (BookChoice == 5)
                                {
                                    Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                                    Console.WriteLine("║                               SEARCH BOOK BY ID                          ║");
                                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                                }
                                else if (BookChoice == 6)
                                {
                                    Console.WriteLine("Thank you for using Library Management System, GoodBye....!!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Choice! Please try again.");
                                    Console.ReadLine();
                                    continue;
                                }
                            }
                            //---------------------- Exit Application ----------------------
                            else if (UserChoice == 3)
                            {
                                Console.WriteLine("Thank you for using Library Management System, GoodBye....!!");
                                break;
                            }
                            //---------------------- Invalide Option ----------------------
                            else
                            {
                                Console.WriteLine("Invalid Choice! Please try again.");
                                Console.WriteLine("Press any key to return to the Main Menu...");
                                Console.ReadLine();
                                continue;
                            }
                        }
                    }

                    cn.Close();
                    Console.ReadLine();
                }
            }
        }
    }
}

public class AddReaders
{ 
    public int ReaderID { get; set; }
    public string ReaderName { get; set; }
    public string ReaderPhoneNumber { get; set; }
    public string ReaderAddress { get; set; }
    public int BookID { get; set; }
    public string ReturnDate { get; set; }
    public string BookName { get; set; }
    public string AuthorName { get; set; }
    public string Category { get; set; }

    public AddReaders(int readerID, string readerName, string readerPhoneNumber, string readerAddress, string ReturnDate, int BookID ,string bookName, string authorName, string category)
    {
        this.ReaderID = readerID;
        this.ReaderName = readerName;
        this.ReaderPhoneNumber = readerPhoneNumber;
        this.ReaderAddress = readerAddress;
        this.BookID = BookID;
        this.ReturnDate = ReturnDate;
        this.BookName = bookName;
        this.AuthorName = authorName;
        this.Category = category;
    }
}

public class ViewAllReader
{
    public int ReaderID { get; set; }
    public string ReaderName { get; set; }
    public string ReaderPhoneNumber { get; set; }
    public string ReaderAddress { get; set; }
    public string ReturnDate { get; set; }
    public int BookID { get; set; }
    public string BookName { get; set; }
    public string AuthorName { get; set; }
    public string Category { get; set; }

    public ViewAllReader(int readerID, string readerName, string readerPhoneNumber, string readerAddress,int BookID, 
        string ReturnDate, string bookName, string authorName, string category)
    {
        this.ReaderID = readerID;
        this.ReaderName = readerName;
        this.ReaderPhoneNumber = readerPhoneNumber;
        this.ReaderAddress = readerAddress;
        this.BookID = BookID;
        this.ReturnDate = ReturnDate;
        this.BookName = bookName;
        this.AuthorName = authorName;
        this.Category = category;
    }
}
public class DeleteReader
{
    public int ReaderID { get; set; }
    public string ReaderName { get; set; }
    public string ReaderPhoneNumber { get; set; }
    public string ReaderAddress { get; set; }
    public string ReturnDate { get; set; }
    public int BookID { get; set; }
    public string BookName { get; set; }
    public string AuthorName { get; set; }
    public string Category { get; set; }

    public DeleteReader(int readerID, string readerName, string readerPhoneNumber, string readerAddress, int BookID,
        string ReturnDate, string bookName, string authorName, string category)
    {
        this.ReaderID = readerID;
        this.ReaderName = readerName;
        this.ReaderPhoneNumber = readerPhoneNumber;
        this.ReaderAddress = readerAddress;
        this.BookID = BookID;
        this.ReturnDate = ReturnDate;
        this.BookName = bookName;
        this.AuthorName = authorName;
        this.Category = category;
    }
}

public class SearchReaderByID
{
    public int ReaderID { get; set; }
    public string ReaderName { get; set; }
    public string ReaderPhoneNumber { get; set; }
    public string ReaderAddress { get; set; }
    public string ReturnDate { get; set; } 
    public int BookID { get; set; }
    public string BookName { get; set; }
    public string AuthorName { get; set; }
    public string Category { get; set; }

    public SearchReaderByID(int readerID, string readerName, string readerPhoneNumber, string readerAddress, int BookID , string ReturnDate, string bookName, string authorName, string category)
    {
        this.ReaderID = readerID;
        this.ReaderName = readerName;
        this.ReaderPhoneNumber = readerPhoneNumber;
        this.ReaderAddress = readerAddress;
        this.BookID = BookID;
        this.ReturnDate = ReturnDate;
        this.BookName = bookName;
        this.AuthorName = authorName;
        this.Category = category;
    }
}

