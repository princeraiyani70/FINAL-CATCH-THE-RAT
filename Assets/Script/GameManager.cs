using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Hexagon, ParentOfHexagon;

    [SerializeField]
    public Sprite ClickedHexagon;

    [SerializeField]
    Sprite Rat;

    [SerializeField]
    public List<GameObject> AllHexagons;

    [SerializeField]
    List<int> EvenObjects, OddObjects;

    [SerializeField]
    List<int> PosibilityOfMove;


    [SerializeField]
    Button MusicButton;

    [SerializeField]
    AudioSource MusicSource,SoundSource;

    [SerializeField]
    Sprite MusicOn, MusicOff;




    public List<int> UserMovePosition;

    bool Odd;

    int HexagonNumber = 0,MiddlePosition, LastPositionOfRat;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        GettingMusicData();


        for (int i = 0; i < 9; i++)
        {
            GameObject HexagonObject;
            for (int j = 0; j < 15; j++)
            {
                if (!Odd)
                {
                    HexagonObject = Instantiate(Hexagon, new Vector2(j * 0.9f, i * 0.9f), Quaternion.identity, ParentOfHexagon.transform);
                    HexagonObject.name = HexagonNumber.ToString();
                    AllHexagons.Add(HexagonObject);
                    EvenObjects.Add(HexagonNumber);
                }
                else
                {
                    HexagonObject = Instantiate(Hexagon, new Vector2((j * 0.9f) + 0.45f, i * 0.9f), Quaternion.identity, ParentOfHexagon.transform);
                    HexagonObject.name = HexagonNumber.ToString();
                    AllHexagons.Add(HexagonObject);
                    OddObjects.Add(HexagonNumber);
                }
                if (i == 0 || i == 8 || j == 0 || j == 14)
                {
                    HexagonObject.tag = "Exit";
                }
                HexagonNumber++;
            }
            Odd = !Odd;
        }
        ParentOfHexagon.transform.position = new Vector2(-6.52f, -4.2f);
        RatSpawnPosition();
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void RatSpawnPosition()
    {
        MiddlePosition = Mathf.RoundToInt(AllHexagons.Count / 2);
        AllHexagons[MiddlePosition].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        AllHexagons[MiddlePosition].GetComponent<SpriteRenderer>().sprite = Rat;

        GetRatMovingPosibilities();
    }

    public void GetRatMovingPosibilities()
    {
        PosibilityOfMove.Clear();
        LastPositionOfRat = MiddlePosition;


        if (EvenObjects.Contains(MiddlePosition))
        {
            int Posibility1 = MiddlePosition + 1;
            int Posibility2 = MiddlePosition - 1;
            int Posibility3 = MiddlePosition + 14;
            int Posibility4 = MiddlePosition - 15;
            int Posibility5 = MiddlePosition + 15;
            int Posibility6 = MiddlePosition - 16;

            if (!UserMovePosition.Contains(Posibility1))
            {
                PosibilityOfMove.Add(Posibility1);
            }
            if (!UserMovePosition.Contains(Posibility2))
            {
                PosibilityOfMove.Add(Posibility2);
            }
            if (!UserMovePosition.Contains(Posibility3))
            {
                PosibilityOfMove.Add(Posibility3);
            }
            if (!UserMovePosition.Contains(Posibility4))
            {
                PosibilityOfMove.Add(Posibility4);
            }
            if (!UserMovePosition.Contains(Posibility5))
            {
                PosibilityOfMove.Add(Posibility5);
            }
            if (!UserMovePosition.Contains(Posibility6))
            {
                PosibilityOfMove.Add(Posibility6);
            }



            //AllHexagons[Posibility1].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility2].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility3].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility4].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility5].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility6].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            int Posibility1 = MiddlePosition + 1;
            int Posibility2 = MiddlePosition - 1;
            int Posibility3 = MiddlePosition + 16;
            int Posibility4 = MiddlePosition - 15;
            int Posibility5 = MiddlePosition + 15;
            int Posibility6 = MiddlePosition - 14;

            if (!UserMovePosition.Contains(Posibility1))
            {
                PosibilityOfMove.Add(Posibility1);
            }
            if (!UserMovePosition.Contains(Posibility2))
            {
                PosibilityOfMove.Add(Posibility2);
            }
            if (!UserMovePosition.Contains(Posibility3))
            {
                PosibilityOfMove.Add(Posibility3);
            }
            if (!UserMovePosition.Contains(Posibility4))
            {
                PosibilityOfMove.Add(Posibility4);
            }
            if (!UserMovePosition.Contains(Posibility5))
            {
                PosibilityOfMove.Add(Posibility5);
            }
            if (!UserMovePosition.Contains(Posibility6))
            {
                PosibilityOfMove.Add(Posibility6);
            }


            //AllHexagons[Posibility1].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility2].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility3].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility4].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility5].GetComponent<SpriteRenderer>().color = Color.white;
            //AllHexagons[Posibility6].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void RatMove()
    {
        int RatMovingPoint = Random.Range(0, PosibilityOfMove.Count);

        if (PosibilityOfMove.Count == 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            MiddlePosition = PosibilityOfMove[RatMovingPoint];
        }

        if (AllHexagons[LastPositionOfRat].tag == "Exit")
        {
            SceneManager.LoadScene(0);
        }
        AllHexagons[LastPositionOfRat].transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        AllHexagons[LastPositionOfRat].GetComponent<SpriteRenderer>().sprite = Hexagon.GetComponent<SpriteRenderer>().sprite;
        AllHexagons[MiddlePosition].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        AllHexagons[MiddlePosition].GetComponent<SpriteRenderer>().sprite = Rat;
        GetRatMovingPosibilities();
    }

    public void RetryButtonClickAction()
    {
        SoundPlayOnButtonClick();
        SceneManager.LoadScene(0);
    }


    public void MusicManagement()
    {
        int Music = PlayerPrefs.GetInt("Music", 0);

        if (Music == 0)
        {
            MusicButton.GetComponent<Image>().sprite = MusicOff;
            MusicSource.mute = true;
            PlayerPrefs.SetInt("Music", 1);
        }
        if (Music == 1)
        {
            SoundPlayOnButtonClick();
            MusicButton.GetComponent<Image>().sprite = MusicOn;
            MusicSource.mute = false;
            PlayerPrefs.SetInt("Music", 0);
        }
    }

    public void GettingMusicData()
    {        
            int Music = PlayerPrefs.GetInt("Music", 0);

            if (Music == 1)
            {
                MusicButton.GetComponent<Image>().sprite = MusicOff;
                MusicSource.mute = true;
            }
            if (Music == 0)
            {
                MusicButton.GetComponent<Image>().sprite = MusicOn;
                MusicSource.mute = false;
            }
    }

    public void SoundPlayOnButtonClick()
    {
        int Music = PlayerPrefs.GetInt("Music", 0);
        if (Music == 0)
        {
            SoundSource.Play();
        }
    }

}
