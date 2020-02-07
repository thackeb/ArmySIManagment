using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArmySIManagment.BuisnessLogic.Models;
using Caliburn.Micro;
namespace ArmySIManagment.GUI.ViewModels
{
    public class RolesInformationViewModel:Conductor<Screen>, IScreen
    {

        private WindowManager _windowManager { get; set; }
        private MainViewModel _mainViewModel { get; set; }

        private List<Roles> _rolesList;
        private List<WeaponAssignments> _weaponAssignmentsList;
        private List<RoleAssignments> _roleAssignmentsList;
        private Roles _selectedRole;
        private WeaponAssignments _selectedWeaponAssignments;
        private RoleAssignments _selectedRoleAssignment;

        private AddRoleViewModel _addRoleViewModel;

        private BindableCollection<Roles> _bindRoles;

        public BindableCollection<Roles> BindRoles
        {
            get
            {
                return _bindRoles;
            }
            set
            {
                _bindRoles = value;
                NotifyOfPropertyChange(() => BindRoles);
            }
        }


        public AddRoleViewModel AddRoleViewModel
        {
            get
            {
                return _addRoleViewModel;
            }
            set
            {
                _addRoleViewModel = value;
                NotifyOfPropertyChange(() => AddRoleViewModel);
            }
        }




        public RoleAssignments SelectedRoleAssignment
        {
            get
            {
                return _selectedRoleAssignment;
            }
            set
            {
                _selectedRoleAssignment = value;
                NotifyOfPropertyChange(() => SelectedRoleAssignment);
            }
        }

        public WeaponAssignments SelectedWeaponAssignments
        {
            get
            {
                return _selectedWeaponAssignments;
            }
            set
            {
                _selectedWeaponAssignments = value;
                NotifyOfPropertyChange(() => SelectedWeaponAssignments);
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
                NotifyOfPropertyChange(() => SelectedRole);
                if (_mainViewModel.RolesAssignmentsList.Count > 0)
                {
                    foreach (RoleAssignments roleAssignments in _mainViewModel.RolesAssignmentsList)
                    {
                        if(roleAssignments.Role == SelectedRole)
                        {
                            SelectedRoleAssignment = roleAssignments;
                        }
                    }
                }
                else
                {
                    SelectedRoleAssignment = new RoleAssignments();
                    
                }
                ActivateItem(new SelectedRoleInfoViewModel(SelectedRole, _mainViewModel.WeaponAssignmentsList, _mainViewModel.WeaponRosterSheets, _mainViewModel.SensitiveItemsList, _mainViewModel.SoldiersList, RoleAssignmentsList));
            }
        }

        public List<RoleAssignments> RoleAssignmentsList
        {
            get
            {
                return _roleAssignmentsList;
            }
            set
            {
                _roleAssignmentsList = value;
                NotifyOfPropertyChange(() => RoleAssignmentsList);
            }
        }

        public List<WeaponAssignments> WeaponAssignmentsList
        {
            get
            {
                return _weaponAssignmentsList;
            }
            set
            {
                _weaponAssignmentsList = value;
                NotifyOfPropertyChange(() => WeaponAssignmentsList);
            }
        }

        public List<Roles> RolesList
        {
            get
            {
                return _rolesList;
            }
            set
            {
                _rolesList = value;
                BindRoles = new BindableCollection<Roles>(value.ToList());
                NotifyOfPropertyChange(() => RolesList);
            }
        }

        public RolesInformationViewModel(MainViewModel mainViewModel)
        {
            DisplayName = "Roles";
            _windowManager = new WindowManager();
            RoleAssignmentsList = mainViewModel.RolesAssignmentsList;
            WeaponAssignmentsList = mainViewModel.WeaponAssignmentsList;
            RolesList = mainViewModel.RolesList;
            _mainViewModel = mainViewModel;
            
        }


        public void AddRoleBtn()
        {
            AddRoleViewModel = new AddRoleViewModel(RolesList);
            _windowManager.ShowWindow(AddRoleViewModel);
            AddRoleViewModel.Deactivated += AddRoleViewModel_Deactivated;
        }

        private void AddRoleViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            BindRoles = new BindableCollection<Roles>( RolesList.ToList());
        }
        public void RemoveRoleBtn()
        {
            if (SelectedRole != null)
            {
                foreach(RoleAssignments role in _mainViewModel.RolesAssignmentsList)
                {
                    if(role.Role == SelectedRole)
                    {
                        _mainViewModel.RolesAssignmentsList.Remove(role);
                        break;
                    }
                }
                foreach(WeaponAssignments weaponAssignments in _mainViewModel.WeaponAssignmentsList)
                {
                    if(weaponAssignments.Role == SelectedRole)
                    {
                        _mainViewModel.WeaponAssignmentsList.Remove(weaponAssignments);
                        break;
                    }
                }
                RolesList.Remove(SelectedRole);
                BindRoles = new BindableCollection<Roles>(RolesList);
            }
        }


    }
}
