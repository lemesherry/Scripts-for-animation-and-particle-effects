using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class RGBImage : MonoBehaviour {

        private readonly float tweenDuration = 0.5f;

        private Image image;

        private void Awake() => GetRawImageComponent();

        private void Start() => StartCoroutine( RGBColor() );

        private void OnDestroy() { DOTween.KillAll( true ); }

        private IEnumerator RGBColor() {

            var randomR = Random.Range( 0f, 1f );
            var randomG = Random.Range( 0f, 1f );
            var randomB = Random.Range( 0f, 1f );

            image.DOColor( new Color( randomR, randomG, randomB, 255 ), tweenDuration ).SetEase( Ease.Linear );

            yield return new WaitForSeconds( tweenDuration );
            StartCoroutine( RGBColor() );
        }

        private void GetRawImageComponent() => image = GetComponent< Image >();

    }

}
