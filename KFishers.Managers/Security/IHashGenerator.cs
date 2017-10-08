namespace KFishers.Managers.Security
{
    public interface IHashGenerator
    {
        string ComputeSHA512Hash(string value);

        bool VerifySHA512Hash(string hash, string value);
    }
}
