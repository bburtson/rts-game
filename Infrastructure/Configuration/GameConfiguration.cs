using System;

namespace Assets
{
    public class GameConfiguration : IGameConfiguration
    {
        private object _userPreferences;

        public T GetUserPreferences<T>()
        {
            return (T)_userPreferences;
        }

        public void SetUserPreferences<T>(T preferencesObject)
        {
            _userPreferences = preferencesObject;
        }
    }
}
