using SSH_Configurer_UI.Model;

namespace SSH_Configurer_UI.Services.Interfaces
{
    public interface IContentService<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T?> GetById(int id);

        public Task<IEnumerable<T>> GetByIds(IEnumerable<int> ids);

        public Task<IEnumerable<T>> SearchByName(string input);

        public Task<int> Add(T device);

        public Task<int> Update(int id, T device);

        public Task<int> Remove(T device);
    }
}
