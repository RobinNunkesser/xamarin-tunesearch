using System;
namespace TuneSearch.Common
{
    public interface IPresenter<Entity,ViewModel>
    {
        ViewModel present(Entity entity);
    }
}