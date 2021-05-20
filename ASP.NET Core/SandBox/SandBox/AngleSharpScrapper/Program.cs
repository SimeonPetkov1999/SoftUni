using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using Newtonsoft.Json;

namespace AngleSharpScrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var watch = new Stopwatch();
            int i = 0;
            watch.Start();
            Console.OutputEncoding = Encoding.Unicode;
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var links = File.ReadAllText("links.txt").Split(Environment.NewLine);

            var carList = new List<CarJsonObject>();


            foreach (var link in links)
            {
                try
                {
                    var document = await context.OpenAsync(link);
                    var inputforModelAnMake = document.Body.QuerySelector(".text-copy h2").TextContent.Split(" ");
                    var make = inputforModelAnMake[0];
                    var model = inputforModelAnMake[1];

                    var saleId = link.Split("/").Last();


                    var priceInput = document.Body.QuerySelector("#main-content > div > div:nth-child(1) > div > div.offer-price > strong");
                    string price = string.Empty;
                    var priceReversed = priceInput.TextContent.Replace(",", string.Empty);

                    foreach (var digit in priceReversed)
                    {
                        if (char.IsDigit(digit))
                        {
                            price += digit;
                        }
                    }



                    var yearMade = document.Body.QuerySelector("#main-content > div > div:nth-child(1) > div > div.text-copy > strong").TextContent;



                    var carInfo = document
                        .Body
                        .QuerySelector("#main-content > div > div:nth-child(1) > div > div.text-copy")
                        .TextContent
                        .Replace("\n", string.Empty)
                        .Trim()
                        .Split(", ", StringSplitOptions.TrimEntries)
                        .Where(x => !x.Contains("EURO")
                               && !x.Contains("нов внос")
                               && !x.Contains("В добро състояние")
                               && !x.Contains("автомобил")
                               && !x.Contains("врати"))
                        .ToArray();
                    if (carInfo.Count() != 8)
                    {
                        //return;
                        continue;
                    }

                    var vechicleType = carInfo[1];
                    var typeOfPetrol = carInfo[2];
                    string kmDriven = carInfo[3].Replace(" ", string.Empty).Replace("км", string.Empty);

                    var typeOfGears = carInfo[4];
                    var horsePower = carInfo[5].Replace("к.с.", string.Empty);
                    var engineCubicCentimeters = carInfo[6].Replace("см3", string.Empty);
                    var color = carInfo[7];


                    var extrasInput = document
                        .Body
                        .QuerySelector("#main-content > div > div:nth-child(2) > div > div.mdc-layout-grid__cell.mdc-layout-grid__cell--span-4-phone.mdc-layout-grid__cell--span-4-tablet.mdc-layout-grid__cell--span-2-desktop > div > div:nth-child(2) > div.description.text-copy")
                        .TextContent;

                    var extrax = extrasInput.Trim().Split(new char[] { ',', ':', '\n' }, StringSplitOptions.TrimEntries).Where(x => x != string.Empty).ToList();

                    var imgLinksInput = document
                        .Body
                        .QuerySelectorAll(".customfig > img");

                    var imgLinks = new List<string>();

                    foreach (var item in imgLinksInput)
                    {
                        imgLinks.Add(item.GetAttribute("data-src"));
                    }

                    var city = document
                        .Body
                        .QuerySelector("#main-content > div > div:nth-child(2) > div > div.mdc-layout-grid__cell.mdc-layout-grid__cell--span-4-phone.mdc-layout-grid__cell--span-4-tablet.mdc-layout-grid__cell--span-2-desktop > div > div:nth-child(4) > div > table > tbody > tr:nth-child(5) > td > div > li")
                        ?.TextContent
                        ?.Split(", ")
                        ?.Last() ?? "Sofia";


                    var info = document
                        .Body
                        .QuerySelector("#main-content > div > div:nth-child(2) > div > div.mdc-layout-grid__cell.mdc-layout-grid__cell--span-4-phone.mdc-layout-grid__cell--span-4-tablet.mdc-layout-grid__cell--span-2-desktop > div > div:nth-child(1) > div > div")
                        ?.TextContent?.Trim()?.TrimStart()?.TrimEnd() ?? string.Empty;

                    carList.Add(new CarJsonObject()
                    {
                        Link = link,
                        SaleId = saleId,
                        Make = make,
                        Model = model,
                        Year = int.Parse(yearMade),
                        Price = decimal.Parse(price),
                        VehicleType = vechicleType,
                        PetrolType = typeOfPetrol,
                        KM = int.Parse(kmDriven),
                        GearsType = typeOfGears,
                        HorsePower = int.Parse(horsePower),
                        EngineCubicCm = int.Parse(engineCubicCentimeters),
                        Color = color,
                        Description = info,
                        City = city,
                        Extras = extrax,
                        ImgUrls = imgLinks

                    });
                    //Console.WriteLine("+");
                    //Console.WriteLine($"Link: {link}");
                    //Console.WriteLine($"SaleId: {saleId}");
                    //Console.WriteLine($"Make: {make}");
                    //Console.WriteLine($"Model: {model}");
                    //Console.WriteLine($"Year: {yearMade}");
                    //Console.WriteLine($"Price: {price}");
                    //Console.WriteLine($"Vehicle Type: {vechicleType}");
                    //Console.WriteLine($"Type of petrol: {typeOfPetrol}");
                    //Console.WriteLine($"KM: {kmDriven}");
                    //Console.WriteLine($"Type of gears: {typeOfGears}");
                    //Console.WriteLine($"Horse Power: {horsePower}");
                    //Console.WriteLine($"Engine CM: {engineCubicCentimeters}");
                    //Console.WriteLine($"Color: {color}");
                    //Console.WriteLine($"Description: {info}");
                    //foreach (var item in extrax)
                    //{
                    //    Console.WriteLine($"---{item}");
                    //}
                    //Console.WriteLine("IMG-Links:");
                    //foreach (var item in imgLinks)
                    //{
                    //    Console.WriteLine($"---{item}");
                    //}
                    //Console.WriteLine($"City: {city}");
                    //Console.WriteLine(new string('-', 15));
                }
                catch (Exception ex)
                {

                    //Console.WriteLine("-");
                }
                Console.WriteLine($"+ {++i}");

            }

            var jsonFormated = JsonConvert.SerializeObject(carList, Formatting.Indented);
            var json = JsonConvert.SerializeObject(carList);
            File.WriteAllText("../../../CarsJsonFormated.json", jsonFormated);
            File.WriteAllText("../../../CarsJson.json", json);

            Console.WriteLine(watch.Elapsed);
        }


        private static async Task GetLinkFromCarsBg()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var uniqueLinks = new HashSet<string>();
            var watch = Stopwatch.StartNew();

            var ids = new int[] {
                86,
                54,
                10,
                63,
                8 ,
                69,
                64,
                26,
                80,
                17,
                25,
                53,
                60,
                31,
                72,
                73,
                57,
                33,
                38,
                76,
                77,
                85,
                4 ,
                15,
                43,
                19,
                37,
                56,
                42,
                21,
                16,
                74,
                71,
                20,
                36,
                68,
                75,
                92,
                45,
                40,
                34,
                23,
                30,
                35,
                59,
                10,
                12,
                79,
                14,
                89,
                41,
                81,
                12,
                55,
                50,
                87,
                9 ,
                47,
                67,
                84,
                24,
                32,
                27,
                10,
                97,
                49,
                70,
                13,
                91,
                14,
                29,
                6 ,
                65,
                13,
                7 ,
                52,
                22,
                1 ,
                13,
                99,
                12,
                12,
                44,
                78,
                13,
                3 ,
                14,
                66,
                95,
                11,
                82,
                10,
                90,
                61,
                136};
            for (int id = 0; id < ids.Length; id++)
            {
                for (int i = 1; i < 50; i++)
                {
                    var document = await context.OpenAsync($"https://www.cars.bg/carslist.php?subm=1&add_search=1&typeoffer=1&brandId={ids[id]}&conditions%5B0%5D=4&conditions%5B1%5D=1&ajax=1&page={i}");

                    //var url = "https://www.cars.bg/carslist.php?conditions%5B0%5D=4&conditions%5B1%5D=1&ajax=1&page={i}";
                    //var urlWithBrandIds = $"https://www.cars.bg/carslist.php?subm=1&add_search=1&typeoffer=1&brandId=86&conditions%5B0%5D=4&conditions%5B1%5D=1&ajax=1&page={i}";
                    var links = document
                        .Body
                        .QuerySelectorAll("div.mdc-card a");

                    foreach (var item in links)
                    {
                        var link = item.GetAttribute("href");
                        if (link.Contains("offer"))
                        {
                            //Console.WriteLine(i);
                            uniqueLinks.Add(link);
                        }
                    }
                }

                uniqueLinks.Add(new string('=', id));
            }


            File.WriteAllText("../../../test.txt", string.Join(Environment.NewLine, uniqueLinks));

            Console.WriteLine(watch.Elapsed);
        }
    }
}
