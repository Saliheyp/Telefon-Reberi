using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    public class TelRehber
    {
        public static Dictionary<string,long> Rehber = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
        public static void VarsayilanNo()
        {
            Rehber.Add("Muhammed Salih",12345678910);
            Rehber.Add("Tutanay Gamze",12345678911);
            Rehber.Add("Serdar Eren",12345678912);
            Rehber.Add("Akın Eğinli",12345678913);
            Rehber.Add("Uğur Geleç",12345678914);
        }
        public static void RehbereEkle()
        {
            Console.WriteLine("Lütfen isim giriniz             : ");
            string addIsim=Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz          : ");
            string addSoyisim=Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarası giriniz : ");
            long addNumara =long.Parse(Console.ReadLine()); 
            Rehber.Add(addIsim+" "+addSoyisim,addNumara);
            foreach (var item in TelRehber.Rehber)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class RehberdeSilme
    {
        
        public static void KisiSilme()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişini adını ya da soyadını giriniz:");
            string silinecekKisi = Console.ReadLine();
            string keys = RehberArama.IsmeGoreArama(silinecekKisi);
            TelRehber.Rehber.Remove(keys);
            RehberdeSiralama.EkranaYazdir();
        }
    }
    public class RehberdeGuncelleme
    {
        public static void KisiGuncelleme()
        {
            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişini adını ya da soyadını giriniz:");
            string guncellenecekKisi = Console.ReadLine();
            string keys = RehberArama.IsmeGoreArama(guncellenecekKisi);
            Console.WriteLine("Lütfen Yeni numara giriniz:");
            long newNumara = long.Parse(Console.ReadLine());
            TelRehber.Rehber[keys]=newNumara;
            RehberdeSiralama.EkranaYazdir();
        }
    }

    public class RehberArama
    {
        public static string IsmeGoreArama(string isim)
        {
            
            List<string> bulunanKisiler = TelRehber.Rehber.Keys.Where(k => k.ToLower().Contains(isim.ToLower())).ToList();
            if (bulunanKisiler.Count > 0)
            {
                foreach (string anahtar in bulunanKisiler)
                {
                    return anahtar;
                }
            }
            Console.WriteLine("Aradığınız kişi bulunamadı");
            return null;
        }

        public static long NumarayaGoreArama(long numara)
        {
           if (TelRehber.Rehber.ContainsValue(numara))
           {
            return numara;
           }
          return 0;
          
           
        }
    }

    public class RehberdeSiralama
    {
        public static void EkranaYazdir()
        {
            foreach (var item in TelRehber.Rehber)
            {
                Console.WriteLine(item);
            }
        }
        public static void AdanZyeSiralama()
        {
            var siraliAnahtarlar = TelRehber.Rehber.Keys.OrderBy(k => k).ToList();

            foreach (var anahtar in siraliAnahtarlar)
            {
                Console.WriteLine(anahtar + ": " + TelRehber.Rehber[anahtar]);
            }

        }
        public static void ZdenAyaSiralma()
        {
            var siraliAnahtarlar = TelRehber.Rehber.Keys.OrderByDescending(k => k).ToList();

            foreach (var anahtar in siraliAnahtarlar)
            {   
                Console.WriteLine(anahtar + ": " + TelRehber.Rehber[anahtar]);
            }

        }

    }
}