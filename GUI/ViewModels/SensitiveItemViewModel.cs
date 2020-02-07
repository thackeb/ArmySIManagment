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
    public class SensitiveItemViewModel:Conductor<Screen>
    {
        private BindableCollection<SensitiveItemBaseClass> _siBindableList;

        private List<SensitiveItemBaseClass> _siList;
        private List<WeaponAssignments> _weaponAssignments;
        private List<RoleAssignments> _roleAssignments;
        private SensitiveItemBaseClass _selectedSI;
      

        public SensitiveItemBaseClass SelectedSI
        {
            get
            {
                return _selectedSI;
            }
            set
            {
                _selectedSI = value;
                NotifyOfPropertyChange(() => SelectedSI);
                WeaponAssignments selectedWeaponAssignment = new WeaponAssignments();
                foreach(WeaponAssignments weaponAssignments in WeaponAssignments)
                {
                    if(weaponAssignments.AssignedSI.Contains(SelectedSI))
                    {
                        selectedWeaponAssignment = weaponAssignments;
                    }
                }
               
                RoleAssignments selectedRoleAssignment = new RoleAssignments();
                if (selectedWeaponAssignment != null)
                {
                    foreach (RoleAssignments roleAssignments in RoleAssignments)
                    {
                        if (selectedWeaponAssignment.Role == roleAssignments.Role)
                        {
                            selectedRoleAssignment = roleAssignments;
                        }
                    }
                }
                ActivateItem(new SelectedSensitiveItemViewModel(SelectedSI, selectedWeaponAssignment, selectedRoleAssignment));
            }
        }

        public List<RoleAssignments> RoleAssignments
        {
            get
            {
                return _roleAssignments;
            }
            set
            {
                _roleAssignments = value;
                NotifyOfPropertyChange(() => RoleAssignments); 
            }
        }

        public List<WeaponAssignments> WeaponAssignments
        {
            get
            {
                return _weaponAssignments;
            }
            set
            {
                _weaponAssignments = value;
                NotifyOfPropertyChange(() => WeaponAssignments);
            }
        }


        public List<SensitiveItemBaseClass> SIList
        {
            get
            {
                return _siList;
            }
            set
            {
                _siList = value;
                NotifyOfPropertyChange(() => SIList);
                SIBindableList = new BindableCollection<SensitiveItemBaseClass>(SIList);
            }
        }

        public BindableCollection<SensitiveItemBaseClass> SIBindableList
        {
            get
            {
                return _siBindableList;
            }
            set
            {
                _siBindableList = value;
                NotifyOfPropertyChange(() => SIBindableList);
            }
        }

        public SensitiveItemViewModel(string equipmentName, List<SensitiveItemBaseClass> siList, List<WeaponAssignments> weaponAssignments, List<RoleAssignments> roleAssignments)
        {
            DisplayName = equipmentName;

            SIList = siList;
            WeaponAssignments = weaponAssignments;
            RoleAssignments = roleAssignments;
            

        }
       
    }
}
