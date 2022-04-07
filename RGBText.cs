using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Sherry.CustomScripts {

    public class RGBText : MonoBehaviour {

        private readonly float tweenDuration = 0.4f;

        private TextMeshProUGUI textMesh;

        private void Awake() => GetTextMeshComponent();

        private void Start() => StartCoroutine( RGBColor() );

        private void OnDestroy() => DOTween.KillAll( true );

        private IEnumerator RGBColor() {

            var randomR = Random.Range( 0f, 1f );
            var randomG = Random.Range( 0f, 1f );
            var randomB = Random.Range( 0f, 1f );

            textMesh.DOColor( new Color( randomR, randomG, randomB, 255 ), tweenDuration ).SetEase( Ease.Linear );

            yield return new WaitForSeconds( tweenDuration );
            StartCoroutine( RGBColor() );
        }

        private void GetTextMeshComponent() => textMesh = GetComponent< TextMeshProUGUI >();

    }

}
