using Assets;
using UnityEngine;

public class MainNode : MonoBehaviour, IInfrastructureNode
{
    public UserPreferences UserPreferences;

    public void SetConfiguration(IGameConfiguration config)
    {
        MapConfigurations(config);
    }

    private void MapConfigurations(IGameConfiguration configuration)
    {
        UserPreferences = configuration.GetUserPreferences<UserPreferences>();
    }
}
