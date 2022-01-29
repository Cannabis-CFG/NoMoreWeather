using EFT.Weather;
using MelonLoader;
using UnityEngine;

namespace NoMoreWeather
{
    public class NoMoreWeather : MelonMod
    {
        bool inRaid = false;


        public override void OnUpdate()
        {
            if (inRaid && WeatherController.Instance != null) 
            {
                AnimationCurve test = new AnimationCurve();
                WeatherController.Instance.RainController.SetIntensity(0f);
                WeatherController.Instance.GlobalFogOvercast = 0f;
                WeatherController.Instance.GlobalFogStrength = test;
                WeatherController.Instance.GlobalFogY = test;
                WeatherController.Instance.FogMultyplyer = test;
                WeatherController.Instance.LightningSummonBandWidth = 0f;
                WeatherController.Instance.RainController.enabled = false;
            }
        }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("NoMoreWeather is now loaded. Weather should now be clear for all raids!");

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Check the game scene's name to see if player is in raid
            //MelonLogger.Msg($"Game scene loaded: {sceneName} | Build index: {buildIndex}");

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
