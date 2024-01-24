class JobOffer
{
    public string JobTitle { get; }
    public string Company { get; }
    public double Salary { get; }

    public JobOffer(string jobTitle, string company, double salary)
    {
        ValidateJobTitle(jobTitle);
        ValidateCompany(company);
        ValidateSalary(salary);

        JobTitle = jobTitle;
        Company = company;
        Salary = salary;
    }

    private void ValidateJobTitle(string jobTitle)
    {
        if (jobTitle.Length < 3 || jobTitle.Length > 30)
        {
            throw new ArgumentException("JobTitle should be between 3 and 30 characters!");
        }
    }

    private void ValidateCompany(string company)
    {
        if (company.Length < 3 || company.Length > 30)
        {
            throw new ArgumentException("Company should be between 3 and 30 characters!");
        }
    }

    private void ValidateSalary(double salary)
    {
        if (salary < 0)
        {
            throw new ArgumentException("Salary should be 0 or positive!");
        }
    }

    public override string ToString()
    {
        return $"Job Title: {JobTitle}\nCompany: {Company}\nSalary: {Salary:F2} BGN";
    }
}

