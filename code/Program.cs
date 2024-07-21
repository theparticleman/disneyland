using System.Globalization;
using CsvHelper;
using disneyland_scripts;
using Spectre.Console;

using (var reader = new StreamReader("data.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<RideInfo>().ToList();
    records = records
        .Where(x => !x.Name.Contains("Not in the video"))
        .OrderBy(x => x.Park)
        .ThenBy(x => x.Land)
        .ToList();
    var table = new Table();
    table.AddColumn("Name");
    table.AddColumn("Park");
    table.AddColumn("Land");
    table.AddColumn("[green]Want to Go[/]");
    table.AddColumn("[yellow]Don't Care[/]");
    table.AddColumn("[red]Don't Want to Go[/]");
    var outputs = new List<OutputRecord>();
    foreach (var record in records)
    {
        var wantToGoNames = GetWantToGoNames(record);
        var doNotCareNames = GetDoNotCareNames(record);
        var doNotWantToGoNames = GetDoNotWantToGoNames(record);
        table.AddRow(record.Name, record.Park, record.Land, wantToGoNames, doNotCareNames, doNotWantToGoNames);
        outputs.Add(new OutputRecord
        {
            Name = record.Name,
            Park = record.Park,
            Land = record.Land,
            WantToGo = wantToGoNames,
            DoNotCare = doNotCareNames,
            DoNotWantToGo = doNotWantToGoNames
        });
    }

    AnsiConsole.Write(table);

    using var writer = new StreamWriter("output.csv");
    using var output = new CsvWriter(writer, CultureInfo.InvariantCulture);
    output.WriteRecords(outputs);
}

static string GetWantToGoNames(RideInfo record) => GetNames(record, ["4", "2"]);
static string GetDoNotWantToGoNames(RideInfo record) => GetNames(record, ["-1"]);
static string GetDoNotCareNames(RideInfo record)
{
    return GetNames(record, ["1", ""]);
}

static string GetNames(RideInfo record, string[] acceptableValues)
{
    if (record.Name.Contains("Not in the video")) return "";
    var listOfNames = new List<string>();
    if (acceptableValues.Contains(record.Samuel)) listOfNames.Add(nameof(RideInfo.Samuel));
    if (acceptableValues.Contains(record.Madeline)) listOfNames.Add(nameof(RideInfo.Madeline));
    if (acceptableValues.Contains(record.Maxwell)) listOfNames.Add(nameof(RideInfo.Maxwell));
    if (acceptableValues.Contains(record.MJ)) listOfNames.Add(nameof(RideInfo.MJ));
    if (acceptableValues.Contains(record.Melissa)) listOfNames.Add(nameof(RideInfo.Melissa));
    if (acceptableValues.Contains(record.Melinda)) listOfNames.Add(nameof(RideInfo.Melinda));
    if (acceptableValues.Contains(record.Nadine)) listOfNames.Add(nameof(RideInfo.Nadine));
    if (acceptableValues.Contains(record.Melody)) listOfNames.Add(nameof(RideInfo.Melody));
    return string.Join(", ", listOfNames);
}
