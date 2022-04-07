using UnityEngine;

namespace UI {

    public class RotateUI : MonoBehaviour {

        private void FixedUpdate() => transform.Rotate( 0, 0, 1 );

    }

}
