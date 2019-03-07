using UnityEngine;

namespace MeccanoMechanic
{
    [DisallowMultipleComponent]
    public class MeccanoHole : MonoBehaviour
    {
        public MeccanoPiece getPiece()
        {
            return this.GetComponentInParent<MeccanoPiece>();
        }

        /// <summary>
        /// Connects this hole to another hole, moving the piece this hole belongs to so that this hole is at the position of <see cref="target"/>.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public void connectTo(Transform target)
        {
            var positionDelta = target.transform.position - this.transform.position;
            getPiece().transform.position += positionDelta;
        }
    }
}