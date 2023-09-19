using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace BackEndCubos.Domain.Core.DTOs
{
    public class Pagination
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        [BindNever]
        [JsonIgnore]
        public int Skip => (CurrentPage - 1) * ItemsPerPage;
    }
}
