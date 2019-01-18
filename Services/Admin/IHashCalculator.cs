namespace DeNew.Services.Admin
{
    public interface IHashCalculator
    {
        string GetHash(string input);
    }
}