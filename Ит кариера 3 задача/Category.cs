class Category
{
    private string name;
    private List<JobOffer> jobOffers;

    public string Name
    {
        get => name;
        private set
        {
            if (value.Length < 2 || value.Length > 40)
            {
                throw new ArgumentException("Name should be between 2 and 40 characters!");
            }

            name = value;
        }
    }

    public Category(string name)
    {
        Name = name;
        jobOffers = new List<JobOffer>();
    }

    public void AddJobOffer(JobOffer offer)
    {
        jobOffers.Add(offer);
    }

    public double AverageSalary()
    {
        if (jobOffers.Count == 0)
        {
            return 0;
        }

        return jobOffers.Average(offer => offer.Salary);
    }

    public List<JobOffer> GetOffersAboveSalary(double salary)
    {
        return jobOffers.Where(offer => offer.Salary >= salary)
                        .OrderByDescending(offer => offer.Salary)
                        .ToList();
    }

    public List<JobOffer> GetOffersWithoutSalary()
    {
        return jobOffers.Where(offer => offer.Salary == 0)
                        .OrderBy(offer => offer.Company)
                        .ToList();
    }

    public override string ToString()
    {
        return $"Category {Name}\nTotal Offers: {jobOffers.Count}";
    }
}