using System;
using System.Collections.Generic;

namespace WorkoutTracker
{
    class Program
    {
        static List<Workout> workouts = new List<Workout>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Workout Tracker ===");
                Console.WriteLine("1. Tambah Workout");
                Console.WriteLine("2. Lihat Workout");
                Console.WriteLine("3. Hapus Workout");
                Console.WriteLine("4. Keluar");
                Console.Write("Pilih menu: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        TambahWorkout();
                        break;
                    case "2":
                        LihatWorkout();
                        break;
                    case "3":
                        HapusWorkout();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }

        static void TambahWorkout()
        {
            Console.Write("Nama Workout: ");
            string nama = Console.ReadLine();
            Console.Write("Durasi (menit): ");
            int durasi = int.Parse(Console.ReadLine());
            Console.Write("Tanggal (yyyy-mm-dd): ");
            DateTime tanggal = DateTime.Parse(Console.ReadLine());

            workouts.Add(new Workout { Nama = nama, Durasi = durasi, Tanggal = tanggal });
            Console.WriteLine("Workout berhasil ditambahkan!");
            Console.ReadKey();
        }

        static void LihatWorkout()
        {
            Console.WriteLine("\n--- Daftar Workout ---");
            if (workouts.Count == 0)
            {
                Console.WriteLine("Belum ada workout.");
            }
            else
            {
                for (int i = 0; i < workouts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {workouts[i]}");
                }
            }
            Console.ReadKey();
        }

        static void HapusWorkout()
        {
            LihatWorkout();
            Console.Write("\nMasukkan nomor workout yang ingin dihapus: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < workouts.Count)
            {
                workouts.RemoveAt(index);
                Console.WriteLine("Workout berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Nomor tidak valid.");
            }
            Console.ReadKey();
        }
    }

    class Workout
    {
        public string Nama { get; set; }
        public int Durasi { get; set; } // dalam menit
        public DateTime Tanggal { get; set; }

        public override string ToString()
        {
            return $"{Nama} - {Durasi} menit - {Tanggal.ToShortDateString()}";
        }
    }
}
