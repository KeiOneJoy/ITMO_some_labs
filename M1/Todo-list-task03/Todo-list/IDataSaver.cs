
namespace Todo_list
{
    public interface IDataSaver
    {
        void SaveData(List<Task> tasks);
        List<Task> LoadData();
    }
}