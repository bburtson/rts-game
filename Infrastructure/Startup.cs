using Assets.Configuration;
using UnityEngine;

public class Startup : MonoBehaviour
{
    private static IGameConfiguration Configuration { get; set; }

    void Awake()
    { 
        Run();
    }

    public static void Run()
    {
        var builder = new GameConfigurationBuilder()
                      .UseInfrastructureNode<MainNode>()
                      .AddUserPreferences<UserPreferences>(config => config.UseDefaults());

        Configuration = builder.Build();
    }
}


