using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Model.DTOs.Group;
using SSH_Configurer_UI.Pages;
using SSH_Configurer_UI.Pages.List;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using SSH_Configurer_UI.Services.Interfaces;
using SSH_Configurer_UI.Model.DTOs.Async;
using Newtonsoft.Json.Linq;

namespace SSH_Configurer_UI.Services
{
    public class GroupService : IContentService<Group>
    {
        private readonly HttpClient httpClient;

        public GroupService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string?> CheckConnection(int id)
        {
            var response = await httpClient.PostAsync($"{id}/async_check_connection/", null).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var jsonObject = JObject.Parse(responseContent);
                string requestUuid = jsonObject["request_uuid"].ToString();
                return requestUuid;
            }
            return null;
        }

        public async Task<int> Add(Group group)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(new GroupDTO(group));
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

        public async Task<int> Update(int id, Group group)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(new GroupDTO(group));
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

        public async Task<IEnumerable<Group>> GetAll()
        {
            try
            {
                var dtos = await httpClient.GetFromJsonAsync<IEnumerable<GroupDTOId>>("").ConfigureAwait(false);

                return dtos.Select(d => new Group(d)).OrderBy(d => d.Id).ToList();
            }
            catch (HttpRequestException)
            {
                return new List<Group>();
            }
        }


        public async Task<Group?> GetById(int id)
        {
            try
            {
                var dto = await httpClient.GetFromJsonAsync<GroupDTOId>($"{id}/").ConfigureAwait(false);

                if (dto != null)
                {
                    return new Group(dto);
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

        public async Task<IEnumerable<Group>> GetByIds(IEnumerable<int> ids)
        {
            var tasks = ids.Select(id => GetById(id));
            var groups = await Task.WhenAll(tasks).ConfigureAwait(false);

            return groups.Where(group => group is not null).Select(group => group!);
        }

        public async Task<IEnumerable<Group>> SearchByName(string input)
        {
            var allGroups = await GetAll().ConfigureAwait(false);

            var filteredGroups = allGroups.Where(group => group.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

            return filteredGroups.ToList();
        }

        public async Task<int> Remove(Group group)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{group.Id}/").ConfigureAwait(false);

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
