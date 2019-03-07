using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MeccanoMechanic
{
    public class InputController : MonoBehaviour
    {
        // the object being dragged
        private Transform dragged;

        /// <summary>
        /// Will automatically connect holes closer than this distance.
        /// </summary>
        public float snapDistance = 10f;

        private static (Transform closest, float distance) GetClosestObject(Transform transform, IEnumerable<Transform> objects)
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (Transform t in objects)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return (tMin, minDist);
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (dragged)
                {
                    Debug.Log("Stopped dragging: " + dragged);
                    var piece = dragged.GetComponent<MeccanoPiece>();
                    foreach (var hole in piece.Holes)
                    {
                        var result = GetClosestObject(dragged, GameObject.FindObjectsOfType<MeccanoHole>().Select(x => x.transform));
                        if (result.distance > snapDistance 
                            || result.closest.parent == dragged 
                            || dragged.parent == result.closest) continue;

                        piece.transform.position = result.closest.position;
                        break;
                    }
                    dragged = null;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit) && hit.transform.GetComponent<MeccanoPiece>())
                {
                    Debug.Log("Started dragging: " + dragged);
                    dragged = hit.transform;
                }
            }

            if (Input.GetMouseButton(0) && dragged != null)
            {
                Debug.Log("Dragging!");
                var distanceToScreen = Camera.main.WorldToScreenPoint(dragged.transform.position).z;
                dragged.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
            }
        }
    }
}
