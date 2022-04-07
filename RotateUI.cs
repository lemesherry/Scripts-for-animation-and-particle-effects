using UnityEngine;

namespace Sherry.CustomScripts {

    public class RotateUI : MonoBehaviour {

        private void FixedUpdate() => transform.Rotate( 0, 0, 1 );

    }

}
