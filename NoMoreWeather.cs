using EFT.Weather;
using MelonLoader;

namespace NoMoreWeather
{
    public class NoMoreWeather : MelonMod
    {
        bool inRaid = false;


        public override void OnUpdate()
        {
            if (inRaid) 
            {
                WeatherController.Instance.RainController.SetIntensity(0f);
                WeatherController.Instance.GlobalFogOvercast = 0f;
                WeatherController.Instance.LightningSummonBandWidth = 0f;
                WeatherController.Instance.RainController.enabled = false;
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Check the game scene's name to see if player is in raid
            switch (sceneName)
            {
                // In raid
                case "GameUIScene":
                    inRaid = true;
                    break;
                // Not in raid
                case "SessionEndUIScene":
                    inRaid = false;
                    break;
                default:
                    break;
            }
        }

    }
}
