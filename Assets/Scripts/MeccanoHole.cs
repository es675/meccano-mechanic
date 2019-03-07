using System.Collections.Generic;
using UnityEngine;

namespace MeccanoMechanic
{
    [DisallowMultipleComponent]
    public class MeccanoHole : MonoBehaviour
    {
        /// <summary>
        /// The objects currently connected to this hole.
        /// </summary>
        public List<Transform> Attachments { get; } = new List<Transform>();

        /// <summary>
        /// The piece this Hole belongs to.
        /// </summary>
        /// <returns></returns>
        public MeccanoPiece getPiece()
        {
            return this.GetComponentInParent<MeccanoPiece>();
        }
    }
}