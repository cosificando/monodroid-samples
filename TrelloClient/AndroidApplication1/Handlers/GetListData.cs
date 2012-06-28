namespace AndroidApplication1.Handlers
{
    using System.Collections;

    public abstract class HandDataList<T> where T: IEnumerable
    {
        public interface GivenA<S>
        {
            T GetDataList(S proxy, string id);
        }
    }
}