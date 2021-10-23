using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{

#pragma warning disable CS8618
public class Platform {

    [Key]
    [Required]
    public int Id {  get; set;}

    [Required]
    public string Name {  get; set;}
    [Required]
    public string Publisher {  get; set;}

    [Required]
    public string Cost  {  get; set;}


}
#pragma warning restore CS8618
}
