using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    class SoldierRosterSquadTabControlViewModel : Conductor<Screen>.Collection.AllActive
    {
        private Dictionary<string, List<Soldier>> _soldierDictionary;

        public Dictionary<string, List<Soldier>> SoldierDictionary
        {
            get
            {
                return _soldierDictionary;
            }
            set
            {
                _soldierDictionary = value;
                NotifyOfPropertyChange(() => SoldierDictionary);
            }
        }
        public SoldierRosterSquadTabControlViewModel(string platoon, List<Soldier> soldiers, List<SensitiveItemBaseClass> sensitiveItemBaseClasses, List<Roles> roles , List<WeaponAssignments> weaponAssignments, List<RoleAssignments> roleAssignments)
        {
            DisplayName = platoon;
            SoldierDictionary = new Dictionary<string, List<Soldier>>();
            SoldierDictionary.Add("HQ", new List<Soldier>());
            foreach (Soldier soldier in soldiers)
            {
                bool foundSquad = false;
                foreach(RoleAssignments roleAssignments1 in roleAssignments)
                {
                    if (soldier == roleAssignments1.AssignedSoldier)
                    {
                        foundSquad = true;
                        if (!SoldierDictionary.ContainsKey(roleAssignments1.Role.SquadString))
                        {
                            SoldierDictionary.Add(roleAssignments1.Role.SquadString, new List<Soldier>());
                            SoldierDictionary[roleAssignments1.Role.SquadString].Add(soldier);
                        }
                        else
                        {
                            SoldierDictionary[roleAssignments1.Role.SquadString].Add(soldier);
                        }
                    }
                }
                if(!foundSquad)
                {
                    SoldierDictionary["HQ"].Add(soldier);
                }
               
            }
            foreach(KeyValuePair<string,List<Soldier>> keyValuePair in SoldierDictionary)
            {
                ActivateItem(new SoldierRosterViewModel(keyValuePair.Key, keyValuePair.Value,weaponAssignments, roles,roleAssignments));
            }
        }
    }
}
