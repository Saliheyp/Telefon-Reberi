using System;

namespace TelefonRehberi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelRehber.VarsayilanNo();
            bool devam = true;
            while(devam)

            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :");
                Console.WriteLine("******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                                          
                        TelRehber.RehbereEkle();
                    break;
                    case 2:
                        RehberdeSilme.KisiSilme();
                    break;
                    case 3:
                        RehberdeGuncelleme.KisiGuncelleme();
                    break;
                    case 4:
                    Console.WriteLine("Rehberi nasıl listelemek istersiniz");
                    Console.WriteLine("(1) A-->Z");
                    Console.WriteLine("(2) Z-->A");
                    int secim2 =int.Parse(Console.ReadLine());
                    if (secim2==1)
                    {
                        RehberdeSiralama.AdanZyeSiralama();
                    }
                    else if (secim2==2)
                    {
                        RehberdeSiralama.ZdenAyaSiralma();
                    }
                    break;
                    case 5:
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                        Console.WriteLine("İsim veya soyisme göre arama yapmak için (1)");
                        Console.WriteLine("Numraya göre arama yapmak için (2)");
                        int secim = int.Parse(Console.ReadLine());
                        if (secim==1)
                        {
                            Console.WriteLine("Aradığın kişinin ismini giriniz");
                            string arananKisi = Console.ReadLine();
                            string bulunanKisi =(RehberArama.IsmeGoreArama(arananKisi));
                            Console.WriteLine(bulunanKisi+" : "+TelRehber.Rehber[bulunanKisi]);

                        }
                        else if(secim==2)
                        {
                            Console.WriteLine("Arama yapmak istediğniz numarayı giriniz");
                            long numara =long.Parse(Console.ReadLine());
                            long bulunanNumara = RehberArama.NumarayaGoreArama(numara);
                            if (bulunanNumara > 0)
                            {
                               var bulunanKisi = TelRehber.Rehber.FirstOrDefault(x => x.Value == bulunanNumara);
                               Console.WriteLine(bulunanKisi);
                            }
                            else
                            {
                                Console.WriteLine("Girdiğiniz numara kayıtlı değildir");
                            }
                        }
                    break;
                
                }
                Console.WriteLine("Devam etmek için bir tuşa basın, çıkmak için 'E' tuşuna basın.");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.E)
                {
                    devam = false;
                }
                Console.Clear();
            }

        }
        
    }
}