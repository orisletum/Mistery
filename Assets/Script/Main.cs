using System;
using System.IO;

using UnityEngine;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;

public class Main : MonoBehaviour {

	void Start(){
		//Creates a new TestSimpleObject object.
		TestSimpleObject obj = new TestSimpleObject();

		Debug.Log("Before serialization the object contains: ");
		obj.Print();

		//Opens a file and serializes the object into it in binary format.
		Stream stream = File.Open("data.xml", FileMode.Create);
//		SoapFormatter formatter = new SoapFormatter();

		BinaryFormatter formatter = new BinaryFormatter();

		formatter.Serialize(stream, obj);
		stream.Close();

		//Empties obj.
		obj = null;

		//Opens file "data.xml" and deserializes the object from it.
		stream = File.Open("data.xml", FileMode.Open);
//		formatter = new SoapFormatter();

		formatter = new BinaryFormatter();

		obj = (TestSimpleObject)formatter.Deserialize(stream);
		stream.Close();

		Debug.Log("");
		Debug.Log("After deserialization the object contains: ");
		obj.Print();
	}



// A test object that needs to be serialized.
[System.Serializable]		
public class TestSimpleObject  {

	public int member1;
	public string member2;
	public string member3;
	public double member4;

	// A field that is not serialized.
	[System.NonSerialized()] public string member5; 

	public TestSimpleObject() {

		member1 = 11;
		member2 = "hello";
		member3 = "hello";
		member4 = 3.14159265;
		member5 = "hello world!";
	}


	public void Print() {

			Debug.Log("member1 = '{0}'"+ member1);
			Debug.Log("member2 = '{0}'"+ member2);
			Debug.Log("member3 = '{0}'"+ member3);
			Debug.Log("member4 = '{0}'"+ member4);
			Debug.Log("member5 = '{0}'"+ member5);
	}
}
}