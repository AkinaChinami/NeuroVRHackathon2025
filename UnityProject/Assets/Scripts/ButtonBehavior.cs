    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit;

    public class ButtonBehavior : MonoBehaviour
    {
        // Start is called before the first frame update
        private XRGrabInteractable grabInteractable;
        //private IXRInteractor grabInteractor;
        public bool isGrabbed = false;
        void Start()
        {
            Debug.Log("hello");
            grabInteractable = gameObject.GetComponent<XRGrabInteractable>();
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("HELLO");
            // var grabInteractor = grabInteractable.Interactors.FirstorDefault<IXRInteractor>();
            // if (grabInteractor != null){
            //      
            // }
        }
        public void OnGrabbed(SelectEnterEventArgs args)
        {
            isGrabbed = true;
            Debug.Log(gameObject.name + " is grabbed.");
            //Destroy(gameObject);
            
        }
    }
