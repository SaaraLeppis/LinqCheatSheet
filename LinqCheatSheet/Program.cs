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
        AmountInDispute =1500,
        CaseType = CaseType.Commercial,
        Client = clients[2],
        Lawyer = lawyers[1]
    }
};