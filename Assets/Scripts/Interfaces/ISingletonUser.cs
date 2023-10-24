public interface ISingletonUser<T>
{
    /*
     * Interface methods
     */
    public T GetSingletonInstance();

    public void SetSingletonInstance();
}
