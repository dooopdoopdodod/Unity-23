using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.interiorlighting.interactable;

namespace com
{
    namespace interiorlighting
    {
        namespace interactor
        {
            public class SceneInteractor : MonoBehaviour
            {
                private GameObject[] lights;
                Color whiteColor = Color.white;
                Color blueColor = Color.blue;
                Color redColor = Color.red;
                Color greenColor = Color.green;
                public AudioSource interactionSound;

                // Start is called before the first frame update
                void Start()
                {
                    lights = GameObject.FindGameObjectsWithTag("DynamicLights");                    
                }

                // Update is called once per frame
                void Update()
                {
                    
                }

                void SetDoorOpen(GameObject door)
                {
                    door.GetComponent<DoorInteraction>().OpenDoor();

                    /**
                        The argument "door" which is a GameObject datatype should contain the reference to "DoorRotationAxis" in the scene.
                        You then need to access the component "DoorInteraction" that is attached to this GameObject, which actually is a C# script
                        This script contains a function called "OpenDoor" that needs to be called for the door to open and you can go outside
                    **/
                }

                void SetLightingIntensity(GameObject go)
                {
                    float lightIntensity = go.GetComponent<LightingIntensityValue>().intensity;
                    foreach(GameObject light in lights)
                    {
                        light.GetComponent<Light>().intensity = lightIntensity;
                    }

                        /**
                        The argument "go" is a GameObject datatype that will contain a reference to either of the intensity cubes on the floor (the ones from white to black).
                        These GameObject cubes have a script attached to them called as "LightingIntensityValue". 
                        You need to access this script as a component and read the public float variable "intensity".
                        The value in the intensity will be set as the intensity to all the lights in the scene marked with the tag "DynamicLights".
                        To access all GameObjects in the scene with a tag you need to use GameObject.FindGameObjectsWithTag("DynamicLights")
                        Once you have all the GameObjects then you need to access their component "<Light>" to which you will set the intensity value.
                        To know how to set the value of intensity visit: https://docs.unity3d.com/ScriptReference/Light-intensity.html
                   **/
                }

                void SetLightingColor(Color c)
                {
                    foreach(GameObject light in lights)
                    {
                        light.GetComponent<Light>().color = c;
                    }
                    
                    /**
                        The argument "c" is a Color datatype that will contain either of the values as Color.red, Color.green, or Color.blue.
                        To access all GameObjects in the scene with a tag you need to use GameObject.FindGameObjectsWithTag("DynamicLights")
                        Once you have all the GameObjects then you need to access their component "<Light>" to which you will set the color value.
                        To know how to set the value of intensity visit: https://docs.unity3d.com/ScriptReference/Light-color.html
                   **/
                }

                void OnTriggerEnter(Collider c)
                {
                    string gameObjectThatWasHit = c.gameObject.name;
                    interactionSound.Play(0);

                    switch (gameObjectThatWasHit)
                    {
                        case "BlueCube":
                            SetLightingColor(blueColor);                            
                            Debug.Log("CHANGE COLOR TO BLUE");
                            break;

                        case "RedCube":
                            SetLightingColor(redColor);
                            Debug.Log("CHANGE COLOR TO RED");
                            break;

                        case "GreenCube":
                            SetLightingColor(greenColor);
                            Debug.Log("CHANGE COLOR TO GREEN");
                            break;

                        case "RugCarpet":
                            SetLightingColor(whiteColor);
                            Debug.Log("CHANGE COLOR TO WHITE");
                            break;

                        case "IntensityCube0.0":
                            SetLightingIntensity(c.gameObject);
                            Debug.Log("CHANGE INTENSITY TO 0");
                            break;

                        case "IntensityCube0.25":
                            SetLightingIntensity(c.gameObject);
                            Debug.Log("CHANGE INTENSITY TO .25");
                            break;

                        case "IntensityCube0.5":
                            SetLightingIntensity(c.gameObject);
                            Debug.Log("CHANGE INTENSITY TO .5");
                            break;

                        case "IntensityCube0.75":
                            SetLightingIntensity(c.gameObject);
                            Debug.Log("CHANGE INTENSITY TO .75");
                            break;

                        case "IntensityCube1.0":
                            SetLightingIntensity(c.gameObject);
                            Debug.Log("CHANGE INTENSITY TO 1");
                            break;

                        case "DoorRotationAxis":
                            SetDoorOpen(c.gameObject);
                            Debug.Log("CHANGE INTENSITY TO 1");
                            break;
                    }    
                    
                    /**
                        This function is triggerred whenever your character collides with any of the colored cubes, intensity cubes, or the door, or the RugCarpet
                        You need to call the appropriate function when any of these collisions occur between your character and the interactables in the scene
                        The variable "gameObjectThatWasHit" contains the name of the GameObject your character collided with. 
                        You can use either if/else-if/else conditionals or switch/case conditional statements to handle what happens after a collisiin is detected
                            - When you hit any of the colored cubes or the RugCarpet
                                - Call the function "SetLightingColor" and pass 
                                    - Color.red if the collision is with RedCube
                                    - Color.green if the collision is with GreenCube
                                    - Color.blue if the collision is with BlueCube
                                    - Color.white if the collision is with the RugCarpet
                            - When you collide with any of the intensity cubes call the function "SetLightingIntensity" and  pass the argument c.gameObject 
                            - when you collide with the "DoorRotationAxis" call the function "SetDoorOpen" and pass the argument c.gameObject
                        
                    **/

                }
            }
        }
    }
}

