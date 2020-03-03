using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Resource
{
    public bool unlocked; //allow to set as unavailable here so that access can be granted/denied in multiple places with ease
    public int count; //how much of this resource is there?

    public Resource(bool unlocked, int count)
    {
        this.unlocked = unlocked;
        this.count = count;
    }

}

public class Resources : MonoBehaviour
{
    //Core Resources
    Resource electricity = new Resource(true, 10);
    Resource health = new Resource(true, 10);
    Resource minions = new Resource(true, 1);

    //Monster Part Resources
    Resource limbs = new Resource(false, 0);
    Resource brains = new Resource(false, 0);
    Resource thread = new Resource(false, 0);
    Resource potions = new Resource(false, 0);
    Resource wrappings = new Resource(false, 0);

    //Armoury Resources
    Resource weapons = new Resource(false, 0);
    Resource armour = new Resource(false, 0);
    Resource iron = new Resource(false, 0);
    Resource leather = new Resource(false, 0);
    //wood is also one of these but its with factory resources because it's used there more

    //Factory Upgrade Resources
    Resource stone = new Resource(false, 0);
    Resource wood = new Resource(false, 0);
    Resource blueprints = new Resource(false, 0);
    Resource gearsPipes = new Resource(false, 0);
    Resource copper = new Resource(false, 0);
    Resource glass = new Resource(false, 0);

    //Special Resources / rare parts
}
