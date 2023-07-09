using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFootsteps : MonoBehaviour
{

    // public AK.Wwise.Switch grass;
    // public AK.Wwise.Switch stone;
    // public AK.Wwise.Switch wood;
    // public AK.Wwise.Switch water;


    private LineRenderer rayLine;

    public float range = 8;
    private Vector3 last;
    private Vector3 rayOrigin;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private string materialName;

    // Start is called before the first frame update
    void Start()
    {
        rayLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rayOrigin = transform.position+Vector3.up;
        if(last != rayOrigin)
            // Debug.Log(transform.position);

        last = rayOrigin;

        RaycastHit hit;
        rayLine.SetPosition(0,rayOrigin);

        if(Physics.Raycast(rayOrigin,Vector3.down, out hit, range))
        {
            rayLine.SetPosition(1,hit.point);
            
            if(hit.collider != null && hit.collider.gameObject.name != "FootstepZoneWater")
            {
                Debug.Log(hit.collider.gameObject.name);
                meshRenderer = hit.collider.gameObject.GetComponent<MeshRenderer>();
                meshFilter = hit.collider.gameObject.GetComponent<MeshFilter>();
                if (meshRenderer != null && meshFilter != null)
                {
                    materialName = meshRenderer.materials[0].name;
                    Debug.Log(materialName);
                    switch(materialName)
                    {
                        // Stone materials
                        case "BLD_BrickHouse1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }

                        case "BLD_Church1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }
                        case "BLD_IndBuilding1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }

                        case "BLD_Structures1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }
                        case "BLD_Structures2 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }


                        case "NAT_Rocks1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }
                        case "PROP_Gravestones1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            break;
                        }


                        // Wood Materials

                        case "BLD_Cabins (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Wood", this.gameObject);
                            break;
                        }
                        case "BLD_Structures1_LOD (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Wood", this.gameObject);
                            break;
                        }

                        case "BLD_Villa1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Wood", this.gameObject);
                            break;
                        }

                        case "BLD_Villa2 (Instance)":
                        {
                            if(meshFilter.mesh.name == "Villa2_Base_Stairs_A")
                            {
                                AkSoundEngine.SetSwitch("Footsteps", "Stone", this.gameObject);
                            }
                            else
                            {
                                AkSoundEngine.SetSwitch("Footsteps", "Wood", this.gameObject);
                                // Debug.Log("On floor");
                            }

                            break;
                        }

                        case "BLD_Bridge1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Wood", this.gameObject);
                            break;
                        }

                        case "BLD_Bridge_B_LOD1 (Instance)":
                        {
                            AkSoundEngine.SetSwitch("Footsteps", "Wood", this.gameObject);
                            break;
                        }
                        
                        // END OF SWITCH
                    }
                // END OF IF
                }


                // Player is walking on the ground
                else if (hit.collider != null && hit.collider.name != "FootstepZoneWater" && hit.collider.gameObject.name == "Terrain" && gameObject.transform.position.y > 16.0f)
                {
                    // Debug.Log(hit.collider.gameObject.name);
                    AkSoundEngine.SetSwitch("Footsteps", "Grass", this.gameObject);
                }


                // Player is in water
                else if (hit.collider != null && hit.collider.gameObject.name == "Terrain" && gameObject.transform.position.y <= 16.0f)
                {
                    AkSoundEngine.SetSwitch("Footsteps", "Water", this.gameObject);
                }

            }

        }
        // If we did not hit anything
        else
        {
            rayLine.SetPosition(1,rayOrigin+(Vector3.forward*range)+Vector3.up);
        }

    }
}
