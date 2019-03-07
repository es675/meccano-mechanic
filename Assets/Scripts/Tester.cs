using UnityEngine;

namespace MeccanoMechanic
{
    public class Tester : MonoBehaviour
    {

        public MeccanoPiece p1;
        public MeccanoPiece p2;

        public void Start()
        {
            p1.Holes[0].connectTo(p2.Holes[0].transform);
        }
    }
}