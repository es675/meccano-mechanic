using UnityEngine;
using UnityEngine.UI;

namespace MeccanoMechanic
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("Meccano Mechanic/UI/DuplicateButton")]
    public sealed class DuplicateButton : MonoBehaviour
    {
        // object to duplicate when this button is clicked
        [SerializeField] private GameObject target;

        // position offset when duplicating
        [SerializeField] private Vector3 positionOffset;

        private void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            var rotation = target.transform.rotation;
            var position = new Vector3(target.transform.position.x + positionOffset.x,
                target.transform.localPosition.y + positionOffset.y,
                target.transform.localPosition.z + positionOffset.z);
            var clone = Instantiate(target, position, rotation);
            clone.transform.SetParent(target.transform.parent, false);
        }
    }
}