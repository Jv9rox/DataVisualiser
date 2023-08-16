using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataVisualiser.Models
{
    public class DashboardConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DashboardConfigurations { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
