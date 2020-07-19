using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORM_Examples.Interfaces;
using ORM_Examples.Models;
using ORM_Examples.Services;
using System;
using System.IO;

namespace ORM_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", true)
                 .Build();
            //IDataAccessService _dataService = new DataAccessServiceEntityFramework(config);
            // IDataAccessService _dataService = new DataAccessServiceLinqToDb(config);
             IDataAccessService _dataService = new DataAccessServiceLinqToDb(config);
            Console.WriteLine("1: Yarat\n2: Deyiş \n3: Sil \n4: İd-ye uyğun melumatı getir \n5: Maşınların siyahısına bax ");
            Again:
            Console.WriteLine("Seçim edin :");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Maşının yaradıcısını daxil edin :");
                        var make = Console.ReadLine();
                        Console.Write("Maşının modelini daxil edin :");
                        var model = Console.ReadLine();
                        Console.Write("Maşının versiyasını daxil edin :");
                        var version = Console.ReadLine();
                        var result = _dataService.Create(new Car
                        {
                            Make = make,
                            Model = model,
                            Version = version
                        });
                        Console.WriteLine();
                        Console.WriteLine($"Netice : {result}");
                        break;
                    }
                case 2:
                    {
                        Console.Write("Maşının id-sini daxil edin :");
                        var id = int.Parse(Console.ReadLine());
                        Console.Write("Maşının yaradıcısını daxil edin :");
                        var make = Console.ReadLine();
                        Console.Write("Maşının modelini daxil edin :");
                        var model = Console.ReadLine();
                        Console.Write("Maşının versiyasını daxil edin :");
                        var version = Console.ReadLine();
                        var result = _dataService.Edit(new Car
                        {
                            Id = id,
                            Make = make,
                            Model = model,
                            Version = version
                        });
                        Console.WriteLine();
                        Console.WriteLine($"Netice : {result}");
                        break;
                    }
                case 3:
                    {
                        Console.Write("Maşının id-sini daxil edin :");
                        var id = int.Parse(Console.ReadLine());
                        var result = _dataService.Delete(id);
                        Console.WriteLine();
                        Console.WriteLine($"Netice : {result}");
                        break;
                    }
                case 4:
                    {
                        Console.Write("Maşının id-sini daxil edin :");
                        var id = int.Parse(Console.ReadLine());
                        var result = _dataService.GetSimple(id);
                        Console.WriteLine();
                        Console.WriteLine($"Netice : {result.Id} | {result.Make} | {result.Model} | {result.Version}");
                        break;
                    }
                case 5:
                    {
                        var result = _dataService.GetList();
                        Console.WriteLine();
                        Console.WriteLine("Netice :");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} | {item.Make} | {item.Model} | {item.Version}");
                        }
                        break;
                    }
            }
            Console.WriteLine("Davam etmek isteyirsinizse \"y\" düymesini basın!");
            var userChoice = Console.ReadLine();
            if (userChoice == "y")
                goto Again;
            
        }
    }
}
