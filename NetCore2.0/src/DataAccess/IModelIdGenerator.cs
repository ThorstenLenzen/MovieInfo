namespace Toto.MovieInfo.DataAccess
{
    public interface IModelIdGenerator<in TModel>
    {
        string Create(TModel model);
    }
}