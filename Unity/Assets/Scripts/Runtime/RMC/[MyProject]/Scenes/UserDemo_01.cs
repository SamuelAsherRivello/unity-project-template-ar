using System.Collections.Generic;
using Niantic.Lightship.AR.ObjectDetection;
using Niantic.Lightship.AR.XRSubsystems;
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

        private float  _lastUpdateTimeSeconds = 0;
        private const float LastUpdateTimeMaxSeconds = 3f;
        
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
            //Update only once per X (Cosmetic reasons)
            if (Time.timeSinceLevelLoad - _lastUpdateTimeSeconds < LastUpdateTimeMaxSeconds)
            {
                return;
            }
            _lastUpdateTimeSeconds = Time.timeSinceLevelLoad;

            List<XRObjectCategorization> filtered = new List<XRObjectCategorization>(0);

            string message = "";
            foreach (var result in obj.Results)
            {
                foreach (var xrObjectCategorization in result.GetConfidentCategorizations())
                {
                    //Add ONE entry max for each name with highest confidence
                    var foundInFiltered = filtered.Find(x => x.CategoryName == xrObjectCategorization.CategoryName);
                    
                    if (foundInFiltered.Equals(default(XRObjectCategorization)) || foundInFiltered.Confidence < xrObjectCategorization.Confidence)
                    {
                        filtered.Add(xrObjectCategorization);
                    }
                }
            }
            
            Debug.Log("OnObjectDetectionsUpdated() Results: " + obj.Results.Count +  " vs filtered: " + filtered.Count);
            //Show filtered
            foreach (var result in filtered)
            {
           
                message += $"{result.CategoryName}({result.Confidence})\n";
            }

            SetTitle(message);
        }

        private void OnMetadataInitialized(ARObjectDetectionModelEventArgs obj)
        {
            Debug.Log(("OnMetadataInitialized() CategoryNames: " + obj.CategoryNames.Count));
        }
    }
}