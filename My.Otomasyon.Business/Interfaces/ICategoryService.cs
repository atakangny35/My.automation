using My.Otomasyon.Entities.Concrete;

namespace My.Otomasyon.Business.Interfaces
{
    public interface ICategoryService:IgenericService<Category>
    {
        void DeleteSoft(int id);
    }
}
