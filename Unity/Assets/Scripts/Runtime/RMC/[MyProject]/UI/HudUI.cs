using UnityEngine;
using UnityEngine.UIElements;

namespace RMC.MyProject.UI
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class HudUI : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public Label UpperLeftLabel { get { return _uiDocument?.rootVisualElement.Q<Label>("UpperLeftLabel"); }}
        public Label UpperRightLabel { get { return _uiDocument?.rootVisualElement.Q<Label>("UpperRightLabel"); }}


        //  Fields ----------------------------------------
        [SerializeField]
        private UIDocument _uiDocument;


        //  Unity Methods ---------------------------------
        protected void Start()
        {
            Debug.Log($"{GetType().Name}.Start()");
        }

        //  Methods ---------------------------------------
        public string SetTitle(string message)
        {
            return UpperLeftLabel.text = message;
        }
        public string SetScore(string message)
        {
            return UpperRightLabel.text = message;
        }


        //  Event Handlers --------------------------------
    }
}