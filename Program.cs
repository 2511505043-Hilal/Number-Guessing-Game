using System;
namespace NumberGuessingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool again = true;

            double easyRecord = double.MaxValue;  // her zorluk için en iyi süre tutulur.
            double mediumRecord = double.MaxValue;
            double hardRecord = double.MaxValue;

            while (again)   // oyunun devamlılığını sağlar.
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--- Number Guessing Game ---");
                Console.WriteLine(" 1 - Easy (1 to 50) ");
                Console.WriteLine(" 2 - Medium (1 to 100) ");
                Console.WriteLine(" 3 - Hard (1 to 1000) ");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
                Console.ResetColor();

                int mod = 0;

                try  // kullanıcıdan zorluk seviyesi alınır.
                {
                    Console.Write("Select a difficulty level (enter a number) : ");
                    mod = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number !!");
                    Console.ResetColor();
                    continue;
                }

                Random random = new Random();
                int numberHeld = 0;

                switch (mod)
                {  // seçilen zorluk seviyesine göre rastgele sayı oluşturur.
                    case 1:
                        numberHeld = random.Next(1, 51);
                        break;

                    case 2:
                        numberHeld = random.Next(1, 101);
                        break;

                    case 3:
                        numberHeld = random.Next(1, 1001);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please enter 1, 2, or 3 !!!");
                        continue;
                }
                // süre ölçümü oyun başladığı anda başlatılır.
                DateTime startTime = DateTime.Now;
                int guess;

                try
                {
                    Console.Write("I have picked a number. What is your guess : ");
                    guess = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number!!");
                    Console.ResetColor();
                    continue;
                }

                int totry = 1;


                while (guess != numberHeld) // tutulan sayı bulunana kadar devam eder.
                {

                    if (guess > numberHeld)
                    {
                        Console.WriteLine("My number is SMALLER");

                        int diff = guess - numberHeld;

                        if (diff <= 3)
                        {
                            Console.WriteLine("But you are very close, almost there..");
                        }

                        else if (diff <= 10)
                        {
                            Console.WriteLine("But you are getting close..");
                        }

                    }
                    else if (guess < numberHeld)
                    {
                        Console.WriteLine("My number is BIGGER");

                        int diff = numberHeld - guess;

                        // tahmini hedef sayıya yaklaştığında fazladan ipucu verilir.
                        if (diff <= 3)
                        {
                            Console.WriteLine("But you are very close, almost there..");
                        }

                        else if (diff <= 10)
                        {
                            Console.WriteLine("But you are getting close..");
                        }
                    }
                    try
                    {
                        Console.Write("What is your new guess : ");
                        guess = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number!!");
                        Console.ResetColor();
                        continue;
                    }

                    totry++;
                }

                if (guess == numberHeld) // tutulan sayı bulunduğunda sonuçlar gösterilir.
                {

                    Console.WriteLine("The number was : " + numberHeld);
                    if (totry == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Wooooww, correct guess on the first try !!!");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("You found it in " + totry + " tries, congratulations !");
                        Console.ResetColor();
                    }

                    DateTime endTime = DateTime.Now;
                    TimeSpan elapsedTime = endTime - startTime; // sayı bulunana kadarki geçen süre hesaplanır.

                    Console.Write("Time elapsed : "); // geçen süre saat dakika saniye olarak ekrana yazdırılır.

                    if (elapsedTime.Hours > 0)
                    {
                        Console.Write(elapsedTime.Hours + " hours ");
                    }

                    if (elapsedTime.Minutes > 0)
                    {
                        Console.Write(elapsedTime.Minutes + " minutes ");
                    }

                    Console.WriteLine(elapsedTime.Seconds + " seconds ");

                    double time = elapsedTime.TotalSeconds;

                    switch (mod)
                    {  // rekoru geçtiysek seçilen mod a göre rekor süresi güncellenir.
                        case 1:

                            if (time < easyRecord)
                            {
                                easyRecord = time;
                                Console.WriteLine("🎉 New Easy mode record!");
                            }
                            Console.WriteLine("Easy mode record : " + easyRecord.ToString("F2"));
                            break;

                        case 2:

                            if (time < mediumRecord)
                            {
                                mediumRecord = time;
                                Console.WriteLine("🎉 New Medium mode record!");
                            }
                            Console.WriteLine("Medium mode record : " + mediumRecord.ToString("F2"));
                            break;

                        case 3:

                            if (time < hardRecord)
                            {
                                hardRecord = time;
                                Console.WriteLine("🎉 New Hard mode record!");
                            }
                            Console.WriteLine("Hard mode record : " + hardRecord.ToString("F2"));
                            break;
                    }
                }
                // kullanıcıya tekrar oynamak isteyip istemediği sorulur.
                Console.Write("Do you want to play again ? (type 'yes' or 'no') : ");
                string choice = Console.ReadLine();

                while ((choice.ToLower() != "no") && (choice.ToLower() != "yes"))
                {    // kullanıcı sadece evet veya hayır yazabilir.

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lütfen sadece ''yes'' veya ''no'' yazınız.");
                    Console.ResetColor();

                    Console.Write("Do you want to play again ? (type 'yes' or 'no') : ");
                    choice = Console.ReadLine();
                }

                if (choice.ToLower() == "no")
                {
                    again = false;
                }
            }
        }
    }
}
