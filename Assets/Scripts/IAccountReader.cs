namespace Banking
{
    public interface IAccountReader
    {
        public void ReadData(string file, Account account);
    }
}