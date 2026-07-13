using System;
namespace SayiTahminOyunu
{

    public class Program
    {
        public static void Main()
        {
            bool tekrar = true;

            double kolayRekor = double.MaxValue;  // her zorluk için en iyi süre tutulur.
            double ortaRekor = double.MaxValue;
            double zorRekor = double.MaxValue;

            while (tekrar)   // oyunun devamlılığını sağlar.
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--- Sayı Tahmin Oyunu ---");
                Console.WriteLine(" 1 - Kolay (1-50 arası) ");
                Console.WriteLine(" 2 - Orta (1-100 arası) ");
                Console.WriteLine(" 3 - Zor (1-1000 arası) ");
                Console.WriteLine("-------------------------");
                Console.WriteLine("");
                Console.ResetColor();

                int mod = 0;

                try  // kullanıcıdan zorluk seviyesi alınır.
                {
                    Console.Write("Hangi zorluğu seçiyorsunuz sayı ile belirtiniz : ");
                    mod = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lütfen bir sayı giriniz!!");
                    Console.ResetColor();
                    continue;
                }

                Random rastgele = new Random();
                int tutulan = 0;

                switch (mod)
                {  // seçilen zorluk seviyesine göre rastgele sayı oluşturur.
                    case 1:
                        tutulan = rastgele.Next(1, 51);
                        break;

                    case 2:
                        tutulan = rastgele.Next(1, 101);
                        break;

                    case 3:
                        tutulan = rastgele.Next(1, 1001);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim lütfen 1 , 2 veya 3 giriniz !!!");
                        continue;
                }
                // süre ölçümü oyun başladığı anda başlatılır.
                DateTime simdi = DateTime.Now;
                int tahmin;

                try
                {
                    Console.Write("Sayıyı tuttum tahminin nedir : ");
                    tahmin = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz!!");
                    Console.ResetColor();
                    continue;
                }

                int deneme = 1;


                while (tahmin != tutulan) // tutulan sayı bulunana kadar devam eder.
                {

                    if (tahmin > tutulan)
                    {
                        Console.WriteLine("Tuttuğum sayı daha KÜÇÜK");

                        int fark = tahmin - tutulan;

                        if (fark <= 3)
                        {
                            Console.WriteLine("Amaaa bulmak üzeresin çok yaklaştın..");
                        }

                        else if (fark <= 10)
                        {
                            Console.WriteLine("Amaaa çok yaklaştın..");
                        }

                    }
                    else if (tahmin < tutulan)
                    {
                        Console.WriteLine("Tuttuğum sayı daha BÜYÜK");

                        int fark = tutulan - tahmin;

                        // tahmini hedef sayıya yaklaştığında fazladan ipucu verilir.
                        if (fark <= 3)
                        {
                            Console.WriteLine("Amaaa bulmak üzeresin çok yaklaştın..");
                        }

                        else if (fark <= 10)
                        {
                            Console.WriteLine("Amaaa çok yaklaştın..");
                        }
                    }
                    try
                    {
                        Console.Write("Yeni tahminin ne : ");
                        tahmin = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lütfen geçerli bir sayı giriniz!!");
                        Console.ResetColor();
                        continue;
                    }

                    deneme++;
                }

                if (tahmin == tutulan) // tutulan sayı bulunduğunda sonuçlar gösterilir.
                {

                    Console.WriteLine("Tutulan sayı : " + tutulan);
                    if (deneme == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Ooo doğru tahmin tekte buldun !!!");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(deneme + " denemede buldun tebrikler");
                        Console.ResetColor();
                    }

                    DateTime bitis = DateTime.Now;
                    TimeSpan gecensure = bitis - simdi; // sayı bulunana kadarki geçen süre hesaplanır.

                    Console.Write("Geçen süre : "); // geçen süre saat dakika saniye olarak ekrana yazdırılır.

                    if (gecensure.Hours > 0)
                    {
                        Console.Write(gecensure.Hours + " saat ");
                    }

                    if (gecensure.Minutes > 0)
                    {
                        Console.Write(gecensure.Minutes + " dakika ");
                    }

                    Console.WriteLine(gecensure.Seconds + " saniye ");

                    double sure = gecensure.TotalSeconds;

                    switch (mod)
                    {  // rekoru geçtiysek seçilen mod a göre rekor süresi güncellenir.
                        case 1:

                            if (sure < kolayRekor)
                            {
                                kolayRekor = sure;
                                Console.WriteLine("🎉 Yeni kolay mod rekoru!");
                            }
                            Console.WriteLine("Kolay mod rekoru : " + kolayRekor.ToString("F2"));
                            break;

                        case 2:

                            if (sure < ortaRekor)
                            {
                                ortaRekor = sure;
                                Console.WriteLine("🎉 Yeni orta mod rekoru!");
                            }
                            Console.WriteLine("Orta mod rekoru : " + ortaRekor.ToString("F2"));
                            break;

                        case 3:

                            if (sure < zorRekor)
                            {
                                zorRekor = sure;
                                Console.WriteLine("🎉 Yeni zor mod rekoru!");
                            }
                            Console.WriteLine("Zor mod rekoru: " + zorRekor.ToString("F2"));
                            break;
                    }
                }
                // kullanıcıya tekrar oynamak isteyip istemediği sorulur.
                Console.Write("Tekrar oynamak ister misin? (evet veya hayır yaz): ");
                string secim = Console.ReadLine();

                while ((secim.ToLower() != "hayır") && (secim.ToLower() != "evet"))
                {    // kullanıcı sadece evet veya hayır yazabilir.

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lütfen sadece ''evet'' veya ''hayır'' yazınız.");
                    Console.ResetColor();

                    Console.Write("Tekrar oynamak ister misin? (evet veya hayır yaz): ");
                    secim = Console.ReadLine();
                }

                if (secim.ToLower() == "hayır")
                {
                    tekrar = false;
                }
            }
        }
    }
}
