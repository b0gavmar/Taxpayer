using TaxpayerConsole.Model;

try
{
    Taxpayer emptymail = new Taxpayer("John Doe", "", 1000);
}
catch (Exception ex)
{
    Console.WriteLine($"Hiba: {ex.Message}");
}

Taxpayer antal = new Taxpayer("Adózó Antal", "adozo.antal@ado.hu");
try
{
    antal.IncreaseTaxCredit(-2000);
}
catch (Exception ex)
{
    Console.WriteLine($"Hiba: {ex.Message}");
}
antal.IncreaseTaxCredit(20000);
antal.DecreaseTaxCredit(10000);
Console.WriteLine(antal);