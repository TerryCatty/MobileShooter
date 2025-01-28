using System.IO;
using UnityEngine;

public class PlayerHealth : EntityHealth
{
   	public override void Init()
	{
		SaveManager.instance?.AddSaveableObject(this);
		
		filePath = Application.persistentDataPath + "/";
		base.Init();
	}

	public override void SaveData()
	{
		string json = JsonUtility.ToJson(healthData);
		Debug.Log(json);
		File.WriteAllText(filePath + $"healthData.json", json);
	}

	public override void LoadData()
	{
		if(File.Exists(filePath + $"healthData.json"))
		{
			string json = File.ReadAllText(filePath + $"healthData.json");
			healthData = JsonUtility.FromJson<HealthData>(json);
			
			SetFilled();
		}
	}
}
