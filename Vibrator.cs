using UnityEngine;

namespace Sherry.CustomScripts {

    public class Vibrator {

        private static class AndroidSet {

            public const string unityPlayer = "com.unity3d.player.UnityPlayer";
            public const string currentActivity = "currentActivity";
            public const string getSystemService = "getSystemService";
            public const string vibrator = "vibrator";
            public const string vibrate = "vibrate";
            public const string cancel = "cancel";

        }
    
    #if UNITY_ANDROID
        private static readonly AndroidJavaClass UnityPlayer = new AndroidJavaClass( AndroidSet.unityPlayer );
        private static readonly AndroidJavaObject CurrentActivity = UnityPlayer.GetStatic< AndroidJavaObject >( AndroidSet.currentActivity );
        private static readonly AndroidJavaObject AndroidVibrator = CurrentActivity.Call< AndroidJavaObject >( AndroidSet.getSystemService, AndroidSet.vibrator );
    #else
        private static AndroidJavaClass unityPlayer;
        private static AndroidJavaObject currentActivity;
        private static AndroidJavaObject vibrator;
    #endif

        public static void Vibrate( long vibrationMilliseconds = 80 ) {

            Debug.Log( "Vibrator is Called" );
            if( IsAndroidDevice() ) AndroidVibrator.Call( AndroidSet.vibrate, vibrationMilliseconds );
            else Handheld.Vibrate();
        }

        public void CancelVibration() {

            if( IsAndroidDevice() ) AndroidVibrator.Call( AndroidSet.cancel );
        }

        private static bool IsAndroidDevice() {

        #if UNITY_ANDROID && !UNITY_EDITOR
                return true;
        #else
            return false;
        #endif
        }

    }

}
