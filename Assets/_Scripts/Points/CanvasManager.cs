using UnityEngine;

namespace _Scripts.Points
{
    public class CanvasManager : MonoBehaviour
    {
        //Canvas:
        [SerializeField] private Canvas winCanvas, normalCanvas, joystickCanvas;
        
        private void Start()
        {
            winCanvas.gameObject.SetActive(false);
            normalCanvas.gameObject.SetActive(true);
            
            GameManager.SharedInstance.onGameFinished.AddListener(GameEnds);
        }

        public void GameEnds()
        {
            winCanvas.gameObject.SetActive(true);
            normalCanvas.gameObject.SetActive(false);
            joystickCanvas.gameObject.SetActive(false);
        }
    }
}