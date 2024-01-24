class OnSiteJobOffer : JobOffer
{
    public string City { get; }

    public OnSiteJobOffer(string jobTitle, string company, double salary, string city)
        : base(jobTitle, company, salary)
    {
        ValidateCity(city);
        City = city;
    }

    private void ValidateCity(string city)
    {
        if (city.Length < 3 || city.Length > 30)
        {
            throw new ArgumentException("City should be between 3 and 30 characters!");
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nCity: {City}";
    }
}



