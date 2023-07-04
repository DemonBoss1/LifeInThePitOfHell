using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    public static GameController gameController;
    private void Awake() {
        gameController = this;
    }
    public void SpawnEmpty(){
        Vector2 pos=new Vector2(-4, 2);
        Instantiate(projectilePrefab, pos, Quaternion.identity);
    }
}
