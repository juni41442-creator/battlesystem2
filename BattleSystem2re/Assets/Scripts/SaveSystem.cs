using UnityEngine;


public class SaveSystem : MonoBehaviour
{
    public PlayerData data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Start()
    {
        Debug.Log("저장시스템 예제구현");

        //alt + shift (위아래)
        //ctrl k ctrl c     ctrl k u 범위 주석 설정, 해제

        //SAVE
        //PlayerPrefs.SetInt("HP", 100);  
        //PlayerPrefs.SetFloat("ATK",0.5f);
        //PlayerPrefs.SetString("NAME", "Hero");
        //PlayerPrefs.SetInt("MONEY", 1000);       

        //LOAD
        Debug.Log("HP : " + PlayerPrefs.GetInt("HP"));
        Debug.Log("ATK : " + PlayerPrefs.GetFloat("ATK"));
        Debug.Log("NAME : " + PlayerPrefs.GetString("NAME"));
        Debug.Log("MONEY : " + PlayerPrefs.GetInt("MONEY"));
        Debug.Log(Application.persistentDataPath);  //레지스터리 저장 위치

        //PlayerData data = new PlayerData("hero",100,5,50);
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
    }

    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PLAYER", json);
    }  
    public static PlayerData Load()
    {
        string json = PlayerPrefs.GetString("PLAYER");
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
