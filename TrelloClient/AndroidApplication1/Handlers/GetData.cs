namespace AndroidApplication1.Handlers
{
    public abstract class HandData<T>
    {
        public interface GivenA<S>
        {
            T GetData(S proxy, string id);
        }
    }
}