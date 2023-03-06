using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CacheMonet {
    public class GameController : MonoBehaviour
    {
        public IList AllGameObjects;
        public int TargetFrameRate;
        private Text text1;
        private Text text2;

        private float updateCount = 0;
        private float fixedUpdateCount = 0;
        void Awake() {
            Application.targetFrameRate = TargetFrameRate;
            Font arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            GameObject canvasObject = new GameObject();
            canvasObject.name = "Canvas";
            canvasObject.AddComponent<Canvas>();
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();

            Canvas canvas;
            canvas = canvasObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            GameObject textObject1 = new GameObject();
            textObject1.transform.parent = canvasObject.transform;
            textObject1.AddComponent<Text>();
            GameObject textObject2 = new GameObject();
            textObject2.transform.parent = canvasObject.transform;
            textObject2.AddComponent<Text>();

            text1 = textObject1.GetComponent<Text>();
            text1.font = arial;
            text1.fontSize = 48;
            text1.alignment = TextAnchor.MiddleCenter;

            text2 = textObject2.GetComponent<Text>();
            text2.font = arial;
            text2.fontSize = 48;
            text2.alignment = TextAnchor.MiddleCenter;

            RectTransform t1, t2;
            t1 = text1.GetComponent<RectTransform>();
            t1.localPosition = new Vector3(0,0,0);
            t1.sizeDelta = new Vector2(600,600);

            t2 = text2.GetComponent<RectTransform>();
            t2.localPosition = new Vector3(200,0,0);
            t2.sizeDelta = new Vector2(600,600);

        }
        // Start is called before the first frame update
        void Start() {
            AllGameObjects = new ArrayList();

        }

        // Update is called once per frame
        void Update() {
            updateCount++;
            text1.text = updateCount.ToString();
        }

        void FixedUpdate() {
            fixedUpdateCount++;
            text2.text = fixedUpdateCount.ToString();
            
        }

        void Pause() {
            Time.timeScale = 0;
        }

        void Resume() {
            Time.timeScale = 1;
        }


        // updates the money amount based on income
        void updateCashBalance() {

        }

        int calculateCashStep(int steps) {
            int delta = 0;
            foreach (AutoObject obj in AllGameObjects) {
                if (obj is AutoCashObject) {
                    delta += ((AutoCashObject)obj).income;
                }
            }
            return delta;
        }
    }
}

