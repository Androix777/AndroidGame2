using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerCreator : MonoBehaviour
{
    const int GUNS_NUMBER = 1;
    const int UPGRADES_NUMBER=5;


    GameObject Hero;
    public GameObject Gun;
    public int[] guns { get; set; }
    public int[] gunsInfo { get; set; }

    public int[] upgrades { get; set; }
    public int[] upgradesInfo { get; set; }

    int[] t = { 1, 2, 3 };
    const float HP = 100;
    const float SPEED = 10;
    const float MULT_DAMAGE = 1;
    const float MULT_SPEED_FIRE = 1;

    const int JUMPS_NUMBER = 4;
    const float JUMP_FORCE = 10;

    private int money;

    private void Awake()
    {
        Hero = Resources.Load("Hero") as GameObject;
        guns = new int[GUNS_NUMBER];
        upgrades = new int[UPGRADES_NUMBER];
    }

    public void CreateHero()
    {
        GameObject Player = Instantiate(Hero, gameObject.transform.position,transform.rotation);
        Player.GetComponent<Hero>().Hp = HP + upgrades[0];
        Player.GetComponent<Hero>().maxSpeed = SPEED + upgrades[1];
        Player.GetComponent<Hero>().sumJumps = JUMPS_NUMBER + upgrades[3];
        Player.GetComponent<Hero>().jumpForce = JUMP_FORCE + upgrades[4];

        GameObject gun = Instantiate(Gun, Player.transform) as GameObject;
        gun.transform.localPosition=Vector3.zero;
        gun.GetComponent<Gun>().damageMultipl = MULT_DAMAGE;
        gun.GetComponent<Gun>().speedFireMultipl = MULT_SPEED_FIRE;
        gun.GetComponent<Gun>().ally = true;
        gun.SetActive(true);
        gun.GetComponent<GunAIHero>().gun=gun;

        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.transform.SetParent(Player.transform);
        cam.transform.localPosition = new Vector3 (0,0,-10);

       

       

        GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>().teleportationNextRoom();
    }

   



    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + "Profile" + ".dat");

        Profile profile = new Profile();

        profile.Hero = Hero;
        profile.Gun = Gun;
        profile.guns = guns;
        profile.upgrades = upgrades;

        bf.Serialize(file, profile);
        file.Close();
        Debug.Log("Save");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "Profile" + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + gameObject.name + ".dat", FileMode.Open);

            Profile profile = (Profile)bf.Deserialize(file);
            file.Close();

            Hero = profile.Hero;
            Gun = profile.Gun;
            guns = profile.guns;
            upgrades = profile.upgrades;

            Debug.Log("Load");
        }

    }




}


[Serializable]
class Profile
{
    public GameObject Hero { get; set; }
    public GameObject Gun { get; set; }
    public int[] guns { get; set; }
    public int[] upgrades { get; set; }

} 