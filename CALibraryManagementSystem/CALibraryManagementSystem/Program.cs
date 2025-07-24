namespace CALibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the library");
            Console.WriteLine("----------------------------");
            LibrarySystem library = new LibrarySystem();
            bool end = true;
            while (end)
            {
                Console.WriteLine("Are you a library user or a librarian ?(u,l)");
                Console.Write(">> ");
                char input = char.Parse(Console.ReadLine().ToLower());
                Console.Clear();
                switch (input)
                {
                    case 'u':
                        Console.WriteLine("What is your name ?");
                        Console.Write(">> ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter your Library card ?");
                        Console.Write(">> ");
                        string CardNO = Console.ReadLine();

                        LibraryUser libraryUser = new LibraryUser(new LibraryCard(CardNO), name, library);
                        Console.WriteLine("Enter a book you want to borrow(title and author name)");
                        Console.Write(">> ");
                        string title = Console.ReadLine();
                        Console.Write(">> ");
                        string authorName = Console.ReadLine();
                        libraryUser.BorrowBook(new Book(title, authorName));
                        break;
                    case 'l':
                        Console.WriteLine("What is your name ?");
                        Console.Write(">> ");
                        string librarianName = Console.ReadLine();

                        Console.WriteLine("Enter your Id ?");
                        Console.Write(">> ");
                        int librarianId = int.Parse(Console.ReadLine());

                        Librarian librarian = new Librarian(librarianId, librarianName, library);
                        Console.WriteLine("Do you want add,remove or display books ?(a,r,d)");
                        Console.Write(">> ");
                        char opr = char.Parse(Console.ReadLine());
                        switch (opr)
                        {
                            case 'a':
                                Console.WriteLine("Enter a book you want to add(title and author name)");
                                Console.Write(">> ");
                                title = Console.ReadLine();
                                Console.Write(">> ");
                                authorName = Console.ReadLine();
                                librarian.AddBook(new Book(title, authorName));
                                break;
                            case 'r':
                                Console.WriteLine("Enter a book you want to remove(title and author name)");
                                Console.Write(">> ");
                                title = Console.ReadLine();
                                Console.Write(">> ");
                                authorName = Console.ReadLine();
                                librarian.RemoveBook(new Book(title, authorName));
                                break;
                            case 'd':
                                librarian.DisplayBooks();
                                break;
                            default:
                                break;
                        }

                        break;
                    default:
                        break;
                }
                Console.ResetColor();
                Console.WriteLine("Do you want to exit the program ? (Y,N)");
                char exit = char.Parse(Console.ReadLine().ToUpper());
                if (exit == 'Y')
                {
                    end = false;
                }
                Console.Clear();

            }

           
        } // end of main
    }
}
