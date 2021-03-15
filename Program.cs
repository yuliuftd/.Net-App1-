using System;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics.Tracing;

namespace Assignment1
{
    public class Program
    {
        private static string UserName, Password;
        private static string FirstName, LastName, Address, Phone = "", Email;
        
        static void Main(string[]args)
        {
            Start();
            Console.ReadKey();
        }
        public static void Start()
        {
                Console.Clear();
                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t║                         WELCOME TO SIMPLE BANKING SYSTEM                           ║");
                Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("\t\t║                                  LOGIN TO START                                    ║");
                Console.WriteLine("\t\t║                                                                                    ║");
                Console.Write("\t\t║                     User Name:");
                int LoginCursorX = Console.CursorTop;
                int LoginCursorY = Console.CursorLeft;
                Console.WriteLine("                                                     ║");
                Console.Write("\t\t║                     Password:");
                int PwdCursorX = Console.CursorTop;
                int PwdCursorY = Console.CursorLeft;
                Console.WriteLine("                                                      ║");
                Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");

                Console.SetCursorPosition(LoginCursorY, LoginCursorX);
                UserName = Console.ReadLine();
                Console.SetCursorPosition(PwdCursorY, PwdCursorX);
                
                //Password = Console.ReadLine();
                //replace password with *
                char passwordChar = '*';
            
                do
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key != ConsoleKey.Enter && pressedKey.Key != ConsoleKey.Backspace)
                    {
                        Password += pressedKey.KeyChar;
                        Console.Write(passwordChar);
                    }
                    else if (pressedKey.Key == ConsoleKey.Backspace && Password.Length > 0)
                    {
                        Password = Password.Substring(0, (Password.Length - 1));
                        Console.Write("\b \b");
                    }
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                } while (true);

