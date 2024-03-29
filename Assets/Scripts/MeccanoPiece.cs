﻿using System.Collections.Generic;
using UnityEngine;

namespace MeccanoMechanic
{
    [DisallowMultipleComponent]
    public class MeccanoPiece : MonoBehaviour
    {
        public List<MeccanoHole> Holes { get; } = new List<MeccanoHole>();

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                var hole = child.GetComponent<MeccanoHole>();
                if (hole) Holes.Add(hole);
            }
        }

        public void moveTo(Vector3 position)
        {
            var delta = position - transform.position;
            transform.position += delta;
        }
    }
}