using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Sherry.CustomScripts {

    public class ScalingUI : MonoBehaviour {

        private readonly float durationOfTween = 0.25f;

        private void Start() => StartCoroutine( ChangeScale() );

        private IEnumerator ChangeScale() {

            var s = DOTween.Sequence();
            s.Append( transform.DOScale( new Vector3( 0.8f, 0.8f, 1 ), durationOfTween ).SetEase( Ease.Linear ) ).Append( transform.DOScale( new Vector3( 1, 1, 1 ), durationOfTween ).SetEase( Ease.Linear ) );

            yield return new WaitForSeconds( durationOfTween * 2 );
            StartCoroutine( ChangeScale() );
        }

        private void OnDestroy() => this.DOKill( true );

    }

}
