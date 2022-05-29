namespace FDNS.Common.DataTransferObjects
{
    public abstract class BaseDTO<TKey> where TKey : IComparable
    {
        public TKey Id { get; set; }
    }
}
