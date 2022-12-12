List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
/* IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions."); */
// Execute Assignment Tasks here!

//Eruption eruptionInChile = eruptions.FirstOrDefault(e => e.Location == "Chile");

Eruption eruptionInHawaii = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (eruptionInHawaii != null)
{
    Console.WriteLine(eruptionInHawaii.ToString());
}
else
{
    Console.WriteLine("No Hawaiian Is eruption found.");
}

Eruption eruptionInGreenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (eruptionInGreenland != null)
{
    Console.WriteLine(eruptionInGreenland.ToString());
}
else
{
    Console.WriteLine("No Greenland eruption found.");
}

Eruption eruptionInNewZealand = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
Console.WriteLine(eruptionInNewZealand);

IEnumerable<Eruption> highElevationEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(highElevationEruptions, "Eruptions with volcanoes over 2000 meters elevation:");

IEnumerable<Eruption> eruptionsStartingWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(eruptionsStartingWithL, "Eruptions with volcano names starting with 'L':");

int numEruptions = eruptionsStartingWithL.Count();
Console.WriteLine($"Number of eruptions found: {numEruptions}");

int maxElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"Highest elevation: {maxElevation}");

IEnumerable<Eruption> highestElevationEruption = eruptions.Where(e => e.ElevationInMeters == maxElevation);
PrintEach(highestElevationEruption);

eruptions.Sort((e1, e2) => e1.Volcano.CompareTo(e2.Volcano));
PrintEach(eruptions);


var totalElevation = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"Total Elevation: {totalElevation} meters");

var eruptedIn2000 = eruptions.Any(e => e.Year == 2000);
if (eruptedIn2000)
{
    Console.WriteLine("At least one volcano erupted in 2000");
}
else
{
    Console.WriteLine("No volcanoes erupted in 2000");
}

var stratovolcanoes = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(stratovolcanoes);

var pre1000Eruptions = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
foreach (var name in pre1000Eruptions)
{
    Console.WriteLine(name);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
