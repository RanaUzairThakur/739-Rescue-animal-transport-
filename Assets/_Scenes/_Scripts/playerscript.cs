using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using SWS;
public class playerscript : MonoBehaviour {
    public static playerscript _instance;
    public Image _parkingimg;
	public GameObject _back;
	public GameObject _sheep;
	public  GameObject _rccCam,maincam,truckcontrol,animalcontroller;
	public GameObject _nextdestipoint,LevelComplete,levelfail,succes_store,Fail_store;
	public GameObject _1stanimal;
	public Transform _cube;
	public GameObject _horsecontrols,lioncontrolsl,sheepcontrols,cowcontrols,deercontrols,dogcontrols;
	public Animator _door;
	public GameObject parkingimgg,backk,newdestinationdog,truckdog;


	void Awake()
	{
		if (PlayerPrefs.GetInt ("MHorse") == 1) {
			animalcontroller = _horsecontrols;
		}
		else	if (PlayerPrefs.GetInt ("MLion") == 1) {
			animalcontroller = lioncontrolsl;
		}

		else	if (PlayerPrefs.GetInt ("MSheep") == 1) {
			animalcontroller = sheepcontrols;
		}

		else	if (PlayerPrefs.GetInt ("MCow") == 1) {
			animalcontroller = cowcontrols;
		}


		else	if (PlayerPrefs.GetInt ("MDeer") == 1) {
			animalcontroller = deercontrols;
		}

		else	if (PlayerPrefs.GetInt ("MDog") == 1) {
			animalcontroller = dogcontrols;
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (wait ());

		if (PlayerPrefs.GetInt ("MLion") == 1) {
			_nextdestipoint.transform.position = _cube.transform.position;
			_nextdestipoint.transform.rotation = _cube.transform.rotation;

		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSecondsRealtime (3f);
		_1stanimal = 	GameObject.Find ("Animals");
		_sheep = _1stanimal .GetComponent<LevelAnimals> ()._Animals [0].gameObject;
		maincam.GetComponent<SmoothFollow> ().target = _sheep.transform;
	}
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag=="parking")
		{
			parkingimgg.SetActive (true);
			_parkingimg.gameObject.SetActive (true);
			col.gameObject.transform.parent = null;
			truckcontrol.gameObject.SetActive (false);
            	Destroy (GameObject.Find("Park"));
			this.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			if (_parkingimg.fillAmount < 1) {
				_parkingimg.fillAmount += 0.005f;

			}
			else if(_parkingimg.fillAmount==1)
			{
				this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				backk.gameObject.SetActive (false);
				_parkingimg.gameObject.SetActive (false);
				parkingimgg.SetActive (false);
				_back.gameObject.SetActive (true);
				_rccCam.gameObject.SetActive (false);
				maincam.gameObject.SetActive (true);
				animalcontroller.gameObject.SetActive (true);
				_parkingimg.fillAmount = 0;
				int currentlevel = PlayerPrefs.GetInt ("LLevel");
				if(currentlevel<=4){
				_nextdestipoint.gameObject.SetActive (true);
				}

				if (PlayerPrefs.GetInt ("MHorse") == 1) 
				{
					int currentlevelhorse = PlayerPrefs.GetInt ("HLevel");
					if (currentlevelhorse == 1) 
					{
						
						_nextdestipoint.gameObject.SetActive (true);
					}
                //    CustomAnalytics.logLevelCompleted("Success", PlayerPrefs.GetInt("HLevel") + "");

                }
				if (PlayerPrefs.GetInt ("MSheep") == 1)
				{
					int currentlevelsheep = PlayerPrefs.GetInt ("SLevel");
					if (currentlevelsheep == 1) 
					{
						_nextdestipoint.gameObject.SetActive (true);
					}
				}

				if (PlayerPrefs.GetInt ("MCow") == 1) {
					int currentlevelcow = PlayerPrefs.GetInt ("CLevel");
					if (currentlevelcow == 1) {
						_nextdestipoint.gameObject.SetActive (true);
					}
					if (currentlevelcow == 5) {
						_sheep.gameObject.transform.parent = null;
						_sheep.gameObject.transform.GetChild (0).gameObject.GetComponent<MeshCollider> ().enabled = true;
						_nextdestipoint.gameObject.SetActive (false);
						print ("check");
					}
				}


				if (PlayerPrefs.GetInt ("MDeer") == 1)
                {

					int currentleveldeer = PlayerPrefs.GetInt ("DLevel");
					if(currentleveldeer==1)
					{
						_nextdestipoint.gameObject.SetActive (true);
					}

				}
				if (currentlevel == 5) {
					_door.enabled = true;
					_door.SetBool ("doorOpen", true);
				} 

				if (PlayerPrefs.GetInt ("MDog") == 1) {

					int currentleveldog = PlayerPrefs.GetInt ("DogLevel");
					if(currentleveldog==3)
					{
						_sheep.gameObject.transform.parent = null;
						_sheep.gameObject.transform.GetChild (0).GetComponent<MeshCollider> ().enabled = true;
						_nextdestipoint.gameObject.SetActive (false);
					}
				}
				_sheep.gameObject.GetComponent<Human_Controller1> ().enabled = true;
				_sheep.gameObject.GetComponent<Rigidbody> ().isKinematic = false;

				Destroy (col.gameObject);
			}
				
		}

		if(col.gameObject.tag=="park1")
		{
			parkingimgg.SetActive (true);
			_parkingimg.gameObject.SetActive (true);
			col.gameObject.transform.parent = null;
			truckcontrol.gameObject.SetActive (false);
			Destroy (GameObject.Find("Park"));
			this.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			_1stanimal = 	GameObject.Find ("Animals");
			_sheep = _1stanimal .GetComponent<LevelAnimals> ()._Animals [0].gameObject;
			if (_parkingimg.fillAmount < 1) {
				_parkingimg.fillAmount += 0.005f;

			} 
			else if (_parkingimg.fillAmount == 1) 
			{
				this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				backk.gameObject.SetActive (false);
				_parkingimg.gameObject.SetActive (false);
				parkingimgg.SetActive (false);
				_back.gameObject.SetActive (true);
				_rccCam.gameObject.SetActive (false);
				maincam.gameObject.SetActive (true);
				animalcontroller.gameObject.SetActive (true);
				_sheep.gameObject.transform.parent = null;
				_sheep.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				_sheep.gameObject.transform.GetChild (0).gameObject.GetComponent<MeshCollider> ().enabled = true;
				_sheep.gameObject.GetComponent<Human_Controller1> ().enabled = true;

			}

	}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Finish") 
		{
            //

            Invoke("timee", 5f);
            if (PlayerPrefs.GetInt ("MHorse") == 1) {
				int no = PlayerPrefs.GetInt ("UnlockLevels");
				int currentlevel = PlayerPrefs.GetInt ("HLevel");
				PlayerPrefs.SetInt ("HUnlockLevels", currentlevel + 1);
             //   CustomAnalytics.logLevelCompleted("Success", PlayerPrefs.GetInt("HLevel") + "");
                // AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
            }

			if (PlayerPrefs.GetInt ("MSheep") == 1) {
				int currentlevel = PlayerPrefs.GetInt ("SLevel");
				PlayerPrefs.SetInt ("SUnlockLevels", currentlevel+1);
			//	CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("SLevel") +"");
    //            AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
            }
			if (PlayerPrefs.GetInt ("MCow") == 1) {
				int currentlevel = PlayerPrefs.GetInt ("CLevel");
				PlayerPrefs.SetInt ("CUnlockLevels", currentlevel+1);
			//	CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("CLevel") +"");
    //            AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
            }

			if (PlayerPrefs.GetInt ("MLion") == 1) {
				int currentlevel = PlayerPrefs.GetInt ("LLevel");
				PlayerPrefs.SetInt ("LUnlockLevels", currentlevel+1);
			//	CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("LLevel") +"");
    //            AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
            }
			if (PlayerPrefs.GetInt ("MDog") == 1) {
				int currentlevel = PlayerPrefs.GetInt ("DogLevel");
				if(currentlevel<5)
				{
					PlayerPrefs.SetInt ("DogUnlockLevels", currentlevel+1);

				}
			//	CustomAnalytics.logLevelCompleted ("Success",PlayerPrefs.GetInt("DogLevel") +"");
    //            AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
            }
            succes_store.gameObject.SetActive(true);
			//LevelComplete.gameObject.SetActive (true);
			AudioListener _audiolistner = GameObject.FindObjectOfType<AudioListener> ();
			_audiolistner.enabled = false;
		}




	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Fail")
		{
			AudioListener _audiolistner = GameObject.FindObjectOfType<AudioListener> ();
			_audiolistner.enabled = false;
            Fail_store.gameObject.SetActive(true);
			//levelfail.gameObject.SetActive (true);
            //AdLoadWarning.Instance.CallAdWarning(AdsMainManagerController.AdType.GP);
        //    CustomAnalytics.logLevelFailed ("Fail","Gameplay");
            Invoke("timee", 0f);
        }

		if(col.gameObject.tag=="traffic")
		{
			col.gameObject.transform.parent.GetComponent<splineMove> ().Pause();
			col.gameObject.transform.GetChild (0).gameObject.SetActive (true);
			StartCoroutine (waitfail());
		}
	}

    public void timee()
    {
        Time.timeScale = 0;
    }
    IEnumerator waitfail()
	{
		yield return new WaitForSeconds (2f);
        Fail_store.gameObject.SetActive(true);
		//levelfail.gameObject.SetActive (true);
        //
        Invoke("timee", 0f);
    }
    public void Unlockalllevels()
    {
    //    InApp_Manager.instance.Buy_UnlockAll_Levels();
    }
    public void Unlockall()
    {
     //   InApp_Manager.instance.Buy_UnlockAll();
    }
}