                try
                {
                    string[] userText = System.IO.File.ReadAllLines("login.txt");
                    foreach (string line in userText)
                    {
                        string[] elements = line.Split('|');
                        string username = elements[0];
                        string password = elements[1];
                        //Console.WriteLine("username: {0}, password {1}", elements[0], elements[1]);

                        if (UserName.CompareTo(username) == 0 && Password.CompareTo(password) == 0)
                        {
                            Console.WriteLine("\n\n\n\n Valid Credentials, press any key to proceed...");
                            Console.ReadKey();
                            Menu();
                            
                        }                                         
                    }
                    foreach (string line in userText)
                    {
                        string[] elements = line.Split('|');
                        string username = elements[0];
                        string password = elements[1];
                        //Console.WriteLine("username: {0}, password {1}", elements[0], elements[1]);

                        if (UserName.CompareTo(username) != 0 || Password.CompareTo(password) != 0)
                        {
                        Password = null;
                        Console.WriteLine("\n\n\n Invalid Credentials, Press any key to restart...");
                        Console.ReadKey();
                        Start();
                        }
                    }

            }

                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
        }

        // The main Menu module:
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                         WELCOME TO SIMPLE BANKING SYSTEM                           ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                                                                    ║");
            Console.WriteLine("\t\t║                         1.Create a new account                                     ║");
            Console.WriteLine("\t\t║                         2.Search for an account                                    ║");
            Console.WriteLine("\t\t║                         3.Deposit                                                  ║");
            Console.WriteLine("\t\t║                         4.Withdraw                                                 ║");
            Console.WriteLine("\t\t║                         5.A/C statement                                            ║");
            Console.WriteLine("\t\t║                         6.Delete account                                           ║");
            Console.WriteLine("\t\t║                         7.Exit                                                     ║");
            
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.Write("\t\t║                         Enter your choice (1-7):");
            int OptionCursorX = Console.CursorTop;
            int OptionCursorY = Console.CursorLeft;
            Console.WriteLine("                                   ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");

            Console.SetCursorPosition(OptionCursorY, OptionCursorX);
            string option = Console.ReadLine();
            switch (option)
            {
                case "1": CreateAccount(); break;
                case "2": SearchAccount(); break;
                case "3": Deposit(); break;
                case "4": Withdraw(); break;
                case "5": ACStatement(); break;
                case "6": DeleteAccount(); break;
                case "7": Exit(); break;
                default:
                    Menu();
                    break;
            }
        }

        //Create Account option module:
        public static void CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                               CREATE A NEW ACCOUNT                                 ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                 ENTER THE DETAILS                                  ║");
            Console.WriteLine("\t\t║                                                                                    ║");
            Console.Write("\t\t║           First Name:");
            int FirstNameCursorX = Console.CursorTop;
            int FirstNameCursorY = Console.CursorLeft;
            Console.WriteLine("                                                              ║");
            Console.Write("\t\t║           Last Name:");
            int LastNameCursorX = Console.CursorTop;
            int LastNameCursorY = Console.CursorLeft;
            Console.WriteLine("                                                               ║");
            Console.Write("\t\t║           Address:");
            int AddressCursorX = Console.CursorTop;
            int AddressCursorY = Console.CursorLeft;
            Console.WriteLine("                                                                 ║");
            Console.Write("\t\t║           Phone:");
            int PhoneCursorX = Console.CursorTop;
            int PhoneCursorY = Console.CursorLeft;
            Console.WriteLine("                                                                   ║");
            Console.Write("\t\t║           Email:");
            int EmailCursorX = Console.CursorTop;
            int EmailCursorY = Console.CursorLeft;
            Console.WriteLine("                                                                   ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(FirstNameCursorY, FirstNameCursorX);
            FirstName = Console.ReadLine();
            Console.SetCursorPosition(LastNameCursorY, LastNameCursorX);
            LastName = Console.ReadLine();
            Console.SetCursorPosition(AddressCursorY, AddressCursorX);
            Address = Console.ReadLine();
            Console.SetCursorPosition(PhoneCursorY, PhoneCursorX);
            //Phone = Console.ReadLine();
            do
            {
                char press = Console.ReadKey().KeyChar;
                if (press == '\r')
                {
                    break;
                }
                else if (press >= 48 && press <= 58)
                {
                    Phone += press;                    
                }
                else
                {
                    Console.WriteLine("Please enter the correct Phone number(integer only)...");                    
                    Console.ReadKey();
                    CreateAccount();                    
                }
            } while (Phone.Length < 10);               
            
            Console.SetCursorPosition(EmailCursorY, EmailCursorX);
            Email = Console.ReadLine();
            if (EmailCheck(Email) == false)
            {
                Console.WriteLine("\nPlease Enter Correct Email Format...");
                Console.ReadKey();
                CreateAccount();
            }
            
                Console.WriteLine("\nIs the information correct (y/n)?");               
                ConsoleKeyInfo enter = Console.ReadKey(true);

            while (enter.Key != ConsoleKey.Y && enter.Key != ConsoleKey.N)
            {
                Console.WriteLine("Please press Y or N only...");
                ConsoleKeyInfo enter1 = Console.ReadKey(true);
                if (enter1.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    SaveAccountInfo();
                    break;
                }
                else if (enter1.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    CreateAccount();
                    break;
                }
            }
            if (enter.Key == ConsoleKey.Y)
            {                
                SaveAccountInfo();
            }
            else if (enter.Key == ConsoleKey.N)
            {
                CreateAccount();
            }
        }

        //save information into a text file
        static public void SaveAccountInfo()
        {
            string accountNumber;
            Random Number = new Random();
            int num = Number.Next(100000, 99999999);
            accountNumber = Convert.ToString(num);

            using (StreamWriter myFile = new StreamWriter(accountNumber + ".txt"))
            {
                myFile.WriteLine("Account Number|" + accountNumber);
                myFile.WriteLine("First Name|" + FirstName);
                myFile.WriteLine("Last Name|" + LastName);
                myFile.WriteLine("Address|" + Address);
                myFile.WriteLine("Phone|" + Phone);
                myFile.WriteLine("Email|" + Email);
                myFile.WriteLine("Balance|0");
                myFile.Close();
            }

            Console.WriteLine("Account Created! Details will be provided via email.");
            Console.WriteLine("Account number is: {0}", accountNumber);

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("liuyuftd@gmail.com");
            mail.To.Add(Email);
            mail.Subject = "Create account successful, congratulations!";
            mail.Body = "<h3>Welcome to simple bank. Account detail s is displayed below:</h3>" +
                    "<table><tr><td>Account Number: " + accountNumber + "</td></tr>" +
                    "<tr><td>First Name: " + FirstName + "</td></tr>" +
                    "<tr><td>Last Name: " + LastName + "</td></tr>" +
                    "<tr><td>Address :" + Address + "</td></tr>" +
                    "<tr><td>Phone: " + Phone + "</td></tr>" +
                    "<tr><td>Email: " + Email + "</td></tr></table>";
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("liuyuftd@gmail.com", "weiye507");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            Console.ReadKey();
            Menu();
        }
        // Email verification module:
        static public bool EmailCheck(string Email)
        {
            if (Email.IndexOf("@") == -1 || (Email.IndexOf("gmail.com") == -1) && (Email.IndexOf("outlook.com") == -1) && (Email.IndexOf("uts.edu.au") == -1))
            {                
                return false;
            }
            else
            {
                return true;
            }
        }

        //Send Email Module:
        
        public static void SearchAccount()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                 SEARCH AN ACCOUNT                                  ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                 ENTER THE DETAILS                                  ║");
            Console.Write("\t\t║             Account Number:");
            int searchCursorX = Console.CursorTop;
            int searchCursorY = Console.CursorLeft;
            Console.WriteLine("                                                        ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(searchCursorY, searchCursorX);
            string searchID = Console.ReadLine();
            try
            {
                string[] accountText = File.ReadAllLines(searchID + ".txt");
                Console.WriteLine("\n\n\n Account found!");
                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t║                                  ACCOUNT DETAILS                                   ║");
                Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("\t\t║                                                                                    ║");
                foreach (string line in accountText)
                {
                string[] elements = line.Split('|');
                string label = elements[0];
                string field = elements[1];
                       
                Console.WriteLine("\t\t              "+ label + ":" + field);
                //Console.WriteLine("                                                        ║");
                }
                Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
                Console.ReadLine();
                Menu();
            }
            catch (FileNotFoundException)
            {
                //Console.WriteLine(e.Message);
                Console.WriteLine("\n\n\n Account not found!");
                Console.WriteLine("Check another account (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);
                                
                if (enter.Key == ConsoleKey.Y)
                {
                    SearchAccount();
                }
                else if (enter.Key == ConsoleKey.N)
                {

                    Menu();
                }
                else
                {
                    Console.WriteLine("Please press Y or N only...");
                    Console.ReadKey();
                    Menu();
                }
                Console.ReadKey();
            }
        }

        public static void Deposit()
        {
            int balance;
            string day;
            string month;
            string year;
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                         DEPOSIT                                    ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                 ENTER THE DETAILS                                  ║");
            Console.Write("\t\t║             Account Number:");
            int accountCursorX = Console.CursorTop;
            int accountCursorY = Console.CursorLeft;
            Console.WriteLine("                                                        ║");
            Console.Write("\t\t║             Amount: $");
            int amountCursorX = Console.CursorTop;
            int amountCursorY = Console.CursorLeft;
            Console.WriteLine("                                                              ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(accountCursorY, accountCursorX);
            string account = null;
            do
            {
                char press = Console.ReadKey().KeyChar;
                if (press == '\r')
                {
                    break;
                }
                else if (press >= 48 && press <= 58)
                {
                    account += press;

                }
                else
                {
                    Console.WriteLine("Account number should be integer only...");
                    Console.ReadKey();
                    Deposit();
                }
            } while (account.Length < 10);
            try 
            {
                string[] lines = File.ReadAllLines(account + ".txt");
             
                Console.WriteLine("\n\n\n Account found! Enter the amount...");
                Console.SetCursorPosition(amountCursorY, amountCursorX);
                int amount = Convert.ToInt32(Console.ReadLine());
                
                string[] elements = lines[6].Split('|');
                balance = Convert.ToInt32(elements[1]) + amount;
                lines[6] = "Balance|" + Convert.ToString(balance);
                day = DateTime.Now.Day.ToString();
                month = DateTime.Now.Month.ToString();
                year = DateTime.Now.Year.ToString();
               // lines[7] = "Deposit $" + amount + "at " + da
                //File.WriteAllLines(account + ".txt", lines);
                using (StreamWriter myFile = new StreamWriter(account + ".txt"))
                {
                    foreach (string line in lines)
                    {
                        if (line != "")
                        {
                            myFile.WriteLine(line);
                        }
                        
                    }
                    myFile.WriteLine("Deposit| $" + amount + " at " + day + " / " + month + " / " + year);
                    myFile.Close();
                }
                Console.WriteLine("\n\n\nDeposit successfully! press any key to main menu...");
                Console.ReadKey();
                Menu();
                

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n\n\n Account not found!");
                Console.WriteLine("Retry (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);

                while (enter.Key != ConsoleKey.Y && enter.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Please press Y or N only...");
                    ConsoleKeyInfo ck1 = Console.ReadKey(true);
                    if (ck1.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        Deposit();
                        break;
                    }
                    else if (ck1.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Menu();
                        break;
                    }
                }
                if (enter.Key == ConsoleKey.Y)
                {

                    Deposit();
                }
                else if (enter.Key == ConsoleKey.N)
                {

                    Menu();
                }
                Console.ReadKey();
            }
            


        }
        public static void Withdraw()
        {
            int balance;
            string day;
            string month;
            string year;
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                      WITHDRAW                                      ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                 ENTER THE DETAILS                                  ║");
            Console.Write("\t\t║             Account Number:");
            int accountCursorX = Console.CursorTop;
            int accountCursorY = Console.CursorLeft;
            Console.WriteLine("                                                        ║");
            Console.Write("\t\t║             Amount: $");
            int amountCursorX = Console.CursorTop;
            int amountCursorY = Console.CursorLeft;
            Console.WriteLine("                                                              ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(accountCursorY, accountCursorX);
            string account = null;
            do
            {
                char press = Console.ReadKey().KeyChar;
                if (press == '\r')
                {
                    break;
                }
                else if (press >= 48 && press <= 58)
                {
                    account += press;

                }
                else
                {
                    Console.WriteLine("Account number should be integer only...");
                    Console.ReadKey();
                    Withdraw();
                }
            } while (account.Length < 10);
            try
            {
                string[] lines = File.ReadAllLines(account + ".txt");

                Console.WriteLine("\n\n\n Account found! Enter the amount...");
                Console.SetCursorPosition(amountCursorY, amountCursorX);
                int amount = Convert.ToInt32(Console.ReadLine());
                
                string[] elements = lines[6].Split('|');
                if (amount <= Convert.ToInt32(elements[1]))
                {
                    balance = Convert.ToInt32(elements[1]) - amount;
                    lines[6] = "Balance|" + Convert.ToString(balance);
                    day = DateTime.Now.Day.ToString();
                    month = DateTime.Now.Month.ToString();
                    year = DateTime.Now.Year.ToString();
                    
                    using (StreamWriter myFile = new StreamWriter(account + ".txt"))
                    {
                        foreach (string line in lines)
                        {
                            if (line != "")
                            {
                                myFile.WriteLine(line);
                            }

                        }
                        myFile.WriteLine("Withdraw| $" + amount + " at " + day + " / " + month + " / " + year);
                        myFile.Close();
                    }
                    Console.WriteLine("\n\n\nWithdraw successfully! press any key to main menu...");
                    Console.ReadKey();
                    Menu();
                }else
                {
                    Console.WriteLine("\n\n\n No enough money to withdraw! press any key to try again...");
                    Console.ReadKey();
                    Withdraw();
                }
                


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n\n\n Account not found!");
                Console.WriteLine("Retry (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);

                while (enter.Key != ConsoleKey.Y && enter.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Please press Y or N only...");
                    ConsoleKeyInfo ck1 = Console.ReadKey(true);
                    if (ck1.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        Deposit();
                        break;
                    }
                    else if (ck1.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Menu();
                        break;
                    }
                }
                if (enter.Key == ConsoleKey.Y)
                {

                    Deposit();
                }
                else if (enter.Key == ConsoleKey.N)
                {

                    Menu();
                }
                Console.ReadKey();
            }


        }
        public static void ACStatement()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                    A/C STATEMENT                                   ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                  ENTER THE DETAILS                                 ║");
            Console.Write("\t\t║             Account Number:");
            int accountCursorX = Console.CursorTop;
            int accountCursorY = Console.CursorLeft;
            Console.WriteLine("                                                        ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(accountCursorY, accountCursorX);
            string account = null;
            do
            {
                char press = Console.ReadKey().KeyChar;
                if (press == '\r')
                {
                    break;
                }
                else if (press >= 48 && press <= 58)
                {
                    account += press;
                }
                else
                {
                    Console.WriteLine("Account number should be integer only...");
                    Console.ReadKey();
                    ACStatement();
                }
            } while (account.Length < 10);
            try
            {

                string[] accountText = File.ReadAllLines(account + ".txt");
                
                string[] account_no_line = accountText[0].Split('|');
                string account_no = account_no_line[1];
                string[] f_name_line = accountText[1].Split('|');
                string f_name = f_name_line[1];
                string[] l_name_line = accountText[2].Split('|');
                string l_name = l_name_line[1];
                string[] address_line = accountText[3].Split('|');
                string address = address_line[1];
                string[] phone_line = accountText[4].Split('|');
                string phone = phone_line[1];
                string[] email_line = accountText[5].Split('|');
                string email = email_line[1];
                string[] balance_line = accountText[6].Split('|');
                string balance = balance_line[1];
                Console.WriteLine("\n\nAccount found! The statement is displayed below...");
                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t║                              SIMPLE BANKING SYSTEM                                 ║");
                Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("\t\t║        Account Statement:                                                          ║");
                Console.WriteLine("\t\t║                                                                                    ║");
                if (accountText.Length <= 12)
                {
                    foreach (string line in accountText)
                    {
                        string[] elements = line.Split('|');
                        string label = elements[0];
                        string field = elements[1];

                        Console.WriteLine("\t\t              " + label + ":" + field);
                        //Console.WriteLine("                                                        ║");

                    }
                    Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");

                }else
                {
                    for (int i=0; i < 7; i++)
                    {
                        string First_6_lines = accountText[i];
                        string[] elements = First_6_lines.Split('|');
                        string label = elements[0];
                        string field = elements[1];

                        Console.WriteLine("\t\t              " + label + ":" + field);
                        //Console.WriteLine("                                                        ║");

                    }
                   
                    for (int j = accountText.Length - 1 ; j > accountText.Length - 6 ; j--)
                    {
                        string Last_5_records = accountText[j];
                        string[] elements = Last_5_records.Split('|');
                        string label = elements[0];
                        string field = elements[1];
                        Console.WriteLine("\t\t              " + label + ":" + field);
                        //Console.WriteLine("                                                        ║");
                    }
                    Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");

                }
            
                Console.WriteLine("\nEmail statement (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);
                if (enter.Key == ConsoleKey.Y)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("liuyuftd@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Account statement";
                    mail.Body = "<h3>Welcome to simple bank. Account statement is displayed below:</h3>" +
                            "<table><tr><td>Account Number: " + account_no + "</td></tr>" +
                            "<tr><td>First Name: " + f_name + "</td></tr>" +
                            "<tr><td>Last Name: " + l_name + "</td></tr>" +
                            "<tr><td>Address :" + address + "</td></tr>" +
                            "<tr><td>Phone: " + phone + "</td></tr>" +
                            "<tr><td>Email: " + email + "</td></tr></table>" +
                            "<tr><td>Balance: " + balance + "</td></tr></table>";
                    for (int n = 7; n < accountText.Length; n++)
                    {
                        string transaction_line = accountText[n];
                        string [] transaction = transaction_line.Split('|');
                        mail.Body += "<tr><td>" + transaction[0] + ":" + transaction[1] + "<td><tr>";
                    }
                    mail.IsBodyHtml = true;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("liuyuftd@gmail.com", "weiye507");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);                    
                    Console.WriteLine("Email sent successfully!...");
                    Console.ReadKey();
                    Menu();
                    
                }
                else if (enter.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Press Y or N only....");
                    Console.ReadKey();
                    Menu();
                }

            }
            catch
            {
                Console.WriteLine("\n\n\n Account not found!");
                Console.WriteLine("Retry (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);

                while (enter.Key != ConsoleKey.Y && enter.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Please press Y or N only...");
                    ConsoleKeyInfo enter1 = Console.ReadKey(true);
                    if (enter1.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        ACStatement();
                        break;
                    }
                    else if (enter1.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Menu();
                        break;
                    }
                }
                if (enter.Key == ConsoleKey.Y)
                {

                    ACStatement();
                }
                else if (enter.Key == ConsoleKey.N)
                {

                    Menu();
                }
                Console.ReadKey();
            }

        }

        //Delete account function module
        public static void DeleteAccount()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                 DELETE AN ACCOUNT                                  ║");
            Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t║                                 ENTER THE DETAILS                                  ║");
            Console.Write("\t\t║             Account Number:");
            int accountCursorX = Console.CursorTop;
            int accountCursorY = Console.CursorLeft;
            Console.WriteLine("                                                        ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(accountCursorY, accountCursorX);
            string account = null;
            do
            {
                char press = Console.ReadKey().KeyChar;
                if (press == '\r')
                {
                    break;
                }
                else if (press >= 48 && press <= 58)
                {
                    account += press;

                }
                else
                {
                    Console.WriteLine("Account number should be integer only...");
                    Console.ReadKey();
                    DeleteAccount();
                }
            } while (account.Length < 10);
            try
            {   

                string[] accountText = File.ReadAllLines(account + ".txt");
                Console.WriteLine("\n\nAccount found! Details are as below...");
                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t║                                  ACCOUNT DETAILS                                   ║");
                Console.WriteLine("\t\t║════════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("\t\t║                                                                                    ║");
                foreach (string line in accountText)
                {
                    string[] elements = line.Split('|');
                    string label = elements[0];
                    string field = elements[1];

                    Console.WriteLine("\t\t              " + label + ":" + field);
                    //Console.WriteLine("                                                        ║");

                }
                Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine("\nDelete (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);
                if (enter.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Account Deleted!...");
                    FileInfo selectedFile = new FileInfo(account + ".txt");
                    selectedFile.Delete();
                    Console.ReadKey();
                    Menu();
                }else if (enter.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Press Y or N only....");
                    Console.ReadKey();
                    Menu();
                }
                
            }
            catch
            {
                Console.WriteLine("\n\n\n Account not found!");
                Console.WriteLine("Retry (y/n)?");
                ConsoleKeyInfo enter = Console.ReadKey(true);

                while (enter.Key != ConsoleKey.Y && enter.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Please press Y or N only...");
                    ConsoleKeyInfo enter1 = Console.ReadKey(true);
                    if (enter1.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        DeleteAccount();
                        break;
                    }
                    else if (enter1.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Menu();
                        break;
                    }
                }
                if (enter.Key == ConsoleKey.Y)
                {

                    DeleteAccount();
                }
                else if (enter.Key == ConsoleKey.N)
                {

                    Menu();
                }
                Console.ReadKey();
            }
        }
        public static void Exit()
        {
            //Console.Clear();
            System.Environment.Exit(0);
        }
    }
}
