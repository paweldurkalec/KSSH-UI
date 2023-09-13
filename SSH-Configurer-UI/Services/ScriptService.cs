using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Model.DTOs.Script;
using SSH_Configurer_UI.Pages.List;
using SSH_Configurer_UI.Services.Interfaces;
using System.Text.Json;

namespace SSH_Configurer_UI.Services
{
    public class ScriptService : IContentService<Script>
    {
        private readonly HttpClient httpClient;

        public ScriptService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> Add(Script script)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(new ScriptDTO(script));
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

        public async Task<int> Update(int id, Script script)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(new ScriptDTO(script));
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

        public async Task<IEnumerable<Script>> GetAll()
        {
            try
            {
                var dtos = await httpClient.GetFromJsonAsync<IEnumerable<ScriptDTOId>>("").ConfigureAwait(false);

                return dtos.Select(d => new Script(d)).OrderBy(d => d.Id).ToList();
            }
            catch (HttpRequestException)
            {
                return new List<Script>();
            }
        }


        public async Task<Script?> GetById(int id)
        {
            try
            {
                var dto = await httpClient.GetFromJsonAsync<ScriptDTOId>($"{id}/").ConfigureAwait(false);

                if (dto != null)
                {
                    return new Script(dto);
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

        public async Task<IEnumerable<Script>> GetByIds(IEnumerable<int> ids)
        {
            var tasks = ids.Select(id => GetById(id));
            var scripts = await Task.WhenAll(tasks).ConfigureAwait(false);

            return scripts.Where(script => script is not null).Select(script => script!);
        }

        public async Task<IEnumerable<Script>> SearchByName(string input)
        {
            var allScripts = await GetAll().ConfigureAwait(false);

            var filteredScripts = allScripts.Where(script => script.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

            return filteredScripts.ToList();
        }

        public async Task<int> Remove(Script script)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{script.Id}").ConfigureAwait(false);

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
