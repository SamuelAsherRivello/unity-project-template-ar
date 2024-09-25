using RMC.MyProject.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RMC.MyProject.Scenes
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class UserDemo_02 : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public HudUI HudUI { get { return _hudUI; } }


        //  Fields ----------------------------------------
        [SerializeField]
        private HudUI _hudUI;


        //  Unity Methods ---------------------------------
        protected void Start()
        {
            Debug.Log($"{GetType().Name}.Start()");
            
            // Set UI Text
            HudUI.SetTitle(SceneManager.GetActiveScene().name + "\nDetect Table");
            HudUI.SetScore("Score: 000");
            
        }


        protected void Update()
        {

        }


        //  Methods ---------------------------------------
        public string SamplePublicMethod(string message)
        {
            return message;
        }


        //  Event Handlers --------------------------------
        public void Target_OnCompleted(string message)
        {

        }
    }
}