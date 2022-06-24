namespace SteamAPI.Models;

public class Group
{
    public int ID { get; set; }
    public int GroupSize { get; set; }
    public string GameName { get; set; }
    public string GameID { get; set; }
    
    public string GroupName { get; set; }
    
    public string Password { get; set; }
}