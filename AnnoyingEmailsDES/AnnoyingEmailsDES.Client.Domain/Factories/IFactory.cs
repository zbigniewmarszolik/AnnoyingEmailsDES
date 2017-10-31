namespace AnnoyingEmailsDES.Client.Domain.Factories
{
    /*
     * Generic factory.
     */
    public interface IFactory<TObject>
    {
        TObject Create();
    }
}
