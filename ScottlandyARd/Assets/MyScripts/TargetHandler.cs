using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;



public class TargetHandler : MonoBehaviour, ITrackableEventHandler {

	public GameObject MainCam;
	public GameObject SecondaryCam;
	public GameObject disableCam1;
	public GameObject ImageMap;

	public int delay;
	private TrackableBehaviour mTrackableBehaviour;

	// Use this for initialization
	void Start () {

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		checkStatus ();
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (ImageMap.GetComponent<MainTracker> ().MainTrackerThere) {

			if (newStatus == TrackableBehaviour.Status.TRACKED) {
			
				MainCam.gameObject.SetActive (false);
				disableCam1.gameObject.SetActive (false);
				SecondaryCam.gameObject.SetActive (true);

				StartCoroutine (checkStatus ());

			} else if (newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			
			}

		}

	}

	IEnumerator checkStatus() {
		yield return new WaitForSeconds(delay);

		SecondaryCam.gameObject.SetActive (false);
		MainCam.gameObject.SetActive (true);
		disableCam1.gameObject.SetActive (true);
	
	}
}
