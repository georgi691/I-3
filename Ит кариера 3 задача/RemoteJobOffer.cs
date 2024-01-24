class RemoteJobOffer : JobOffer
{
    public bool FullyRemote { get; }

    public RemoteJobOffer(string jobTitle, string company, double salary, bool fullyRemote)
        : base(jobTitle, company, salary)
    {
        FullyRemote = fullyRemote;
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nFully Remote: {(FullyRemote ? "yes" : "no")}";
    }
}
   