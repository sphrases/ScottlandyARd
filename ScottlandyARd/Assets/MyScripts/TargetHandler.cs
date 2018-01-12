using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;

public class TargetHandler : MonoBehaviour, ITrackableEventHandler {

	public Camera MainCam;
	public Camera SecondaryCam;
	public Camera disableCam1;
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
			
				//MainCam.gameObject.SetActive (false);
				MainCam.enabled = false;
				disableCam1.enabled = false;
				SecondaryCam.enabled = true;
				/*
				MainCam.SetActive(false);
				disableCam1.SetActive(false);
				SecondaryCam.SetActive(true);
				*/
				StartCoroutine (checkStatus ());

			} else if (newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			
			}

		}

	}

	IEnumerator checkStatus() {
		yield return new WaitForSeconds(delay);

		MainCam.enabled = true;
		disableCam1.enabled = false;
		SecondaryCam.enabled = false;
	
	}
}
