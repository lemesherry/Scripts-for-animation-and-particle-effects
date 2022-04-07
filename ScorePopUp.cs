using System;
using Core;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Extras {

    public class ScorePopUp : MonoBehaviour {

        private TextMeshPro textmesh;

        private void Awake() {
            
            GetTextMeshComponent();
        }

        private void Start() {

            textmesh.text = $"+{GameManager.Instance.GameSettings.scoreToAdd}";
            textmesh.DOFade( 0f, 1.5f );
            transform.DOMove( transform.position + Vector3.up * 2, 1.55f ).OnComplete( () => {
                Destroy( gameObject );
            } );
        }

        private void GetTextMeshComponent() => textmesh = GetComponent< TextMeshPro >();

        private void OnDestroy() {
            
            this.DOKill( true );
        }

    }

}
