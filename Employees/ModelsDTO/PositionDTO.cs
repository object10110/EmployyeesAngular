using Newtonsoft.Json;

namespace Employees.ModelsDTO
{
    public class PositionDTO
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}