using System;
using System.Media;
using System.Threading;
//BillWagner. (n.d.). C# Guide - .NET managed language. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/csharp/
public class Chatbot
{
    private string UserName { get; set; }

    public void PlayWelcomeAudio()
    {
        try
        {
            string audioFile = "welcome.wav";
            string fullPath = System.IO.Path.GetFullPath(audioFile);
            Console.WriteLine($"Attempting to play: {fullPath}");

            if (!System.IO.File.Exists(audioFile))
            {
                Console.WriteLine($"Error: {audioFile} not found in the application directory.");
                return;
            }
            // Dotnet-Bot. (n.d.-b). SoundPlayer Class (System.Media). Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer?view=windowsdesktop-9.0
            SoundPlayer player = new SoundPlayer(audioFile);
            player.Play(); // Asynchronous playback
            Console.WriteLine("Audio playback started.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing audio: {ex.Message}\nStack Trace: { ex.StackTrace}");
        }
        }

    public void DisplayLogo()
    {
        try
        {
            Console.WriteLine("Displaying logo.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = @"
       ==============================
             Cybersecurity Bot
        ==============================
          ___          _ _       
         | _ \__ _ _ _| | | ___  
         |  _/ _` | '_| | |/ _ \ 
         |_| \__,_|_| |_|_|\___/
        ==============================";
        // ASCII Art Archive. (n.d.). ASCII Art Archive. https://www.asciiart.eu/#google_vignette
            TypeResponse(logo);
            Console.WriteLine("Logo displayed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error showing logo: {ex.Message}");
        }
    }

    public void GreetUser()
    {
        try
        { 
            Console.WriteLine("Starting GreetUser.");
            Console.WriteLine(new string('-', 50));
            TypeResponse("Please enter your name:");
            UserName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(UserName))
                UserName = "User";

            Console.ForegroundColor = ConsoleColor.Green;
            string welcomeMessage = $"Hello, {UserName}! Welcome to the Cybersecurity Awareness Bot!";
            Console.WriteLine("Starting welcome message.");
            PlayWelcomeAudio(); // Begin WAV playback
            //Dotnet-Bot. (n.d.-b). SoundPlayer Class (System.Media). Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer?view=windowsdesktop-9.0
            TypeResponse(welcomeMessage); // Type welcome message in parallel
            Console.WriteLine("Welcome message completed.");
            TypeResponse("I'm here to help you learn about staying safe online.");
            Console.WriteLine("GreetUser completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GreetUser: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }
    }

    public void ProcessUserInput(string input)
    {
        try
        {
            input = input.ToLower().Trim();

            string response;
            switch (input)
            {
                case "how are you?":
                    response = "I'm doing wonderful, thanks for asking! How are you?";
                    break;
                case "what's your purpose?":
                    response = "I'm here to guide you with cybersecurity information and keep you safe online!";
                    break;
                case "what can i ask you about?":
                    response = "You can ask about password security, phishing attacks, secure browsing, or just chat!";
                    break;
                case "password safety":
                    response = "Employ passwords that are over 12 characters in length, consisting of letters, numbers, and special characters. Never use duplicate passwords!";
                    break;
                case "phishing":
                    response = "Phishing emails trick you into giving away personal details. Always check the sender's email and do not click on unknown links.";
                    break;
                case "safe browsing":
                    response = "Use HTTPS sites, don't use public Wi-Fi for sensitive activities, and update your browser.";
                    break;
                default:
                    response = "I didn't catch that quite. Could you explain it another way?"; ;
                    break;
            }
            TypeResponse(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing input: {ex.Message}");
        }
        // Dotnet-Bot. (n.d.). Console Class (System). Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/api/system.console?view=net-9.0
    }

    public void TypeResponse(string message)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }  // Dotnet-Bot. (n.d.-b). System.Threading Namespace. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/api/system.threading?view=net-9.0
            Console.WriteLine();
            Console.ResetColor();
        }
        catch (Exception ex)
        {
Console.WriteLine($"Error in TypeResponse: {ex.Message}");
        }

    }

    public void Run()
    {
        try
        {
            Console.WriteLine("Starting Run.");
DisplayLogo();
            GreetUser();

            while (true)
            {
                Console.WriteLine(new string('-', 50));
TypeResponse("What would you like to know? (Type 'exit' to quit)");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
{
                    TypeResponse("Please enter a valid question or command.");
                    continue;
}

                if (input.ToLower() == "exit")
                    break;

ProcessUserInput(input);
            }
            Console.WriteLine("Run completed.");
        }
        catch (Exception ex)
        {
Console.WriteLine($"Error in Run: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }
    }

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Program started.");
            Chatbot bot = new Chatbot();
            bot.Run();
            Console.WriteLine("Program ended.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Main: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }
                }
                }
//BillWagner. (n.d.). C# Guide - .NET managed language. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/csharp/