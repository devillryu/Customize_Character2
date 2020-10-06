using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadResource : MonoBehaviour
{
    Object[] AllHairobj,AllClothobj,AllPantobj;
    public Transform content,content2,content3;
    List<GameObject> hair, cloth, pant;
    Transform hair_pos, cloth_pos, pant_pos;
    GameObject firstui, contenthair,contentcloth,contentpant, backbutton;
    int id,idcloth,idpant;
    bool Showhairselection, ShowClothselection, ShowPantselection;
    bool Havehair, Havecloth , Havepant;
    GameObject newhair, newcloth, newpant;
    void Start()
    {
        contenthair = GameObject.Find("Content");
        contentcloth = GameObject.Find("Content2");
        contentpant = GameObject.Find("Content3");
        firstui = GameObject.Find("UI");
        backbutton = GameObject.Find("BackButton");
        backbutton.SetActive(false);
        Loadoldcustomize();
    }
    void Loadoldcustomize()
    {
        hair = new List<GameObject>();
        cloth = new List<GameObject>();
        pant = new List<GameObject>();

        //Load Old index
        int oldhairindex = PlayerPrefs.GetInt("HairIndex");
        int oldclothindex = PlayerPrefs.GetInt("ClothIndex");
        int oldpantindex = PlayerPrefs.GetInt("PantIndex");

        AllHairobj = Resources.LoadAll("Hair");
        AllClothobj = Resources.LoadAll("Cloth");
        AllPantobj = Resources.LoadAll("Pant");

        hair_pos = transform.Find("/Player/Head/Hair_pos");
        hair.Add(Resources.Load("Hair/Hair_01") as GameObject);
        hair.Add(Resources.Load("Hair/Hair_02") as GameObject);
        hair.Add(Resources.Load("Hair/Hair_03") as GameObject); //add here if have new Hair
        newhair = Instantiate(hair[oldhairindex], hair_pos.transform.position, Quaternion.identity);
        newhair.transform.parent = hair_pos.transform;
        Havehair = true;

        AllClothobj = Resources.LoadAll("Cloth");
        cloth_pos = transform.Find("/Player/Cloth_pos");
        cloth.Add(Resources.Load("Cloth/Cloth_01") as GameObject);
        cloth.Add(Resources.Load("Cloth/Cloth_02") as GameObject);
        cloth.Add(Resources.Load("Cloth/Cloth_03") as GameObject); //add here if have new Cloth
        newcloth = Instantiate(cloth[oldclothindex], cloth_pos.transform.position, Quaternion.identity);
        newcloth.transform.parent = cloth_pos.transform;
        Havecloth = true;

        AllPantobj = Resources.LoadAll("Pant");
        pant_pos = transform.Find("/Player/Pant_pos");
        pant.Add(Resources.Load("Pant/Pant_01") as GameObject);
        pant.Add(Resources.Load("Pant/Pant_02") as GameObject);
        pant.Add(Resources.Load("Pant/Pant_03") as GameObject); //add here if have new Pant
        newpant = Instantiate(pant[oldpantindex], pant_pos.transform.position, Quaternion.identity);
        newpant.transform.parent = pant_pos.transform;
        Havepant = true;

        //removeallList
        hair.Clear();
        cloth.Clear();
        pant.Clear();
    }
    //Hair selection
    void CreateHairButton(string buttonname, int index)
    {
        GameObject button = new GameObject();
        button.transform.parent = content;
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.name = buttonname;
        button.GetComponent<Button>().onClick.AddListener(() => Haircreate(index));
    }
    void Haircreate(int index)
    {
        if(Havehair)
        {
            Destroy(newhair);
            Havehair = false;
        }
        newhair = Instantiate(hair[index],hair_pos.transform.position,Quaternion.identity);
        PlayerPrefs.SetInt("HairIndex", index);
        newhair.transform.parent = hair_pos.transform;
        Havehair = true;
    }
    public void HairButton()
    {
        firstui.SetActive(false);
        contenthair.SetActive(true);
        contentcloth.SetActive(false);
        contentpant.SetActive(false);
        backbutton.SetActive(true);
        if (!Showhairselection)
        {
            hair = new List<GameObject>();
            AllHairobj = Resources.LoadAll("Hair");
            hair_pos = transform.Find("/Player/Head/Hair_pos");
            hair.Add(Resources.Load("Hair/Hair_01") as GameObject);
            hair.Add(Resources.Load("Hair/Hair_02") as GameObject);
            hair.Add(Resources.Load("Hair/Hair_03") as GameObject);
            foreach (var Allhair in AllHairobj)
            {
                Debug.Log(Allhair.name);
                CreateHairButton(Allhair.name, id);
                id++;
            }
            Showhairselection = true;
        }
    }
    //Cloth selection
    public void ClothButton()
    {
        firstui.SetActive(false);
        contenthair.SetActive(false);
        contentcloth.SetActive(true);
        contentpant.SetActive(false);
        backbutton.SetActive(true);
        if (!ShowClothselection)
        {
            cloth = new List<GameObject>();
            AllClothobj = Resources.LoadAll("Cloth");
            cloth_pos = transform.Find("/Player/Cloth_pos");
            cloth.Add(Resources.Load("Cloth/Cloth_01") as GameObject);
            cloth.Add(Resources.Load("Cloth/Cloth_02") as GameObject);
            cloth.Add(Resources.Load("Cloth/Cloth_03") as GameObject);
            foreach (var AllCloth in AllClothobj)
            {
                Debug.Log(AllCloth.name);
                CreateClothButton(AllCloth.name, idcloth);
                idcloth++;
            }
            ShowClothselection = true;
        }
    }
    void CreateClothButton(string buttonname, int index)
    {
        GameObject button = new GameObject();
        button.transform.parent = content2;
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.name = buttonname;
        button.GetComponent<Button>().onClick.AddListener(() => Clothcreate(index));
    }
    void Clothcreate(int index)
    {
        if (Havecloth)
        {
            Destroy(newcloth);
            Havecloth = false;
        }
        newcloth = Instantiate(cloth[index], cloth_pos.transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("ClothIndex", index);
        newcloth.transform.parent = cloth_pos.transform;
        Havecloth = true;
    }
    //Pant selection
    public void PantButton()
    {
        firstui.SetActive(false);
        contenthair.SetActive(false);
        contentcloth.SetActive(false);
        contentpant.SetActive(true);
        backbutton.SetActive(true);
        if (!ShowPantselection)
        {
            pant = new List<GameObject>();
            AllPantobj = Resources.LoadAll("Pant");
            pant_pos = transform.Find("/Player/Pant_pos");
            pant.Add(Resources.Load("Pant/Pant_01") as GameObject);
            pant.Add(Resources.Load("Pant/Pant_02") as GameObject);
            pant.Add(Resources.Load("Pant/Pant_03") as GameObject);
            foreach (var AllPant in AllPantobj)
            {
                Debug.Log(AllPant.name);
                CreatePantButton(AllPant.name, idpant);
                idpant++;
            }
            ShowPantselection = true;
        }
    }
    void CreatePantButton(string buttonname, int index)
    {
        GameObject button = new GameObject();
        button.transform.parent = content3;
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.name = buttonname;
        button.GetComponent<Button>().onClick.AddListener(() => Pantcreate(index));
    }
    void Pantcreate(int index)
    {
        if (Havepant)
        {
            Destroy(newpant);
            Havepant = false;
        }
        newpant = Instantiate(pant[index], pant_pos.transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("PantIndex", index);
        newpant.transform.parent = pant_pos.transform;
        Havepant = true;
    }
    public void Back()
    {
        firstui.SetActive(true);
        contenthair.SetActive(false);
        contentcloth.SetActive(false);
        contentpant.SetActive(false);
    }
}
