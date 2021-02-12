using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour{
    public GameObject menu;
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            menu.SetActive(true);
            menu.transform.GetChild(1).GetComponentInChildren<Text>().text = "Yay, you won!!!";
            menu.transform.GetChild(2).GetComponentInChildren<Text>().text = "Next level";
            menu.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(LoadNextScene);
            Time.timeScale = 0;
        }
    }
    public void LoadNextScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
