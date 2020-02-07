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
    class SensitiveItemTabControlViewModel: Conductor<Screen>.Collection.AllActive
    {
        private Dictionary<string, List<SensitiveItemBaseClass>> _siDictionary;
        private AddSIItemViewModel _addSIItemViewModel;
        private List<SensitiveItemBaseClass> _sensitiveItemBaseClasses;
        private List<WeaponAssignments> _weaponAssignments;
        private List<RoleAssignments> _roleAssignments;
        private WindowManager WindowManager { get; set; }
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

        public List<SensitiveItemBaseClass> SensitiveItemBaseClasses
        {
            get
            {
                return _sensitiveItemBaseClasses;
            }
            set
            {
                _sensitiveItemBaseClasses = value;
                NotifyOfPropertyChange(() => SensitiveItemBaseClasses
                );
            }
        }

        public AddSIItemViewModel AddSIItemViewModel
        {
            get
            {
                return _addSIItemViewModel;
            }
            set
            {
                _addSIItemViewModel = value;
                NotifyOfPropertyChange(() => AddSIItemViewModel);
            }
        }
        public Dictionary<string, List<SensitiveItemBaseClass>> SIDictionary
        {
            get
            {
                return _siDictionary;
            }
            set
            {
                _siDictionary = value;
                NotifyOfPropertyChange(() => SIDictionary);
            }
        }

        public SensitiveItemTabControlViewModel(List<SensitiveItemBaseClass> allSI, List<RoleAssignments> roleAssignments, List<WeaponAssignments> weaponAssignments)
        {
            WindowManager = new WindowManager();
            DisplayName = "Sensitive Item Roster";
            SIDictionary = new Dictionary<string, List<SensitiveItemBaseClass>>();
            SensitiveItemBaseClasses = allSI;
            foreach (SensitiveItemBaseClass si in allSI)
            {
                if(!SIDictionary.ContainsKey(si.EquipmentName))
                {
                    SIDictionary.Add(si.EquipmentName, new List<SensitiveItemBaseClass>());
                    SIDictionary[si.EquipmentName].Add(si);
                }
                else
                {
                    SIDictionary[si.EquipmentName].Add(si);
                }
            }
            foreach(KeyValuePair<string,List<SensitiveItemBaseClass>> si in SIDictionary)
            {
                ActivateItem(new SensitiveItemViewModel(si.Key, si.Value,weaponAssignments,roleAssignments));
            }
        }
        public void AddSensitiveItemBtn()
        {
         
            AddSIItemViewModel = new AddSIItemViewModel(SensitiveItemBaseClasses);
            AddSIItemViewModel.Deactivated += AddSIItemViewModel_Deactivated;
            WindowManager.ShowWindow(AddSIItemViewModel);

        }

        private void AddSIItemViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            
            while(Items.Count != 0)
            {
                Items[0].TryClose();
            }
            foreach (SensitiveItemBaseClass si in SensitiveItemBaseClasses)
            {
                if (!SIDictionary.ContainsKey(si.EquipmentName))
                {
                    SIDictionary.Add(si.EquipmentName, new List<SensitiveItemBaseClass>());
                    SIDictionary[si.EquipmentName].Add(si);
                }
                else
                {
                    SIDictionary[si.EquipmentName].Add(si);
                }
            }
            foreach (KeyValuePair<string, List<SensitiveItemBaseClass>> si in SIDictionary)
            {
                ActivateItem(new SensitiveItemViewModel(si.Key, si.Value, WeaponAssignments, RoleAssignments));
            }
        }
    }
}
