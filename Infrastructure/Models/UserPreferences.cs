using System;

[Serializable]
public class UserPreferences 
{
    // Other game options will goo here eventually (sound, graphics excetera)
    public float ScrollSpeed = 0;
    public float ScrollBoundary = 0;

    public void UseDefaults()
    {
        ScrollSpeed = 15;
        ScrollBoundary = 55;
    }
}
