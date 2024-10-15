using System;
using System.Collections.Generic;

namespace RentACarSistemi
{
    public class Arac
    {
        public string AracTipi { get; set; }  
        public string Marka { get; set; }
        public string Model { get; set; }
        public double Fiyat { get; set; } 
        public double GunlukKiralamaUcreti { get; set; } 

        public Arac(string aracTipi, string marka, string model, double fiyat, double gunlukKiralamaUcreti)
        {
            AracTipi = aracTipi;
            Marka = marka;
            Model = model;
            Fiyat = fiyat;
            GunlukKiralamaUcreti = gunlukKiralamaUcreti;
        }

        public override string ToString()
        {
            return $"{AracTipi} - {Marka} {Model} - Fiyat: {Fiyat} TL - Günlük Kiralama Ücreti: {GunlukKiralamaUcreti} TL";
        }
    }

    public class Program
    {
        static List<Arac> araclar = new List<Arac>();

        static void Main(string[] args)
        {
            int secim;

            do
            {
                Console.WriteLine("\nAraç Yönetim Sistemi");
                Console.WriteLine("1. Araç Ekle");
                Console.WriteLine("2. Araç Sil");
                Console.WriteLine("3. Araçları Listele");
                Console.WriteLine("4. Araç Satın Alma İşlemi");
                Console.WriteLine("5. Araç Kiralama İşlemi");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        AracEkle();
                        break;
                    case 2:
                        AracSil();
                        break;
                    case 3:
                        AraclariListele();
                        break;
                    case 4:
                        AracSatinAl();
                        break;
                    case 5:
                        AracKirala();
                        break;
                }

            } while (secim != 0);

            Console.WriteLine("Çıkış yapıldı.");
        }

        static void AracEkle()
        {
            Console.Write("Araç Tipi (Araba/Kamyonet): ");
            string aracTipi = Console.ReadLine();
            Console.Write("Marka: ");
            string marka = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Satın Alma Fiyatı: ");
            double fiyat = Convert.ToDouble(Console.ReadLine());
            Console.Write("Günlük Kiralama Ücreti: ");
            double gunlukKiralamaUcreti = Convert.ToDouble(Console.ReadLine());

            araclar.Add(new Arac(aracTipi, marka, model, fiyat, gunlukKiralamaUcreti));
            Console.WriteLine("Araç başarıyla eklendi.");
        }

        static void AracSil()
        {
            AraclariListele();
            Console.Write("Silmek istediğiniz aracın numarasını girin: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < araclar.Count)
            {
                araclar.RemoveAt(index);
                Console.WriteLine("Araç başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Geçersiz araç numarası.");
            }
        }

        static void AraclariListele()
        {
            if (araclar.Count == 0)
            {
                Console.WriteLine("Sistemde kayıtlı araç yok.");
            }
            else
            {
                for (int i = 0; i < araclar.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {araclar[i]}");
                }
            }
        }

        static void AracSatinAl()
        {
            AraclariListele();
            Console.Write("Satın almak istediğiniz aracın numarasını girin: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < araclar.Count)
            {
                Arac secilenArac = araclar[index];
                Console.WriteLine($"Seçilen Araç: {secilenArac}");
                Console.Write("Satış için uygulanacak ilk indirim yüzdesi: ");
                double indirim1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Satış için uygulanacak ikinci indirim yüzdesi: ");
                double indirim2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Satış için uygulanacak üçüncü indirim yüzdesi: ");
                double indirim3 = Convert.ToDouble(Console.ReadLine());

                double toplamIndirim = secilenArac.Fiyat * ((indirim1 + indirim2 + indirim3) / 100);
                double satisTutari = secilenArac.Fiyat - toplamIndirim;

                Console.WriteLine($"Toplam İndirim: {toplamIndirim} TL");
                Console.WriteLine($"Satış Tutarı: {satisTutari} TL");
            }
            else
            {
                Console.WriteLine("Geçersiz araç numarası.");
            }
        }

        static void AracKirala()
        {
            AraclariListele();
            Console.Write("Kiralamak istediğiniz aracın numarasını girin: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < araclar.Count)
            {
                Arac secilenArac = araclar[index];
                Console.WriteLine($"Seçilen Araç: {secilenArac}");
                Console.Write("Kaç gün kiralamak istiyorsunuz?: ");
                int kiralamaSuresi = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kiralama için uygulanacak ilk indirim yüzdesi: ");
                double indirim1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Kiralama için uygulanacak ikinci indirim yüzdesi: ");
                double indirim2 = Convert.ToDouble(Console.ReadLine());

                double toplamKiralamaUcreti = secilenArac.GunlukKiralamaUcreti * kiralamaSuresi;
                double toplamIndirim = toplamKiralamaUcreti * ((indirim1 + indirim2) / 100);
                double odenecekTutar = toplamKiralamaUcreti - toplamIndirim;

                Console.WriteLine($"Toplam İndirim: {toplamIndirim} TL");
                Console.WriteLine($"Kiralama Tutarı: {odenecekTutar} TL");
            }
            else
            {
                Console.WriteLine("Geçersiz araç numarası.");
            }
        }
    }
}
