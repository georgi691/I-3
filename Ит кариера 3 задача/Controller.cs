class Controller
{
    private List<Category> categories;

    public Controller()
    {
        categories = new List<Category>();
    }

    public string ProcessCommand(string command)
    {
        string[] commandParts = command.Split();
        string action = commandParts[0].ToLower();

        switch (action)
        {
            case "addcategory":
                return AddCategory(commandParts.Skip(1).ToList());
            case "addjoboffer":
                return AddJobOffer(commandParts.Skip(1).ToList());
            case "getaveragesalary":
                return GetAverageSalary(commandParts.Skip(1).ToList());
            case "getoffersabovesalary":
                return GetOffersAboveSalary(commandParts.Skip(1).ToList());
            case "getofferswithoutsalary":
                return GetOffersWithoutSalary(commandParts.Skip(1).ToList());
            case "end":
                return "Exiting the program.";
            default:
                return "Invalid command.";
        }
    }

    private string AddCategory(List<string> parameters)
    {
        try
        {
            string name = parameters[0];
            ValidateCategoryName(name);

            Category newCategory = new Category(name);
            categories.Add(newCategory);

            return $"Created Category {name}!";
        }
        catch (ArgumentException ex)
        {
            return $"Error: {ex.Message}";
        }
    }

        
    private string AddJobOffer(List<string> parameters)
    {
        try
        {
            string categoryName = parameters[0];
            ValidateCategoryExists(categoryName);

            string jobTitle = parameters[1];
            string company = parameters[2];
            double salary = double.Parse(parameters[3]);

            string type = parameters[4].ToLower();
            switch (type)
            {
                case "onsite":
                    string city = parameters[5];
                    OnSiteJobOffer onsiteJobOffer = new OnSiteJobOffer(jobTitle, company, salary, city);
                    AddJobOfferToCategory(categoryName, onsiteJobOffer);
                    break;

                case "remote":
                    bool fullyRemote = bool.Parse(parameters[5]);
                    RemoteJobOffer remoteJobOffer = new RemoteJobOffer(jobTitle, company, salary, fullyRemote);
                    AddJobOfferToCategory(categoryName, remoteJobOffer);
                    break;

                default:
                    throw new ArgumentException("Invalid job offer type.");
            }

            return $"Created JobOffer {jobTitle} in Category {categoryName}!";
        }
        catch (ArgumentException ex)
        {
            return $"Error: {ex.Message}";
        }
        catch (FormatException)
        {
            return "Error: Invalid input format.";
        }
    }

    private string GetAverageSalary(List<string> parameters)
    {
        try
        {
            string categoryName = parameters[0];
            ValidateCategoryExists(categoryName);

            Category category = categories.First(c => c.Name == categoryName);
            double averageSalary = category.AverageSalary();

            return $"The average salary is: {averageSalary:F2} BGN";
        }
        catch (ArgumentException ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    private string GetOffersAboveSalary(List<string> parameters)
    {
        try
        {
            string categoryName = parameters[0];
            double salary = double.Parse(parameters[1]);

            ValidateCategoryExists(categoryName);

            Category category = categories.First(c => c.Name == categoryName);
            List<JobOffer> offers = category.GetOffersAboveSalary(salary);

            return GetFormattedJobOffers(offers);
        }
        catch (ArgumentException ex)
        {
            return $"Error: {ex.Message}";
        }
        catch (FormatException)
        {
            return "Error: Invalid input format.";
        }
    }

    private string GetOffersWithoutSalary(List<string> parameters)
    {
        try
        {
            string categoryName = parameters[0];
            ValidateCategoryExists(categoryName);

            Category category = categories.First(c => c.Name == categoryName);
            List<JobOffer> offers = category.GetOffersWithoutSalary();

            return GetFormattedJobOffers(offers);
        }
        catch (ArgumentException ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    private string GetFormattedJobOffers(List<JobOffer> offers)
    {
        return offers.Any()
            ? string.Join("\n", offers.Select(offer => offer.ToString()))
            : "No job offers found.";
    }

    private void ValidateCategoryExists(string categoryName)
    {
        if (!categories.Any(c => c.Name == categoryName))
        {
            throw new ArgumentException($"Category {categoryName} does not exist.");
        }
    }

    private void ValidateCategoryName(string name)
    {
        if (categories.Any(c => c.Name == name))
        {
            throw new ArgumentException($"Category {name} already exists.");
        }
    }

    private void AddJobOfferToCategory(string categoryName, JobOffer jobOffer)
    {
        Category category = categories.First(c => c.Name == categoryName);
        category.AddJobOffer(jobOffer);
    }

}