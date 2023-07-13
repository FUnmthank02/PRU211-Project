using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private int index;
    [SerializeField] GameObject[] characters;
    [SerializeField] TextMeshProUGUI characterName;

    [SerializeField] GameObject[] characterPrefabs;
    
    public static GameObject selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        SelectCharacter();
    }

    public void OnPreBtnClick()
    {
        if(index > 0)
        {
            index--;
        }
        SelectCharacter();
        Debug.Log(index);
    }

    public void OnNextBtnClick()
    {
        if(index < characters.Length -1)
        {
            index++;
        }
        SelectCharacter();
    }

    public void OnPlayBtnClick()
    {
        SceneManager.LoadScene(4);
    }

    private void SelectCharacter()
    {
        for(int i=0; i < characters.Length; i++)
        {
            if(i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                characters[i].GetComponent<Animator>().enabled = true;
                selectedCharacter = characterPrefabs[i];
                characterName.text = characterPrefabs[i].name;
            }
            else
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.black;
                characters[i].GetComponent<Animator>().enabled = false;

            }
        }
    }

   
}
