using Online_Cloth_Ordering.ViewModel;

namespace Online_Cloth_Ordering.Model
{
    public interface ISessionsRepro
    {
        Sessions Add(Sessions session);
        String GetUsername();
    }
}
