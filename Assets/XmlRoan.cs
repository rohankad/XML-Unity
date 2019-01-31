using UnityEngine;
using System.Collections;
using System.Xml;

public class XmlRoan : MonoBehaviour {

	// npc data
	string npcName;

	
	// chat data
	int maxData ;
	int showData ;
	string[] data ;


	void OnGUI()
	{
		
	/*	if(showData<maxData)
		{
			print (" npc name : "+npcName);
			print (" no entries : "+maxData);
			print (" data : "+data[showData]);
			

						GUI.Label(Rect(0,20,200,100), data[showData]);
						if(GUI.Button(Rect(0,120,200,20),"Next"))
						{
			//				// goto next
						showData++;
			//				// wrap
							if(showData>=maxData)
								showData=0;
						}
		}*/
	}

	// Use this for initialization
	void Start () {
		// initialise data
		maxData = 0;
		showData = 0;
		npcName = "unset";
		data = null;
		
		//readxml from chat.xml in project folder (Same folder where Assets and Library are in the Editor)
		XmlReader reader = XmlReader.Create("roan.xml");
		
		//while there is data read it
		while(reader.Read())
		{
			//when you find a npc tag do this
			if(reader.IsStartElement("roan"))
			{
				// get attributes from npc tag
				npcName=reader.GetAttribute("name");
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
						print ("Speach : - "+reader.ReadString());
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
