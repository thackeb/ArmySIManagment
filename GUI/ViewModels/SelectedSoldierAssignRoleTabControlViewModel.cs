using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
   public class SelectedSoldierAssignRoleTabControlViewModel:Conductor<Screen>.Collection.AllActive
    {
        private Dictionary<string, List<Roles>> _roleDictionary;
        private List<SelectedSoldierAssignRoleViewModel> _selectedSoldierAssignRoleViewModels;

        public List<SelectedSoldierAssignRoleViewModel> SelectedSoldierAssignRoleViewModels
        {
            get
            {
                return _selectedSoldierAssignRoleViewModels;
            }
            set
            {
                _selectedSoldierAssignRoleViewModels = value;
                NotifyOfPropertyChange(() => SelectedSoldierAssignRoleViewModels);
            }
        }

        public Dictionary<string, List<Roles>> RoleDictionary
        {
            get
            {
                return _roleDictionary;
            }
            set
            {
                _roleDictionary = value;
                NotifyOfPropertyChange(() => RoleDictionary);
            }
        }
        public SelectedSoldierAssignRoleTabControlViewModel(Soldier soldier, List<RoleAssignments> roleAssignments, List<Roles> roles)
        {
            SelectedSoldierAssignRoleViewModels = new List<SelectedSoldierAssignRoleViewModel>();
            RoleDictionary = new Dictionary<string, List<Roles>>();
            DisplayName = "Assign Role";
            foreach(Roles roleAssignment in roles)
            {
                if (!RoleDictionary.ContainsKey(roleAssignment.PlatoonString))
                {
                    RoleDictionary.Add(roleAssignment.PlatoonString, new List<Roles>());
                    RoleDictionary[roleAssignment.PlatoonString].Add(roleAssignment);
                }
                else
                {
                    RoleDictionary[roleAssignment.PlatoonString].Add(roleAssignment);
                }
            }
            foreach (KeyValuePair<string, List<Roles>> keyValuePair in RoleDictionary)
            {
                SelectedSoldierAssignRoleViewModels.Add(new SelectedSoldierAssignRoleViewModel(keyValuePair.Key, roleAssignments, soldier, keyValuePair.Value));
                ActivateItem(SelectedSoldierAssignRoleViewModels.Last());
                SelectedSoldierAssignRoleViewModels.Last().AttemptingDeactivation += SelectedSoldierAssignRoleTabControlViewModel_AttemptingDeactivation;
            }
        }

        private void SelectedSoldierAssignRoleTabControlViewModel_AttemptingDeactivation(object sender, DeactivationEventArgs e)
        {
            TryClose();
        }
    }
}
