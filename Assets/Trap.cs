using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trap : MonoBehaviour{
    public GameObject menu;
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            menu.SetActive(true);
            menu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Oh no, you got trapped!";
            menu.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(RestartGame);
            Time.timeScale = 0;
        }
    }
    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
