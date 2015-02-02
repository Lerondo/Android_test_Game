using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Profiler {
	private static Dictionary<string,float> profilerList = new Dictionary<string,float>();
	
	public static void StartTime (string tag)
	{
		if(profilerList.ContainsKey(tag))
		{
			Debug.LogError("this tag has been already started!");
		} else {
			profilerList.Add(tag,Time.realtimeSinceStartup);
		}
	}
	public static void EndTime (string tag)
	{
		if(profilerList.ContainsKey(tag))
		{
			Debug.Log(tag + " " + (Time.realtimeSinceStartup - profilerList[tag]) + " MS");
			profilerList.Remove(tag);
		} else {
			Debug.LogError("this tag has not been started yet!");
		}
	}
}