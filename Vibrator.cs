using UnityEngine;

namespace Sherry.CustomScripts {

    public class Vibrator {

    #if UNITY_ANDROID
        private static AndroidJavaClass unityPlayer = new AndroidJavaClass( AndroidSet.unityPlayer );
        private static AndroidJavaObject currentActivity = unityPlayer.GetStatic< AndroidJavaObject >( AndroidSet.currentActivity );
        private static AndroidJavaObject vibrator = currentActivity.Call< AndroidJavaObject >( AndroidSet.getSystemService, AndroidSet.vibrator );
    #else
        private static AndroidJavaClass unityPlayer;
        private static AndroidJavaObject currentActivity;
        private static AndroidJavaObject vibrator;
    #endif

        public void Vibrate( long vibrationMilliseconds = 80 ) {

            if( IsAndroidDevice() ) vibrator.Call( AndroidSet.vibrate, vibrationMilliseconds );
            else Handheld.Vibrate();
        }

        public void CancelVibration() {

            if( IsAndroidDevice() ) vibrator.Call( AndroidSet.cancel );
        }

        private bool IsAndroidDevice() {

        #if UNITY_ANDROID && !UNITY_EDITOR
                return true;
        #else
            return false;
        #endif
        }

    }

            
    public class AndroidSet {

        public const string unityPlayer = "com.unity3d.player.UnityPlayer";
        public const string currentActivity = "currentActivity";
        public const string getSystemService = "getSystemService";
        public const string vibrator = "vibrator";
        public const string vibrate = "vibrate";
        public const string cancel = "cancel";


    }
}
