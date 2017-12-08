using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;

public class MainTracker : MonoBehaviour, ITrackableEventHandler {


	public Boolean MainTrackerThere;
	private TrackableBehaviour mTrackableBehaviour;

	// Use this for initialization
	void Start () {

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		

		if (newStatus == TrackableBehaviour.Status.TRACKED) {
			MainTrackerThere = true;
		} else if (newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			MainTrackerThere = false;
		}

	}


}
