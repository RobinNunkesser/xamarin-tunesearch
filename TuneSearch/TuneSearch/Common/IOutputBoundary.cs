namespace TuneSearch.Common
{
    public interface IOutputBoundary<T>
    {
        void Receive(Response<T> response);         
    }
}