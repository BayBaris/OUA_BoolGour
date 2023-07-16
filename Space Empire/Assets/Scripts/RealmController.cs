using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Threading.Tasks;
using System;

public class RealmController : MonoBehaviour
{
    public static RealmController Instance;

    public string RealmAppId = "space-realms-fqymh";

    private Realm _realm;
    private App _realmApp;
    private User _realmUser;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    void OnDisable()
    {
        if (_realm != null)
        {
            _realm.Dispose();
        }
    }

    public async Task<string> Login(string email, string password)
    {
        if (email != "" && password != "")
        {
            _realmApp = App.Create(
                new AppConfiguration(RealmAppId)
                {
                    MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
                }
            );
            try
            {
                if (_realmUser == null)
                {
                    _realmUser = await _realmApp.LogInAsync(
                        Credentials.EmailPassword(email, password)
                    );
                    _realm = await Realm.GetInstanceAsync(
                        new PartitionSyncConfiguration(_realmUser.Id, _realmUser)
                    );
                }
                else
                {
                    _realm = Realm.GetInstance(
                        new PartitionSyncConfiguration(_realmUser.Id, _realmUser)
                    );
                }
            }
            catch (ClientResetException clientResetEx)
            {
                if (_realm != null)
                {
                    _realm.Dispose();
                }
                clientResetEx.InitiateClientReset();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        return "All fields must be present!";
    }

    public async Task<string> Register(string name, string email, string password)
    {
        if (name != "" && email != "" && password != "")
        {
            try
            {
                _realmApp = App.Create(
                    new AppConfiguration(RealmAppId)
                    {
                        MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
                    }
                );
                await _realmApp.EmailPasswordAuth.RegisterUserAsync(email, password);
                await Login(email, password);
                CreatePlayerProfile(_realmUser.Id, name, email);
            }
            catch (ClientResetException clientResetEx)
            {
                if (_realm != null)
                {
                    _realm.Dispose();
                }
                clientResetEx.InitiateClientReset();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        return "All fields must be present!";
    }

    public PlayerProfile CreatePlayerProfile(string id, string name, string email)
    {
        PlayerProfile _playerProfile = _realm.Find<PlayerProfile>(id);
        if (_playerProfile == null)
        {
            _realm.Write(() =>
            {
                _playerProfile = _realm.Add(new PlayerProfile(id, name, email));
            });
        }
        return _playerProfile;
    }

    public PlayerProfile GetPlayerProfile()
    {
        PlayerProfile _playerProfile = _realm.Find<PlayerProfile>(_realmUser.Id);
        if (_playerProfile == null)
        {
            _realm.Write(() =>
            {
                _playerProfile = _realm.Add(
                    new PlayerProfile(_realmUser.Id, _realmUser.Profile.Email)
                );
            });
        }
        return _playerProfile;
    }

    public void IncreaseMoney(int money)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.Money += money;
            });
        }
    }

    public void IncreaseBigMoney(int bigMoney)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.BigMoney += bigMoney;
            });
        }
    }

    public void XPosition(double x)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.X = x;
            });
        }
    }

    public void YPosition(double y)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.Y = y;
            });
        }
    }

    public void InPlanet(bool inPlanet)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.InPlanet = inPlanet;
            });
        }
    }

    public void HealtBar(int healtBar)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.HealtBar = healtBar;
            });
        }
    }
    
    public void FuelBar(int fuelBar)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.FuelBar = fuelBar;
            });
        }
    }

    public void RocketLife(int rocketLife)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.RocketLife = rocketLife;
            });
        }
    }

    public void Level(int level)
    {
        PlayerProfile _playerProfile = GetPlayerProfile();
        if (_playerProfile != null)
        {
            _realm.Write(() =>
            {
                _playerProfile.Level = level;
            });
        }
    }

}
