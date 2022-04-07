using System.Collections.Generic;
using System.Linq;
using Extras;
using UnityEngine;

namespace Sherry.CustomScripts {

    public class DrawRays : MonoBehaviour {

        private const int directionsCount = 16;
        private const float maxDistance = 1.5f;

        private void Start() => GetDistanceToGround();

        private float GetDistanceToGround() {
            
            var distances = new List< float >();

            foreach( var direction in GetSphereDirections( directionsCount ) ) {
                Debug.DrawRay( transform.position, direction * 1.2f, Color.red );

                if( !Physics.Raycast( transform.position, direction, out var _hitObject, maxDistance ) ) continue;
                distances.Add( _hitObject.distance );

                if( _hitObject.transform.CompareTag( Tags.point ) ) Destroy( _hitObject.transform.gameObject );
            }

            return distances.Any() ? distances.Min() : maxDistance;
        }

        private static IEnumerable< Vector3 > GetSphereDirections( int numDirections ) {
            var pts = new Vector3[numDirections];
            var inc = Mathf.PI * ( 3 - Mathf.Sqrt( 5 ) );
            var off = 2f / numDirections;

            foreach( var k in Enumerable.Range( 0, numDirections ) ) {
                var y = k * off - 1 + ( off / 2 );
                var r = Mathf.Sqrt( 1 - y * y );
                var phi = k * inc;
                var x = ( float )( Mathf.Cos( phi ) * r );
                var z = ( float )( Mathf.Sin( phi ) * r );
                pts[k] = new Vector3( x, y, z );
            }

            return pts;
        }

    }

}
