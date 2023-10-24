using LinqCheatSheet;

var lawyers = new[]
{
    new Lawyer()
    {
        FirstName = "Patty",
        LastName = "Smith"
    },
    new Lawyer()
    {
        FirstName = "John",
        LastName ="Someone"
    }
};

var clients = new[]
{
    new Client()
    {
        FirstName = "Assi",
        LastName ="Asiakas"
    },
    new Client()
    {
        FirstName = "Clive",
        LastName ="Client"
    },
    new Client()
    {
        FirstName = "Jaska",
        LastName ="Jokunen"
    }
};

var cases = new[]
{
    new Case()
    {
        Title ="Car accident",
        AmountInDispute =10000,
        CaseType = CaseType.Commercial,
        Client = clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title ="Molding flat",
        AmountInDispute =65000,
        CaseType = CaseType.ProBono,
        Client = clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title ="Death threat",
        AmountInDispute =15000,
        CaseType = CaseType.Commercial,
        Client = clients[1],
        Lawyer = lawyers[1]
    },
    new Case()
    {
        Title ="Robbery",
        AmountInDispute =1000,
        CaseType = CaseType.Commercial,
        Client = clients[2],
        Lawyer = lawyers[1]
    }
};

//Where 
foreach (Lawyer lawyer in lawyers)
{  
    lawyer.Cases = cases.Where(c => c.Lawyer == lawyer).ToList();
}

foreach (Client client in clients)
{
    client.Cases = cases.Where(c => c.Client == client).ToList();
}
//First and Single
// if we want to return only the first lawyer:
// var workingFirstExample = lawyers.First();
// otherwise we need a condition as argument  (here lambda function)

var workingFirstExample = lawyers.First(l => l.FirstName == "Patty");

try
{
    var firstExceptionExample = lawyers.First(l => l.FirstName == "Pat");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Invalid operation exception, cause no matching element found"); 
}

// FirstOrDefault returns the default value for the specified datatype, if no matching element is found.
// For classes thats null and for value typre thats the default value. For example for int it is 0. 
var firstOrDefaultExample = lawyers.FirstOrDefault(l => l.FirstName == "Pat");

// Single works like First, but ensures that only a single element matches the specified condition. 
var workingSingleExample = lawyers.Single(l => l.FirstName == "Patty");
try
{
    var singleExceptionExample = lawyers.Single(l => l.FirstName == "Pat");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Invalid operation exception, cause no matching element found");
}

try
{
    var singleExceptionExample = lawyers.Single(l => l.LastName.Contains("S"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Throws invalid operation exception, cause more than one element matches the condition");
}

// SingleOrDefault returns the default value for the specific datatype, if no matching element was found. 
//For classes thats null and for value types thats the default value. For example for int it is 0. 
// Evertything else works slike Single
var singleOrDefaultExample = lawyers.SingleOrDefault(l => l.FirstName == "Pat");

// Any and All 
var proBonoLawyers = lawyers.Where(l => l.Cases.Any(c => c.CaseType == CaseType.ProBono));
var commercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial));

// Working with numbers
var sumOfAmountInDispute = cases.Sum(c => c.AmountInDispute);
var averageAmountInDispute = cases.Average(c => c.AmountInDispute);
var maxOfInDispute = cases.Max(c => c.AmountInDispute);
var minOfInDispute = cases.Min(c => c.AmountInDispute);
Console.WriteLine($" {sumOfAmountInDispute}, {averageAmountInDispute}, {maxOfInDispute}, {minOfInDispute} ");

// OrderBy 
//Ascending and Descending  
var lawyersByAmountInDisputeAsc = lawyers.OrderBy(l => l.Cases.Sum(c => c.AmountInDispute));
var lawyersByAmountInDisputeDesc = lawyers.OrderByDescending(l => l.Cases.Sum(c => c.AmountInDispute));

Console.WriteLine($" Lawyers by amount *Ascending :{lawyersByAmountInDisputeAsc}," +
    $"* Descending: {lawyersByAmountInDisputeDesc}");
