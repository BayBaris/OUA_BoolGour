using Realms;
using Realms.Sync;

public class PlayerProfile : RealmObject {

    [PrimaryKey]
    [MapTo("_id")]
    public string UserId { get; set; }

    [MapTo("name")]
    public string Name { get; set; }

    [MapTo("email")]
    public string Email { get; set; }

    [MapTo("money")]
    public int Money { get; set; }

    [MapTo("bigMoney")]
    public int BigMoney { get; set; }

    [MapTo("x")]
    public double X { get; set; }

    [MapTo("y")]
    public double Y { get; set; }

    [MapTo("inPlanet")]
    public bool InPlanet { get; set; }

    [MapTo("healtBar")]
    public int HealtBar { get; set; }

    [MapTo("fuelBar")]
    public int FuelBar { get; set; }

    [MapTo("rocketLife")]
    public int RocketLife { get; set; }

    [MapTo("level")]
    public int Level { get; set; }

    [MapTo("firsTutarial")]
    public bool FirstTutarial { get; set; }


    public PlayerProfile() {}

    public PlayerProfile(string userId, string email) {
        this.UserId = userId;
        this.Name = "";
        this.Email = email;
        this.Money = 0;
        this.BigMoney = 0;
        this.X = -5.91;
        this.Y = -1.74;
        this.InPlanet = false;
        this.HealtBar = 10;
        this.FuelBar = 10;
        this.RocketLife = 10;
        this.Level = 1;
        this.FirstTutarial = false;
    }

    public PlayerProfile(string userId, string name, string email) {
        this.UserId = userId;
        this.Name = name;
        this.Email = email;
        this.Money = 0;
        this.BigMoney = 0;
        this.X = -5.91;
        this.Y = -1.74;
        this.InPlanet = false;
        this.HealtBar = 10;
        this.FuelBar = 10;
        this.RocketLife = 10;
        this.Level = 1;
        this.FirstTutarial = false;
    }

}