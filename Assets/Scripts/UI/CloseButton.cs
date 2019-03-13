using UnityEngine;
using UnityEngine.UI;

namespace MeccanoMechanic
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("Meccano Mechanic/UI/CloseButton")]
    public sealed class CloseButton : MonoBehaviour
    {
        // object to destroy when this button is clicked
        [SerializeField] private GameObject target;

        private void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            Destroy(target);
        }
    }
}