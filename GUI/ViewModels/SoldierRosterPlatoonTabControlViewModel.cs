using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.BuisnessLogic.Models.SensitiveItems;
namespace ArmySIManagment.GUI.ViewModels
{
    class SoldierRosterPlatoonTabControlViewModel:Conductor<Screen>.Collection.AllActive
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
        public SoldierRosterPlatoonTabControlViewModel(MainViewModel mainViewModel)
        {
            DisplayName = "Soldier Roster";
            SoldierDictionary = new Dictionary<string, List<Soldier>>();
            foreach(RoleAssignments role in mainViewModel.RolesAssignmentsList)
            {
                if(!SoldierDictionary.ContainsKey(role.Role.PlatoonString))
                {
                    SoldierDictionary.Add(role.Role.PlatoonString, new List<Soldier>());
                    SoldierDictionary[role.Role.PlatoonString].Add(role.AssignedSoldier);
                }
                else
                {
                    SoldierDictionary[role.Role.PlatoonString].Add(role.AssignedSoldier);
                }
            }
            foreach (KeyValuePair<string, List<Soldier>> keyValuePair in SoldierDictionary)
            {
                ActivateItem(new SoldierRosterSquadTabControlViewModel(keyValuePair.Key, keyValuePair.Value, mainViewModel.SensitiveItemsList, mainViewModel.RolesList, mainViewModel.WeaponAssignmentsList, mainViewModel.RolesAssignmentsList));
            }
            ActivateItem(new SoldierRosterViewModel(mainViewModel));
        }
    }
}
