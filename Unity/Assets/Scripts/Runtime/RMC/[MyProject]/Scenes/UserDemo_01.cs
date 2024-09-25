using Niantic.Lightship.AR.ObjectDetection;
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
    public class UserDemo_01 : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public HudUI HudUI { get { return _hudUI; } }


        //  Fields ----------------------------------------
        [SerializeField]
        private HudUI _hudUI;

        [SerializeField] 
        private ARObjectDetectionManager _arObjectDetectionManager;

        //  Unity Methods ---------------------------------
        protected void Start()
        {
            Debug.Log($"{GetType().Name}.Start()");
            
            // Set UI Text
            SetTitle("");
            HudUI.SetScore("Score: 000");

            _arObjectDetectionManager.MetadataInitialized += OnMetadataInitialized;
            _arObjectDetectionManager.ObjectDetectionsUpdated += OnObjectDetectionsUpdated;

        }

        private void SetTitle(string message)
        {
            HudUI.SetTitle(SceneManager.GetActiveScene().name + "\nObject Detection\n" + message);
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
        private void OnObjectDetectionsUpdated(ARObjectDetectionsUpdatedEventArgs obj)
        {
            Debug.Log(("OnObjectDetectionsUpdated Results: " + obj.Results.Count));

            string message = "";
            foreach (var result in obj.Results)
            {
                foreach (var xrObjectCategorization in result.GetConfidentCategorizations())
                {
                    message += $"{xrObjectCategorization.CategoryName}({xrObjectCategorization.Confidence})\n";
                }
            }

            SetTitle(message);
        }

        private void OnMetadataInitialized(ARObjectDetectionModelEventArgs obj)
        {
            Debug.Log(("OnMetadataInitialized CategoryNames: " + obj.CategoryNames.Count));
        }
    }
}