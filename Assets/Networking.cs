using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Networking : MonoBehaviour
    {
        private static Networking _instance = null;

        public static Networking Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType(typeof(Networking)) as Networking;

                    if (_instance == null && Application.isEditor)
                        Debug.LogError("Could not locate a Networking object. You have to have exactly one Networking in the scene.");
                }

                return _instance;
            }
        }

        void Awake()
        {
            // See if we are a superfluous instance:
            if (_instance != null)
            {
                Debug.LogError("You can only have one instance of the Networking singleton object in existence.");
            }
            else
                _instance = this;
        }

        private List<WwwMessage> messages = new List<WwwMessage>();
        public static string ACCESS_POINT_URL = "http://my.djohnnie.be:8998/";

        // register all created WWWMessage objects and keep track of their status and yield progress. If they yield longer than the timeout stop the coroutine and make them call the error callback
        public void addMessage(WwwMessage msg)
        {
            messages.Add(msg);
        }

        public void start()
        {

        }

        public void update()
        {
            foreach (WwwMessage msg in messages)
            {
                if (msg.hasExpired())
                {
                    msg.invokeErrorCallback("Connection timeout", "error");
                }
            }
            messages.RemoveAll(msg => msg.isDone());
        }

        public void refreshTeams(Action<JSONObject> successCallback, Action<JSONObject> errorCallback)
        {
            var msg = new WwwMessage(this, "dashboard/teams", successCallback, errorCallback);
            msg.addHeaderParam("htf-identification", "7f395e9b-8eb2-4829-b948-49ca2df65b2c");
            Networking.Instance.StartCoroutine(msg.send());
        }
    }
}