using UnityEngine;
using System.Collections;
using System.Xml;

public class XmlRead : MonoBehaviour {
	
	// npc data
	 string npcName;
	string npcType;
	
	// chat data
	int maxData ;
	int showData ;
	string[] data ;

	//simple gui to show read data
	void OnGUI()
	{
		// ensures I don't try to show data I don't have
		if(showData<maxData)
		{
			print (" npc type : "+npcType);
			print (" npc name : "+npcName);
			print (" data : "+data[showData]);

			//GUI.Label(Rect(0,0,200,20), npcType+":"+npcName);
//			GUI.Label(Rect(0,20,200,100), data[showData]);
//			if(GUI.Button(Rect(0,120,200,20),"Next"))
//			{
//				// goto next
//				showData++;
//				// wrap
//				if(showData>=maxData)
//					showData=0;
//			}
		}
	}

	// Use this for initialization
	void Start () {
		// initialise data
		maxData = 0;
		showData = 0;
		npcName = "unset";
		npcName = "unset";
		data = null;
		
		//readxml from chat.xml in project folder (Same folder where Assets and Library are in the Editor)
		XmlReader reader = XmlReader.Create("chat.xml");

		//while there is data read it
		while(reader.Read())
		{
			//when you find a npc tag do this
			if(reader.IsStartElement("npc"))
			{
				// get attributes from npc tag
				npcName=reader.GetAttribute("name");
				npcType = reader.GetAttribute("npcType");
				maxData = int.Parse(reader.GetAttribute("entries"));

				//allocate string pointer array
				data = new string[maxData];
				
				//read speach elements (showdata is used instead of having a new int I reset it later)
				for(showData = 0;showData<maxData;showData++)
				{
					reader.Read();
					if(reader.IsStartElement("speach"))
					{
						//fill strings
						data[showData] = reader.ReadString();
					}
				}
				//reset showData index
				showData=0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
