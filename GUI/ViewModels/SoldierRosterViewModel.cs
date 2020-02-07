using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmySIManagment.BuisnessLogic.Models;
using ArmySIManagment.Connectors;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    class SoldierRosterViewModel : Conductor<Screen>, IScreen
    {
        private List<Soldier> _soldierList;
        private Soldier _selectedSoldier;
        private Roles _selectedRole;
        private WindowManager WindowManager { get; set; }
    


        private BindableCollection<Soldier> _bindSoldiers;
        private AddSoldierViewModel _addSoldierViewModel;
        private List<WeaponAssignments> _weaponAssignments;
        private List<Roles> _roles;
        private List<RoleAssignments> _roleAssignments;

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

        public List<Roles> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                NotifyOfPropertyChange(() => Roles);
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

        public AddSoldierViewModel AddSoldierViewModel
        {
            get
            {
                return _addSoldierViewModel;
            }
            set
            {
                _addSoldierViewModel = value;
                NotifyOfPropertyChange(() => AddSoldierViewModel);
            }
        }


        public BindableCollection<Soldier> BindSoldiers
        {
            get
            {
                return _bindSoldiers;
            }
            set
            {
                _bindSoldiers = value;
                NotifyOfPropertyChange(() => BindSoldiers);
            }
        }




        public Roles SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
            }
        }

        public Soldier SelectedSoldier
        {
            get
            {
                return _selectedSoldier;
            }
            set
            {
                _selectedSoldier = value;
                NotifyOfPropertyChange(() => SelectedSoldier);
                foreach (RoleAssignments role in RoleAssignments)
                {
                    if (role.AssignedSoldier == SelectedSoldier)
                    {
                        SelectedRole = role.Role;
                        break;
                    }
                }
                if (SelectedSoldier != null)
                {
                    ActivateItem(new SelectedSoldierInfoViewModel(SelectedSoldier, WeaponAssignments, RoleAssignments, Roles));
                }
            }   
        }

        public List<Soldier> SoldierList
        {
            get
            {
                return _soldierList;
            }
            set
            {
                _soldierList = value;
                NotifyOfPropertyChange(() => SoldierList);
                BindSoldiers = new BindableCollection<Soldier>(SoldierList);
            }
        }

        public SoldierRosterViewModel( MainViewModel mainViewModel)
        {
            WindowManager = new WindowManager();
            DisplayName = "Master Soldier Roster";

            SoldierList = mainViewModel.SoldiersList;
            RoleAssignments = mainViewModel.RolesAssignmentsList;
            WeaponAssignments = mainViewModel.WeaponAssignmentsList;
            Roles = mainViewModel.RolesList;
            if (SelectedSoldier != null)
            {
                ActivateItem(new SelectedSoldierInfoViewModel(SelectedSoldier, WeaponAssignments, RoleAssignments, Roles)); ;
            }
        }
        public SoldierRosterViewModel(string squad, List<Soldier> soldiers, List<WeaponAssignments> weaponAssignments, List<Roles > roles, List<RoleAssignments> roleAssignments)
        {
            WindowManager = new WindowManager();
            DisplayName = squad;
            
            SoldierList = soldiers;
            RoleAssignments = roleAssignments;
            WeaponAssignments = weaponAssignments;
            if (SelectedSoldier != null)
            {
                ActivateItem(new SelectedSoldierInfoViewModel(SelectedSoldier, WeaponAssignments, RoleAssignments, Roles)); ;
            }
        }

        public void AddSoldierBtn()
        {
            AddSoldierViewModel = new AddSoldierViewModel(SoldierList, RoleAssignments, Roles, WeaponAssignments);
            AddSoldierViewModel.Deactivated += AddSoldierViewModel_Deactivated;
            WindowManager.ShowDialog(AddSoldierViewModel);
            
        }

        private void AddSoldierViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            BindSoldiers = new BindableCollection<Soldier>(SoldierList);
        }

        public void RemoveSoldierBtn()
        {
            if(SelectedSoldier != null)
            {
                DeactivateItem(ActiveItem,true);
                foreach(RoleAssignments roleAssignments in RoleAssignments)
                {
                    if(roleAssignments.AssignedSoldier == SelectedSoldier)
                    {
                        ArmyDataBaseConnector.RemoveRoleAssignments(roleAssignments);
                        RoleAssignments.Remove(roleAssignments);
                        break;
                    }
                }
                ArmyDataBaseConnector.RemoveSoldierInfo(SelectedSoldier);

                SoldierList.Remove(SelectedSoldier);
                BindSoldiers = new BindableCollection<Soldier>(SoldierList);

            }
        }
    }
}
