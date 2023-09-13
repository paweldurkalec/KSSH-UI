using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Model.DTOs.KeyPair;
using SSH_Configurer_UI.Pages.List;
using SSH_Configurer_UI.Services.Interfaces;
using System.Text.Json;

namespace SSH_Configurer_UI.Services
{
    public class KeyPairService : IContentService<KeyPair>
    {
        private readonly HttpClient httpClient;

        public KeyPairService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> Add(KeyPair keyPair)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(new KeyPairDTO(keyPair));
                var bytes = MyUtils.ConvertToBytes(serialized);

                var response = await httpClient.PostAsync("", bytes).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (HttpRequestException)
            {
                return 0;
            }
        }

        public async Task<int> Update(int id, KeyPair keyPair)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(new KeyPairDTO(keyPair));
                var bytes = MyUtils.ConvertToBytes(serialized);

                var response = await httpClient.PutAsync($"{id}/", bytes).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (HttpRequestException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<KeyPair>> GetAll()
        {
            try
            {
                var dtos = await httpClient.GetFromJsonAsync<IEnumerable<KeyPairDTOId>>("").ConfigureAwait(false);

                return dtos.Select(d => new KeyPair(d)).OrderBy(d => d.Id).ToList();
            }
            catch (HttpRequestException)
            {
                return new List<KeyPair>();
            }
        }


        public async Task<KeyPair?> GetById(int id)
        {
            try
            {
                var dto = await httpClient.GetFromJsonAsync<KeyPairDTOId>($"{id}/").ConfigureAwait(false);

                if (dto != null)
                {
                    return new KeyPair(dto);
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<IEnumerable<KeyPair>> GetByIds(IEnumerable<int> ids)
        {
            var tasks = ids.Select(id => GetById(id));
            var keyPairs = await Task.WhenAll(tasks).ConfigureAwait(false);

            return keyPairs.Where(keyPair => keyPair is not null).Select(keyPair => keyPair!);
        }

        public async Task<IEnumerable<KeyPair>> SearchByName(string input)
        {
            var allKeyPairs = await GetAll().ConfigureAwait(false);

            var filteredKeyPairs = allKeyPairs.Where(keyPair => keyPair.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

            return filteredKeyPairs.ToList();
        }

        public async Task<int> Remove(KeyPair keyPair)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{keyPair.Id}").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (HttpRequestException)
            {
                return 1;
            }
        }
    }
}
