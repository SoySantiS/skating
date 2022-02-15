using UnityEngine;

public class Collectible : MonoBehaviour
{
    public PointsManager pointsManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            pointsManager.AddPoints(50);
            
            //TODO: agregar sonido
        }
    }
}
