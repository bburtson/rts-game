using System;
using System.Text;
using UnityEngine;

namespace Assets.Configuration
{
    public class GameConfigurationBuilder
    {
        private GameConfiguration _gameConfig;
        private IInfrastructureNode _infrastructureNode;


        public GameConfigurationBuilder()
        {
            _gameConfig = new GameConfiguration();
        }

        public GameConfigurationBuilder UseInfrastructureNode<T>() where T : MonoBehaviour
        {
            var node = GameObject.FindObjectOfType<T>() as T;

            _infrastructureNode = node as IInfrastructureNode;

            if(_infrastructureNode == null)
            {
                var sb = new StringBuilder();

                sb.Append("Provided generic argument does not implement Interface IInfrastructureNode. ");
                sb.Append("Nodes must be attatched to a GameObject in the scene, ");
                sb.Append("derive from MonoBehaviour, and implement IInfrastructureNode ");

                var errorMessage = sb.ToString();

                var exception = new ArgumentException(errorMessage, typeof(T).ToString());

                throw exception;
            }

            return this;
        }


        /// <summary>
        /// Adds a user preferences object specified as type T
        /// </summary>
        /// <returns>instance of GameConfigurationBuilder with Default Preferences</returns>
        public GameConfigurationBuilder AddUserPreferences<T>() where T : new()
        {
            _gameConfig.SetUserPreferences(new T());

            return this;
        }

        /// <summary>
        /// Adds a user preferences object specified as type T
        /// </summary>
        /// <returns>instance of GameConfigurationBuilder with User Preferences Configuration Action</returns>
        public GameConfigurationBuilder AddUserPreferences<T>(Action<T> configurePreferences) where T : new()
        {
            var prefs = new T();

            configurePreferences(prefs);

            _gameConfig.SetUserPreferences(prefs);

            return this;
        }

        public GameConfiguration Build()
        {
            if(_infrastructureNode != null)
            {
                _infrastructureNode.SetConfiguration(_gameConfig);
            }
            

            return _gameConfig;
        }
    }
}
