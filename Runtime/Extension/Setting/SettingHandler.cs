using UnityEngine;

namespace itismarciiExtansion.Runtime.Setting
{
    public static class SettingHandler
    {
        public static void SetScreenResolution(in int height, in int width) =>
            Screen.SetResolution(width, height, Screen.fullScreen);

        public static void ToggleFullscreen() => Screen.fullScreen = !Screen.fullScreen;
        
    }
}
